<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="PRUEBA_TECNICA_IMOVS.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Prueba Técnica - Sistema de Cotizaciones</title>
    <style>
        body { 
            font-family: Arial, sans-serif; 
            margin: 0; 
            padding: 20px; 
            background-color: #f5f5f5;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
            background-color: white;
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h1 {
            color: #333;
            text-align: center;
            border-bottom: 3px solid #4CAF50;
            padding-bottom: 10px;
        }
        h3 {
            color: #666;
            text-align: center;
            margin-bottom: 30px;
        }
        .menu-section {
            background-color: #f9f9f9;
            padding: 20px;
            border-radius: 5px;
            margin: 20px 0;
            border-left: 4px solid #4CAF50;
        }
        .menu-title {
            color: #333;
            margin-top: 0;
        }
        .nav-link {
            display: block;
            padding: 12px 20px;
            margin: 10px 0;
            background-color: #4CAF50;
            color: white;
            text-decoration: none;
            border-radius: 5px;
            font-weight: bold;
            text-align: center;
            transition: background-color 0.3s;
        }
        .nav-link:hover {
            background-color: #45a049;
            text-decoration: none;
            color: white;
        }
        .nav-link-secondary {
            background-color: #2196F3;
        }
        .nav-link-secondary:hover {
            background-color: #1976D2;
        }
        .footer {
            text-align: center;
            margin-top: 30px;
            color: #666;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>PRUEBA TÉCNICA</h1>
            <h3>Sistema de Cotización de Compra de Productos</h3>
            
            <div class="menu-section">
                <h2 class="menu-title">Módulos del Sistema</h2>
                
                <a href="Views/GestionProductos.aspx" class="nav-link">
                    📦 Gestión de Productos
                </a>
                
                <a href="Views/Cotizaciones.aspx" class="nav-link nav-link-secondary">
                    📋 Realizar Cotización
                </a>
            </div>
            

            
            <div class="footer">
                <p>Sistema desarrollado para prueba técnica - <%= DateTime.Now.Year %></p>
            </div>
        </div>
    </form>
</body>
</html>