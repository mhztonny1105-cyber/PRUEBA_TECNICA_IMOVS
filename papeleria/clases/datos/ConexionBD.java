package datos;
import java.sql.*;
public class ConexionBD{

private Connection connT=null;
private Connection connU=null;
private Connection connD=null;

	public ConexionBD(){
		String urlU="jdbc:mysql://192.168.1.143:3306/";
		String userU="vianey", passwordU="123";
		estConnection(urlU,userU,passwordU);
		//usuario2
		String urlD="jdbc:mysql://192.168.1.143:3306/";
		String userD="gerente", passwordD="123";
		estConnection(urlD,userD,passwordD);
		//usuario3
		String urlT="jdbc:mysql://192.168.1.143:3306/";
		String userT="empleado", passwordT="123";
		estConnection(urlT,userT,passwordT);

	}//conectar
	private void estConnection(String url, String user, String password){
		try{
			if (user.equals("vianey")) {
                connU = DriverManager.getConnection(url, user, password);
            } else if (user.equals("gerente")) {
                connD = DriverManager.getConnection(url, user, password);
            } else {
                connT = DriverManager.getConnection(url, user, password);
            }
		}catch(SQLException e){
			System.out.print("Error clase conexion: "+e.getMessage());
		}//catch
	}//estConnection
	
	//getConnection 
	public Connection getConnectionU(){
		return this.connU;
	}//Connnection
	public Connection getConnectionD(){
		return this.connD;
	}//Connnection
	public Connection getConnectionT() {
        return this.connT;
    }//Connnection
	//Desconectar
	public void desconectarBD(){
		try {
            if (connU != null) {
                connU.close();
            }
            if (connD != null) {
                connD.close();
            }
            if (connT != null) {
                connT.close();
            }
        } catch (SQLException e) {
            System.out.println("Error" + e.getMessage());
        }
	}//desconectar
}//class fin


