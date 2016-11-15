using _30abysses.WWW.Utilities.Common.RawContents.Contents;
using _30abysses.WWW.Utilities.Common.RawContents.Interfaces;
using System;
using System.IO;

namespace _30abysses.WWW.Utilities.UpdateWebsite
{
    public static class Program
    {
        public static int Main(string[] commandLineArguments)
        {
            string inputDirectoryPath;
            string outputDirectoryPath;
            try
            {
                if (commandLineArguments == null) { throw new ArgumentNullException(nameof(commandLineArguments)); }

                {
                    const int expectedArgumentCount = 2;
                    var actualArgumentCount = commandLineArguments.Length;
                    if (actualArgumentCount != expectedArgumentCount) { throw new ArgumentException($"Received {actualArgumentCount} argument(s) but expected {expectedArgumentCount} argument(s).", nameof(commandLineArguments)); }
                }

                const string nullOrWhiteSpaceArgumentExceptionMessage = "String argument `{0}` must not be null, empty, or consist only of white-space characters.";
                {
                    var commandLineArgument0 = commandLineArguments[0];
                    const string argumentName = nameof(commandLineArgument0);
                    if (string.IsNullOrWhiteSpace(commandLineArgument0)) { throw new ArgumentException(string.Format(nullOrWhiteSpaceArgumentExceptionMessage, argumentName), argumentName); }
                    if (!Directory.Exists(commandLineArgument0)) { throw new ArgumentException($"Input directory `{commandLineArgument0}` does not exist.", argumentName); }
                    inputDirectoryPath = Path.GetFullPath(commandLineArgument0);
                    Console.WriteLine($"Converted {argumentName} `{commandLineArgument0}` to {nameof(inputDirectoryPath)} `{inputDirectoryPath}`.");
                }

                {
                    var commandLineArgument1 = commandLineArguments[1];
                    const string argumentName = nameof(commandLineArgument1);
                    if (string.IsNullOrWhiteSpace(commandLineArgument1)) { throw new ArgumentException(string.Format(nullOrWhiteSpaceArgumentExceptionMessage, argumentName), argumentName); }
                    if (File.Exists(commandLineArgument1)) { throw new ArgumentException($"Output directory `{commandLineArgument1}` is occupied by a file."); }
                    outputDirectoryPath = Path.GetFullPath(commandLineArgument1);
                    Console.WriteLine($"Converted {argumentName} `{commandLineArgument1}` to {nameof(outputDirectoryPath)} `{outputDirectoryPath}`.");
                }
            }
            catch (ArgumentException e)
            {
                Console.Error.WriteLine(e.Message);
                return 1;
            }

            var contentsRoot = new ContentsRoot(inputDirectoryPath);
            var updateWebsiteVisitor = new UpdateWebsiteVisitor(contentsRoot.WwwRoot.Path, outputDirectoryPath);
            ((IVisitable) contentsRoot).Accept(updateWebsiteVisitor);
            return 0;
        }
    }
}
