import java.util.ArrayList;

public class ProductsSold {
  private ArrayList<ProductSold> productsSold;

  public ProductsSold() {
    this.productsSold = new ArrayList<>();
  }

  public ArrayList<ProductSold> getProductsSold() {
    return this.productsSold;
  }

  public void addProductSold(ProductSold productSold) {
    int code = productSold.getCode();
  }
}
