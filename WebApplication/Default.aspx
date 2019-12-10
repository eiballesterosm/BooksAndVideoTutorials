<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>


    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>
                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" DataValueField="Id"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:AdventureWorksLT2008R2ConnectionString1 %>" ProviderName="<%$ ConnectionStrings:AdventureWorksLT2008R2ConnectionString1.ProviderName %>" SelectCommand="SELECT [Id], [Nombre] FROM [tabla]"></asp:SqlDataSource>
                Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>

    </div>

    <table style="border: 1px solid; width: 100%">
        <tr style="font-weight:bold; text-align:center">
            <td>Operator</td>
            <td>TimeSpan</td>
            <td>DateTime</td>
        </tr>
        <tr>
            <td>Assignment (=)</td>
            <td>Because TimeSpan is a structure, assignment returns a copy and not a reference</td>
            <td>Because DateTime is a structure, assignment returns a copy and not a reference</td>
        </tr>
        <tr>
            <td>Addition (+)</td>
            <td>Adds two TimeSpan instances</td>
            <td>Adds a TimeSpan to a DateTime</td>
        </tr>
        <tr>
            <td>Subtraction (-)</td>
            <td>Subtracts one TimeSpan instance from another</td>
            <td>Subtracts a TimeSpan or a DateTime from a DateTime</td>
        </tr>
        <tr>
            <td>Equality (==)</td>
            <td>Compares two TimeSpan instances and returns true if they are equal</td>
            <td>Compares two DateTime instances and returns true if they are equal</td>
        </tr>
        <tr>
            <td>Inequality (!=)</td>
            <td>Compares two TimeSpan instances and returns true if they aren't equal</td>
            <td>Compares two DateTime instances and returns true if they aren't equal</td>
        </tr>
        <tr>
            <td>Greater Than (>)</td>
            <td>Determines if one TimeSpan is greater than another TimeSpan</td>
            <td>Determines if one DateTime is greater than another DateTime</td>
        </tr>
        <tr>
            <td>Greater Than or Equal(>=)</td>
            <td>Determines if one TimeSpan is greater than or equal to another TimeSpan</td>
            <td>Determines if one DateTime is greater than or equal to another DateTime</td>
        </tr>
        <tr>
            <td>Less Than (<)</td>
            <td>Determines if one TimeSpan is less than another TimeSpan</td>
            <td>Determines if one DateTime is less than another DateTime</td>
        </tr>
        <tr>
            <td>Less Than or Equal (<=)</td>
            <td>Determines if one TimeSpan is less than or equal to another TimeSpan</td>
            <td>Determines if one DateTime is less than or equal to another DateTime</td>
        </tr>
        <tr>
            <td>Unary Negation (-)</td>
            <td>Returns a TimeSpan with a negated value of the specified TimeSpan</td>
            <td>Not Supported/td>
        </tr>
        <tr>
            <td>Unary Plus (+)</td>
            <td>Returns the TimeSpan specified</td>
            <td>Not Supported</td>
        </tr>
    </table>

</asp:Content>
