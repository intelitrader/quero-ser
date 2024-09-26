import java.util.ArrayList;

public class Divergences {
  ArrayList<Divergence> divergences;

  public Divergences() {
    this.divergences = new ArrayList<>();
  }

  public void addDivergence(Divergence divergence) {
    this.divergences.add(divergence);
  }

  public ArrayList<Divergence> getDivergences() {
    return divergences;
  }
}
