package datos;
import java.sql.*;


public class ToolsEmpleados{

    String adv="\t\t\t\t\t\t\t   / \\\n"+
"\t\t\t\t\t\t\t  / | \\\n"+
"\t\t\t\t\t\t\t /__O__\\\n";

    public void one_emp(String nom){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("call sp_con_empleado_vianey('"+nom+"')");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo se encontro ningun empleado con este nombre.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
				System.out.print("\t\t\t|No. empleado\t|Nombre\t\t| Apellido Paterno\t|Apellido Materno\t |");
				System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
                while(resul.next()){
				System.out.println("\t\t\t\t\t\t\t\t\t\t|\t"+resul.getInt(1)+"\t|"+resul.getString(2)+"\t\t "+resul.getString(3)+"\t\t\t "+resul.getString(4));
				}//while
				System.out.print("\t\t\t\t\t__________________________________________________________________________________\n");
			}//else 
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void con_emp(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
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
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void nvo_emp(String nom, String apt, String amt){ 
			try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_ins_emp_vianey('"+nom+"','"+apt+"','"+amt+"')");//ejecutar la sentencia
			if (filasAfectadas>0) {
			System.out.print("\n\n\t\t\t\t\t\t\t___________________________________________ ");
            System.out.println("\n\n\t\t\t\t\t\t\t|El empleado se agrego correctamente\t|\n");
			System.out.print("\t\t\t\t\t\t\t___________________________________________\n\n ");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo agregar el empleado\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//insertar

	public void act_emp(int ida, String nom, String apt, String amt){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas = sentencia.executeUpdate("CALL sp_mod_emp_vianey("+ida+",'"+nom+"','"+apt+"','"+amt+"')");
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tLos datos del empleado se actualizaron correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudieron actualizar los datos del empleado\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
		
	}//actu
	
	public void eli_emp(int ide){
		try{
			ConexionBD bd= new ConexionBD();//objeto de la clase conexion
			Connection connU= bd.getConnectionU();
			Statement sentencia= connU.createStatement();
			sentencia.executeUpdate("use vianey_pro");
			//comprobar
			int filasAfectadas=sentencia.executeUpdate("CALL sp_eli_emp_vianey("+ide+")");
			if (filasAfectadas>0) {
            System.out.println("\n\n\t\t\tEl empleado se elimino correctamente\n\n\n");
        	} else {
            System.out.println("\n\n"+adv+"\t\t\t\t\t\tNo se pudo eliminar el empleado\n\n\n");
        	}//fin
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+ e.getMessage());
		}//catch
	}//del

}//toolsclientes