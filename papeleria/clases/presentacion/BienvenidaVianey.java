package presentacion;
import java.util.Scanner;

public class BienvenidaVianey{
	
	public void bienV(){
		portadaV();
		System.out.print("\n\n\t____________________________________________________________________________________________________________________________________________________\n\t____________________________________________________________________________________________________________________________________________________");
		System.out.println("\n\t\t\t\t\t\t\t\tEntrar al sistema\n\t\t\t\t\t\t\t\t1-Si 2-No");
		Scanner leer= new Scanner(System.in);
		int opc;
		opc= leer.nextInt();
			switch (opc){
			case 1: 
				IniVianey ent = new IniVianey();
				ent.entrarV();
			break;
			case 2: 
				System.out.print("\n\t\t\tGracias por entrar...");
			break;
			default: System.out.print("\n\t\t\tOpcion no valida");
			}//switch
		
		
	}//bienvenida

	public void portadaV(){
		System.out.print("\n\n\t____________________________________________________________________________________________________________________________________________________\n\t____________________________________________________________________________________________________________________________________________________");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\t\t\tMontano Flores Fatima Vianey\n\n\t\t\t\t\t\t\t\t\t7IDSM1");
		System.out.print("\n\t____________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\t\t\tAcerca del sistema");
		System.out.print("\n\n\t\t\t\t\t\tLa presente aplicacion se realizo para el S.O Windows en lenguaje Java y con el SGBD MYSQL");
		System.out.print("\n\n\t\t\t\t\t\t\t\tCuenta con una arquitectura en Capas");
	}//portada

}//class