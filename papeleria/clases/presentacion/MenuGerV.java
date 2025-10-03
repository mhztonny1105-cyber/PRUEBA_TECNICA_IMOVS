package presentacion;
import java.util.Scanner;
import negocio.MovesAccionG;
//import negocio.MovesProductos;

public class MenuGerV{
    public void menuGer(){
		Scanner leer= new Scanner(System.in);
		int opc;
		
		do {
        System.out.print("\n\n\n\n\n\n");
		System.out.print("\n\n\n\t_____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\t_____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\t\t\tBienvenido Gerente\n");
		System.out.print("\n\n\n\t_____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\t\t\t\t\t ______________________________\t\t\t  _____________________________");
		System.out.print("\n\t\t\t\t\t| 1.Clientes                   |\t\t| 2.Ventas                    |");
		System.out.print("\n\t\t\t\t\t|______________________________|\t\t|_____________________________|\n");
        System.out.print("\n\t\t\t\t\t ______________________________\t\t\t  _____________________________");
		System.out.print("\n\t\t\t\t\t| 3.Productos                  |\t\t| 4.Salir                     |");
		System.out.print("\n\t\t\t\t\t|______________________________|\t\t|_____________________________|\n");
        
		opc=leer.nextInt();
		switch(opc){
			case 1: adminCli(); break;
			case 2: adminVen(); break;
            case 3: adminPro(); break;
			case 4: System.exit(0); break;
			default: System.out.print("Opcion no valida pruebe otra vez");
		}//switch
		} while(opc!=3);
	}//Menugerente

    /************************************CLIENTES************************* */
    public void adminCli(){
		Scanner leer= new Scanner(System.in);
		int opc;
		String clien="\t\t\t\t\t\t\t\t\t   ~~~~~~\t\t\t     ___\n"+
				   "\t\t\t\t\t\t\t\t  |      |\t\t\t ___|___|___  \n"+
				  "\t\t\t\t\t\t\t\t  |______|\t\t\t|           |\n"+
				   "\t\t\t\t\t\t\t\t ----------\t\t\t|    $$$    | \n"+
				    "\t\t\t\t\t\t\t\t|    $    |\t\t\t|           | \n"+
					"\t\t\t\t\t\t\t\t|    $    |\t\t\t|___________| \n"; 

          do{
			System.out.print("\n\n\t____________________________________________________________________________________________________________________________________________________\n\t____________________________________________________________________________________________________________________________________________________");
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
	
			MovesAccionG objMAE = new MovesAccionG();
			switch(opc){
				case 1:
					objMAE.mostrar_clientes();
					
				break;
				case 2:
					objMAE.insertar_clien();
					
				break;
				case 3:
					objMAE.actualizar_clien();
					
				break;
				case 4:
					objMAE.eliminar_clien();
					
				break;
				case 5:
					objMAE.mostrar_cliente();
				break;
				case 6:
					menuGer();
				break;
				default:
					System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

				}//switch
			}while(opc!=6);
	}//clientes
	/**********************************************	VENTAS	* */
    public void adminVen(){

		MovesAccionG objMAE = new MovesAccionG();
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
						"\t\t|   1. Ver ventas       |\t\t\t| 2. Agregar venta      |\t\t\t| 3. Regresar     |\n"+		
						"\t\t|_______________________|\t\t\t|_______________________|\t\t\t|_________________|\n\n");
				System.out.print("\n\t\t\tEliga una opcion: ");opc=leer.nextInt();
	
			
				switch(opc){
					case 1:
						objMAE.mostrar_ventas();
						
					break;
					case 2:
						objMAE.insertar_ven();
						
					break;
					case 3:
						menuGer();
					break;
					default:
						System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

					}//switch
				}while(opc!=3);
	}//ventas
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
	
MovesAccionG objMP = new MovesAccionG();
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
				menuGer();
			break;
			default:
				System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

			}//switch
		}while(opc!=6);
    }//productos

}//class