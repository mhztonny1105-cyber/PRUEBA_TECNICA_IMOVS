package presentacion;
import negocio.*;
import java.util.Scanner;

public class MenuAdminV{

    public void menuAdmin(){
		Scanner leer= new Scanner(System.in);
		int opc;

		do {
        System.out.print("\n\n\n\n\n\n");
		System.out.print("\n\n\n\t_____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\t_____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\t\t\t\tBienvenida Vianey\n");
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________________________\n");
	    
		System.out.print("\n\t\t\t ______________________________\t\t\t  _____________________________\t\t  _____________________________");
		System.out.print("\n\t\t\t| 1.Administrar base de datos  |\t\t| 2.Gestionar empleados       |\t\t| 3.Gestionar productos       |  ");
		System.out.print("\n\t\t\t|______________________________|\t\t|_____________________________|\t\t|_____________________________|\n");
        System.out.print("\n\t\t\t ______________________________\t\t\t  _____________________________\t\t  _____________________________");
		System.out.print("\n\t\t\t| 4.Gestionar clientes         |\t\t| 5.Gestionar ventas          |\t\t| 6.Ver Bitacora              |  ");
		System.out.print("\n\t\t\t|______________________________|\t\t|_____________________________|\t\t|_____________________________|\n");
        System.out.print("\n\t\t\t\t\t\t\t\t\t ______________________________");
		System.out.print("\n\t\t\t\t\t\t\t\t\t| 7. Salir                     |");
		System.out.print("\n\t\t\t\t\t\t\t\t\t|______________________________|\n");
        
		System.out.print("\n\n\n\n\t\t\tEliga una opciion..."); opc=leer.nextInt();
		
		switch(opc){
			case 1:  adminBD(); break;
			case 2:  adminEmp(); break;
            case 3:  adminPro(); break;
            case 4:  adminCli(); break;
            case 5:  adminVen(); break;
			case 6:  adminBitacora(); break;
			case 7: System.exit(0); break;
			default: System.out.print("Opcion no valida pruebe otra vez");
		}//switch
		} while(opc!=7);
	}//MenuAdmin

    public void adminBD(){
	 	Scanner leer= new Scanner(System.in);
		int opc;
		
		MovesBD objBD = new MovesBD();
		
	    do{System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n\t_____________________________________________________________________________________________________________________________________");
		System.out.print("\n\n\t\t\t\t\t\t\tAdministrar base de datos\n");
	System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
	    
		System.out.print("\n\n\t\t________________________\t\t\t  __________________________\t\t\t ________________________\n"+
			"\t\t|1. Crear gerente       |\t\t\t| 2. Crear usuario empleado  |\t\t\t| 3. Crear base de datos |\n"+		
			"\t\t|_______________________|\t\t\t|____________________________|\t\t\t|________________________|\n\n" +
			"\t\t ____________________________\t\t\t  ________________________\t\t\t ________________________\n"+
			"\t\t|   4. Crear tablas          |\t\t\t| 5. Crear procedimientos |\t\t\t|  6. Crear triggers    |\n"+			
			"\t\t|____________________________|\t\t\t|_________________________|\t\t\t|_______________________|\n"+
			"\t\t\t\t\t  ________________________\t\t\t  ________________________\n"+
			"\t\t\t\t\t| 7. Regresar             |\t\t\t| 8. Crear Salir          |\n"+			
			"\t\t\t\t\t|_________________________|\t\t\t|_________________________|\n");
			
			System.out.print("\n\tEliga una opcion: ");
			opc=leer.nextInt();
		switch(opc){
			case 1:
				objBD.usuario2();
			break;
			case 2:
				objBD.usuario3();
			break;
			case 3:
				objBD.base();
			break;
			case 4:
				objBD.tabla();
			break;
			case 5:
				objBD.procedimientos();
				
			break;
			case 6:
				objBD.triggers();
			break;
			case 7:
				menuAdmin();
			break;
			case 8:
				System.out.print("\n\t\t\t\t\t Nos vemos!!!\n");
				System.exit(0);
			break; 
			default:
				System.out.print("\n*****Opcion no valida...Por favor eliga otra\n");

			}//switch
		}while(opc!=8);
		
	}//menuBD
/************bitacora */
    public void adminBitacora(){
        Scanner leer= new Scanner(System.in);
		int opc;

          do{System.out.print("\n\n\t______________________________________________________________________________________________________________________________________________________\n");
	System.out.print("\n\n\t\t\t\t\t\t\t\tBenvenido a la bitacora\n");
	System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
	System.out.print("\n\n\t\t________________________\t\t\t  ______________________\t\t\t __________________\n"+
"\t\t|   1. Ver bitacora     |\t\t\t| 2. Buscar por fecha   |\t\t\t| 3. Regresar       |\n"+		
"\t\t|_______________________|\t\t\t|_______________________|\t\t\t|___________________|\n\n");

			System.out.print("\n\n\n\n\n\t\t\tEliga una opcion: ");opc=leer.nextInt();
	
MovesBitacora objMB = new MovesBitacora();
		switch(opc){
			case 1:
				objMB.mostrar_bitacora();
			break;
			case 2:
				objMB.mostrar_fecha();
			break;
			case 3:
				menuAdmin();
			break;
			default:
				System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

			}//switch
		}while(opc!=6);
    }//menuBitacora


/*************clientes */
    public void adminCli(){
		Scanner leer= new Scanner(System.in);
		int opc;
		String clien="\t\t\t\t\t\t\t\t\t   ~~~~~~\t\t\t     ___\n"+
				   "\t\t\t\t\t\t\t\t  |      |\t\t\t ___|___|___  \n"+
				  "\t\t\t\t\t\t\t\t  |______|\t\t\t|           |\n"+
				   "\t\t\t\t\t\t\t\t ----------\t\t\t|    $$$    | \n"+
				    "\t\t\t\t\t\t\t\t|    $    |\t\t\t|           | \n"+
					"\t\t\t\t\t\t\t\t|    $    |\t\t\t|___________| \n"; 

          do{System.out.print("\n\n\t____________________________________________________________________________________________________________________________________________________\n\t____________________________________________________________________________________________________________________________________________________");
	System.out.print("\n\n\t\t\t\t\t\t\t\tBenvenido a la seccion de clientes\n");
	System.out.print("\n\n\t____________________________________________________________________________________________________________________________________________________\n\t____________________________________________________________________________________________________________________________________________________");
		System.out.print(clien);
	System.out.print("\n\n\t\t________________________\t\t\t  ___________________________\t\t\t ________________________\n"+
"\t\t|   1. Ver clientes     |\t\t\t| 2. Agregar un nuevo cliente|\t\t\t| 3. Modificar cliente   |\n"+		
"\t\t|_______________________|\t\t\t|____________________________|\t\t\t|________________________|\n\n" +

"\t\t ________________________\t\t\t  ___________________________\t\t\t ________________________\n"+
"\t\t|   4. Borrar cliente   |\t\t\t| 5. Buscar cliente          |\t\t\t| 6. Regresar            |\n"+			
"\t\t|_______________________|\t\t\t|____________________________|\t\t\t|________________________|\n\n\n\n\n\n\n");

			
			System.out.print("\n\t\t\tEliga una opcion: ");opc=leer.nextInt();
	
MovesClientes objMC = new MovesClientes();
		switch(opc){
			case 1:
				objMC.mostrar_clientes();
				
			break;
			case 2:
				objMC.insertar_clien();
				
			break;
			case 3:
				objMC.actualizar_clien();
				
			break;
			case 4:
				objMC.eliminar_clien();
				
			break;
			case 5:
				objMC.mostrar_cliente();
			break;
			case 6:
				menuAdmin();
			break;
			default:
				System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

			}//switch
		}while(opc!=6);
    }//clientes

