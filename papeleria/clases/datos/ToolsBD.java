package datos;
import java.sql.*;


public class ToolsBD{
    
    public void crearUD(){
	try{
            ConexionBD bd= new ConexionBD();
            Connection connU= bd.getConnectionU();
            Statement sql= connU.createStatement();
            sql.executeUpdate("CREATE USER 'gerente'@'%' IDENTIFIED BY '123'");
	        Statement sq= connU.createStatement();
	        sq.executeUpdate("GRANT insert, delete, update, select ON vianey_pro.clientes TO 'gerente'@'%';");
		    sq.executeUpdate("GRANT insert, delete, update, select ON vianey_pro.ventas TO 'gerente'@'%';");
		    sq.executeUpdate("GRANT insert, delete, update, select ON vianey_pro.productos TO 'gerente'@'%';");
		    sq.executeUpdate("GRANT select ON vianey_pro.empleados TO 'gerente'@'%';");
            sq.executeUpdate("GRANT EXECUTE, TRIGGER ON *.* TO 'gerente'@'%';");
            sq.executeUpdate("flush privileges");
            connU.close();
            System.out.print("\n\n\t\t\t\t\t\tUsuario empleado creado\n\n");
        }catch(SQLException e){
            System.out.print("\n\n\t\t\t\t\t\tError: "+e.getMessage());
        }//catch
    }//usuario dos
    public void crearUT(){
	try{
            ConexionBD bd= new ConexionBD();
            Connection connU= bd.getConnectionU();
            Statement sql= connU.createStatement();
            sql.executeUpdate("CREATE USER 'empleado'@'%' IDENTIFIED BY '123'");
	        Statement sq= connU.createStatement();
	        sq.executeUpdate("GRANT insert, delete, update, select ON vianey_pro.clientes TO 'empleado'@'%'");
		    sq.executeUpdate("GRANT insert, delete, update, select ON vianey_pro.ventas TO 'empleado'@'%'");
            sq.executeUpdate("GRANT select ON vianey_pro.empleados TO 'empleado'@'%'");
            sq.executeUpdate("GRANT select ON vianey_pro.productos TO 'empleado'@'%'");
            sq.executeUpdate("GRANT EXECUTE, TRIGGER ON *.* TO 'empleado'@'%'");
            sq.executeUpdate("flush privileges");
            connU.close();
            System.out.print("\n\n\t\t\t\t\t\tUsuario empleado creado\n\n");
        }catch(SQLException e){
            System.out.print("\n\n\t\t\t\t\t\tError: "+e.getMessage());
        }//catch
    }//usuario dos
    


    public void crearDB(){
        try{
        ConexionBD bd= new ConexionBD();
        Connection connU= bd.getConnectionU();
        Statement sql =connU.createStatement();
        sql.executeUpdate("CREATE DATABASE vianey_pro");
        connU.close();
        System.out.print("\n\n\t\t\t\t\t\tBase de datos creada\n\n");
        }catch(SQLException e){
            System.out.print("\n\n\t\t\t\t\t\tError: "+e.getMessage());
        }//catch
    }//crear base 

    public void crearTB(){
        try{
            ConexionBD bd= new ConexionBD();
            Connection connU= bd.getConnectionU();
            Statement sql= connU.createStatement();
            sql.executeUpdate("USE vianey_pro");
            sql.executeUpdate("create table clientes(id_cliente int AUTO_INCREMENT primary key, nom_cliente varchar(50), apt_pat_clien varchar(50), apt_mat_clien varchar(50));");
            sql.executeUpdate("create table empleados(id_empleado int AUTO_INCREMENT primary key, nom_empleado varchar(50), apt_pat_emp varchar(50), apt_mat_emp varchar(50));");
            sql.executeUpdate("create table productos(id_producto int AUTO_INCREMENT primary key, nom_pro varchar(50), precio float);");
            sql.executeUpdate("create table ventas(id_venta int AUTO_INCREMENT primary key, id_cliente int, id_producto int, id_empleado int, precio_u float, cantidad int, total float, fecha date);");
            sql.executeUpdate("CREATE TABLE bitacora (id INT AUTO_INCREMENT PRIMARY KEY,usuario VARCHAR(25), actividad VARCHAR(255), fecha_hora TIMESTAMP );");
           
            connU.close();
            System.out.print("\n\n\t\t\t\t\t\tTablas creadas\n\n");
        }catch(SQLException e){
            System.out.print("\n\n\t\t\t\t\t\tError: "+e.getMessage());
        }
    }//creare tables
    
