using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the file path: ");     
        string filePath = Console.ReadLine();
        ReplaceGuid(filePath);
    }

    static void ReplaceGuid(string filePath)
    {
        try
        {
            // Read the content of the file
            string content = File.ReadAllText(filePath);

            // Define regex pattern to match @Guid( followed by a GUID
            string pattern = @"@Guid\((.*?)\)";

            // Generate a new GUID
            string newGuid = Guid.NewGuid().ToString();

            // Replace all occurrences of @Guid( followed by a GUID with the new GUID
            string newContent = Regex.Replace(content, pattern, "@Guid(" + newGuid + ")");

            // Write the modified content back to the file
            File.WriteAllText(filePath, newContent);

            Console.WriteLine("GUIDs replaced successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
