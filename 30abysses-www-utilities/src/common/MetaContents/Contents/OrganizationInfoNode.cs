namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class OrganizationInfoNode
    {
        public string Name { get; }
        public string RelativePath { get; }

        public OrganizationInfoNode(string name, string relativePath)
        {
            Name = name;
            RelativePath = relativePath;
        }
    }
}
