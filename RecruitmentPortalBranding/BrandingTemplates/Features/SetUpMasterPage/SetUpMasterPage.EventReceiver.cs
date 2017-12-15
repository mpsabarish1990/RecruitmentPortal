using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace BrandingTemplates.Features.SetUpMasterPage
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("05508ca3-8fa1-4b10-aa81-a45a94c142a7")]
    public class SetUpMasterPageEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {

            using (SPWeb oWeb = properties.Feature.Parent as SPWeb)
            {
                //   SPWeb web = site.OpenWeb();
                string serverPath = string.Empty;

                if (oWeb.ParentWeb.ServerRelativeUrl.ToString().EndsWith("/"))
                {
                    serverPath = oWeb.ParentWeb.ServerRelativeUrl.ToString();
                }
                else
                {
                    serverPath = oWeb.ParentWeb.ServerRelativeUrl.ToString() + "/";
                }

                oWeb.CustomMasterUrl = serverPath + "_catalogs/masterpage/Branding Files/RecruitmentPortal.master";
                oWeb.Update();
            }

        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        //public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
