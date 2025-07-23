<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cotizaciones.aspx.cs" Inherits="PRUEBA_TECNICA_IMOVS.Views.Cotizaciones" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cotizaciones de Productos</title>
    <style>
        body { 
            font-family: Arial, sans-serif; 
            margin: 20px; 
            background-color: #f5f5f5;
        }
        .container {
            max-width: 1200px;
            margin: 0 auto;
            background-color: white;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h2 {
            color: #333;
            border-bottom: 2px solid #2196F3;
            padding-bottom: 10px;
        }
        .form-section {
            background-color: #f9f9f9;
            padding: 15px;
            border-radius: 5px;
            margin-bottom: 20px;
        }
        .gridview {
            width: 100%;
            border-collapse: collapse;
            margin: 10px 0;
        }
        .gridview th, .gridview td {
            border: 1px solid #ddd;
            padding: 8px;
            text-align: left;
        }
        .gridview th {
            background-color: #2196F3;
            color: white;
        }
        .error { color: red; font-weight: bold; }
        .success { color: green; font-weight: bold; }
        .warning { color: orange; font-weight: bold; }
        .form-group {
            margin: 10px 0;
            display: inline-block;
            margin-right: 15px;
        }
        .form-group label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .form-group input, .form-group select {
            padding: 5px;
            border: 1px solid #ddd;
            border-radius: 3px;
        }
        .btn-primary {
            background-color: #2196F3;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-weight: bold;
        }
        .btn-primary:hover {
            background-color: #1976D2;
        }
        .btn-success {
            background-color: #4CAF50;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-weight: bold;
        }
        .btn-success:hover {
            background-color: #45a049;
        }
        .btn-danger {
            background-color: #f44336;
            color: white;
            padding: 10px 20px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-weight: bold;
        }
        .btn-danger:hover {
            background-color: #d32f2f;
        }
        .total-section {
            background-color: #e3f2fd;
            padding: 15px;
            border-radius: 5px;
            margin: 20px 0;
            text-align: right;
        }
        .total-item {
            margin: 5px 0;
            font-size: 18px;
        }
        .total-final {
            font-size: 24px;
            font-weight: bold;
            color: #2196F3;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>📋 Sistema de Cotizaciones</h2>
            
            <asp:Label ID="lblMensaje" runat="server" CssClass="error"></asp:Label>
            
            <!-- Sección para seleccionar productos -->
            <div class="form-section">
                <h3>Seleccionar Productos</h3>
                <div class="form-group">
                    <label for="ddlProductos">Producto:</label>
                    <asp:DropDownList ID="ddlProductos" runat="server" Width="300px">
                    </asp:DropDownList>
                </div>
                <div class="form-group">
                    <label for="txtUnidades">Unidades:</label>
                    <asp:TextBox ID="txtUnidades" runat="server" Width="100px" Text="1"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnAgregarProducto" runat="server" 
                        Text="Agregar a Cotización" 
                        CssClass="btn-primary" 
                        OnClick="btnAgregarProducto_Click" />
                </div>
            </div>
            
            <!-- Grid de productos seleccionados -->
            <h3>Productos en Cotización</h3>
            <asp:GridView ID="GridViewCotizacion" runat="server" 
                AutoGenerateColumns="false"
                CssClass="gridview"
                EmptyDataText="No hay productos agregados a la cotización"
                OnRowDeleting="GridViewCotizacion_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Producto" />
                    <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="UnidadesCotizadas" HeaderText="Unidades" />
                    <asp:BoundField DataField="PrecioTotal" HeaderText="Total" DataFormatString="{0:C}" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" />
                </Columns>
            </asp:GridView>
            
            <!-- Sección de totales -->
            <div class="total-section">
                <div class="total-item">
                    Subtotal: <asp:Label ID="lblSubtotal" runat="server" Text="$0.00"></asp:Label>
                </div>
                <div class="total-item">
                    IVA (16%): <asp:Label ID="lblIVA" runat="server" Text="$0.00"></asp:Label>
                </div>
                <div class="total-item total-final">
                    Total: <asp:Label ID="lblTotal" runat="server" Text="$0.00"></asp:Label>
                </div>
            </div>
            
            <!-- Botón para confirmar cotización -->
            <div style="text-align: center; margin: 20px 0;">
                <asp:Button ID="btnConfirmarCotizacion" runat="server" 
                    Text="✅ Confirmar Cotización como Venta" 
                    CssClass="btn-success" 
                    OnClick="btnConfirmarCotizacion_Click" 
                    Enabled="false" />
            </div>
            
            <br />
            <a href="../Index.aspx" class="btn-primary" style="text-decoration: none; padding: 10px 20px;">🏠 Volver al Menú Principal</a>
        </div>
    </form>
</body>
</html>