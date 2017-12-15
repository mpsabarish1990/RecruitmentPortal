using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint.Taxonomy;
using RecruitPortal.API_Interface;

namespace RecruitPortal.Controller
{
    public class Controller_DataAccess
    {
    }

    public class Controller_DataAccess_Navigation
    {
        /// <summary>
        /// To Access TermSet Collection
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="termSetName"></param>
        public static TermSet LeftNavigation(string siteUrl,string termSetName)
        {
            TermSet ts = null;
            ts = API_Interface.RequestToServer.GetTermSet(siteUrl, termSetName);
            return ts;
        }
    }
}
