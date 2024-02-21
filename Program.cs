using System;
using System.IO;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

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
        /* try
        {
            // Read the content of the file
            string content = File.ReadAllText(filePath);

            // Define regex pattern to match @Guid( followed by a GUID
            string pattern = @"@Guid\((.*?)\)";

            // Replace GUIDs using a MatchEvaluator delegate
            string newContent = Regex.Replace(content, pattern, delegate (Match match)
            {
                // Generate a new GUID for each match
                string newGuid = Guid.NewGuid().ToString();
                return "@Guid(" + newGuid + ")";
            });

            // Write the modified content back to the file
            File.WriteAllText(filePath, newContent);

            Console.WriteLine("GUIDs replaced successfully.");
        } */

        
        try  
        {
            FileInfo fileInfo = new FileInfo(filePath);

            // Read the content of the file

            string content = File.ReadAllText(filePath);

            // Define regex pattern to match @Guid( followed by a GUID

            string pattern = @"@Guid\((.*?)\)";

            // Replace all occurrences of @Guid( followed by a GUID with the new GUID

            MatchEvaluator evaluator = new MatchEvaluator((Match m) => { return "@Guid(" + Guid.NewGuid().ToString() + ")"; });

            string newContent = Regex.Replace(content, pattern, evaluator);

            // Write the modified content back to the file

            File.WriteAllText(fileInfo.Name + ".new", newContent);

            Console.WriteLine("GUIDs replaced successfully.");

        }

        catch (Exception ex)

        {

            Console.WriteLine("An error occurred: " + ex.Message);

        }

    }
}
