<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--https://stackoverflow.com/questions/22581345/click-button-copy-to-clipboard-using-jquery--%>
    <%--https://www.aspforums.net/Threads/181766/Cut-Copy-Paste-GridView-Rows-using-Right-Click-Context-Menu-using-jQuery-in-ASPNet/--%>

    <link href="Scripts/jq/css/jquery.contextMenu.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
    <script src="Scripts/jq/js/jquery.simplemodal-1.1.1.js"></script>
    <script src="Scripts/jq/js/jquery.contextMenu.js"></script>
    <script type="text/javascript">
        var GridRow;
        var LastAction;
        var lastRowindex;
        var LastGridId;
        $(document).ready(function () {
            AppenedCustomerRowClass('GridView1');
            ContextMenu();
        });

        function AppenedCustomerRowClass(GridId) {
            $('[id*=' + GridId + '] tr').each(function () {
                $(this).addClass('customerRow');
            });
        }

        function contextMenuWork(action, el, pos) {
            var rowindex = (el[0].rowIndex * 1);
            var GridId = $(el).parents('table')[0].id;
            switch (action) {
                case "paste":
                    {
                        if (GridRow == null) {
                            alert('Please select row to be pasted');
                            return false;
                        } else {
                            $('[id*=' + GridId + '] tr').eq(rowindex).after("<tr>" + $(GridRow).html() + "</tr>");
                            $('[id*=' + GridId + '] tr').eq(rowindex).next()[0].className = 'customerRow';
                        }
                        if (LastAction == 'cut') {
                            $('[id*=' + LastGridId + '] tr').eq(lastRowindex).remove();
                        }
                        ContextMenu();
                        LastAction = 'paste';
                        break;
                    }
                case "cut":
                    {
                        lastRowindex = rowindex;
                        GridRow = $(el);
                        LastGridId = GridId;
                        $('[id*=' + GridId + '] tr').eq(rowindex).css('background-color', 'darkgray');
                        LastAction = 'cut';
                        break;
                    }
                case "copy":
                    {
                        if (LastAction == 'cut') {
                            $('[id*=' + LastGridId + '] tr').eq(lastRowindex).css('background-color', 'White')
                        }
                        GridRow = $(el);
                        LastAction = 'copy';
                        break;
                    }
            }
            return false;
        }

        function ContextMenu() {
            $(".customerRow").contextMenu({ menu: 'myMenu' }, function (action, el, pos) { contextMenuWork(action, el, pos); });
            $(".openmenu").contextMenu({ menu: 'myMenu', leftButton: true }, function (action, el, pos) { contextMenuWork(action, el.parent("tr"), pos); });
        }
    </script>
    <style type="text/css">
        .customerRow {
            background-color: White;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <ul id="myMenu" class="customerRow">
            <li class="cut"><a href="#cut">Cut</a></li>
            <li class="copy"><a href="#copy">Copy</a></li>
            <li class="paste"><a href="#paste">Paste</a></li>
        </ul>


        <asp:GridView ID="GridView1" ClientIDMode="Static" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                <asp:TemplateField HeaderText="id">
                    <ItemTemplate>
                        <asp:Label ID="id" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ecommerceConnectionString1 %>" DeleteCommand="DELETE FROM [brands] WHERE [id] = @id" InsertCommand="INSERT INTO [brands] ([name], [description]) VALUES (@name, @description)" ProviderName="<%$ ConnectionStrings:ecommerceConnectionString1.ProviderName %>" SelectCommand="SELECT [id], [name], [description] FROM [brands]" UpdateCommand="UPDATE [brands] SET [name] = @name, [description] = @description WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="name" Type="String" />
                <asp:Parameter Name="description" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>



    </form>
</body>
</html>
