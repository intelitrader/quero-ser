import java.util.ArrayList;

public class RegisteredPoducts {
  private ArrayList<Product> products;

  public void addProduct(Product product) {
    this.products.add(product);
  }

  public ArrayList<Product> getProducts() {
    return this.products;
  }

  public boolean isRegisteredProduct(Product product) {
    for (Product value : this.products) {
      return value.getCode() == product.getCode();
    }
    return false;
  }
}
