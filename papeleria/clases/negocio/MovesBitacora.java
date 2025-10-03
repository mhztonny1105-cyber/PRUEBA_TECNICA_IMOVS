package negocio;
import java.util.Scanner;
import datos.ToolsBitacora;

public class MovesBitacora{
//variables
	Scanner leer= new Scanner(System.in);
	String a,m,d, date;
    ToolsBitacora objB= new ToolsBitacora();

    public void mostrar_bitacora(){
		System.out.print("\n\n\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t|\tSeccion de bitacora\t\t\t\t|");
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n");
		objB.con_bit();
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n\n");
		System.out.print("\n\n\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//select

	public void mostrar_fecha(){
		System.out.print("\n\n\t\t\t\t\t\t\t ______________________________________________\n\n\t\t\t\t\t\t\t|\tBitacoras\t\t\t\t|");
		System.out.print("\n\t___________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\t\t\tIntroduzaca la fecha que desea buscar");
		System.out.print("\n\t___________________________________________________________________________________________________________________________________________________\n");
		System.out.print("\n\n\t\t\t\t\t\tIngrese el ano en formato AAAA");
        System.out.print("\n\n\t\t\t\t\t\tAño:  ");
		a= leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tIngrese el mes en formato MM");
        System.out.print("\n\n\t\t\t\t\t\tMes:  ");
		m= leer.nextLine();
        System.out.print("\n\n\t\t\t\t\t\tIngrese el dia en formato DD");
        System.out.print("\n\n\t\t\t\t\t\tDia:  ");
		d= leer.nextLine();
        date=a+"-"+m+"-"+d;
			objB.con_fecha(date);
		System.out.print("\n\t_____________________________________________________________________________________________________________________________________\n\n");
		System.out.print("\n\n\t\tPresiona una tecla para continuar...");
		leer.nextLine();
	}//empleado
}//class