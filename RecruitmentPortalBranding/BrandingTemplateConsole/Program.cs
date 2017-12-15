using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandingTemplateConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string siteurl = "http://livesp13:20202/";
            using (SPSite site = new SPSite(siteurl))
            {
                if (site != null)
                {
                    SPWeb topLevelSite = site.RootWeb;
                    string webAppRelativePath = topLevelSite.ServerRelativeUrl;
                    if (!webAppRelativePath.EndsWith("/"))
                    {
                        webAppRelativePath += "/";
                    }
                    foreach (SPWeb web in site.AllWebs)
                    {
                        // Activate the publishing feature for all webs.
                        web.MasterUrl = webAppRelativePath + "_catalogs/masterpage/Branding Files/RecruitmentPortal.master";
                        web.CustomMasterUrl = webAppRelativePath + "_catalogs/masterpage/Branding Files/RecruitmentPortal.master";

                        web.Update();
                    }

                }

            }


            Console.ReadKey();
        }
    }
}
