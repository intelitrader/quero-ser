package poker;

import java.util.ArrayList;
import java.util.Collections;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class Jogador {
	Set<Carta> hand = new HashSet<>();
	
	public Jogador() {
		
	}

	public Set<Carta> getHand() {
		return hand;
	}

	public void setHand(Set<Carta> hand) {
		this.hand = hand;
	}
	
	public void addCard(Carta card) {
		this.hand.add(card);
	}

	public List<Carta> ordenarCartas() {
		List<Carta> cartasOrdenadas = new ArrayList<Carta>(hand);
		Collections.sort(cartasOrdenadas);
		return cartasOrdenadas;
	}

}
