package poker;

import java.util.Objects;

public class Carta implements Comparable<Carta>{
	public String naipe;
	public String num;
	public Integer numeroCarta;
	
	
	public Carta(String naipe, String num, Integer numeroCarta) {
		this.num = num;
		this.naipe = naipe;
		this.numeroCarta = numeroCarta;
	}
	
	public Integer getNumeroCarta() {
		return numeroCarta;
	}
	
	@Override
    public int hashCode() {
        int hash = 5;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Carta other = (Carta) obj;
        if (!Objects.equals(this.naipe, other.naipe)) {
            return false;
        }
        if (!Objects.equals(this.num, other.num)) {
            return false;
        }
        if (!Objects.equals(this.numeroCarta, other.numeroCarta)) {
            return false;
        }
        return true;
    }
    
    public String getNaipe() {
		return naipe;
	}

	public String getNum() {
		return num;
	}
	
	

	@Override
    public String toString() {
    	// TODO Auto-generated method stub
    	return num + naipe + " ";
    }

	@Override
	public int compareTo(Carta o) {
		if (this.getNumeroCarta() < o.getNumeroCarta()) { 
			  return -1; 
			  } if (this.getNumeroCarta() < o.getNumeroCarta()) { 
			  return 1; 
			  } 
			  return 0; 
		}
	
}
