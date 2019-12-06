<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Webform2.aspx.cs" Inherits="WebApplication.Webform2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <script type="text/javascript" src="https://code.jquery.com/jquery-2.2.4.min.js"></script>
    <script>

        $(document).ready(function () {
            AgregarClaseCeldaGrid('GridView1');
            $('.tdCopy').click(function () {
                CopiarTexto($(this).text());
            });
        });

        function AgregarClaseCeldaGrid(GridId) {
            $('[id*=' + GridId + '] td').each(function () {
                $(this).addClass('tdCopy');
            });
        }

        function CopiarTexto(text) {
            var textArea = document.createElement("textarea");
            // Si se renderiza por alguna razón
            textArea.style.background = 'transparent';
            textArea.value = text;
            document.body.appendChild(textArea);
            textArea.select();
            try {
                var ok = document.execCommand('copy');
                //console.log('La copia del texto es correcta ' + ok);
            } catch (err) {
                //console.log('No se pudo copiar');
            }
            document.body.removeChild(textArea);
        }
    </script>
</head>
<body>
    <form runat="server">

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" EmptyDataText="There are no data records to display.">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
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
