package datos;
import java.sql.*;


public class ToolsVentas{

String adv="\t\t\t\t\t\t\t   / \\\n"+
"\t\t\t\t\t\t\t  / | \\\n"+
"\t\t\t\t\t\t\t /__O__\\\n";

    public void one_ven(String nom){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void con_ven(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void nvo_ven(int clien, int pro, int emp, int cant
    ){ 
			try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_ins_ven_vianey("+clien+","+pro+","+emp+","+cant+")");//ejecutar la sentencia
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tLa venta se agrego correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo agregar la venta\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//insertar

	public void act_ven(int ida, int clien, int pro, int emp, int cant){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_mod_ven_vianey("+ida+","+clien+","+pro+","+emp+","+cant+")");
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tLos datos del producto se actualizaron correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudieron actualizar los datos del producto\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
		
	}//actu
	
	public void eli_ven(int ide){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas=sentencia.executeUpdate("CALL sp_eli_ven_vianey("+ide+")");
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tLa venta se elimino correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo eliminar la venta\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//del
}//toolsclientes