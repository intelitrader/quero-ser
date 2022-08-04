import java.util.ArrayList;

public class ProductsSold {
  private ArrayList<ProductSold> productsSold;

  public void ProductSold(ProductSold productSold) {
    for (ProductSold value : this.productsSold) {
      if (value.getProduct().getCode() == productSold.getProduct().getCode()) {
        value.setAmountSales(productSold.getAmountSales());
      } else {
        this.productsSold.add(productSold);
      }
    }
  }

  public ArrayList<ProductSold> getProductsSold() {
    return this.productsSold;
  }
}