    public void crearP(){
        try{ 
            ConexionBD bd= new ConexionBD();
            Connection connU= bd.getConnectionU();
            Statement sql= connU.createStatement();
            sql.executeUpdate("use vianey_pro");
            //Procedimientos del cliente
            sql.executeUpdate("CREATE PROCEDURE sp_ins_clien_vianey(nom varchar(50), aptp varchar(50), aptm varchar(50)) BEGIN insert into clientes values(null, nom, aptp, aptm); END");
            sql.executeUpdate("CREATE PROCEDURE sp_mod_clien_vianey(idu int, nom varchar(50), aptp varchar(50), aptm varchar(50)) BEGIN UPDATE clientes SET nom_cliente = nom, apt_pat_clien=aptp, apt_mat_clien=aptm  WHERE id_cliente =idu; END ");
            sql.executeUpdate("CREATE PROCEDURE sp_eli_clien_vianey(ide int) BEGIN DELETE FROM clientes WHERE id_cliente=ide; END");
            sql.executeUpdate("CREATE PROCEDURE sp_con_clientes_vianey() BEGIN SELECT*FROM clientes; END");
            sql.executeUpdate("CREATE PROCEDURE sp_con_cliente_vianey(nom varchar(50)) BEGIN SELECT*FROM clientes WHERE nom_cliente LIKE nom; END");
            //procedimientos empleado
            sql.executeUpdate("CREATE PROCEDURE sp_ins_emp_vianey(nom varchar(50), aptp varchar(50), aptm varchar(50)) BEGIN insert into empleados values(null, nom, aptp, aptm); END");
            sql.executeUpdate("CREATE PROCEDURE sp_mod_emp_vianey(idu int, nom varchar(50), aptp varchar(50), aptm varchar(50)) BEGIN UPDATE empleados SET nom_empleado = nom, apt_pat_emp=aptp, apt_mat_emp=aptm  WHERE id_empleado=idu; END ");
            sql.executeUpdate("CREATE PROCEDURE sp_eli_emp_vianey(ide int) BEGIN DELETE FROM empleados WHERE id_empleado=ide; END");
            sql.executeUpdate("CREATE PROCEDURE sp_con_empleados_vianey() BEGIN SELECT*FROM empleados; END");
            sql.executeUpdate("CREATE PROCEDURE sp_con_empleado_vianey(nom varchar(50)) BEGIN SELECT*FROM empleados WHERE nom_empleado LIKE nom; END");
            //procedimientos producto
            sql.executeUpdate("CREATE PROCEDURE sp_ins_pro_vianey(nom varchar(50), pre float) BEGIN insert into productos values(null, nom, pre); END");
            sql.executeUpdate("CREATE PROCEDURE sp_mod_pro_vianey(idu int, nom varchar(50), pre float) BEGIN UPDATE productos SET nom_pro = nom, precio=pre  WHERE id_producto =idu; END ");
            sql.executeUpdate("CREATE PROCEDURE sp_eli_pro_vianey(ide int) BEGIN DELETE FROM productos WHERE id_producto=ide; END");
            sql.executeUpdate("CREATE PROCEDURE sp_con_productos_vianey() BEGIN SELECT*FROM productos; END");
            sql.executeUpdate("CREATE PROCEDURE sp_con_producto_vianey(nom varchar(50)) BEGIN SELECT*FROM productos WHERE nom_pro LIKE nom; END");
            //procedimiento ventas
            sql.executeUpdate("CREATE PROCEDURE sp_ins_ven_vianey(id_clie int, id_pro int, id_emp int, cant int) BEGIN insert into ventas values(null, id_clie, id_pro, id_emp, null, cant, null); END");
            sql.executeUpdate("CREATE PROCEDURE sp_mod_ven_vianey(idu int, id_clie int, id_pro int, id_emp int, cant int) BEGIN UPDATE ventas SET id_cliente = id_clie, id_producto=id_pro, id_empleado=id_emp, cantidad= cant WHERE id_venta =idu; END ");
            sql.executeUpdate("CREATE PROCEDURE sp_eli_ven_vianey(ide int) BEGIN DELETE FROM ventas WHERE id_venta=ide; END ");
            sql.executeUpdate("CREATE PROCEDURE sp_con_ventas_vianey() BEGIN  Select id_venta,nom_cliente,nom_pro,nom_empleado,precio_u,cantidad,total,fecha from ventas join clientes on ventas.id_cliente=clientes.id_cliente join empleados on ventas.id_empleado=empleados.id_empleado join productos on ventas.id_producto=productos.id_producto; END");
	        //procedimientos bitacora
            sql.executeUpdate("CREATE PROCEDURE sp_con_bitacora_vianey() BEGIN SELECT*FROM bitacora; END");
            sql.executeUpdate("CREATE PROCEDURE sp_con_fecha_vianey(IN fecha_parametro DATE) BEGIN SELECT * FROM bitacora WHERE DATE(fecha_hora) = fecha_parametro; END");
            
            connU.close();
            System.out.print("\n\n\t\t\t\t\t\tProcedimientos almacenados creados\n\n");
        }catch(SQLException e){
            System.out.print("\n\n\t\t\t\t\t\tError: "+e.getMessage());
        }//catch
    }//crear procedimientos

