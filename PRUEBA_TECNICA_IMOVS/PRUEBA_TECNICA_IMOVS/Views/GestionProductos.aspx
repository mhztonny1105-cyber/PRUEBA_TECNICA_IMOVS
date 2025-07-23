<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GestionProductos.aspx.cs" Inherits="PRUEBA_TECNICA_IMOVS.Views.GestionProductos" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Productos</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 20px; }
        .gridview { width: 100%; border-collapse: collapse; margin: 20px 0; }
        .gridview th, .gridview td { border: 1px solid #ddd; padding: 8px; text-align: left; }
        .gridview th { background-color: #f2f2f2; }
        .error { color: red; font-weight: bold; }
        .success { color: green; font-weight: bold; }
        .form-section { 
            background-color: #f9f9f9; 
            padding: 15px; 
            border: 1px solid #ddd; 
            margin-bottom: 20px;
        }
        .form-group { margin: 10px 0; }
        .form-group label { display: inline-block; width: 150px; font-weight: bold; }
        .form-group input { padding: 5px; margin: 5px; width: 200px; }
        .btn-agregar { 
            background-color: #4CAF50; 
            color: white; 
            padding: 10px 20px; 
            border: none; 
            cursor: pointer; 
            font-size: 16px;
        }
        .btn-agregar:hover { background-color: #45a049; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Gestión de Productos</h2>
            
            <!-- Formulario simple para agregar producto -->
            <div class="form-section">
                <h3>Agregar Nuevo Producto</h3>
                <div class="form-group">
                    <label>Nombre:</label>
                    <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Precio Unitario:</label>
                    <asp:TextBox ID="txtPrecio" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Stock Disponible:</label>
                    <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label>Estatus:</label>
                    <asp:CheckBox ID="chkEstatus" runat="server" Text="Activo" Checked="true" />
                </div>
                <div class="form-group">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar Producto" CssClass="btn-agregar" OnClick="btnAgregar_Click" />
                </div>
            </div>
            
            <asp:Label ID="lblMensaje" runat="server"></asp:Label>
            
            <br /><br />
            
            <asp:GridView ID="GridViewProductos" runat="server" 
                AutoGenerateColumns="false" 
                DataKeyNames="Id"
                CssClass="gridview"
                OnRowEditing="GridViewProductos_RowEditing"
                OnRowCancelingEdit="GridViewProductos_RowCancelingEdit"
                OnRowUpdating="GridViewProductos_RowUpdating"
                OnRowDeleting="GridViewProductos_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio Unitario" DataFormatString="{0:C}" />
                    <asp:BoundField DataField="StockDisponible" HeaderText="Stock Disponible" />
                    <asp:TemplateField HeaderText="Estatus">
                        <ItemTemplate>
                            <asp:Label ID="lblEstatus" runat="server" 
                                Text='<%# Eval("Estatus").ToString() == "True" ? "Activo" : "Inactivo" %>'></asp:Label>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkEstatusEdit" runat="server" Checked='<%# Bind("Estatus") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="true" EditText="Editar" />
                    <asp:CommandField ShowDeleteButton="true" DeleteText="Eliminar" />
                </Columns>
            </asp:GridView>
            
            <br />
            <a href="Default.aspx">Volver al menú principal</a>
        </div>
    </form>
</body>
</html>