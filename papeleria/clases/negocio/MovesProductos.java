package negocio;
import java.util.Scanner;
import datos.ToolsProductos;

public class MovesProductos{
//variables
	Scanner leer= new Scanner(System.in);
	int ide, idm;
	String nom=null;
    float precio;
    ToolsProductos objP= new ToolsProductos();

    public void mostrar_productos(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tProductos\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objP.con_pro();
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
			objP.one_pro(nom);
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
			objP.nvo_pro(nom,precio);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//insertar

	public void actualizar_pro(){

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tModificar informacion del producto\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\t\tProductos\t\t\t\t\t\t|");
		objP.con_pro();
			//obtener el id
            System.out.print("\n\n\t\t\t\t\t\tNumero de producto: ");
			    idm= leer.nextInt();
				leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tNombre del producto:  ");
			    nom= leer.nextLine();
            System.out.print("\n\n\t\t\t\t\t\tPrecio: ");
			    precio= leer.nextFloat();
            
			objP.act_pro(idm, nom, precio);
	}//actualizar

	public void eliminar_pro(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tEliminar producto\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tProducto\t\t\t\t\t\t\t|");
			objP.con_pro();
			System.out.print("\n\n\t\t\t\t\t\tNumero de producto que desea eliminar:");
			ide = leer.nextInt();
			objP.eli_pro(ide);
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//eliminar


}//class