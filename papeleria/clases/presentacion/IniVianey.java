package presentacion;
import java.util.Scanner;

public class IniVianey{

/*********Elegir usuario */
	public void entrarV(){
		Scanner leer= new Scanner(System.in);
		int opc;
		//Imagenes//
		String pape="\t\t  ___   __\t\t\t\t\t        ||\t\t\t\t                         /  | \n"+
					"\t\t  |__| | _|\t\t\t\t\t     ( ( ) )\t\t\t\t  __________            /   |\n"+
					"\t\t  |  | | _|\t\t\t\t\t      // \\\\\t\t\t\t (|          |         / /| |\n"+
					"\t\t  |  | | _|\t\t\t\t\t   __//___\\\\__\t\t\t\t (|   Notas  |        / / | |\n"+
					"\t\t  |  | | _|\t\t\t\t\t    //     \\\\\t\t\t\t (|          |       / /  | |\n"+
					"\t\t  |__| | _|\t\t\t\t\t   //       \\\\\t\t\t\t (|__________|      / /___| |\n"+
					"\t\t   \\/  |__|\t\t\t\t\t   /         \\\t\t\t\t                   /________|\n";



		////////MENU
		System.out.print("\n\n\n\t_____________________________________________________________________________________________________________________________________\n\t_____________________________________________________________________________________________________________________________________");
		System.out.print("\n\n\t\t\t\t\t\t\tBienvenido a la papeleria MOFAVA");
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		System.out.print(pape);
		System.out.print("\n\n\t ______________________________\t\t\t ______________________________\t\t\t_______________________________");
		System.out.print("\n\t| 1.Entrar como administrador  |\t\t| 2.Entrar como gerente        |\t\t| 3.Entrar como empleado       |");
		System.out.print("\n\t|______________________________|\t\t|______________________________|\t\t|______________________________|\n\n\n\n\n\n\n\n\n\n\n\n");
		System.out.print("\n\n\n\n\n\t\t\t\tEliga una opcion..."); opc=leer.nextInt();
		switch(opc){
			case 1: inisesion(); break;
			case 2: MenuGerV mg= new MenuGerV(); mg.menuGer();   break;
			case 3: MenuEmpV me = new MenuEmpV(); me.menuEmp();  break;
			case 4: System.exit(0); break;
			default: System.out.print("\t\t\t\t\t\t\tOpcion no valida");
		}//switch
	}//entrar
/**********Iniciar sesion */
	public void inisesion(){
		String imagenAscii = "\t    _\n"+
							 "\t __|_|__\n"+
							 "\t|   |   |\t\t\t\t\t\tIniciar sesion\n"+
							 "\t|___0___|\n";

		Scanner leer= new Scanner(System.in);
		String usu, contra;
        System.out.print("\n\n\n\n\n\n");
		System.out.print("\n\n\n\t_____________________________________________________________________________________________________________________________________\n\t_____________________________________________________________________________________________________________________________________\n");
	    System.out.println(imagenAscii);
		System.out.print("\t_____________________________________________________________________________________________________________________________________\n");
		System.out.print("\n \t\t\t\t\t\t\t_______________________________________\n\t\t\t\t\t\t\t|\t\t\t\t\t|\n");
		System.out.print("\t\t\t\t\t\t\t|\tUsuario:");
		usu=leer.nextLine();
		System.out.print("\t\t\t\t\t\t\t|\tContrasena:");
		contra=leer.nextLine();
		System.out.print("\n\t\t\t\t\t\t\t|\t\t\t\t\t|\n \t\t\t\t\t\t\t_______________________________________\n");
		validar(usu, contra);
	}//inic
	/****validar usuario */
	public void validar(String usu, String contra){
		String adv="\t\t\t\t\t\t\t   / \\\n"+
"\t\t\t\t\t\t\t  / | \\\n"+
"\t\t\t\t\t\t\t /__O__\\\n";

		String u="vianey", con="123";
		if(usu.equals(u) && contra.equals(con)){
			MenuAdminV menuA = new MenuAdminV();
            menuA.menuAdmin();
		}
		else{
			System.out.print(adv+"\n\t\t\t\t\t\t\tAcceso denegado!!!");
		}//else
	}//validar


}//class