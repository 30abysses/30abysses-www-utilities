using _30abysses.WWW.Utilities.Common.RawContents.Contents;

namespace _30abysses.WWW.Utilities.Common.RawContents.Abstracts
{
    public abstract class ContentVisitor
    {
        public virtual void Leave(_404Template _404Template) { }
        public virtual void Leave(ContentsRoot contentsRoot) { }
        public virtual void Leave(Day day) { }
        public virtual void Leave(Month month) { }
        public virtual void Leave(Topic topic) { }
        public virtual void Leave(WwwRoot wwwRoot) { }
        public virtual void Leave(Year year) { }
        public virtual void Leave(Zone zone) { }
        public virtual void Visit(_404Template _404Template) { }
        public virtual void Visit(ContentsRoot contentsRoot) { }
        public virtual void Visit(Day day) { }
        public virtual void Visit(Month month) { }
        public virtual void Visit(Topic topic) { }
        public virtual void Visit(WwwRoot wwwRoot) { }
        public virtual void Visit(Year year) { }
        public virtual void Visit(Zone zone) { }
    }
}
