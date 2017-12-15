using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using RecruitPortal.Constants;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace RecruitPortal.Webparts.QuickLaunchNavigation
{
    [ToolboxItemAttribute(false)]
    public partial class QuickLaunchNavigation : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public QuickLaunchNavigation()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            string currentUserName = SPContext.Current.Web.CurrentUser.Name;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {

                    string siteUrl=SPContext.Current.Site.Url;
                    string currentuser_IsPrivileged = string.Empty;
                    currentuser_IsPrivileged = CheckCurrentUser_Privileges(currentUserName);
                    hdnIsCurrentUserFullPrivilege.Value = currentuser_IsPrivileged;
                    ltrlNavigationDiv.Text = RecruitPortal.Components.Component_ConstructHTML_Navigation.LeftNavigationHtml(siteUrl, StringConstants.TermsetTopNavigationName);

                });
            }
            catch (Exception ex)
            {
                SPDiagnosticsService.Local.WriteTrace(0, new SPDiagnosticsCategory("Error-Recruit-Portal", TraceSeverity.Unexpected, EventSeverity.Error), TraceSeverity.Unexpected, ex.Message, ex.StackTrace);
            }





        }

        /// <summary>
        /// To Check Whether the Current user is part of the Full Privilege user Group
        /// </summary>
        /// <returns></returns>
        private string CheckCurrentUser_Privileges(string currentUsername)
        {
            string isCurrent_User_FullPrivileged = string.Empty;
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {

                SPGroup fullControlGroup = site.OpenWeb().Groups[StringConstants.FullControlUserGroup];
                isCurrent_User_FullPrivileged = currentUsername + ",false";
                foreach (SPUser user in fullControlGroup.Users)
                {
                    if (user.Name.ToLower() == currentUsername.ToLower()|| user.Name.ToLower() == "system account")
                    {
                        isCurrent_User_FullPrivileged = currentUsername + ",true";
                    }

                }

            }

            return isCurrent_User_FullPrivileged;
        }
    }
}
