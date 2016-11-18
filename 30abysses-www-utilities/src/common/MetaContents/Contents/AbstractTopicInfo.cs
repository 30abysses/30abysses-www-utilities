﻿using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
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

        public static AbstractTopicInfo New(AbstractTopic abstractTopic)
        {
            var abstractTopicInfo = new AbstractTopicInfo();

            {
                var firstFourLines = File.ReadLines(abstractTopic.Path, Encoding.UTF8).Take(4).ToArray();

                abstractTopicInfo.AuthorUri = new Uri(UrlHeaderRegex.Match(firstFourLines[0]).Groups[1].ToString());

                {
                    var authorInfoMatch = AuthorHeaderRegex.Match(firstFourLines[1]);
                    abstractTopicInfo.AuthorName = authorInfoMatch.Groups[1].ToString();
                    abstractTopicInfo.AuthorEmail = authorInfoMatch.Groups[2].ToString();
                }

                abstractTopicInfo.Title = TitleHeaderRegex.Match(firstFourLines[3]).Groups[1].ToString();
            }

            abstractTopicInfo.Contents = string.Join(Environment.NewLine, File.ReadLines(abstractTopic.Path, Encoding.UTF8).Skip(3));
            return abstractTopicInfo;
        }

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public static string GetPseudoInputFilePath(string path) => path + ".abstract-topic-info.json";

        public static readonly Regex UrlHeaderRegex = new Regex(@"^> (.+)$");
        public static readonly Regex AuthorHeaderRegex = new Regex(@"^> by (.+) <(.+@.+)> \d{4}-\d{2}-\d{2} CC-BY-4\.0$");
        public static readonly Regex TitleHeaderRegex = new Regex(@"^# (.+)$");
    }
}
