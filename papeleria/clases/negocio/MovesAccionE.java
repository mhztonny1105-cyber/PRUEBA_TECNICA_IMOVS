package negocio;
import java.util.Scanner;
import datos.*;

public class MovesAccionE{
        //variables
	Scanner leer= new Scanner(System.in);
	int ide, idm, pro, emp, clien, cant;
	String nom=null, apat=null, amat=null;
    ToolsAccionE objTAE= new ToolsAccionE();

    public void mostrar_clientes(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tClientes\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objTAE.con_clien();
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
			objTAE.one_clien(nom);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\n\t\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//cliente

	public void insertar_clien(){
		String empcomp="\t\t\t\t\t\t\t   ~~~~~~\t\t\t  ____________ \n"+
				   "\t\t\t\t\t\t\t  |      |\t\t\t||            || \n"+
				  "\t\t\t\t\t\t\t  |______|\t\t\t||   Datos    || \n"+
				   "\t\t\t\t\t\t\t ----------\t\t\t||____________|| \n"+
				    "\t\t\t\t\t\t\t|    $     |\t\t\t ____|____|_____ \n"+
					"\t\t\t\t\t\t\t|    $     |\t\t\t|_______________| \n"; 

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
			objTAE.nvo_clien(nom,apat,amat);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\tPresione una tecla para continuar...");
		leer.nextLine(); 
	}//insertar

	public void actualizar_clien(){

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tModificar informacion del clientes\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tClientes\t\t\t\t\t\t\t|");
		    objTAE.con_clien();
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
            
			objTAE.act_clien(idm, nom, apat, amat);
	}//actualizar

	public void eliminar_clien(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tEliminar clientes\t\t\t\t|");
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tClientes\t\t\t\t\t\t\t|");
			objTAE.con_clien();	
			System.out.print("\n\n\t\t\t\t\t\tNumero de cliente:");
			ide = leer.nextInt();
			objTAE.eli_clien(ide);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//eliminar
/*****************************Ventas */
    public void mostrar_ventas(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tVentas\t\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objTAE.con_ven();
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n\n");
		System.out.print("\n\n\t\t\t\t\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//select

	public void insertar_ven(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\t\tAgregar venta\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\t_______________________________________________ ");
		System.out.print("\n\n\t\t\t\t\t\t|\t\tDatos de la  venta\t\t|");
		System.out.print("\n\t\t\t\t\t\t_______________________________________________\n\n");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t\t\t\t\t\tClientes");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
		objTAE.con_clien();
        System.out.print("\n\n\t\t\t\t\t\tNumero del cliente:  ");
			clien= leer.nextInt();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t\t\t\t\t\tProductos");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
        objTAE.con_pro();
        System.out.print("\n\n\t\t\t\t\t\tNumero del producto:  ");
			pro= leer.nextInt();
        System.out.print("\n\n\t\t\t\t\t\tCantidad: ");
			cant= leer.nextInt();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t\t\t\t\t\tEmpleados");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
        objTAE.con_emp();
        System.out.print("\n\n\t\t\t\t\t\tNumero de empleado: ");
			emp= leer.nextInt();
			objTAE.nvo_ven(clien, pro, emp, cant);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//insertar

}//class
