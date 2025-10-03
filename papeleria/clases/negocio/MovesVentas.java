package negocio;
import java.util.Scanner;
import datos.*;

public class MovesVentas{
//variables
	Scanner leer= new Scanner(System.in);
	int ide, idm, pro, emp, clien, cant;
    ToolsVentas objV= new ToolsVentas(); 
    ToolsProductos objP= new ToolsProductos();
    ToolsClientes objC= new ToolsClientes();
    ToolsEmpleados objE= new ToolsEmpleados();

    public void mostrar_ventas(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\t\tVentas\t\t\t\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		objV.con_ven();
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
		objC.con_clien();
        System.out.print("\n\n\t\t\t\t\t\tNumero del cliente:  ");
			clien= leer.nextInt();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t\t\t\t\t\tProductos");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
        objP.con_pro();
        System.out.print("\n\n\t\t\t\t\t\tNumero del producto:  ");
			pro= leer.nextInt();
        System.out.print("\n\n\t\t\t\t\t\tCantidad: ");
			cant= leer.nextInt();
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t\t\t\t\t\tEmpleados");
		System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
        objE.con_emp();
        System.out.print("\n\n\t\t\t\t\t\tNumero de empleado: ");
			emp= leer.nextInt();
			objV.nvo_ven(clien, pro, emp, cant);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//insertar

	public void actualizar_ven(){

		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tModificar datos de la venta\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tVentas\t\t\t\t\t\t\t|");
		    objV.con_ven();
			//obtener el id
            System.out.print("\n\n\t\t\t\t\t\tNumero de la venta: ");
			    idm= leer.nextInt();
			System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
			System.out.print("\n\t\t\t\t\t\t\t\t\t\tClientes");
			System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
            objC.con_clien();
            System.out.print("\n\n\t\t\t\t\t\tNumero del cliente:  ");
                clien= leer.nextInt();
			System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
			System.out.print("\n\t\t\t\t\t\t\t\t\t\tProductos");
			System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
            objP.con_pro();
            System.out.print("\n\n\t\t\t\t\t\tNumero del producto:  ");
                pro= leer.nextInt();
            System.out.print("\n\n\t\t\t\t\t\tCantidad: ");
                cant= leer.nextInt();
			System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");
			System.out.print("\n\t\t\t\t\t\t\t\t\t\tEmpleados");
			System.out.print("\n\t\t\t\t\t__________________________________________________________________________________\n");				
		
            objE.con_emp();
            System.out.print("\n\n\t\t\t\t\t\tNumero de empleado: ");
                emp= leer.nextInt();
			objV.act_ven(idm,clien,pro,emp,cant);
	}//actualizar

	public void eliminar_ven(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tEliminar venta\t|");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t_________________________________________________________________________________\n");
		System.out.print("\t\t\t\t\t|\t\tVentaseeesse\t\t\t\t\t\t\t|");
			objV.con_ven();
			
			System.out.print("\n\n\t\t\t\t\t\tNumero de venta:");
			ide = leer.nextInt();
			objV.eli_ven(ide);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		leer.nextLine(); 
	}//eliminar

}//class