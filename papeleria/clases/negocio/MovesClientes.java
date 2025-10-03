package negocio;
import java.util.Scanner;
import datos.ToolsClientes;

public class MovesClientes{

    //variables
	Scanner leer= new Scanner(System.in);
	int ide, idm;
	String nom=null, apat=null, amat=null;
    ToolsClientes objC= new ToolsClientes();

    public void mostrar_clientes(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tClientes\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objC.con_clien();
		System.out.print("\n\n\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\n\t\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//select

	public void mostrar_cliente(){
		String clien="\t\t\t\t\t\t\t\t   ~~~~~~ \n"+
				   "\t\t\t\t\t\t\t\t  |      |\n"+
				  "\t\t\t\t\t\t\t\t  |______\n"+
				   "\t\t\t\t\t\t\t\t ----------\n"+
				    "\t\t\t\t\t\t\t\t|    $    |\n"+
					"\t\t\t\t\t\t\t\t|    $    |\n"; 

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tBuscar cliente\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print(clien);
		System.out.print("\n\n\t\t\t\t\t\tNombre del cliente que desea buscar:  ");
		nom= leer.nextLine();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\t\tResultados\t\t\t\t|");	
			objC.one_clien(nom);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\n\t\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//cliente

	public void insertar_clien(){
		String empcomp="\t\t\t\t\t\t\t   ~~~~~~\t\t\t  ____________ \n"+
				   "\t\t\t\t\t\t\t  |      |\t\t\t||            || \n"+
				  "\t\t\t\t\t\t\t  |______|\t\t\t||   Datos    || \n"+
				   "\t\t\t\t\t\t\t ----------\t\t\t||____________|| \n"+
				    "t\t\t\t\t\t\t|    $     |\t\t\t ____|____|_____ \n"+
					"t\t\t\t\t\t\t|    $     |\t\t\t|_______________| \n"; 

		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tRegistrar cliente\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print(empcomp);
		System.out.print("\n\n\t\t\t\t\t\t_______________________________________________ ");
		System.out.print("\n\n\t\t\t\t\t\t|\t\tDatos del cliente\t\t|");
		System.out.print("\n\t\t\t\t\t\t_______________________________________________ ");
		System.out.print("\n\n\t\t\t\t\t\tNombre del empleado:  ");
			nom= leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tApellido paterno: ");
			apat= leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tApellido materno: ");
			amat= leer.nextLine();
			objC.nvo_clien(nom,apat,amat);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\tPresione una tecla para continuar...");
		leer.nextLine(); 
	}//insertar

	public void actualizar_clien(){

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tModificar informacion del clientes\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tClientes\t\t\t\t\t\t\t|");
		    objC.con_clien();
			//obtener el id
            System.out.print("\n\n\t\t\t\t\t\tNumero de cliente: ");
			    idm= leer.nextInt();
				leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tNombre del cliente:  ");
			    nom= leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tApellido paterno: ");
			    apat= leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tApellido materno: ");
			    amat= leer.nextLine();
            
			objC.act_clien(idm, nom, apat, amat);
	}//actualizar

	public void eliminar_clien(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tEliminar clientes\t\t\t\t|");
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tClientes\t\t\t\t\t\t\t|");
			objC.con_clien();	
			System.out.print("\n\n\t\t\t\t\t\tNumero de cliente:");
			ide = leer.nextInt();
			objC.eli_clien(ide);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//eliminar

}//class