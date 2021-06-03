<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="wfmProductoLista.aspx.cs" Inherits="prycarrito.Public.Productos.wfmProductoLista" %>

<%@ Register Src="~/UserControls/ucGrid.ascx" TagName="UC_Grid" TagPrefix="Uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div align="center" width="95%">

        <table width="95%">
            <tr>
                <td>
                    <h3>Lista Producto</h3>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td>
                    <asp:ImageButton ID="imgNuevo" runat="server" ImageUrl="~/images/icon_nuevo.png" Width="32px" Height="32px" />
                    <asp:LinkButton ID="lnkNuevo" runat="server">Nuevo</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td>&nbsp;
                </td>
            </tr>
            <tr>
                <td align="center">

                    <Uc1:UC_Grid ID="UC_Grid1" runat="server"/>
                    <Uc1:UC_Grid ID="UC_Grid2" runat="server"/>


                    <asp:GridView ID="gdvDatosProductos" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgModificar" runat="server" ImageUrl="~/images/modificar.png" Width="32px" Height="32px" CommandName="Modificar" CommandArgument='<%#Eval("ID") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="imgEliminar" runat="server" ImageUrl="~/images/icon_delete.png" Width="32px" Height="32px" CommandName="Eliminar" CommandArgument='<%#Eval("ID") %>'/>
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

                </td>
            </tr>

        </table>
    </div>




</asp:Content>
