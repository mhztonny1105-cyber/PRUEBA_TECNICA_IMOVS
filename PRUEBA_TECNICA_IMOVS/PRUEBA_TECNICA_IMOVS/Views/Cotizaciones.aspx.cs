using PRUEBA_TECNICA_IMOVS.Models;
using PRUEBA_TECNICA_IMOVS.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PRUEBA_TECNICA_IMOVS.Views
{
    public partial class Cotizaciones : System.Web.UI.Page
    {
        private readonly Context _context = new Context();

        // Lista tempral 
        private List<CotizacionDetalle> ProductosCotizacion
        {
            get
            {
                if (Session["ProductosCotizacion"] == null)
                {
                    Session["ProductosCotizacion"] = new List<CotizacionDetalle>();
                }
                return (List<CotizacionDetalle>)Session["ProductosCotizacion"];
            }
            set
            {
                Session["ProductosCotizacion"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductosDisponibles();
                ActualizarGridCotizacion();
                CalcularTotales();
            }
        }

        private void CargarProductosDisponibles()
        {
            try
            {
                // Solo productos activos y con stock diff 0
                var productos = _context.Productos
                    .Where(p => p.Estatus && p.StockDisponible > 0)
                    .OrderBy(p => p.Nombre)
                    .ToList();

                ddlProductos.DataSource = productos;
                ddlProductos.DataTextField = "Nombre";
                ddlProductos.DataValueField = "Id";
                ddlProductos.DataBind();

                ddlProductos.Items.Insert(0, new ListItem("-- Seleccione un producto --", "0"));
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al cargar productos: {ex.Message}";
                lblMensaje.CssClass = "error";
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlProductos.SelectedValue == "0" || string.IsNullOrEmpty(ddlProductos.SelectedValue))
                {
                    lblMensaje.Text = "Por favor seleccione un producto";
                    lblMensaje.CssClass = "error";
                    return;
                }

                // Validar unidades
                if (!int.TryParse(txtUnidades.Text, out int unidades) || unidades <= 0)
                {
                    lblMensaje.Text = "Por favor ingrese una cantidad válida mayor a cero.";
                    lblMensaje.CssClass = "error";
                    return;
                }

                int productoId = Convert.ToInt32(ddlProductos.SelectedValue);
                var producto = _context.Productos.Find(productoId);

                if (producto == null)
                {
                    lblMensaje.Text = "Producto no encontrado.";
                    lblMensaje.CssClass = "error";
                    return;
                }

                // valida stock disponible may productos
                if (unidades > producto.StockDisponible)
                {
                    lblMensaje.Text = $"No hay suficiente stock. Disponible: {producto.StockDisponible} unidades.";
                    lblMensaje.CssClass = "error";
                    return;
                }

                //no repetir producto en cotizacion
                var productoExistente = ProductosCotizacion.FirstOrDefault(p => p.ProductoId == productoId);
                if (productoExistente != null)
                {
                    // sumar las unidades
                    productoExistente.UnidadesCotizadas += unidades;
                    productoExistente.PrecioTotal = productoExistente.UnidadesCotizadas * producto.PrecioUnitario;
                }
                else
                {
                    // Agregar nuevo producto a la cot
                    var detalle = new CotizacionDetalle
                    {
                        ProductoId = producto.Id,
                        UnidadesCotizadas = unidades,
                        PrecioTotal = unidades * producto.PrecioUnitario,
                        Nombre = producto.Nombre, 
                        PrecioUnitario = producto.PrecioUnitario
                    };
                    ProductosCotizacion.Add(detalle);
                }

                // clean
                ddlProductos.SelectedIndex = 0;
                txtUnidades.Text = "1";

                // relooad
                ActualizarGridCotizacion();
                CalcularTotales();
                lblMensaje.Text = "Producto agregado correctamente.";
                lblMensaje.CssClass = "success";

                // el boton enabled si hay al lo menos 1 producto
                btnConfirmarCotizacion.Enabled = ProductosCotizacion.Count > 0;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al agregar producto: {ex.Message}";
                lblMensaje.CssClass = "error";
            }
        }

        private void ActualizarGridCotizacion()
        {
            GridViewCotizacion.DataSource = ProductosCotizacion;
            GridViewCotizacion.DataBind();
        }

        //requerimiento del aplicar el iva y y finalmente calcular total
        private void CalcularTotales()
        {
            decimal subtotal = ProductosCotizacion.Sum(p => p.PrecioTotal);
            decimal iva = subtotal * 0.16m; 
            decimal total = subtotal + iva;

            lblSubtotal.Text = subtotal.ToString("C");
            lblIVA.Text = iva.ToString("C");
            lblTotal.Text = total.ToString("C");
        }

        protected void GridViewCotizacion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                if (index >= 0 && index < ProductosCotizacion.Count)
                {
                    ProductosCotizacion.RemoveAt(index);
                    ActualizarGridCotizacion();
                    CalcularTotales();
                    lblMensaje.Text = "Producto eliminado de la cotización.";
                    lblMensaje.CssClass = "success";

                    btnConfirmarCotizacion.Enabled = ProductosCotizacion.Count > 0;
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al eliminar producto: {ex.Message}";
                lblMensaje.CssClass = "error";
            }
        }

        protected void btnConfirmarCotizacion_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProductosCotizacion.Count == 0)
                {
                    lblMensaje.Text = "No hay productos en la cotizacion.";
                    lblMensaje.CssClass = "error";
                    return;
                }

                // Crear la cotizacion
                var cotizacion = new Cotizacion
                {
                    FechaCotizacion = DateTime.Now,
                    TotalCotizacion = ProductosCotizacion.Sum(p => p.PrecioTotal),
                    IVA = ProductosCotizacion.Sum(p => p.PrecioTotal) * 0.16m,
                    EstadoVenta = true, 
                    Detalles = new List<CotizacionDetalle>()
                };

                //  actualizar stock
                foreach (var detalle in ProductosCotizacion)
                {
                    var producto = _context.Productos.Find(detalle.ProductoId);
                    if (producto != null)
                    {
                        // reduce stok de la entidad prodcuto depsues de cotizar
                        producto.StockDisponible -= detalle.UnidadesCotizadas;
                    }

                    // Agregar detalle a la cotizacin
                    cotizacion.Detalles.Add(new CotizacionDetalle
                    {
                        ProductoId = detalle.ProductoId,
                        UnidadesCotizadas = detalle.UnidadesCotizadas,
                        PrecioTotal = detalle.PrecioTotal
                    });
                }

                // save
                _context.Cotizaciones.Add(cotizacion);
                _context.SaveChanges();
                ProductosCotizacion = new List<CotizacionDetalle>();

                // Clean
                ActualizarGridCotizacion();
                CalcularTotales();
                CargarProductosDisponibles(); // Recargar productos ya que pued eque stock llegue a 0

                lblMensaje.Text = "Cotizacion confirmada como venta. Stock actualizado.";
                lblMensaje.CssClass = "success";
                btnConfirmarCotizacion.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error al confirmar cotizacion: {ex.Message}";
                lblMensaje.CssClass = "error";
            }
        }
    }
}