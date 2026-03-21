Prueba Tecnica: API de Gestión de Pagos (IMOVS)

Lenguaje: C#
Framework: .NET Framework 4.8
Tipo de Proyecto: ASP.NET Web API 2
ORM: Entity Framework 6
Base de Datos: SQL Server
IDE: Visual Studio 2022

Configuracion e Instalación

1. Clonacion y Rama

git clone https://github.com/mhztonny1105-cyber/PRUEBA_TECNICA_IMOVS.git
git checkout AldoAlejandroOlveraDomniguez

2. Base de Datos
Se hace uso de local bd. 
Para la ceracion de la base de datos, utiliza la consola del administrador de paquetes.

Update-Database
Nota: el string conection esta configurado en el Web.config bajo el nombre Context apuntando a (localdb)\MSSQLLocalDB.

3. Configuracion JSON
Se configuro el WebApiConfig.cs para ignorar referencias circulares.

Nota: Se incluye una colección de Postman (Prueba Tecnica IMOVS - Aldo Olvera.postman_collection.json) en el path ..\PRUEBA_TECNICA_IMOVS\PRUEBA_TECNICA_IMOVS
