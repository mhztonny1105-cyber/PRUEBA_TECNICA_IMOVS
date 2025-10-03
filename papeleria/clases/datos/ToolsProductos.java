package datos;
import java.sql.*;


public class ToolsProductos{

String adv="\t\t\t\t\t\t\t   / \\\n"+
"\t\t\t\t\t\t\t  / | \\\n"+
"\t\t\t\t\t\t\t /__O__\\\n";

    public void one_pro(String nom){
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
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
				System.out.print("\t\t\t\t\t|No. producto\t|Producto\t\t| Precio\t\t\t\t|");
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
                while(resul.next()){
				System.out.println("\t\t\t\t\t|\t"+resul.getInt(1)+"\t|"+resul.getString(2)+"\t\t"+resul.getString(3));
				}//while
				System.out.print("\t\t\t\t\t__________________________________________________________________________________\n");
			}//else 
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void con_pro(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void nvo_pro(String nom, float precio){ 
			try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_ins_pro_vianey('"+nom+"',"+precio+")");//ejecutar la sentencia
			if (filasAfectadas>0) {
            System.out.print("\n\n\t\t\t\t\t\t\t___________________________________________ ");
            System.out.println("\n\n\t\t\t\t\t\t\t|El producto se agrego correctamente\t|\n");
			System.out.print("\t\t\t\t\t\t\t___________________________________________\n\n ");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo agregar el producto\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//insertar

	public void act_pro(int ida, String nom, float precio){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_mod_pro_vianey("+ida+",'"+nom+"',"+precio+")");
			if (filasAfectadas>0) {
            System.out.print("\n\n\t\t\t\t\t\t\t___________________________________________ ");
            System.out.println("\n\n\t\t\t\t\t\t\t|El producto se modifico correctamente\t|\n");
			System.out.print("\t\t\t\t\t\t\t___________________________________________\n\n ");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudieron actualizar los datos del producto\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
		
	}//actu
	
	public void eli_pro(int ide){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas=sentencia.executeUpdate("CALL sp_eli_pro_vianey("+ide+")");
			if (filasAfectadas>0) {
           System.out.print("\n\n\t\t\t\t\t\t\t___________________________________________ ");
            System.out.println("\n\n\t\t\t\t\t\t\t|El producto se elimino correctamente\t|\n");
			System.out.print("\t\t\t\t\t\t\t___________________________________________\n\n ");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo eliminar el producto\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//del
}//toolsclientes