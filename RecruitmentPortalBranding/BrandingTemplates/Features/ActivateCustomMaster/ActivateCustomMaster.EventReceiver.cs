using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace BrandingTemplates.Features.ActivateCustomMaster
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("c9f793f5-6a6a-4e26-8052-7c130818da09")]
    public class ActivateCustomMasterEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {

            SPSite oSite = properties.Feature.Parent as SPSite;
            if (oSite != null)
            {
                SPWeb oWeb = oSite.RootWeb;
                SPFile masterFile = oWeb.GetFile(oWeb.Url + "/_catalogs/masterpage/Branding Files/RecruitmentPortal.html");
                TriggerMasterFileConversion(masterFile);
            }
        }

        public void TriggerMasterFileConversion(SPFile File)
        {
            if (File.CheckOutType == SPFile.SPCheckOutType.None)
            {
                File.CheckOut();
                File.Update();
                File.CheckIn("CheckIn by SPFeature Activation");
                File.Publish("Published by SPFeature Activation");
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
