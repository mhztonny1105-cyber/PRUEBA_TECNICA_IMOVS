<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html>
<html lang="es">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Gestión de Ventas a Crédito - Prueba Técnica</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.0/font/bootstrap-icons.css" rel="stylesheet">
    <style>
        body {
            background-color: #f8f9fa;
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
        }
        .navbar {
            box-shadow: 0 2px 4px rgba(0,0,0,.1);
        }
        .card {
            border: none;
            box-shadow: 0 0 15px rgba(0,0,0,.1);
            margin-bottom: 20px;
        }
        .card-header {
            background: linear-gradient(135deg, #667eea 0%, #764ba2 100%);
            color: white;
            font-weight: bold;
        }
        .btn-action {
            margin: 2px;
        }
        .badge-porpagar {
            background-color: #ffc107;
            color: #000;
        }
        .badge-pagado {
            background-color: #28a745;
            color: #fff;
        }
        .table-responsive {
            max-height: 400px;
            overflow-y: auto;
        }
        .loading {
            display: none;
            text-align: center;
            padding: 20px;
        }
        .modal-lg {
            max-width: 900px;
        }
    </style>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark mb-4">
        <div class="container-fluid">
            <a class="navbar-brand" href="#">
                <i class="bi bi-cart-check-fill"></i> Sistema de Ventas a Crédito
            </a>
            <span class="navbar-text text-white">
                Prueba Técnica - Jesús Fabián Ortiz Mora
            </span>
        </div>
    </nav>

    <div class="container-fluid">
        <ul class="nav nav-tabs mb-4" id="mainTabs" role="tablist">
            <li class="nav-item" role="presentation">
                <button class="nav-link active" id="productos-tab" data-bs-toggle="tab" data-bs-target="#productos" type="button">
                    <i class="bi bi-box-seam"></i> Productos
                </button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="tickets-tab" data-bs-toggle="tab" data-bs-target="#tickets" type="button">
                    <i class="bi bi-receipt"></i> Tickets
                </button>
            </li>
            <li class="nav-item" role="presentation">
                <button class="nav-link" id="pagos-tab" data-bs-toggle="tab" data-bs-target="#pagos" type="button">
                    <i class="bi bi-cash-coin"></i> Pagos
                </button>
            </li>
        </ul>

        <div class="tab-content" id="mainTabContent">
            <div class="tab-pane fade show active" id="productos" role="tabpanel">
                <div class="row">
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-header">
                                <i class="bi bi-plus-circle"></i> <span id="productoFormTitle">Agregar Producto</span>
                            </div>
                            <div class="card-body">
                                <form id="formProducto">
                                    <input type="hidden" id="productoId">
                                    <div class="mb-3">
                                        <label class="form-label">Nombre *</label>
                                        <input type="text" class="form-control" id="productoNombre" required>
                                    </div>
                                    <div class="mb-3">
                                        <label class="form-label">Descripción</label>
                                        <textarea class="form-control" id="productoDescripcion" rows="2"></textarea>
                                    </div>
                                    <div class="mb-3">
                                        <label class="form-label">Precio Unitario *</label>
                                        <input type="number" class="form-control" id="productoPrecio" step="0.01" required>
                                    </div>
                                    <div class="mb-3">
                                        <label class="form-label">Stock *</label>
                                        <input type="number" class="form-control" id="productoStock" required>
                                    </div>
                                    <button type="submit" class="btn btn-primary w-100">
                                        <i class="bi bi-save"></i> Guardar
                                    </button>
                                    <button type="button" class="btn btn-secondary w-100 mt-2" onclick="limpiarFormProducto()">
                                        <i class="bi bi-x-circle"></i> Cancelar
                                    </button>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="card">
                            <div class="card-header d-flex justify-content-between align-items-center">
                                <span><i class="bi bi-list-ul"></i> Lista de Productos</span>
                                <button class="btn btn-light btn-sm" onclick="cargarProductos()">
                                    <i class="bi bi-arrow-clockwise"></i> Actualizar
                                </button>
                            </div>
                            <div class="card-body">
                                <div class="loading" id="loadingProductos">
                                    <div class="spinner-border text-primary" role="status"></div>
                                </div>
                                <div class="table-responsive">
                                    <table class="table table-hover">
                                        <thead class="table-light">
                                            <tr>
                                                <th>ID</th>
                                                <th>Nombre</th>
                                                <th>Precio</th>
                                                <th>Stock</th>
                                                <th>Acciones</th>
                                            </tr>
                                        </thead>
                                        <tbody id="tablaProductos"></tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="tab-pane fade" id="tickets" role="tabpanel">
                <div class="row mb-3">
                    <div class="col-md-12">
                        <button class="btn btn-success" data-bs-toggle="modal" data-bs-target="#modalNuevoTicket">
                            <i class="bi bi-plus-circle"></i> Nuevo Ticket
                        </button>
                    </div>
                </div>
                <div class="card">
                    <div class="card-header d-flex justify-content-between align-items-center">
                        <span><i class="bi bi-receipt-cutoff"></i> Lista de Tickets</span>
                        <button class="btn btn-light btn-sm" onclick="cargarTickets()">
                            <i class="bi bi-arrow-clockwise"></i> Actualizar
                        </button>
                    </div>
                    <div class="card-body">
                        <div class="loading" id="loadingTickets">
                            <div class="spinner-border text-primary" role="status"></div>
                        </div>
                        <div class="table-responsive">
                            <table class="table table-hover">
                                <thead class="table-light">
                                    <tr>
                                        <th>Folio</th>
                                        <th>Cliente</th>
                                        <th>Fecha Creación</th>
                                        <th>Fecha Liquidación</th>
                                        <th>Total</th>
                                        <th>Pagado</th>
                                        <th>Pendiente</th>
                                        <th>Estatus</th>
                                        <th>Acciones</th>
                                    </tr>
                                </thead>
                                <tbody id="tablaTickets"></tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>

            <div class="tab-pane fade" id="pagos" role="tabpanel">
                <div class="row">
                    <div class="col-md-4">
                        <div class="card">
                            <div class="card-header">
                                <i class="bi bi-cash-stack"></i> Registrar Pago
                            </div>
                            <div class="card-body">
                                <form id="formPago">
                                    <div class="mb-3">
                                        <label class="form-label">Ticket *</label>
                                        <select class="form-select" id="pagoTicketId" required onchange="cargarInfoTicket()">
                                            <option value="">Seleccione un ticket...</option>
                                        </select>
                                    </div>
                                    <div id="infoTicket" style="display:none;" class="alert alert-info">
                                        <small>
                                            <strong>Total:</strong> $<span id="infoTotal">0.00</span><br>
                                            <strong>Pagado:</strong> $<span id="infoPagado">0.00</span><br>
                                            <strong>Pendiente:</strong> $<span id="infoPendiente">0.00</span>
                                        </small>
                                    </div>
                                    <div class="mb-3">
                                        <label class="form-label">Monto *</label>
                                        <input type="number" class="form-control" id="pagoMonto" step="0.01" required>
                                    </div>
                                    <div class="mb-3">
                                        <label class="form-label">Observaciones</label>
                                        <textarea class="form-control" id="pagoObservaciones" rows="2"></textarea>
                                    </div>
                                    <button type="submit" class="btn btn-success w-100">
                                        <i class="bi bi-check-circle"></i> Registrar Pago
                                    </button>
                                </form>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-8">
                        <div class="card">
                            <div class="card-header">
                                <i class="bi bi-clock-history"></i> Historial de Pagos
                            </div>
                            <div class="card-body">
                                <div class="mb-3">
                                    <select class="form-select" id="filtroTicketPagos" onchange="cargarPagosPorTicket()">
                                        <option value="">Seleccione un ticket para ver su historial...</option>
                                    </select>
                                </div>
                                <div class="loading" id="loadingPagos">
                                    <div class="spinner-border text-primary" role="status"></div>
                                </div>
                                <div id="historialPagos"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade" id="modalNuevoTicket" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"><i class="bi bi-receipt"></i> Crear Nuevo Ticket</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body">
                    <form id="formTicket">
                        <div class="mb-3">
                            <label class="form-label">Cliente *</label>
                            <input type="text" class="form-control" id="ticketCliente" required>
                        </div>
                        <hr>
                        <h6>Detalles del Ticket</h6>
                        <div id="detallesTicket">
                            <div class="row mb-2 detalle-item">
                                <div class="col-md-6">
                                    <select class="form-select producto-select" required>
                                        <option value="">Seleccione producto...</option>
                                    </select>
                                </div>
                                <div class="col-md-3">
                                    <input type="number" class="form-control cantidad-input" placeholder="Cantidad" min="1" required>
                                </div>
                                <div class="col-md-3">
                                    <button type="button" class="btn btn-danger btn-sm" onclick="eliminarDetalle(this)">
                                        <i class="bi bi-trash"></i>
                                    </button>
                                </div>
                            </div>
                        </div>
                        <button type="button" class="btn btn-secondary btn-sm" onclick="agregarDetalle()">
                            <i class="bi bi-plus"></i> Agregar Producto
                        </button>
                    </form>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <button type="button" class="btn btn-primary" onclick="crearTicket()">
                        <i class="bi bi-save"></i> Crear Ticket
                    </button>
                </div>
            </div>
        </div>
    </div>


    <div class="modal fade" id="modalDetalleTicket" tabindex="-1">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title"><i class="bi bi-receipt-cutoff"></i> Detalle del Ticket</h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal"></button>
                </div>
                <div class="modal-body" id="contenidoDetalleTicket">
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script>
        const API_URL = '/api';
        let productosGlobal = [];

        document.addEventListener('DOMContentLoaded', function () {
            cargarProductos();
            cargarTickets();
            cargarTicketsParaPagos();

            document.getElementById('formProducto').addEventListener('submit', guardarProducto);
            document.getElementById('formPago').addEventListener('submit', registrarPago);
        });

        async function cargarProductos() {
            document.getElementById('loadingProductos').style.display = 'block';
            try {
                const response = await fetch(`${API_URL}/productos`);
                const result = await response.json();
                productosGlobal = result.data;

                const tbody = document.getElementById('tablaProductos');
                tbody.innerHTML = '';

                result.data.forEach(producto => {
                    tbody.innerHTML += `
                        <tr>
                            <td>${producto.productoId}</td>
                            <td>${producto.nombre}</td>
                            <td>$${producto.precioUnitario.toFixed(2)}</td>
                            <td>${producto.stock}</td>
                            <td>
                                <button class="btn btn-sm btn-warning btn-action" onclick='editarProducto(${JSON.stringify(producto)})'>
                                    <i class="bi bi-pencil"></i>
                                </button>
                                <button class="btn btn-sm btn-danger btn-action" onclick="eliminarProducto(${producto.productoId})">
                                    <i class="bi bi-trash"></i>
                                </button>
                            </td>
                        </tr>
                    `;
                });

                actualizarSelectsProductos();
            } catch (error) {
                console.error('Error:', error);
                alert('Error al cargar productos');
            }
            document.getElementById('loadingProductos').style.display = 'none';
        }

        async function guardarProducto(e) {
            e.preventDefault();

            const producto = {
                nombre: document.getElementById('productoNombre').value,
                descripcion: document.getElementById('productoDescripcion').value,
                precioUnitario: parseFloat(document.getElementById('productoPrecio').value),
                stock: parseInt(document.getElementById('productoStock').value),
                activo: true
            };

            const id = document.getElementById('productoId').value;
            const url = id ? `${API_URL}/productos/${id}` : `${API_URL}/productos`;
            const method = id ? 'PUT' : 'POST';

            try {
                const response = await fetch(url, {
                    method: method,
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(producto)
                });

                const result = await response.json();

                if (result.success) {
                    alert(result.message);
                    limpiarFormProducto();
                    cargarProductos();
                } else {
                    alert('Error: ' + result.message);
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Error al guardar producto');
            }
        }

        function editarProducto(producto) {
            document.getElementById('productoId').value = producto.productoId;
            document.getElementById('productoNombre').value = producto.nombre;
            document.getElementById('productoDescripcion').value = producto.descripcion || '';
            document.getElementById('productoPrecio').value = producto.precioUnitario;
            document.getElementById('productoStock').value = producto.stock;
            document.getElementById('productoFormTitle').textContent = 'Editar Producto';
        }

        function limpiarFormProducto() {
            document.getElementById('formProducto').reset();
            document.getElementById('productoId').value = '';
            document.getElementById('productoFormTitle').textContent = 'Agregar Producto';
        }

        async function eliminarProducto(id) {
            if (!confirm('¿Está seguro de eliminar este producto?')) return;

            try {
                const response = await fetch(`${API_URL}/productos/${id}`, {
                    method: 'DELETE'
                });

                const result = await response.json();

                if (result.success) {
                    alert(result.message);
                    cargarProductos();
                } else {
                    alert('Error: ' + result.message);
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Error al eliminar producto');
            }
        }

        async function cargarTickets() {
            document.getElementById('loadingTickets').style.display = 'block';
            try {
                const response = await fetch(`${API_URL}/tickets`);
                const result = await response.json();

                const tbody = document.getElementById('tablaTickets');
                tbody.innerHTML = '';

                result.data.forEach(ticket => {
                    const estatusBadge = ticket.estatus === 'Pagado'
                        ? '<span class="badge badge-pagado">Pagado</span>'
                        : '<span class="badge badge-porpagar">Por Pagar</span>';

                    const fechaLiquidacion = ticket.fechaLiquidacion
                        ? new Date(ticket.fechaLiquidacion).toLocaleDateString()
                        : '<span class="text-muted">-</span>';

                    tbody.innerHTML += `
                        <tr>
                            <td>${ticket.folio}</td>
                            <td>${ticket.cliente || 'N/A'}</td>
                            <td>${new Date(ticket.fechaCreacion).toLocaleDateString()}</td>
                            <td>${fechaLiquidacion}</td>
                            <td>$${ticket.montoTotal.toFixed(2)}</td>
                            <td>$${ticket.montoPagado.toFixed(2)}</td>
                            <td>$${ticket.montoPendiente.toFixed(2)}</td>
                            <td>${estatusBadge}</td>
                            <td>
                                <button class="btn btn-sm btn-info btn-action" onclick="verDetalleTicket(${ticket.ticketId})">
                                    <i class="bi bi-eye"></i>
                                </button>
                                <button class="btn btn-sm btn-danger btn-action" onclick="eliminarTicket(${ticket.ticketId})" ${ticket.cantidadPagos > 0 ? 'disabled' : ''}>
                                    <i class="bi bi-trash"></i>
                                </button>
                            </td>
                        </tr>
                    `;
                });
            } catch (error) {
                console.error('Error:', error);
                alert('Error al cargar tickets');
            }
            document.getElementById('loadingTickets').style.display = 'none';
        }

        function actualizarSelectsProductos() {
            const selects = document.querySelectorAll('.producto-select');
            selects.forEach(select => {
                select.innerHTML = '<option value="">Seleccione producto...</option>';
                productosGlobal.forEach(p => {
                    select.innerHTML += `<option value="${p.productoId}">${p.nombre} - $${p.precioUnitario.toFixed(2)} (Stock: ${p.stock})</option>`;
                });
            });
        }

        function agregarDetalle() {
            const container = document.getElementById('detallesTicket');
            const nuevoDetalle = document.createElement('div');
            nuevoDetalle.className = 'row mb-2 detalle-item';
            nuevoDetalle.innerHTML = `
                <div class="col-md-6">
                    <select class="form-select producto-select" required>
                        <option value="">Seleccione producto...</option>
                    </select>
                </div>
                <div class="col-md-3">
                    <input type="number" class="form-control cantidad-input" placeholder="Cantidad" min="1" required>
                </div>
                <div class="col-md-3">
                    <button type="button" class="btn btn-danger btn-sm" onclick="eliminarDetalle(this)">
                        <i class="bi bi-trash"></i>
                    </button>
                </div>
            `;
            container.appendChild(nuevoDetalle);
            actualizarSelectsProductos();
        }

        function eliminarDetalle(btn) {
            const detalles = document.querySelectorAll('.detalle-item');
            if (detalles.length > 1) {
                btn.closest('.detalle-item').remove();
            } else {
                alert('Debe haber al menos un detalle');
            }
        }

        async function crearTicket() {
            const cliente = document.getElementById('ticketCliente').value;
            const detalles = [];

            document.querySelectorAll('.detalle-item').forEach(item => {
                const productoId = parseInt(item.querySelector('.producto-select').value);
                const cantidad = parseInt(item.querySelector('.cantidad-input').value);

                if (productoId && cantidad) {
                    detalles.push({ productoId, cantidad });
                }
            });

            if (detalles.length === 0) {
                alert('Agregue al menos un producto');
                return;
            }

            const ticket = { cliente, detalles };

            try {
                const response = await fetch(`${API_URL}/tickets`, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(ticket)
                });

                const result = await response.json();

                if (result.success) {
                    alert(result.message);
                    bootstrap.Modal.getInstance(document.getElementById('modalNuevoTicket')).hide();
                    document.getElementById('formTicket').reset();
                    cargarTickets();
                    cargarTicketsParaPagos();
                    cargarProductos();
                } else {
                    alert('Error: ' + result.message);
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Error al crear ticket');
            }
        }

        async function verDetalleTicket(id) {
            try {
                const response = await fetch(`${API_URL}/tickets/${id}`);
                const result = await response.json();
                const ticket = result.data;

                let detallesHtml = '';
                ticket.detalles.forEach(d => {
                    detallesHtml += `
                        <tr>
                            <td>${d.productoNombre}</td>
                            <td>${d.cantidad}</td>
                            <td>$${d.precioUnitario.toFixed(2)}</td>
                            <td>$${d.subtotal.toFixed(2)}</td>
                        </tr>
                    `;
                });

                let pagosHtml = '';
                ticket.pagos.forEach(p => {
                    pagosHtml += `
                        <tr>
                            <td>${p.folio}</td>
                            <td>${p.numeroPago}</td>
                            <td>$${p.monto.toFixed(2)}</td>
                            <td>${new Date(p.fechaPago).toLocaleString()}</td>
                        </tr>
                    `;
                });

                const fechaLiquidacionDetalle = ticket.fechaLiquidacion
                    ? `<strong>Fecha Liquidación:</strong> ${new Date(ticket.fechaLiquidacion).toLocaleString()}<br>`
                    : '';

                document.getElementById('contenidoDetalleTicket').innerHTML = `
                    <div class="row mb-3">
                        <div class="col-md-6">
                            <strong>Folio:</strong> ${ticket.folio}<br>
                            <strong>Cliente:</strong> ${ticket.cliente || 'N/A'}<br>
                            <strong>Fecha Creación:</strong> ${new Date(ticket.fechaCreacion).toLocaleString()}<br>
                            ${fechaLiquidacionDetalle}
                        </div>
                        <div class="col-md-6 text-end">
                            <h4>Total: $${ticket.montoTotal.toFixed(2)}</h4>
                            <p class="mb-0">Pagado: $${ticket.montoPagado.toFixed(2)}</p>
                            <p class="mb-0">Pendiente: $${ticket.montoPendiente.toFixed(2)}</p>
                            <span class="badge ${ticket.estatus === 'Pagado' ? 'badge-pagado' : 'badge-porpagar'}">${ticket.estatus}</span>
                        </div>
                    </div>
                    <h6>Productos:</h6>
                    <table class="table table-sm">
                        <thead><tr><th>Producto</th><th>Cant.</th><th>P. Unit.</th><th>Subtotal</th></tr></thead>
                        <tbody>${detallesHtml}</tbody>
                    </table>
                    <h6 class="mt-3">Historial de Pagos:</h6>
                    ${ticket.pagos.length > 0 ? `
                        <table class="table table-sm">
                            <thead><tr><th>Folio</th><th># Pago</th><th>Monto</th><th>Fecha</th></tr></thead>
                            <tbody>${pagosHtml}</tbody>
                        </table>
                    ` : '<p class="text-muted">No hay pagos registrados</p>'}
                `;

                new bootstrap.Modal(document.getElementById('modalDetalleTicket')).show();
            } catch (error) {
                console.error('Error:', error);
                alert('Error al cargar detalle');
            }
        }

        async function eliminarTicket(id) {
            if (!confirm('¿Está seguro de eliminar este ticket?')) return;

            try {
                const response = await fetch(`${API_URL}/tickets/${id}`, {
                    method: 'DELETE'
                });

                const result = await response.json();

                if (result.success) {
                    alert(result.message);
                    cargarTickets();
                } else {
                    alert('Error: ' + result.message);
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Error al eliminar ticket');
            }
        }

        async function cargarTicketsParaPagos() {
            try {
                const response = await fetch(`${API_URL}/tickets`);
                const result = await response.json();

                const ticketsPendientes = result.data.filter(t => t.estatus !== 'Pagado');

                const selectPago = document.getElementById('pagoTicketId');
                const selectFiltro = document.getElementById('filtroTicketPagos');

                selectPago.innerHTML = '<option value="">Seleccione un ticket...</option>';
                selectFiltro.innerHTML = '<option value="">Seleccione un ticket para ver su historial...</option>';

                ticketsPendientes.forEach(t => {
                    selectPago.innerHTML += `<option value="${t.ticketId}">${t.folio} - ${t.cliente} - Pendiente: $${t.montoPendiente.toFixed(2)}</option>`;
                });

                result.data.forEach(t => {
                    selectFiltro.innerHTML += `<option value="${t.ticketId}">${t.folio} - ${t.cliente}</option>`;
                });
            } catch (error) {
                console.error('Error:', error);
            }
        }

        async function cargarInfoTicket() {
            const ticketId = document.getElementById('pagoTicketId').value;
            if (!ticketId) {
                document.getElementById('infoTicket').style.display = 'none';
                return;
            }

            try {
                const response = await fetch(`${API_URL}/tickets/${ticketId}`);
                const result = await response.json();
                const ticket = result.data;

                document.getElementById('infoTotal').textContent = ticket.montoTotal.toFixed(2);
                document.getElementById('infoPagado').textContent = ticket.montoPagado.toFixed(2);
                document.getElementById('infoPendiente').textContent = ticket.montoPendiente.toFixed(2);
                document.getElementById('infoTicket').style.display = 'block';
            } catch (error) {
                console.error('Error:', error);
            }
        }

        async function registrarPago(e) {
            e.preventDefault();

            const pago = {
                ticketId: parseInt(document.getElementById('pagoTicketId').value),
                monto: parseFloat(document.getElementById('pagoMonto').value),
                observaciones: document.getElementById('pagoObservaciones').value
            };

            try {
                const response = await fetch(`${API_URL}/pagos`, {
                    method: 'POST',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(pago)
                });

                const result = await response.json();

                if (result.success) {
                    alert(result.message);
                    document.getElementById('formPago').reset();
                    document.getElementById('infoTicket').style.display = 'none';
                    cargarTickets();
                    cargarTicketsParaPagos();
                } else {
                    alert('Error: ' + result.message);
                }
            } catch (error) {
                console.error('Error:', error);
                alert('Error al registrar pago');
            }
        }

        async function cargarPagosPorTicket() {
            const ticketId = document.getElementById('filtroTicketPagos').value;
            if (!ticketId) {
                document.getElementById('historialPagos').innerHTML = '';
                return;
            }

            document.getElementById('loadingPagos').style.display = 'block';

            try {
                const response = await fetch(`${API_URL}/pagos/ticket/${ticketId}`);
                const result = await response.json();

                let html = `
                    <div class="alert alert-info">
                        <strong>Total:</strong> $${result.data.montoTotal.toFixed(2)}<br>
                        <strong>Pagado:</strong> $${result.data.montoPagado.toFixed(2)}<br>
                        <strong>Pendiente:</strong> $${result.data.montoPendiente.toFixed(2)}<br>
                        <strong>Estatus:</strong> <span class="badge ${result.data.estatus === 'Pagado' ? 'badge-pagado' : 'badge-porpagar'}">${result.data.estatus}</span>
                    </div>
                `;

                if (result.data.pagos.length > 0) {
                    html += '<table class="table table-striped"><thead><tr><th>Folio</th><th># Pago</th><th>Monto</th><th>Fecha</th><th>Observaciones</th></tr></thead><tbody>';
                    result.data.pagos.forEach(p => {
                        html += `
                            <tr>
                                <td>${p.folio}</td>
                                <td>${p.numeroPago}</td>
                                <td>$${p.monto.toFixed(2)}</td>
                                <td>${new Date(p.fechaPago).toLocaleString()}</td>
                                <td>${p.observaciones || '-'}</td>
                            </tr>
                        `;
                    });
                    html += '</tbody></table>';
                } else {
                    html += '<p class="text-muted">No hay pagos registrados</p>';
                }

                document.getElementById('historialPagos').innerHTML = html;
            } catch (error) {
                console.error('Error:', error);
                alert('Error al cargar historial de pagos');
            }

            document.getElementById('loadingPagos').style.display = 'none';
        }
    </script>
</body>
</html>