	public void adminEmp(){
		Scanner leer= new Scanner(System.in);
		int opc;
		////Imagenes
		String emp= "\t\t\t\t\t   ~~~~~~                 \t\t\t\t ________________________\n"+
					"\t\t\t\t\t  |      |     __________\t\t\t\t|  _____                 | \n"+
					 "\t\t\t\t\t  |______|   (|          |\t\t\t\t| |     | ~~~~~~~~~~~~~~ | \n"+ 
                     "\t\t\t\t\t ----------  (|Empleados |\t\t\t\t| |_____| ~~~~~~~~~~~~~~ |\n"+
					 "\t\t\t\t\t|    \\/    | (|          |\t\t\t\t| ~~~~~~~ ~~~~~~~~~~~~~~ |\n"+
					 "\t\t\t\t\t|    ||    | (|__________|\t\t\t\t|________________________|\n\n\n";
		///

          do{
	System.out.print("\n\n\t____________________________________________________________________________________________________________________________________________________\n\t____________________________________________________________________________________________________________________________________________________");
	System.out.print("\n\n\t\t\t\t\t\t\t\tBenvenido a la seccion de empleados\n");
	System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
	System.out.print(emp);
	System.out.print("\n\n\t\t________________________\t\t\t  ____________________________\t\t\t ________________________\n"+
"\t\t|   1. Ver empleados    |\t\t\t| 2. Agregar un nuevo empleado|\t\t\t| 3. Modificar empleado  |\n"+		
"\t\t|_______________________|\t\t\t|_____________________________|\t\t\t|________________________|\n\n" +

"\t\t ________________________\t\t\t  ____________________________\t\t\t ________________________\n"+
"\t\t|   4. Borrar empleado  |\t\t\t| 5. Buscar empleado          |\t\t\t| 6. Regresar           |\n"+			
"\t\t|_______________________|\t\t\t|_____________________________|\t\t\t|_______________________|\n\n\n\n\n\n\n");

			
			System.out.print("\n\t\t\tEliga una opcion: ");opc=leer.nextInt();
	
        MovesEmpleados objME = new MovesEmpleados();

		switch(opc){
			case 1:
				objME.mostrar_empleados();
				
			break;
			case 2:
				objME.insertar_emp();
				
			break;
			case 3:
				objME.actualizar_emp();
				
			break;
			case 4:
				objME.eliminar_emp();
				
			break;
			case 5:
				objME.mostrar_empleado();
			break;
			case 6:
				menuAdmin();
			break;
			default:
				System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

			}//switch
		}while(opc!=6);
	}//empleados
/****************productos */
    public void adminPro(){

        Scanner leer= new Scanner(System.in);
		int opc;
		String img_pro="\t\t                   ___   __ \t\t\t\t                        /  | \t\t\t\t\n"+
					   "\t\t                   |__| | _|\t\t\t\t  __________           /   | \t\t\t\t\n"+
					   "\t\t                   |  | | _|\t\t\t\t(|          |         / /| | \t\t\t\t\n"+
					   "\t\t _________  ____   |  | | _|\t\t\t\t(|   Notas  |        / / | | \t\t\t\t _________  ____ \n"+
					   "\t\t/________/|\\____\\  |  | | _|\t\t\t\t(|          |       / /  | | \t\t\t\t/________/|\\____\\\n"+
 					   "\t\t |        |     |  |__| | _|\t\t\t\t(|__________|      / /___| | \t\t\t\t |        |     |\n"+
					   "\t\t |________|_____|  \\/  |__|\t\t\t\t                  /________| \t\t\t\t |________|_____|\n";

          do{
	System.out.print("\n\n\t_____________________________________________________________________________________________________________________________________\n\t_____________________________________________________________________________________________________________________________________");
	System.out.print("\n\n\t\t\t\t\t\t\t\tBenvenido a la seccion de productos\n");
	System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
	System.out.print(img_pro);
	System.out.print("\n\n\t\t________________________\t\t\t  ____________________________\t\t\t ________________________\n"+
"\t\t|   1. Ver producto     |\t\t\t| 2. Agregar un nuevo producto|\t\t\t| 3. Editar producto     |\n"+		
"\t\t|_______________________|\t\t\t|_____________________________|\t\t\t|________________________|\n\n" +

"\t\t ________________________\t\t\t  ____________________________\t\t\t ________________________\n"+
"\t\t|   4. Borrar producto   |\t\t\t| 5. Buscar producto         |\t\t\t| 6. Regresar           |\n"+			
"\t\t|________________________|\t\t\t|____________________________|\t\t\t|_______________________|\n\n\n\n\n\n\n");

			
			System.out.print("\n\t\t\tEliga una opcion: ");opc=leer.nextInt();
	
MovesProductos objMP = new MovesProductos();
		switch(opc){
			case 1:
				objMP.mostrar_productos();
				
			break;
			case 2:
				objMP.insertar_pro();
				
			break;
			case 3:
				objMP.actualizar_pro();
				
			break;
			case 4:
				objMP.eliminar_pro();
				
			break;
			case 5:
				objMP.mostrar_producto();
			break;
			case 6:
				menuAdmin();
			break;
			default:
				System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

			}//switch
		}while(opc!=6);
    }//producto
/************************************************************ventas */
    public void adminVen(){
        Scanner leer= new Scanner(System.in);
		int opc;
		String img_ven= "\t\t\t\t\t\t                _                                          ___\n"+
						"\t\t\t  _____________//                                      ___|___|___\n"+ 
						"\t\t\t \\____\\____\\__/   _________________                   |           |      _\n"+
						"\t\t\t  \\____\\___\\__/   ____________                        |    $$$    |    _|_|_\n"+
						"\t\t\t   \\____\\___\\__/   ______                             |           |   /  $ \\\n"+
						"\t\t\t  __( o )__( o )______________________________________|___________|_ /______\\\n";
          do{
	System.out.print("\n\n\t_____________________________________________________________________________________________________________________________________\n\t_____________________________________________________________________________________________________________________________________");
	System.out.print("\n\n\t\t\t\t\t\t\t\tBenvenido a la seccion de ventas\n");
	System.out.print("\n\n\t_____________________________________________________________________________________________________________________________________\n\t_____________________________________________________________________________________________________________________________________");
	System.out.print(img_ven);
	System.out.print("\n\n\t\t________________________\t\t\t  _______________________\t\t\t _________________\n"+
"\t\t|   1. Ver ventas       |\t\t\t| 2. Agregar venta      |\t\t\t| 3. Editar venta |\n"+		
"\t\t|_______________________|\t\t\t|_______________________|\t\t\t|_________________|\n\n" +

"\t\t ______________________\t\t\t\t ________________________\n"+
"\t\t|   4. Eliminar venta  |\t\t\t| 5. Regresar           |\n"+			
"\t\t|______________________|\t\t\t|_______________________|\n");

			
			System.out.print("\n\t\t\tEliga una opcion: ");opc=leer.nextInt();
	
MovesVentas objMV = new MovesVentas();
		switch(opc){
			case 1:
				objMV.mostrar_ventas();
				
			break;
			case 2:
				objMV.insertar_ven();
				
			break;
			case 3:
				objMV.actualizar_ven();
				
			break;
			case 4:
				objMV.eliminar_ven();
				
			break;
			case 5:
				menuAdmin();
			break;
			default:
				System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

			}//switch
		}while(opc!=5);
    }//Ventas

}//class