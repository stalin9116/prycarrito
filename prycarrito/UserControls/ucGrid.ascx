<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucGrid.ascx.cs" Inherits="prycarrito.UserControls.ucGrid" %>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">

    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="imgModificar" runat="server" ImageUrl="~/images/modificar.png" Width="32px" Height="32px" CommandName="Modificar" CommandArgument='<%#Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/images/icon_delete.png" Width="32px" Height="32px" CommandName="Eliminar" CommandArgument='<%#Eval("ID") %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>

    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />

</asp:GridView>
