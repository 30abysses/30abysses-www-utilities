﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.UpdateWebsite.Renderer
{
    public class TopicRenderer : AbstractRenderer
    {
        private Topic topic;

        public TopicRenderer(Topic topic)
        {
            this.topic = topic;
        }

        public override string GetOutputFileContents()
        {
            throw new NotImplementedException();
        }

        public override string GetPseudoInputFilePath()
        {
            throw new NotImplementedException();
        }
    }
}
