using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitPortal.API_Interface
{
    public class RequestToServer
    {
        public static TermSet GetTermSet(string currentWebUrl, string termsetName)
        {

            TermSet ts = null;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite Osite = new SPSite(currentWebUrl))
                    {
                        using (SPWeb Oweb = Osite.OpenWeb())
                        {
                            TaxonomySession taxonomySession = new TaxonomySession(Osite);
                            TermStore taxStore = taxonomySession.TermStores[0];
                            Group taxGroup = taxStore.GetSiteCollectionGroup(Osite);
                            ts = taxGroup.TermSets[termsetName];
                        }
                    }
                });
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("Error-Recruit-Portal", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, ex.Message, ex.StackTrace);

            }
            return ts;
        }
    }
}
