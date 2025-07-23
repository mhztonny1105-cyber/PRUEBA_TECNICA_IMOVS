using PRUEBA_TECNICA_IMOVS.Models;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRUEBA_TECNICA_IMOVS.Views
{
    public partial class GestionProductos : System.Web.UI.Page
    {
        private readonly Context _context = new Context(); 

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            try
            {
                var productos = _context.Productos.ToList();
                GridViewProductos.DataSource = productos;
                GridViewProductos.DataBind();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al cargar productos: {ex.Message}";
                lblMensaje.CssClass = "error";
            }
        }

        // Método para agregar nuevo producto
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones simples en el code-behind
                if (string.IsNullOrWhiteSpace(txtNombre.Text))
                {
                    lblMensaje.Text = "El nombre es requerido.";
                    lblMensaje.CssClass = "error";
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio < 0)
                {
                    lblMensaje.Text = "Precio inválido. Debe ser un número positivo.";
                    lblMensaje.CssClass = "error";
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
                {
                    lblMensaje.Text = "Stock inválido. Debe ser un número entero positivo.";
                    lblMensaje.CssClass = "error";
                    return;
                }

                // Crear nuevo producto
                var nuevoProducto = new PRUEBA_TECNICA_IMOVS.Models.Entities.Producto
                {
                    Nombre = txtNombre.Text.Trim(),
                    PrecioUnitario = precio,
                    StockDisponible = stock,
                    Estatus = chkEstatus.Checked
                };

                // Guardar en base de datos
                _context.Productos.Add(nuevoProducto);
                _context.SaveChanges();

                // Limpiar campos
                txtNombre.Text = "";
                txtPrecio.Text = "";
                txtStock.Text = "";
                chkEstatus.Checked = true;

                // Mostrar mensaje de éxito
                lblMensaje.Text = "Producto agregado correctamente.";
                lblMensaje.CssClass = "success";

                // Recargar grid
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al agregar producto: {ex.Message}";
                lblMensaje.CssClass = "error";
            }
        }

        protected void GridViewProductos_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewProductos.EditIndex = e.NewEditIndex;
            CargarGrid();
        }

        protected void GridViewProductos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewProductos.EditIndex = -1;
            CargarGrid();
        }

        protected void GridViewProductos_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(GridViewProductos.DataKeys[e.RowIndex].Value);
                var producto = _context.Productos.Find(id);

                if (producto != null)
                {
                    // Actualizar campos
                    producto.Nombre = ((TextBox)GridViewProductos.Rows[e.RowIndex].Cells[1].Controls[0]).Text;

                    // Validar y convertir precio
                    var precioText = ((TextBox)GridViewProductos.Rows[e.RowIndex].Cells[2].Controls[0]).Text;
                    if (decimal.TryParse(precioText, out decimal precio))
                    {
                        producto.PrecioUnitario = precio;
                    }

                    // Validar y convertir stock
                    var stockText = ((TextBox)GridViewProductos.Rows[e.RowIndex].Cells[3].Controls[0]).Text;
                    if (int.TryParse(stockText, out int stock))
                    {
                        producto.StockDisponible = stock;
                    }

                    // Obtener estatus del checkbox
                    var chkEstatus = (CheckBox)GridViewProductos.Rows[e.RowIndex].Cells[4].FindControl("chkEstatusEdit");
                    if (chkEstatus != null)
                    {
                        producto.Estatus = chkEstatus.Checked;
                    }

                    _context.SaveChanges();
                    lblMensaje.Text = "Producto actualizado correctamente.";
                    lblMensaje.CssClass = "success";
                }

                GridViewProductos.EditIndex = -1;
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al actualizar el producto: {ex.Message}";
                lblMensaje.CssClass = "error";
            }
        }

        protected void GridViewProductos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                var id = Convert.ToInt32(GridViewProductos.DataKeys[e.RowIndex].Value);
                var producto = _context.Productos.Find(id);

                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    _context.SaveChanges();
                    lblMensaje.Text = "Producto eliminado correctamente.";
                    lblMensaje.CssClass = "success";
                }

                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al eliminar el producto, no se puede eliminar un prodcuto confirmado para venta";
                lblMensaje.CssClass = "error";
            }
        }
    }
}