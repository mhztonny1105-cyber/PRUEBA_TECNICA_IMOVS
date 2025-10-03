package negocio;
import java.util.Scanner;
import datos.ToolsEmpleados;

public class MovesEmpleados{

//variables
	Scanner leer= new Scanner(System.in);
	int ide, idm;
	String nom=null, apat=null, amat=null;
    ToolsEmpleados objE= new ToolsEmpleados();

    public void mostrar_empleados(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tEmpleados\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objE.con_emp();
		System.out.print("\n\n\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\n\t\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//select

	public void mostrar_empleado(){
		String emp="\t\t\t\t\t\t\t\t   ~~~~~~ \n"+
				   "\t\t\t\t\t\t\t\t  |      |\n"+
				  "\t\t\t\t\t\t\t\t  |______\n"+
				   "\t\t\t\t\t\t\t\t ----------\n"+
				    "\t\t\t\t\t\t\t\t|    \\/    |\n"+
					"\t\t\t\t\t\t\t\t|    ||    |\n"; 

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tBuscar empleado\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print(emp);
		System.out.print("\n\n\t\t\t\t\t\tNombre del empleado que desea buscar:  ");
		nom= leer.nextLine();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\t\tResultados\t\t\t\t|");	
			objE.one_emp(nom);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\n\t\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//empleado

	public void insertar_emp(){
		String empcomp="\t\t\t\t\t\t   ~~~~~~\t\t\t  ____________ \n"+
				   "\t\t\t\t\t\t  |      |\t\t\t||            || \n"+
				  "\t\t\t\t\t\t  |______|\t\t\t||   Datos    || \n"+
				   "\t\t\t\t\t\t ----------\t\t\t||____________|| \n"+
				    "\t\t\t\t\t\t|    \\/    |\t\t\t ____|____|_____ \n"+
					"\t\t\t\t\t\t|    ||    |\t\t\t|_______________| \n"; 

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\t\tRegistrar empleado\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print(empcomp);
		System.out.print("\n\n\t\t\t\t\t\t_______________________________________________ ");
		System.out.print("\n\n\t\t\t\t\t\t|\t\tDatos del empleado\t\t|");
		System.out.print("\n\t\t\t\t\t\t_______________________________________________ ");
		System.out.print("\n\n\t\t\t\t\t\tNombre del empleado:  ");
			nom= leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tApellido paterno: ");
			apat= leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tApellido materno: ");
			amat= leer.nextLine();
			objE.nvo_emp(nom,apat,amat);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\tPresione una tecla para continuar...");
		leer.nextLine(); 
	}//insertar

	public void actualizar_emp(){

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tModificar informacion del empleado\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tEmpleados\t\t\t\t\t\t\t|");
				    objE.con_emp();
			//obtener el id
            System.out.print("\n\n\t\t\t\t\t\tNumero de empleado: ");
			    idm= leer.nextInt();
				leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tNombre del empleado:  ");
			    nom= leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tApellido paterno: ");
			    apat= leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tApellido materno: ");
			    amat= leer.nextLine();
            
			objE.act_emp(idm, nom, apat, amat);
	}//actualizar

	public void eliminar_emp(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tEliminar empleado\t\t\t\t|");
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tEmpleados\t\t\t\t\t\t\t|");
			objE.con_emp();
			System.out.print("\n\n\t\t\t\t\t\tNumero de empleado:");
			ide = leer.nextInt();
			objE.eli_emp(ide);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//eliminar

}//class