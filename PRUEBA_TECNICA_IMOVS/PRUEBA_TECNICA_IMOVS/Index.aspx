<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PRUEBA_TECNICA_IMOVS.Index" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>API IMOVS - Demo</title>
  <style>
    body { font-family: Segoe UI, Arial; margin:24px; line-height:1.5; }
    .row { display:flex; gap:24px; flex-wrap:wrap; }
    .card { border:1px solid #ddd; border-radius:8px; padding:16px; width:420px; background:#fff; }
    .card h3 { margin-top:0; }
    input, textarea { width:100%; box-sizing:border-box; padding:8px; margin:6px 0 10px; }
    button { padding:8px 12px; cursor:pointer; }
    code { background:#f5f5f5; padding:2px 6px; border-radius:6px; }
    .small { color:#666; font-size:12px; }
    .ok { color:#0a7a2f; }
    .err { color:#b00020; }
    #out { white-space:pre-wrap; background:#0f172a; color:#e2e8f0; padding:12px; border-radius:8px; max-height:360px; overflow:auto; }
    a[target="_blank"] { text-decoration:none; }
  </style>
</head>
<body>
<form id="form1" runat="server">
  <h1>PRUEBA TÉCNICA — API REST (ASP.NET Web API 2)</h1>
  <p class="small">Base URL típica (IIS Express): <code>https://localhost:44349/</code></p>

  <!-- ENLACES RÁPIDOS (GET) -->
  <h2>Enlaces rápidos (GET)</h2>
  <div class="row">
    <div class="card">
      <h3>Smoke test</h3>
      <ul>
        <li><a runat="server" href="~/api/values" target="_blank">GET /api/values</a></li>
      </ul>
    </div>

    <div class="card">
      <h3>Products</h3>
      <ul>
        <li><a runat="server" href="~/api/products" target="_blank">GET /api/products</a></li>
        <li><a runat="server" href="~/api/products/1" target="_blank">GET /api/products/{id}</a></li>
      </ul>
      <p class="small">POST: <code>/api/products</code> — PUT/DELETE: <code>/api/products/{id}</code></p>
    </div>

    <div class="card">
      <h3>Customers</h3>
      <ul>
        <li><a runat="server" href="~/api/customers" target="_blank">GET /api/customers</a></li>
        <li><a runat="server" href="~/api/customers/1" target="_blank">GET /api/customers/{id}</a></li>
      </ul>
      <p class="small">POST: <code>/api/customers</code> — PUT/DELETE: <code>/api/customers/{id}</code></p>
    </div>

    <div class="card">
      <h3>Tickets</h3>
      <ul>
        <li><a runat="server" href="~/api/tickets" target="_blank">GET /api/tickets</a></li>
        <li><a runat="server" href="~/api/tickets/1" target="_blank">GET /api/tickets/{id}</a></li>
        <li><a runat="server" href="~/api/tickets/1/payments" target="_blank">GET /api/tickets/{id}/payments</a></li>
      </ul>
      <p class="small">POST: <code>/api/tickets</code> — PUT/DELETE: <code>/api/tickets/{id}</code><br/>
      Pagos: <code>POST /api/tickets/{id}/payments</code></p>
    </div>
  </div>

  <hr />

  <!-- PANEL CRUD RÁPIDO -->
  <h2>Probar CRUD rápido (fetch)</h2>
  <div class="row">
    <!-- PRODUCTS -->
    <div class="card">
      <h3>Products</h3>
      <label>GET by id</label>
      <input id="prodId" type="number" placeholder="id (e.g. 1)" />
      <button type="button" onclick="call('GET', `/api/products/${val('prodId')}`)">GET /api/products/{id}</button>
      <br />

      <label>POST body (JSON)</label>
      <textarea id="prodPost" rows="5">
{ "name": "Mouse", "sku": "MOU-001", "unitPrice": 250.0 }
      </textarea>
      <button type="button" onclick="call('POST', '/api/products', txt('prodPost'))">POST /api/products</button>
      <br />

      <label>PUT id + body (JSON)</label>
      <input id="prodPutId" type="number" placeholder="id a actualizar" />
      <textarea id="prodPut" rows="4">
{ "name": "Mouse Pro", "sku": "MOU-001", "unitPrice": 300.0 }
      </textarea>
      <button type="button" onclick="call('PUT', `/api/products/${val('prodPutId')}`, txt('prodPut'))">PUT /api/products/{id}</button>
      <br />

      <label>DELETE id</label>
      <input id="prodDelId" type="number" placeholder="id a eliminar" />
      <button type="button" onclick="call('DELETE', `/api/products/${val('prodDelId')}`)">DELETE /api/products/{id}</button>
    </div>

    <!-- CUSTOMERS -->
    <div class="card">
      <h3>Customers</h3>
      <label>GET by id</label>
      <input id="custId" type="number" placeholder="id (e.g. 1)" />
      <button type="button" onclick="call('GET', `/api/customers/${val('custId')}`)">GET /api/customers/{id}</button>
      <br />

      <label>POST body (JSON)</label>
      <textarea id="custPost" rows="5">
{ "name": "Juan Pérez", "email": "juan@example.com", "phone": "555-1234" }
      </textarea>
      <button type="button" onclick="call('POST', '/api/customers', txt('custPost'))">POST /api/customers</button>
      <br />

      <label>PUT id + body (JSON)</label>
      <input id="custPutId" type="number" placeholder="id a actualizar" />
      <textarea id="custPut" rows="4">
{ "name": "Juan Pérez", "email": "juan.p@example.com", "phone": "555-5678" }
      </textarea>
      <button type="button" onclick="call('PUT', `/api/customers/${val('custPutId')}`, txt('custPut'))">PUT /api/customers/{id}</button>
      <br />

      <label>DELETE id</label>
      <input id="custDelId" type="number" placeholder="id a eliminar" />
      <button type="button" onclick="call('DELETE', `/api/customers/${val('custDelId')}`)">DELETE /api/customers/{id}</button>
    </div>

    <!-- TICKETS + PAYMENTS -->
    <div class="card">
      <h3>Tickets</h3>
      <label>GET by id</label>
      <input id="tktId" type="number" placeholder="ticketId (e.g. 1)" />
      <button type="button" onclick="call('GET', `/api/tickets/${val('tktId')}`)">GET /api/tickets/{id}</button>
      <br />

      <label>POST Ticket (JSON)</label>
      <textarea id="tktPost" rows="7">
{
  "customerId": 1,
  "items": [
    { "productId": 1, "quantity": 2 },
    { "productId": 2, "quantity": 1 }
  ]
}
      </textarea>
      <button type="button" onclick="call('POST', '/api/tickets', txt('tktPost'))">POST /api/tickets</button>
      <br />

      <label>PUT Ticket (JSON)</label>
      <input id="tktPutId" type="number" placeholder="ticketId a actualizar" />
      <textarea id="tktPut" rows="5">
{ "customerId": 1 }
      </textarea>
      <button type="button" onclick="call('PUT', `/api/tickets/${val('tktPutId')}`, txt('tktPut'))">PUT /api/tickets/{id}</button>
      <br />

      <label>DELETE Ticket</label>
      <input id="tktDelId" type="number" placeholder="ticketId a eliminar" />
      <button type="button" onclick="call('DELETE', `/api/tickets/${val('tktDelId')}`)">DELETE /api/tickets/{id}</button>
      <hr />

      <h4>Payments</h4>
      <label>GET pagos por ticket</label>
      <input id="payTktId" type="number" placeholder="ticketId" />
      <button type="button" onclick="call('GET', `/api/tickets/${val('payTktId')}/payments`)">GET /api/tickets/{id}/payments</button>
      <br />

      <label>POST pago (JSON)</label>
      <input id="payTktId2" type="number" placeholder="ticketId" />
      <textarea id="payPost" rows="5">
{ "amount": 500.00, "note": "Abono 1" }
      </textarea>
      <button type="button" onclick="call('POST', `/api/tickets/${val('payTktId2')}/payments`, txt('payPost'))">POST /api/tickets/{id}/payments</button>
    </div>
  </div>

  <h2>Salida</h2>
  <div id="out">(esperando llamadas)</div>
</form>

<script>
  function $(id){ return document.getElementById(id); }
  function val(id){ return ($(id).value||'').trim(); }
  function txt(id){ return ($(id).value||'').trim(); }

  async function call(method, url, body){
    const opts = { method, headers: { 'Accept':'application/json' } };
    if (body) { opts.headers['Content-Type'] = 'application/json'; opts.body = body; }

    let base = window.location.origin; // e.g. https://localhost:44349
    // Si el url ya empieza con http, úsalo tal cual. Si no, combina base + url relativo:
    const finalUrl = /^https?:\/\//i.test(url) ? url : (base.replace(/\/+$/,'') + url);

    let t0 = performance.now();
    try {
      const res = await fetch(finalUrl, opts);
      const text = await res.text(); // no asumimos JSON siempre
      let pretty = text;
      try { pretty = JSON.stringify(JSON.parse(text), null, 2); } catch {}
      const ms = (performance.now()-t0).toFixed(0);
      $('out').textContent = `${method} ${finalUrl}\nstatus: ${res.status}\n(${ms} ms)\n\n${pretty}`;
    } catch (e){
      $('out').textContent = `ERROR: ${method} ${finalUrl}\n${e}`;
    }
  }
</script>
</body>
</html>
