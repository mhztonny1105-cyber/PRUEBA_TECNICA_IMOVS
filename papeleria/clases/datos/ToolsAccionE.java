package datos;
import java.sql.*;


public class ToolsAccionE{

String adv="\t\t\t\t\t\t\t   / \\\n"+
"\t\t\t\t\t\t\t  / | \\\n"+
"\t\t\t\t\t\t\t /__O__\\\n";

    public void one_clien(String nom){

		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connT = bd.getConnectionT();	
			Statement consulta= connT.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("call sp_con_cliente_vianey('"+nom+"')");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo se encontro ningun cliente con este nombre.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
				System.out.print("\t\t\t\t\t|No. cliente\t|Nombre\t\t| Apellido Paterno\t|Apellido Materno\t |");
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
                
                while(resul.next()){
				System.out.println("\t\t\t\t\t|\t"+resul.getInt(1)+"\t|"+resul.getString(2)+"\t\t "+resul.getString(3)+"\t\t\t "+resul.getString(4));
				}//while
				System.out.print("\t\t\t\t\t__________________________________________________________________________________\n");
			}//else 
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void con_clien(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connT = bd.getConnectionT();	
			Statement consulta= connT.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("CALL sp_con_clientes_vianey");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo hay clientes que mostrar.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
				System.out.print("\t\t\t\t\t|No. cliente\t|Nombre\t\t| Apellido Paterno\t|Apellido Materno\t |");
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
                
                while(resul.next()){
				System.out.println("\t\t\t\t\t|\t"+resul.getInt(1)+"\t|"+resul.getString(2)+"\t\t "+resul.getString(3)+"\t\t\t "+resul.getString(4));
				}//while
				System.out.print("\t\t\t\t\t__________________________________________________________________________________\n");
			
			}//else 
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void nvo_clien(String nom, String apt, String amt){ 
			try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connT= bd.getConnectionT();
			Statement sentencia= connT.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_ins_clien_vianey('"+nom+"','"+apt+"','"+amt+"')");//ejecutar la sentencia
			if (filasAfectadas>0) {
            System.out.print("\n\n\t\t\t\t\t\t\t___________________________________________ ");
            System.out.println("\n\n\t\t\t\t\t\t\t|El cliente se agrego correctamente\t|\n");
			System.out.print("\t\t\t\t\t\t\t___________________________________________\n\n ");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo agregar el cliente\n\n\n");
        	}//fin
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//insertar

	public void act_clien(int ida, String nom, String apt, String amt){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connT= bd.getConnectionT();
			Statement sentencia= connT.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_mod_clien_vianey("+ida+",'"+nom+"','"+apt+"','"+amt+"')");
			if (filasAfectadas>0) {
            System.out.print("\n\n\t\t\t\t\t\t\t___________________________________________ ");
            System.out.println("\n\n\t\t\t\t\t\t\t|El cliente se modifico correctamente\t|\n");
			System.out.print("\t\t\t\t\t\t\t___________________________________________\n\n ");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudieron actualizar los datos del cliente\n\n\n");
        	}//fin
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
		
	}//actu
	
	public void eli_clien(int ide){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connT= bd.getConnectionT();
			Statement sentencia= connT.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas=sentencia.executeUpdate("CALL sp_eli_clien_vianey("+ide+")");
			if (filasAfectadas>0) {
            System.out.print("\n\n\t\t\t\t\t\t\t___________________________________________ ");
            System.out.println("\n\n\t\t\t\t\t\t\t|El cliente se elimino correctamente\t|\n");
			System.out.print("\t\t\t\t\t\t\t___________________________________________\n\n ");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo eliminar el cliente\n\n\n");
        	}//fin
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//del CLIENTE
    /*************************TOOLS VENTAS ******************* */

    public void one_ven(String nom){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connT = bd.getConnectionT();	
			Statement consulta= connT.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("call sp_con_producto_vianey('"+nom+"')");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo se encontro ningun producto con este nombre.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
                while(resul.next()){
				System.out.println("\t|\t\t\t\t\t\t\t"+resul.getInt(1)+" . "+resul.getString(2)+" "+resul.getString(3)+" "+resul.getString(4));
				}//while
			}//else 
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void con_ven(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connT = bd.getConnectionT();	
			Statement consulta= connT.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("CALL sp_con_ventas_vianey()");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo hay ventas que mostrar.\n\n\n");
 			} else {
                 // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t\t\t_____________________________________________________________________________________________________________________\n");
				System.out.print("\t\t\t|No. venta\t|Cliente\t|\tProducto\t|\t Empleado \t| Precio unitario | Cantidad | Total | Fecha");
				System.out.print("\n\t\t\t_____________________________________________________________________________________________________________________\n");
                while(resul.next()){
				System.out.println("\t\t|\t"+resul.getInt(1)+"\t|"+resul.getString(2)+"  \t\t "+resul.getString(3)+" \t "+resul.getString(4)+"\t\t\t "+resul.getString(5)+"\t\t "+resul.getString(6)+" \t"+resul.getString(7)+"\t"+resul.getString(8));
				}//while
				System.out.print("\t\t\t______________________________________________________________________________________________________________________\n");
				
			}//else 
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void nvo_ven(int clien, int pro, int emp, int cant
    ){ 
			try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connT= bd.getConnectionT();
			Statement sentencia= connT.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_ins_ven_vianey("+clien+","+pro+","+emp+","+cant+")");//ejecutar la sentencia
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tLa venta se agrego correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo agregar la venta\n\n\n");
        	}//fin
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//insertar

	public void act_ven(int ida, int clien, int pro, int emp, int cant){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connT= bd.getConnectionT();
			Statement sentencia= connT.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_mod_ven_vianey("+ida+","+clien+","+pro+","+emp+","+cant+")");
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tLos datos del producto se actualizaron correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudieron actualizar los datos del producto\n\n\n");
        	}//fin
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
		
	}//actu
	
	public void eli_ven(int ide){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connT= bd.getConnectionT();
			Statement sentencia= connT.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas=sentencia.executeUpdate("CALL sp_eli_ven_vianey("+ide+")");
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tLa venta se elimino correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo eliminar la venta\n\n\n");
        	}//fin
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//del
/*********************************TOOLS EMPLEADOS********************************** */
public void con_emp(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connT = bd.getConnectionT();	
			Statement consulta= connT.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("CALL sp_con_empleados_vianey");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo hay empleados que mostrar.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
				System.out.print("\t\t\t\t\t|No. empleado\t|Nombre\t\t| Apellido Paterno\t|Apellido Materno\t |");
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
                while(resul.next()){
				System.out.println("\t\t\t\t\t|\t"+resul.getInt(1)+"\t|"+resul.getString(2)+"\t\t "+resul.getString(3)+"\t\t\t "+resul.getString(4));
				}//while
				System.out.print("\t\t\t\t\t__________________________________________________________________________________\n");
			}//else 
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel
/*********************************TOOLS PRODUCTOS********************************** */
public void con_pro(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connT = bd.getConnectionT();	
			Statement consulta= connT.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("CALL sp_con_productos_vianey");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo hay productos que mostrar.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
				System.out.print("\t\t\t\t\t|No. producto\t|Producto\t\t| Precio\t\t\t\t|");
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
                while(resul.next()){
				System.out.println("\t\t\t\t\t|\t"+resul.getInt(1)+"\t|"+resul.getString(2)+"\t\t"+resul.getString(3));
				}//while
				System.out.print("\t\t\t\t\t__________________________________________________________________________________\n");
			}//else 
			connT.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel
}//tools