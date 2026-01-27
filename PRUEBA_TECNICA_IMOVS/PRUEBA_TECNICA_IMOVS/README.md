# PRUEBA TÉCNICA IMOVS

API REST para manejo de productos, tickets y pagos, desarrollada con ASP.NET Web API y Entity Framework (Code First).  
El backend permite crear tickets de venta, registrar pagos parciales o totales y controlar el estado del ticket automáticamente.

---

## Tecnologías usadas

- ASP.NET Web API
- Entity Framework 6 (Code First)
- SQL Server
- Newtonsoft.Json
- Postman

---

## Modelos

### Product
Representa los productos disponibles para venta.

Campos principales:
- Id
- Sku
- Name
- Description
- Price
- IsActive
- CreatedAt

---

### Ticket
Representa un ticket de venta.

Campos principales:
- Id
- Folio
- TotalAmount
- PendingAmount
- Status
- CreatedAt
- PaidAt
- Details
- Payments

El ticket inicia con estado Pending y cambia según los pagos registrados.

---

### TicketDetail
Detalle de los productos dentro de un ticket.

Campos principales:
- Id
- TicketId
- ProductId
- Quantity
- UnitPrice
- Total
- CreatedAt

---

### Payment
Representa un pago aplicado a un ticket.

Campos principales:
- Id
- TicketId
- Folio
- PaymentNumber
- Amount
- PaymentDate

Cada pago guarda su número consecutivo y su propio folio.

---

## Funcionamiento del backend

1. Se crean productos activos.
2. Se crea un ticket con uno o más productos.
3. El total del ticket se calcula automáticamente.
4. El ticket inicia con PendingAmount igual al total.
5. Se registran pagos:
   - Si el pago es parcial, el ticket pasa a InProgress.
   - Si el pago liquida el total, el ticket pasa a Paid y se guarda la fecha de liquidación.
6. No se permiten pagos mayores al monto pendiente ni pagos a tickets ya pagados.
7. El historial de pagos se obtiene ordenado del más reciente al más antiguo.

---

## Endpoints

### Productos

Crear producto  
POST /api/products

```json
{
  "name": "PC Gamer",
  "price": 1800,
  "isActive": true
}

Obtener productos  
GET /api/products

Obtener producto por id  
GET /api/products/{id}

---

### Tickets

Crear ticket  
POST /api/tickets

```json
{
  "folio": "TCK-001",
  "details": [
    {
      "productId": 1,
      "quantity": 2
    }
  ]
}

Obtener ticket por id  
GET /api/tickets/{id}

Incluye los detalles del ticket y los pagos asociados.

---

### Pagos

Registrar pago  
POST /api/payments

```json
{
  "ticketId": 1,
  "amount": 1800
}

Obtener pagos por ticket  
GET /api/payments/ticket/{ticketId}

Los pagos se devuelven ordenados del más reciente al más antiguo.

---

## Base de datos

La base de datos se genera automáticamente usando Entity Framework Code First.  
Solo es necesario configurar la cadena de conexión en el archivo Web.config.

---

## Notas finales

- Cada ticket y cada pago tienen su propio folio.
- Se guarda la fecha de creación del ticket y la fecha de liquidación.
- El estado del ticket se actualiza automáticamente según los pagos.
- Se evita la serialización circular usando JsonIgnore.


