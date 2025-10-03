package negocio;
import java.util.Scanner;
import datos.*;

public class MovesAccionG{
    //variables
	Scanner leer= new Scanner(System.in);
	int ide, idm, pro, emp, clien, cant;
	String nom=null, apat=null, amat=null, nom_pto=null;
    ToolsAccionG objTAG= new ToolsAccionG();
    float precio;

    public void mostrar_clientes(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tClientes\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objTAG.con_clien();
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
			objTAG.one_clien(nom);
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
			objTAG.nvo_clien(nom,apat,amat);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\tPresione una tecla para continuar...");
		leer.nextLine(); 
	}//insertar

	public void actualizar_clien(){

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tModificar informacion del clientes\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tClientes\t\t\t\t\t\t\t|");
		    objTAG.con_clien();
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
            
			objTAG.act_clien(idm, nom, apat, amat);
	}//actualizar

	public void eliminar_clien(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tEliminar clientes\t\t\t\t|");
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tClientes\t\t\t\t\t\t\t|");
			objTAG.con_clien();	
			System.out.print("\n\n\t\t\t\t\t\tNumero de cliente:");
			ide = leer.nextInt();
			objTAG.eli_clien(ide);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//eliminar
/*****************************Ventas */
    public void mostrar_ventas(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tVentas\t\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objTAG.con_ven();
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
		objTAG.con_clien();
        System.out.print("\n\n\t\t\t\t\t\tNumero del cliente:  ");
			clien= leer.nextInt();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t\t\t\t\t\tProductos");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
        objTAG.con_pro();
        System.out.print("\n\n\t\t\t\t\t\tNumero del producto:  ");
			pro= leer.nextInt();
        System.out.print("\n\n\t\t\t\t\t\tCantidad: ");
			cant= leer.nextInt();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t\t\t\t\t\tEmpleados");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
        objTAG.con_emp();
        System.out.print("\n\n\t\t\t\t\t\tNumero de empleado: ");
			emp= leer.nextInt();
			objTAG.nvo_ven(clien, pro, emp, cant);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//insertar
/***********************************************PRODUCTOS */
public void mostrar_productos(){
    System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tProductos\t\t\t|");
    System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
    objTAG.con_pro();
    System.out.print("\n\n\n\t____________________________________________________________________________________________________________________________________________________\n");
    System.out.print("\n\n\n\t\t\tPresiona una tecla para continuar...");
    leer.nextLine();
}//select

public void mostrar_producto(){
    System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\t\tBuscar producto\t\t\t|");
    System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
    System.out.print("\n\n\t\t\t\t\t\tNombre del producto que desea buscar:  ");
    nom= leer.nextLine();
    System.out.print("\n\t\t\t\t\t___________________________________________________________________\n");
    System.out.print("\t\t\t\t\t|\t\t\tResultados\t\t\t\t|");	
        objTAG.one_pro(nom);
    System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n\n");
    System.out.print("\t\t\t\t\tPresiona una tecla para continuar...");
    leer.nextLine();
}//empleado


public void insertar_pro(){
    System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\t\tAgregar producto\t\t|");
    System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
    //System.out.print(empcomp);
    System.out.print("\n\n\t\t\t\t\t\t_______________________________________________ ");
    System.out.print("\n\n\t\t\t\t\t\t|\t\tDatos del producto\t\t|");
    System.out.print("\n\t\t\t\t\t\t_______________________________________________ ");
    System.out.print("\n\n\t\t\t\t\t\tNombre del producto:  ");
        nom= leer.nextLine();
    System.out.print("\n\n\t\t\t\t\t\tPrecio: ");
        precio= leer.nextFloat();
        objTAG.nvo_pro(nom,precio);
    System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
    leer.nextLine(); 
}//insertar

public void actualizar_pro(){

    System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tModificar informacion del producto\t|");
    System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
    System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
    System.out.print("\t\t\t\t\t|\t\t\tProductos\t\t\t\t\t\t|");
    objTAG.con_pro();
        //obtener el id
        System.out.print("\n\n\t\t\t\t\t\tNumero de producto: ");
            idm= leer.nextInt();
            leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tNombre del producto:  ");
            nom= leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tPrecio: ");
            precio= leer.nextFloat();
        
        objTAG.act_pro(idm, nom, precio);
}//actualizar

public void eliminar_pro(){
    System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tEliminar producto\t|");
    System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
    System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
    System.out.print("\t\t\t\t\t|\t\tProducto\t\t\t\t\t\t\t|");
        objTAG.con_pro();
        System.out.print("\n\n\t\t\t\t\t\tNumero de producto que desea eliminar:");
        ide = leer.nextInt();
        objTAG.eli_pro(ide);
    System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
    leer.nextLine(); 
}//eliminar



}//class