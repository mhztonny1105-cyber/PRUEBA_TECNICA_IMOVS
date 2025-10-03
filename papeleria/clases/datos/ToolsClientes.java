package datos;
import java.sql.*;


public class ToolsClientes{

    String adv="\t\t\t\t\t\t\t   / \\\n"+
"\t\t\t\t\t\t\t  / | \\\n"+
"\t\t\t\t\t\t\t /__O__\\\n";

    public void one_clien(String nom){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void con_clien(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void nvo_clien(String nom, String apt, String amt){ 
			try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//insertar

	public void act_clien(int ida, String nom, String apt, String amt){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
		
	}//actu
	
	public void eli_clien(int ide){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//del

}//toolsclientes