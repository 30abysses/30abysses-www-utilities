using _30abysses.WWW.Utilities.Common.RawContents.Abstracts;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace _30abysses.WWW.Utilities.Common.MetaContents.Contents
{
    public class OrganizationInfo : List<OrganizationInfoNode>
    {
        public static OrganizationInfo New(OrganizationInfo organizationInfo, Item item, ItemInfo itemInfo)
        {
            var newOrganizationInfo = new OrganizationInfo();
            newOrganizationInfo.AddRange(organizationInfo.Select(node => new OrganizationInfoNode(node.Name, "../" + node.RelativePath)));
            newOrganizationInfo.Add(new OrganizationInfoNode(itemInfo.Name, string.Empty));
            return newOrganizationInfo;
        }

        public static OrganizationInfo New(Item item, ItemInfo itemInfo)
        {
            var organizationInfo = new OrganizationInfo();
            organizationInfo.Add(new OrganizationInfoNode(itemInfo.Name, string.Empty));
            return organizationInfo;
        }

        public string GetOutputFileContents() => JsonConvert.SerializeObject(this, Formatting.Indented);

        public static string GetPseudoInputFilePath(string path) => path + ".organization-info.json";
    }
}
