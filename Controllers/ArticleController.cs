using codegym_api.Dtos;
using Microsoft.AspNetCore.Mvc;
using codegym_api.Extensions;
using codegym_api.Data;
using codegym_api.Interfaces;
using codegym_api.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace codegym_api.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ArticleController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly ICodeExecutionService _codeExecutionService;

    public ArticleController(DataContext dataContext, ICodeExecutionService codeExecutionService)
    {
        _dataContext = dataContext;
        _codeExecutionService = codeExecutionService;
    }

    [HttpPost]
    public async Task<ActionResult<Article>> AddArticle(AddArticleDto addArticleDto)
    {
        var userId = User.GetUserId();
        var user = await _dataContext.Users.FindAsync(userId);
        if (user is null)
        {
          return BadRequest("User does not Exist");
        }
        // if (user.Type != "Admin")
        // {
        //   return BadRequest("You need Admin powers to add articles");
        // }
        Article article = new()
        {
          Title = addArticleDto.Title,
          Score = addArticleDto.Score,
          Content = addArticleDto.Content,
          Solution = addArticleDto.Solution,
          Type = addArticleDto.Type,
          Category = addArticleDto.Category,
        };

        _dataContext.Articles.Add(article);
        await _dataContext.SaveChangesAsync();
        return Ok(article);
    }

    [HttpGet("{category}")]
    public async Task<ActionResult<List<Article>>> GetArticleCollection(string category)
    {
       return Ok(await _dataContext.Articles.Where(x => x.Category == category).ToListAsync());
    }

    [HttpPost("set-seen/id")]
    public async Task<ActionResult> SetArticleSeen(int id)
    {
      var userId = User.GetUserId();
      var user = await _dataContext.Users.FindAsync(userId);
      if (user is null)
      {
        return BadRequest("User is not Authenticated");
      }

      var article = await _dataContext.Articles.FindAsync(id);
      if (article is null)
      {
        return BadRequest("User is not Authenticated");
      }

      user.DoneArticles.Add(new DoneArticle{ UserId = userId, ArticleId = article.Id });
      await _dataContext.SaveChangesAsync();

      return Ok();
    }

    [HttpGet("get-done")]
    public async Task<ActionResult<List<DoneArticle>>> GetDoneArticles()
    {
      var userId = User.GetUserId();
      return Ok(await _dataContext.DoneArticles.Where(x => x.UserId == userId).ToListAsync());
    }

    [HttpPost("run")]
    public async Task<ActionResult<RunSubmissionResultDto>> RunCode(RunSubmissionDto runSubmissionDto)
    {
      var article = await _dataContext.Articles.FindAsync(runSubmissionDto.ArticleId);
      if (article is null)
        return BadRequest("Article does not exist");
      var output = (await _codeExecutionService.Execute(runSubmissionDto.Code)).Trim();
      var result = new RunSubmissionResultDto
      {
        Output = output,
        Status = "",
      };

      if (article.Type == "Problem")
      {
        if (output == article.Solution)
          result.Status = "Correct";
        else
          result.Status = "Incorrect";
      }
      var submission = new Submission
      {
        Code = runSubmissionDto.Code,
        ArticleId = runSubmissionDto.ArticleId,
        Status = result.Status,
        Output = result.Output,
        UserId = User.GetUserId(),
      };

      await _dataContext.Submissions.AddAsync(submission);
      await _dataContext.SaveChangesAsync();
        

      return Ok(result);
    }

    [HttpGet("Submissions")]
    public async Task<ActionResult<List<Submission>>> GetSubmissions()
    {
      return await _dataContext.Submissions.Where(x => x.UserId == User.GetUserId()).ToListAsync();
    }
}
