using Microsoft.SharePoint.Taxonomy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecruitPortal.Components
{
    public class Component_ConstructHTML
    {

    }

    public class Component_ConstructHTML_Navigation
    {
        /// <summary>
        /// To Construct Html for Menu Component
        /// </summary>
        /// <param name="siteUrl"></param>
        /// <param name="termSetName"></param>
        /// <returns></returns>
        public static string LeftNavigationHtml(string siteUrl, string termSetName)
        {
            string constructHtml = "";
            TermSet NavigationTermset = RecruitPortal.Controller.Controller_DataAccess_Navigation.LeftNavigation(siteUrl, termSetName);


            if (NavigationTermset != null && NavigationTermset.Terms.Count > 0)
            {
                constructHtml += "             <div class='resposnivemenu'>     ";
                constructHtml += "     <ul class='leftmenu'>  ";
                foreach (Term parentTerm in NavigationTermset.Terms)
                {
                    string parentlink = parentTerm.CustomProperties.ContainsKey("Url") ? parentTerm.CustomProperties["Url"] : string.Empty;
                    string parent_iconClass = parentTerm.CustomProperties.ContainsKey("Icon") ? parentTerm.CustomProperties["Icon"] : string.Empty;
                    string parent_pageName = parentTerm.CustomProperties.ContainsKey("PageName") ? parentTerm.CustomProperties["PageName"] : string.Empty;

                    if (parentTerm.Terms.Count > 0)
                    {
                        if (!string.IsNullOrEmpty(parentlink))
                        {
                            constructHtml += "         <li class='open'><a href='" + parentlink + "' class='" + parent_iconClass + "'>" + parentTerm.Name + "</a>  ";
                        }
                        else
                        {
                            constructHtml += "         <li class='open'><a class='" + parent_iconClass + "'>" + parentTerm.Name + "</a>  ";
                        }

                        constructHtml += "             <ul class='innermenu'>   ";
                        foreach (Term childTerm in parentTerm.Terms)
                        {
                            string childlink = childTerm.CustomProperties.ContainsKey("Url") ? childTerm.CustomProperties["Url"] : string.Empty;
                            string child_iconClass = childTerm.CustomProperties.ContainsKey("Icon") ? childTerm.CustomProperties["Icon"] : string.Empty;
                            string child_pageName = childTerm.CustomProperties.ContainsKey("PageName") ? childTerm.CustomProperties["PageName"] : string.Empty;

                            if (!string.IsNullOrEmpty(childlink))
                            {
                                constructHtml += "         <li class='open'><a href='" + childlink + "' class='" + child_iconClass + "r'>" + childTerm.Name + "</a>  ";
                            }
                            else
                            {
                                constructHtml += "         <li class='open'><a  class='" + child_iconClass + "'>" + childTerm.Name + "</a>  ";
                            }

                        }
                        constructHtml += "             </ul> ";
                    }
                    else
                    {
                        constructHtml += "         <li><a href='" + parentlink + "' class='" + parent_iconClass + "'>" + parentTerm.Name + "</a>  ";
                    }


                }
                constructHtml += "     </ul>                                                                                                                                                  ";
                constructHtml += " </div>";

            }



            return constructHtml;
        }
    }
}
