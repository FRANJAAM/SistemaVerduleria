<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MantenimientoTipoProducto.aspx.cs" Inherits="SistemaVerduleria.MantenimientoTipoProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mantenimiento de verduleria</title>
        
    <link rel="stylesheet" type="text/css" href="Estilos.css"/>

</head>
<body>
    <form id="forms" runat="server">
       <header id="main-header">
				 <div style="height:100%;margin: auto;padding: 10px;width:100%; margin-left: -0.7%; margin-top: -0.7%; background-color: #34a0c5">
				 </div>
			</header><!-- / #main-header -->  
        


        <div style="width: 100%; height: 570px;">
            <div style="                    float: left;
                    width: 30%;
                    height: 25px;">
                <div class="container">
                    <div class="card">
                        <div class="header">
                            <h3 style="text-align: center;
                                    margin-left: 0%;
                                    width: 100%;
                                    height: 50%;
                                    color: #34a0c5;
                                    font-family: Arial;
                                    font-size: x-large;
                                    font-weight: bold">Mantenimiento de Tipo de Producto<i class="fas fa-angle-down iconM"></i></h3>
                        </div>
                        <div class="body">
                            <br />
                            <div class="control-label" style="font-weight: bold">Nombre Producto</div>
                            <div>
                               <asp:TextBox ID="txtNombreProducto" runat="server" CssClass="CamposRedondos" Height="20px"></asp:TextBox>
                                <br />
                                <br />
                            </div>

                            <div class="control-label" style="font-weight: bold">Tipo</div>
                            <div>
                                <asp:DropDownList ID="ListaTipoProducto" CssClass="CamposRedondos" runat="server" Height="25px" ClientIDMode="Static">
                                    <asp:ListItem Text="---Seleccione una Opción---" Value="---Seleccione una Opción---">---Seleccione una Opción---</asp:ListItem>
                                    <asp:ListItem Text="Verduras" Value="Verduras">Verduras</asp:ListItem>
                                    <asp:ListItem Text="Frutas" Value="Frutas">Frutas</asp:ListItem>
                                    <asp:ListItem Text="Vegetales" Value="Vegetales">Vegetales</asp:ListItem>
                                    <asp:ListItem Text="Tubérculos" Value="Tubérculos">Tubérculos</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                            </div>

                            <div class="control-label" style="font-weight: bold">Tipo de Precio</div>
                            <div>
                                <asp:DropDownList ID="ListaTipoPrecio" CssClass="CamposRedondos" runat="server" Height="25px" ClientIDMode="Static" >
                                    <asp:ListItem Text="---Seleccione una Opción---" Value="---Seleccione una Opción---">---Seleccione una Opción---</asp:ListItem>
                                    <asp:ListItem Text="Unidad" Value="Unidad">Unidad</asp:ListItem>
                                    <asp:ListItem Text="Por kilo" Value="Por kilo">Por kilo</asp:ListItem>
                                    <asp:ListItem Text="Bandeja" Value="Bandeja">Bandeja</asp:ListItem>
                                    <asp:ListItem Text="Caja" Value="Caja">Caja</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                            </div>

                            <div class="control-label" style="font-weight: bold">Cantidad (Solo permite números)</div>
                            <div>
<asp:TextBox ID="txtCantidad" runat="server" CssClass="CamposRedondos" Height="20px" onkeydown="if((event.keyCode<48 || event.keyCode>57) && (event.keyCode<96 || event.keyCode>105)) event.returnValue=false;"></asp:TextBox>
                                <br />
                                <br />
                            </div>

                            <div class="control-label" style="font-weight: bold">Precio (Solo permite números)</div>
                            <div>
                               <asp:TextBox ID="txtPrecio" runat="server" CssClass="CamposRedondos" Height="20px" onkeydown="if((event.keyCode<48 || event.keyCode>57) && event.keyCode!=188)event.returnValue=false;"></asp:TextBox>
                            </div>
                            <br /> 
                            <div style="width: 45%; display: inline-block; text-align: center;">
                                <asp:Button ID="btnGuardar" CssClass="boton" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            
        </div>        
    </form>
</body>
</html>
