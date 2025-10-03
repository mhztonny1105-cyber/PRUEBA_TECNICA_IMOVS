package negocio;
import datos.ToolsBD;


public class MovesBD{

    ToolsBD obj= new ToolsBD();
	
	public void base(){
		//System.out.print("Crear base de datos");
		obj.crearDB();
	}//base

	public void tabla(){
		//System.out.print("Crear tablas");
		obj.crearTB();
	}//tabla

	public void usuario2(){
		//System.out.print("Crear usuario dos");
		obj.crearUD();
	}//crear usuario2

	public void usuario3(){
		//System.out.print("Crear usuario dos");
		obj.crearUT();
	}//crear usuario3

	public void procedimientos(){
		//System.out.print("Crear procedimientos");
		obj.crearP();
		//obj.crearT();
	}//pro

    public void triggers(){
        obj.crearT();
    }//triggers

}///class