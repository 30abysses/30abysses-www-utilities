using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _30abysses.WWW.Utilities.Common.MetaContents
{
    public class TopicContents
    {
        public Uri Uri { get; }
        public string AuthorName { get; }
        public string AuthorEmail { get; }
        public string Title { get; }
        public string Contents { get; }

        public TopicContents(string path)
        {
            {
                var firstFourLines = File.ReadLines(path, Encoding.UTF8).Take(4).ToArray();

                Uri = new Uri(UrlHeaderRegex.Match(firstFourLines[0]).Groups[1].ToString());

                {
                    var authorInfoMatch = AuthorHeaderRegex.Match(firstFourLines[1]);
                    AuthorName = authorInfoMatch.Groups[1].ToString();
                    AuthorEmail = authorInfoMatch.Groups[2].ToString();
                }

                Title = TitleHeaderRegex.Match(firstFourLines[3]).Groups[1].ToString();
            }

            Contents = string.Join(Environment.NewLine, File.ReadLines(path, Encoding.UTF8).Skip(3));
        }

        public static Regex UrlHeaderRegex { get; } = new Regex(@"^> (.+)$");
        public static Regex AuthorHeaderRegex { get; } = new Regex(@"^> by (.+) <(.+@.+)> \d{4}-\d{2}-\d{2} CC-BY-4\.0$");
        public static Regex TitleHeaderRegex { get; } = new Regex(@"^# (.+)$");
    }
}
