<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickLaunchNavigation.ascx.cs" Inherits="RecruitPortal.Webparts.QuickLaunchNavigation.QuickLaunchNavigation" %>



<asp:Literal ID="ltrlNavigationHTML" runat="server"></asp:Literal>
<asp:HiddenField ID="hdnIsCurrentUserFullPrivilege" runat="server" />


<asp:Literal ID="ltrlNavigationDiv" runat="server"></asp:Literal>

<%--<div class="resposnivemenu">
    <ul class="leftmenu">
        <li class="open"><a href="javascript:void(0);" class="menu_hr">HR</a>
            <ul class="innermenu">
                <li><a href="http://devsp13:20202/RecruitmentPortal/Pages/Candidates.aspx" class="menu_candidates active">Candidates</a></li>
                <li><a href="http://devsp13:20202/RecruitmentPortal/Pages/Appointments.aspx" class="menu_apointment">Appointments</a></li>
                <li><a href="http://devsp13:20202/RecruitmentPortal/Pages/Skills.aspx" class="menu_skills">Skills</a></li>
                <li><a href="http://devsp13:20202/RecruitmentPortal/Pages/Feedback.aspx" class="menu_feedback">Feedback</a></li>
                <li><a href="http://devsp13:20202/RecruitmentPortal/Pages/Offers.aspx" class="menu_offers">Offers</a></li>
            </ul>
        </li>
        <li><a href="#" class="menu_leavebox">Leavebox</a></li>
        <li><a href="#" class="menu_asetmngt">Asset Management</a></li>
        <li><a href="#" class="menu_finance">Finance</a></li>
        <li><a href="#" class="menu_employee">Employee</a></li>
    </ul>
</div>--%>


<script type="text/javascript">

    $(document).ready(function () {

        var IsCurrentUserFullPrivilege = $('#<%=hdnIsCurrentUserFullPrivilege.ClientID%>').val();
        var setArray = [];
        setArray = IsCurrentUserFullPrivilege.split(',');
        var currentUserName = setArray[0];
        var isFullAccess = setArray[1];
        
        if (isFullAccess=='false') {
            $('#ms-designer-ribbon').hide();
        }
        $('.rightmenu li:first-child a').attr('href', '/_layouts/15/signout.aspx');

        $('.rightmenu li:last-child a').html(currentUserName);

    //    /_layouts/15/signout.aspx

    });

</script>