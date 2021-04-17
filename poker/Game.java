package poker;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class Game {
	int qtdC2, qtdC3, qtdC4, qtdC5, qtdC6, qtdC7, qtdC8, qtdC9, qtdC10, qtdCJ, qtdCQ, qtdCK, qtdCA;
	Jogador player;
	Set<Carta> cartasUni = new HashSet<Carta>();
	List<Carta> cartasUnicas = new ArrayList<Carta>();
	String cartas = "", maiorCarta= "";
	int par = 0, trinca = 0, quadra = 0, maiorCard = 0, valueHand = 0;
	int parDesempate = 0, trincaDesempate = 0, quadraDesempate = 0;
	boolean royalFlush = false, straightFlush = false, fourKind = false, fullHouse = false,
			flush = false, straight = false, threeKind = false, twoPairs = false, pair = false;
	
	public Game(Jogador player) {
		super();
		this.player = player;
	}
	
	public String contagemCartas() {
		qtdC2 = qtdC3 = qtdC4 = qtdC5 = qtdC6 = qtdC7 = qtdC8 = qtdC9 = qtdC10 = qtdCJ = qtdCQ = qtdCK = qtdCA = 0;
		for (Carta card : player.hand) {
			if (card.getNumeroCarta() == 2)
				this.qtdC2++;
			else if (card.getNumeroCarta() == 3)
				this.qtdC3++;
			else if (card.getNumeroCarta() == 4)
				this.qtdC4++;
			else if (card.getNumeroCarta() == 5)
				this.qtdC5++;
			else if (card.getNumeroCarta() == 6)
				this.qtdC6++;
			else if (card.getNumeroCarta() == 7)
				this.qtdC7++;
			else if (card.getNumeroCarta() == 8)
				this.qtdC8++;
			else if (card.getNumeroCarta() == 9)
				this.qtdC9++;
			else if (card.getNumeroCarta() == 10)
				this.qtdC10++;
			else if (card.getNumeroCarta() == 11)
				this.qtdCJ++;
			else if (card.getNumeroCarta() == 12)
				this.qtdCQ++;
			else if (card.getNumeroCarta() == 13)
				this.qtdCK++;
			else if (card.getNumeroCarta() == 14)
				this.qtdCA++;
		}
		if (qtdC2 > 0) {
			if (qtdC2 == 2) {
				cartas += "Par de dois | ";
				par++;
				parDesempate = 2;
			}
			else if (qtdC2 == 3) {
				cartas += "Trinca de dois | ";
				trinca++;
				trincaDesempate = 2;
			}
			else if (qtdC2 == 4) {
				cartas += "Quadra de dois | ";
				quadra++;
				quadraDesempate = 2;
			}
			else {
				preencherCartasUnicas(2, player);
			}
		}
		if (qtdC3 > 0) {
			if (qtdC3 == 2) {
				cartas += "Par de três | ";
				par++;
				parDesempate = 3;
			}
			else if (qtdC3 == 3) {
				cartas += "Trinca de três | ";
				trinca++;
				trincaDesempate = 3;
			}
			else if (qtdC3 == 4) {
				cartas += "Quadra de três | ";
				quadra++;
				quadraDesempate = 3;
			}
			else {
				preencherCartasUnicas(3, player);
			}
		}
		if (qtdC4 > 0) {
			if (qtdC4 == 2) {
				cartas += "Par de quatro | ";
				par++;
				parDesempate = 4;
			}
			else if (qtdC4 == 3) {
				cartas += "Trinca de quatro | ";
				trinca++;
				trincaDesempate = 4;
			}
			else if (qtdC4 == 4) {
				cartas += "Quadra de quatro | ";
				quadra++;
				quadraDesempate = 4;
			}
			else {
				preencherCartasUnicas(4, player);
			}
		}
		if (qtdC5 > 0) {
			if (qtdC5 == 2) {
				cartas += "Par de cinco | ";
				par++;
				parDesempate = 5;
			}
			else if (qtdC5 == 3) {
				cartas += "Trinca de cinco | ";
				trinca++;
				trincaDesempate = 5;
			}
			if (qtdC5 == 4) {
				cartas += "Quadra de cinco | ";
				quadra++;
				quadraDesempate = 5;
			}
			else {
				preencherCartasUnicas(5, player);
			}
		}
		if (qtdC6 > 0) {
			if (qtdC6 == 2) {
				cartas += "Par de seis | ";
				par++;
				parDesempate = 6;
			}
			else if (qtdC6 == 3) {
				cartas += "Trinca de seis | ";
				trinca++;
				trincaDesempate = 6;
			}
			else if (qtdC6 == 4) {
				cartas += "Quadra de seis | ";
				quadra++;
				quadraDesempate = 6;
			}
			else {
				preencherCartasUnicas(6, player);
			}
		}
		if (qtdC7 > 0) {
			if (qtdC7 == 2) {
				cartas += "Par de sete | ";
				par++;
				parDesempate = 7;
			}
			else if (qtdC7 == 3) {
				cartas += "Trinca de sete | ";
				trinca++;
				trincaDesempate = 7;
			}
			else if (qtdC7 == 4) {
				cartas += "Quadra de sete | ";
				quadra++;
				quadraDesempate = 7;
			}
			else {
				preencherCartasUnicas(7, player);
			}
		}
		if (qtdC8 > 0) {
			if (qtdC8 == 2) {
				cartas += "Par de oito | ";
				par++;
				parDesempate = 8;
			}
			else if (qtdC8 == 3) {
				cartas += "Trinca de oito | ";
				trinca++;
				trincaDesempate = 8;
			}
			else if (qtdC8 == 4) {
				cartas += "Quadra de oito | ";
				quadra++;
				quadraDesempate = 8;
			}
			else {
				preencherCartasUnicas(8, player);
			}
		}
		if (qtdC9 > 0) {
			if (qtdC9 == 2) {
				cartas += "Par de nove | ";
				par++;
				parDesempate = 9;
			}
			else if (qtdC9 == 3) {
				cartas += "Trinca de nove | ";
				trinca++;
				trincaDesempate = 9;
			}
			else if (qtdC9 == 4) {
				cartas += "Quadra de nove | ";
				quadra++;
				quadraDesempate = 9;
			}
			else {
				preencherCartasUnicas(9, player);
			}
		}
		if (qtdC10 > 0) {
			if (qtdC10 == 2) {
				cartas += "Par de dez | ";
				par++;
				parDesempate = 10;
			}
			else if (qtdC10 == 3) {
				cartas += "Trinca de dez | ";
				trinca++;
				trincaDesempate = 10;
			}
			else if (qtdC10 == 4) {
				cartas += "Quadra de dez | ";
				quadra++;
				quadraDesempate = 10;
			}
			else {
				preencherCartasUnicas(10, player);
			}
		}
		if (qtdCJ > 0) {
			if (qtdCJ == 2) {
				cartas += "Par de valetes | ";
				par++;
				parDesempate = 11;
			}
			else if (qtdCJ == 3) {
				cartas += "Trinca de valetes | ";
				trinca++;
				trincaDesempate = 11;
			}
			else if (qtdCJ == 4) {
				cartas += "Quadra de valetes | ";
				quadra++;
				quadraDesempate = 11;
			}
			else {
				preencherCartasUnicas(11, player);
			}
		}
		if (qtdCQ > 0) {
			if (qtdCQ == 2) {
				cartas += "Par de damas";
				par++;
				parDesempate = 12;
			}
			else if (qtdCQ == 3) {
				cartas += "Trinca de damas | ";
				trinca++;
				trincaDesempate = 12;
			}
			else if (qtdCQ == 4) {
				cartas += "Quadra de damas | ";
				quadra++;
				quadraDesempate = 12;
			}
			else {
				preencherCartasUnicas(12, player);
			}
		}
		if (qtdCK > 0) {
			if (qtdCK == 2) {
				cartas += "Par de reis | ";
				par++;
				parDesempate = 13;
			}
			else if (qtdCK == 3) {
				cartas += "Trinca de reis | ";
				trinca++;
				trincaDesempate = 13;
			}
			else if (qtdCK == 4) {
				cartas += "Quadra de reis | ";
				quadra++;
				quadraDesempate = 13;
			}
			else {
				preencherCartasUnicas(13, player);
			}
		}
		if (qtdCA > 0) {
			if (qtdCA == 2) {
				cartas += "Par de ás | ";
				par++;
				parDesempate = 14;
			}
			else if (qtdCA == 3) {
				cartas += "Trinca de ás | ";
				trinca++;
				trincaDesempate = 14;
			}
			else if (qtdCA == 4) {
				cartas += "Quadra de ás | ";
				quadra++;
				quadraDesempate = 14;
			}
			else {
				preencherCartasUnicas(14, player);
			}
		}
		
		maiorCartaFunction();
		checkPairs();
		checkThreeKind();
		String lastNum = checkStraight();
		String[] n = checkFlush();
		checkFullHouse();
		checkFourKind();
		checkStraightFlush(n, lastNum);
		checkRoyalFlush(n);
		
		if(!pair && !twoPairs && !threeKind && !straight && !flush &&
		   !fullHouse && !fourKind && !straightFlush && !royalFlush) {
			this.valueHand = 1;
			cartas += "Maior carta: " + maiorCarta;
		}
		
		return cartas;
}
	
	public void maiorCartaFunction() {
		List<Carta> list = player.ordenarCartas();
		Carta c = (Carta) list.get(4);
		if(c.getNum().equals("J"))
			this.maiorCarta = "Valete";
		else if(c.getNum().equals("Q"))
			this.maiorCarta = "Dama";
		else if(c.getNum().equals("K"))
			this.maiorCarta = "Rei";
		else if(c.getNum().equals("A"))
			this.maiorCarta = "Ás";
		else
			this.maiorCarta = c.getNum();
		this.maiorCard = c.getNumeroCarta();
		}
	
	
	public void checkFourKind() {
		if(quadra == 1) {
			fourKind = true;
			cartas += "\nFour of a kind!";
			valueHand = 8;
		}
	}
	
	public void checkThreeKind() {
		if(trinca == 1) {
			threeKind = true;
			valueHand = 4;
		}
	}
	
	public void checkPairs() {
		if(par == 2) {
			twoPairs = true;
			cartas += "\nTwo Pairs!";
			valueHand = 3;
		}
		else if(par == 1) {
			pair = true;
			valueHand = 2;
		}
	}
	
	public void checkFullHouse() {
		if(pair && threeKind) {
			fullHouse = true;
			valueHand = 7;
			cartas += "\nFullHouse!";
		}
		if(threeKind && !pair)
			cartas += "\nThree of a kind!";
		if(pair && !threeKind)
			cartas += "\nPair!";
	}
	
	public String checkStraight() {
		List<Carta> list = player.ordenarCartas();
		int i;
		String n = "";
		for(i = 0; i < list.size();i++) {
			Carta c = (Carta) list.get(i);
			if(i < 4) {
				Carta c2 = (Carta) list.get(i + 1);
				if(c.getNumeroCarta() == c2.getNumeroCarta() - 1)
					continue;
				else
					break;
			}else if(i == 4)
				n = c.getNum();
		}
		if (i > 4) {
			straight = true;
			valueHand = 5;
			return n;
		}
		return n;
	}
	
	public String[] checkFlush() {
		List<Carta> list = player.ordenarCartas();
		int i;
		String[] naipeNum = new String[2];
		for(i = 0; i < list.size(); i++) {
			Carta c = (Carta) list.get(i);
			naipeNum[0] = c.getNaipe();
			
			if(i < 4) {
				Carta c2 = (Carta) list.get(i + 1);
				if(c.getNaipe().equals(c2.getNaipe()))
					continue;
				else
					break;
			}else if(i == 4) 
				naipeNum[1] = c.getNum();
			
		}
		if (i > 4) {
			flush = true;
			valueHand = 6;
			return naipeNum;
		}
		naipeNum[0] = naipeNum[1] = "";
		return naipeNum;
	}
	
	public void checkStraightFlush(String[] naipeNum, String lastNum) {
		if(straight && flush) {
			straightFlush = true;
			valueHand = 9;
			if(maiorCard != 14) {
				cartas += "\nStraight Flush de " + checkNaipe(naipeNum[0]) +", "
						+ "terminado em " + naipeNum[1] + "!";
			}
		}
		if(straight && !flush)
			cartas += "\nStraight terminado em " + lastNum + "!";
		if(!straight && flush) {
			cartas += "\nFlush de " + checkNaipe(naipeNum[0]) + "!";
		}
	}
	
	public String checkNaipe(String naipe) {
		String n = "";
		if(naipe.equals("D"))
			n = "Ouro";
		else if(naipe.equals("S"))
			n = "Espadas";
		else if(naipe.equals("H"))
			n = "Copas";
		else
			n = "Paus";
		return n;
	}
	
	public void checkRoyalFlush(String[] naipeNum) {
		List<Carta> list = player.ordenarCartas();
		Carta d = (Carta) list.get(0);
		if(d.numeroCarta != 10 || !straightFlush) {
			return;
		}
		int i;
		for(i = 0; i < list.size(); i++) {
			Carta c = (Carta) list.get(i);
			if(i < 4) {
				Carta c2 = (Carta) list.get(i + 1);
				if(c.getNumeroCarta() == c2.getNumeroCarta() - 1)
					continue;
				else
					break;
			}
		}
		if (i > 4) {
			royalFlush = true;
			valueHand = 10;
			cartas = "\nRoyal Flush de " + checkNaipe(naipeNum[0]) + "!";
		}
	}
	
	public static String checkWinner(Game g1, Game g2) {
		String vencedor = "";
		if(g1.getValueHand() > g2.getValueHand()) 
			vencedor = "Jogador 1";
		else if(g1.getValueHand() < g2.getValueHand())
			vencedor = "Jogador 2";
		else {
			if(g1.fourKind || g1.threeKind) {
				if(g1.quadraDesempate > g2.quadraDesempate || g1.trincaDesempate > g2.trincaDesempate)
					vencedor = "Jogador 1";
				else if(g1.quadraDesempate < g2.quadraDesempate || g1.trincaDesempate < g2.trincaDesempate)
					vencedor = "Jogador 2";
			}else if(g1.pair || g1.twoPairs) {
				if(g1.parDesempate > g2.parDesempate) 
					vencedor = "Jogador 1";
				else if(g2.parDesempate > g1.parDesempate)
					vencedor = "Jogador 2";
				else {
					if(lastIndex(g1.cartasUnicas).numeroCarta > lastIndex(g2.cartasUnicas).numeroCarta) 
						vencedor = "Jogador 1: carta maior!";
					else if(lastIndex(g1.cartasUnicas).numeroCarta < lastIndex(g2.cartasUnicas).numeroCarta)
						vencedor = "jogador 2: carta maior!";
					else
						vencedor = "EMPATE!";
				}
			}else if(g1.royalFlush) {
				vencedor = "EMPATE!";
			}else {
				if(g1.maiorCard > g2.maiorCard)
					vencedor = "Maior carta = " + g1.maiorCarta + "\nJogador 1 é o vencedor";
				else if(g1.maiorCard < g2.maiorCard)
					vencedor = "Maior carta = " + g2.maiorCarta + "\nJogador 2 é o vencedor";
				else
					vencedor = "\nEMPATE!";
			}
		}
		return vencedor;	
	}
	

	public int getValueHand() {
		return valueHand;
	}
	
	public void preencherCartasUnicas(int n, Jogador j) {
		for (Carta card : j.hand) {
    		if (card.getNumeroCarta() == n)
    			cartasUni.add(card);
		}
		cartasUnicas = ordenarCartas();
	}
	
	public List<Carta> ordenarCartas() {
		List<Carta> cartasOrdenadas = new ArrayList<Carta>(cartasUni);
		Collections.sort(cartasOrdenadas);
		return cartasOrdenadas;
	}
	
	
	public static Carta lastIndex(List<Carta> list) {
		Carta i = list.get(list.size() - 1);
		return i;
	}

}























