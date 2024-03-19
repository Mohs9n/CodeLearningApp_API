namespace codegym_api.Interfaces;

public interface ICodeExecutionService
{
    public Task<string> Execute(string code);
}