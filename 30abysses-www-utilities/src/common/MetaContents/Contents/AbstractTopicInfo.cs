using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class AbstractTopicInfo
    {
        public string Title { get; set; }
        public Uri AuthorUri { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmail { get; set; }
        public string Contents { get; set; }

        public AbstractTopicInfo() { }

        public AbstractTopicInfo(AbstractTopic abstractTopic)
        {
            {
                var firstFourLines = File.ReadLines(abstractTopic.Path, Encoding.UTF8).Take(4).ToArray();

                AuthorUri = new Uri(UrlHeaderRegex.Match(firstFourLines[0]).Groups[1].ToString());

                {
                    var authorInfoMatch = AuthorHeaderRegex.Match(firstFourLines[1]);
                    AuthorName = authorInfoMatch.Groups[1].ToString();
                    AuthorEmail = authorInfoMatch.Groups[2].ToString();
                }

                Title = TitleHeaderRegex.Match(firstFourLines[3]).Groups[1].ToString();
            }

            Contents = string.Join(Environment.NewLine, File.ReadLines(abstractTopic.Path, Encoding.UTF8).Skip(3));
        }

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public const string FilenameExtension = ".abstract-topic-info.json";

        private static readonly Regex UrlHeaderRegex = new Regex(@"^> (.+)$");
        private static readonly Regex AuthorHeaderRegex = new Regex(@"^> by (.+) <(.+@.+)> \d{4}-\d{2}-\d{2} CC-BY-4\.0$");
        private static readonly Regex TitleHeaderRegex = new Regex(@"^# (.+)$");
    }
}
