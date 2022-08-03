import java.util.ArrayList;

public class RegisteredPoducts {
  private ArrayList<Product> products;

  public void addProduct(Product product) {
    this.products.add(product);
  }

  public boolean isRegisteredProduct(Product product) {
    for (int i = 0; i < this.products.size(); i += 1) {
        return this.products.get(i).getCode() == product.getCode();
    }
    return false;
  }
}
