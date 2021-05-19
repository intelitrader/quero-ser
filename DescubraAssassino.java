import java.awt.List;
import java.util.ArrayList;
import java.util.Scanner;

public class DescubraAssassino {
	Scanner in = new Scanner(System.in);
	int resposta = 9;

	ArrayList<ItemLista> suspeitos = new ArrayList<ItemLista>();
	ArrayList<ItemLista> locais = new ArrayList<ItemLista>();
	ArrayList<ItemLista> armas = new ArrayList<ItemLista>();

	
	public void init() {
	
		//Adição de valores no array
		suspeitos.add(new ItemLista(1, "Charles B. Abbage"));
		suspeitos.add(new ItemLista(2, "Donald Duck Knuth"));
		suspeitos.add(new ItemLista(3, "Ada L. Ovelace"));
		suspeitos.add(new ItemLista(4, "Alan T. Uring"));
		suspeitos.add(new ItemLista(5, "Ivar J. Acobson"));
		suspeitos.add(new ItemLista(6, "Ras Mus Ler Dorf"));
		
		locais.add(new ItemLista(1, "Redmond"));
		locais.add(new ItemLista(2, "Palo Alto"));
		locais.add(new ItemLista(3, "San Francisco"));
		locais.add(new ItemLista(4, "Tokio"));
		locais.add(new ItemLista(5, "Restaurante no Fim do Universo"));
		locais.add(new ItemLista(6, "São Paulo"));
		locais.add(new ItemLista(7, "Cupertino"));
		locais.add(new ItemLista(8, "Helsinki"));
		locais.add(new ItemLista(9, "Maida Vale"));
		locais.add(new ItemLista(10, "Toronto"));
		
		armas.add(new ItemLista(1, "Peixeira"));
		armas.add(new ItemLista(2, "DynaTAC 8000X"));
		armas.add(new ItemLista(3, "Trezoitão"));
		armas.add(new ItemLista(4, "Trebuchet"));
		armas.add(new ItemLista(5, "Maçã"));
		armas.add(new ItemLista(6, "Gládio"));
		
			
		System.out.println(
				chute(
					(int) (Math.random() * suspeitos.size()) + 1,
					(int) (Math.random() * locais.size()) + 1,
					(int) (Math.random() * armas.size()) + 1
					)
				);
	}
	
	public String chute(int suspeito, int local, int arma) {
		
		System.out.println(suspeitos.get(suspeito - 1).numero + " , "  +
							armas.get(arma - 1).numero + ", " +
							locais.get(local - 1).numero);

		System.out.println("Está correto?");
		resposta = in.nextInt();
		
		if(resposta == 1) {
			suspeitos.remove(suspeito - 1);
			
			chute((int) (Math.random() * this.suspeitos.size()) + 1, 
				local, 
				arma);
			
		}else if(resposta == 2) {
			locais.remove(local - 1);
			
			chute(suspeito, 
					(int) (Math.random() * this.locais.size()) + 1, 
					arma);
			
			
		}else if(resposta == 3){
			this.armas.remove(arma - 1);
			chute(suspeito, 
					local, 
					(int) (Math.random() * this.armas.size()) + 1);
		
		}
		
		return "CASO SOLUCIONADO";
		
	}

	class ItemLista{
		
		int numero;
		String valor;
		
		public ItemLista(int num, String valor) {
			numero = num;
			this.valor = valor;
		}

	}
	
	public static void main(String[] args) {
		
		DescubraAssassino d = new DescubraAssassino();
		d.init();
	
	}
	
	
}
