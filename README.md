1. Clonar o abrir el proyecto

Abrir la solución PRUEBA_TECNICA_IMOVS.sln en Visual Studio.

2. Configurar la base de datos

Ejecutar en SQL Server:

CREATE DATABASE ImovsDb;


Dentro de la DB crear las tablas (si no existen):

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY,
    Nombre NVARCHAR(100) NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL
);

CREATE TABLE Tickets (
    Id INT PRIMARY KEY IDENTITY,
    Folio NVARCHAR(50),
    Descripcion NVARCHAR(255),
    Estatus NVARCHAR(20),
    FechaCreacion DATETIME NOT NULL,
    FechaLiquidacion DATETIME NULL,
    Pendiente DECIMAL(18,2) NOT NULL
);

CREATE TABLE TicketDetalles (
    Id INT PRIMARY KEY IDENTITY,
    TicketId INT NOT NULL,
    ProductoId INT NOT NULL,
    Cantidad INT NOT NULL,
    FOREIGN KEY (TicketId) REFERENCES Tickets(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Pagos (
    Id INT PRIMARY KEY IDENTITY,
    TicketId INT NOT NULL,
    NumeroPago INT NOT NULL,
    Folio NVARCHAR(50),
    FechaPago DATETIME NOT NULL,
    Monto DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (TicketId) REFERENCES Tickets(Id)
);

3. Configurar la cadena de conexión

En Web.config asegúrate de tener:

<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=ALANIS;Initial Catalog=ImovsDb;Integrated Security=True;MultipleActiveResultSets=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>


⚠️ Cambia ALANIS por el nombre de tu instancia de SQL Server.

4. Configurar WebApi

En Global.asax.cs:

GlobalConfiguration.Configure(WebApiConfig.Register);


En WebApiConfig.cs agrega para evitar ciclos JSON:

config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling =
    Newtonsoft.Json.ReferenceLoopHandling.Ignore;

▶️ Ejecución

Pulsa Ctrl + F5 en Visual Studio.

La API se levantará en:

http://localhost:8080/

📌 Endpoints principales
Productos

GET /api/productos

POST /api/productos

{ "Nombre": "Laptop", "PrecioUnitario": 25000 }

Tickets

POST /api/tickets

{
  "Folio": "T-001",
  "Descripcion": "Ticket de prueba",
  "Estatus": "Pendiente",
  "FechaCreacion": "2025-09-24T10:00:00",
  "Detalles": [
    { "ProductoId": 1, "Cantidad": 2 }
  ]
}


GET /api/tickets/1

Pagos

POST /api/pagos

{
  "TicketId": 1,
  "Monto": 5000
}


GET /api/pagos/ticket/1

⚠️ Nota sobre problemas al clonar

Al clonar y ejecutar por primera vez, aparecieron detalles con IIS Express y configuración de puertos.

Se corrigió ajustando:

El archivo applicationhost.config (sección <sites>) para usar puerto 8080.

El Web.config con la cadena de conexión correcta.

Asegurando que Global.asax invoque a WebApiConfig.Register.

Después de esos cambios, la API funcionó correctamente en Postman.
