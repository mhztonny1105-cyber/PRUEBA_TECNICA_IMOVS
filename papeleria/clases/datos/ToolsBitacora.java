package datos;
import java.sql.*;


public class ToolsBitacora{
      String adv="\t\t\t\t\t\t\t   / \\\n"+
"\t\t\t\t\t\t\t  / | \\\n"+
"\t\t\t\t\t\t\t /__O__\\\n";

    public void con_fecha(String date){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("call sp_con_fecha_vianey('"+date+"')");
			if (!resul.isBeforeFirst()) {
			System.out.print("\n\t__________________________________________________________________________________________________________________________________________________\n");
			System.out.print("\n\t__________________________________________________________________________________________________________________________________________________\n");
            System.out.println(adv+"\t\t\t\tNo se encontro ningun registro con esta fecha.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t__________________________________________________________________________________________________________________________________________________\n");
				System.out.print("\t\t\t\t\t\t\tRegistros encontrados\n\n");
				System.out.print("\n\t___________________________________________________________________________________________________________________________________________________\n");
				System.out.print("\t|No. registro\t|Usuario\t\t| Actividad\t\t\t\t\t|Fecha\t\t|");
				System.out.print("\n\t___________________________________________________________________________________________________________________________________________________\n");
                while(resul.next()){
				System.out.println("\t|\t\t"+resul.getInt(1)+" | "+resul.getString(2)+"\t|"+resul.getString(3)+"  "+resul.getString(4));
				}//while
			}//else 
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel

	public void con_bit(){
		try{
			ConexionBD bd = new ConexionBD();//objeto clasee conexion
			Connection connU = bd.getConnectionU();	
			Statement consulta= connU.createStatement();
			consulta.executeUpdate("use vianey_pro");
			ResultSet resul=consulta.executeQuery("CALL sp_con_bitacora_vianey");
			if (!resul.isBeforeFirst()) {
            System.out.println("\n\n\t\t\t\t\t\t\t\tNo hay registros que mostrar.\n\n\n");
 			} else {
                // Itera a trav�s de los registros y muestra los datos
				System.out.print("\n\t__________________________________________________________________________________________________________________________________________________\n");
				System.out.print("\t|No. registro\t|Usuario\t\t| Actividad\t\t\t\t\t|Fecha\t\t|");
				System.out.print("\n\t___________________________________________________________________________________________________________________________________________________\n");
                while(resul.next()){
				System.out.println("\t|\t\t"+resul.getInt(1)+" | "+resul.getString(2)+"\t|"+resul.getString(3)+"  "+resul.getString(4));
				}//while
			}//else 
			connU.close();
		}catch(SQLException e){
			System.out.print("Error"+e.getMessage());
		}//catch
	}//sel
}//toolsclientes