    public void crearT(){
        try{ 
            ConexionBD bd= new ConexionBD();
            Connection connU= bd.getConnectionU();
            Statement sql= connU.createStatement();
            sql.executeUpdate("use vianey_pro");
            sql.executeUpdate("CREATE TRIGGER calcular_total_venta BEFORE INSERT ON ventas FOR EACH ROW BEGIN DECLARE producto_precio DECIMAL(10,2); SELECT precio INTO producto_precio FROM productos WHERE id_producto = NEW.id_producto; SET NEW.total = NEW.cantidad * producto_precio; SET NEW.precio_u = producto_precio; SET NEW.fecha = now();END;");
            sql.executeUpdate("CREATE TRIGGER insert_clien AFTER INSERT ON clientes FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Agregó al cliente: ', NEW.nom_cliente, ' ', NEW.apt_pat_clien, ' ', NEW.apt_mat_clien), NOW()); END;");
            sql.executeUpdate("CREATE TRIGGER update_clien AFTER UPDATE ON clientes FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Modificó los datos del cliente: ', OLD.nom_cliente, ' ', OLD.apt_pat_clien, ' ', OLD.apt_mat_clien,' a ',NEW.nom_cliente, ' ', NEW.apt_pat_clien, ' ', NEW.apt_mat_clien),NOW()); END;");
            sql.executeUpdate("CREATE TRIGGER delete_clien AFTER DELETE ON clientes FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Eliminó al cliente: ', OLD.id_cliente, '.', OLD.nom_cliente, ' ', OLD.apt_pat_clien, ' ', OLD.apt_mat_clien), NOW());END;");
            sql.executeUpdate("CREATE TRIGGER insert_emp AFTER INSERT ON empleados FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Agregó al empleado: ', NEW.nom_empleado, ' ', NEW.apt_pat_emp, ' ', NEW.apt_mat_emp), NOW()); END");
            sql.executeUpdate("CREATE TRIGGER update_emp AFTER UPDATE ON empleados FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Modificó los datos del empleado: ', OLD.nom_empleado, ' ', OLD.apt_pat_emp, ' ', OLD.apt_mat_emp,' a ', NEW.nom_empleado, ' ', NEW.apt_pat_emp, ' ', NEW.apt_mat_emp), NOW());END");
            sql.executeUpdate("CREATE TRIGGER delete_emp AFTER DELETE ON empleados FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Eliminó al empleado: ', OLD.id_empleado, ' . ', OLD.nom_empleado,' ', OLD.apt_pat_emp, ' ', OLD.apt_mat_emp), NOW()); END");
            sql.executeUpdate("CREATE TRIGGER insert_pro AFTER INSERT ON productos FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Agregó el producto: ', NEW.nom_pro, ' con el precio de: ', NEW.precio), NOW());END");
            sql.executeUpdate("CREATE TRIGGER update_pro AFTER UPDATE ON productos FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Modificó los datos del producto: ',OLD.nom_pro, ' ', OLD.precio, ' a ', NEW.nom_pro, ' ', NEW.precio),NOW()); END");
            sql.executeUpdate("CREATE TRIGGER delete_pro AFTER DELETE ON productos FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Eliminó el producto: ', OLD.id_producto, ' . ', OLD.nom_pro,), NOW());END");
            sql.executeUpdate("CREATE TRIGGER insert_ven AFTER INSERT ON ventas FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Agregó la venta con id: ', NEW.id_venta),NOW());END");
            sql.executeUpdate("CREATE TRIGGER update_ven AFTER UPDATE ON ventas FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Modificó los datos de la venta: ', id_venta),NOW());END");
            sql.executeUpdate("CREATE TRIGGER delete_ven AFTER DELETE ON ventas FOR EACH ROW BEGIN INSERT INTO bitacora (usuario, actividad, fecha_hora) VALUES (USER(), CONCAT('Eliminó la venta: ', OLD.id_venta), NOW());END");
            connU.close();
        }catch(SQLException e){
            System.out.print("Error en trigger : "+e.getMessage());
        }//catch
    }//crearT

}//class menu tools two