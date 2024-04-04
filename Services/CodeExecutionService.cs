using System.Diagnostics;
using codegym_api.Interfaces;

namespace codegym_api.Services;

public class CodeExecutionService : ICodeExecutionService
{
    public async Task<string> Execute(string code)
    {
        var now = DateTime.Now;
        string filename = $"code{Random.Shared.Next()}_.go";

        // Create the file with the code
        File.WriteAllText(filename, code);

        // Execute the file using the dotnet CLI
        Process process = new Process();
        process.StartInfo.FileName = "go";
        process.StartInfo.Arguments = $"run /home/mohsen/src/cs/codegym_api/{filename}";
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();

        // Capture the output
        string output = process.StandardOutput.ReadToEnd();

        // Wait for process completion
        process.WaitForExit();
        await process.WaitForExitAsync();

        // Store output in a variable (replace with appropriate type if needed)
        string outputVariable = output;

        Console.WriteLine("Captured output: ");
        Console.WriteLine(outputVariable);

        // Optional: Delete the temporary file
        File.Delete(filename);
        return outputVariable;
    }
}
