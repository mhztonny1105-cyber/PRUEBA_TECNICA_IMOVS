package presentacion;
import java.util.Scanner;
import negocio.MovesAccionE;

public class MenuEmpV{
 
 public void menuEmp(){
		Scanner leer= new Scanner(System.in);
		int opc;
		
		do {
        System.out.print("\n\n\n\n\n\n");
		System.out.print("\n\n\n\t_____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\t_____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\t\t\tBienvenido Empleado\n");
		System.out.print("\n\n\n\t_____________________________________________________________________________________________________________________________________________________\n");
		
		System.out.print("\n\t\t\t ______________________________\t\t\t  _____________________________\t\t  _____________________________");
		System.out.print("\n\t\t\t| 1.Clientes                   |\t\t| 2.Ventas                    |\t\t| 3.Salir                     |");
		System.out.print("\n\t\t\t|______________________________|\t\t|_____________________________|\t\t|_____________________________|\n");
        
		opc=leer.nextInt();
		switch(opc){
			case 1: adminCli(); break;
			case 2: adminVen(); break;
            case 3: System.exit(0); break;
			default: System.out.print("Opcion no valida pruebe otra vez");
		}//switch
		} while(opc!=3);
	}//MenuAdmin
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
	
			MovesAccionE objMAE = new MovesAccionE();
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
					menuEmp();
				break;
				default:
					System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

				}//switch
			}while(opc!=6);
	}//clientes
	/**********************************************	VENTAS	* */
    public void adminVen(){

		MovesAccionE objMAE = new MovesAccionE();
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
						menuEmp();
					break;
					default:
						System.out.print("\n\t\t\t\t\t\t*****Opcion no valida...Por favor eliga otra\n");

					}//switch
				}while(opc!=3);
	}//ventas
    
}//class