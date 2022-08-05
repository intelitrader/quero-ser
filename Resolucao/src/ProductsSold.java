import java.util.ArrayList;
import java.util.Arrays;
import java.util.stream.IntStream;

public class ProductsSold {
  private ArrayList<ProductSold> productsSold;

  public ProductsSold() {
    this.productsSold = new ArrayList<>();
  }

  public ArrayList<ProductSold> getProductsSold() {
    return this.productsSold;
  }

  public void addProductSold(ProductSold productSold) {
    int [] unauthorizedStatus = { 135, 190, 999 };

    if (IntStream.of(unauthorizedStatus).anyMatch(x -> x == productSold.getStatusSale())) {
      return;
    }

    for (ProductSold product : this.getProductsSold()) {
      if (product.getCode() == productSold.getCode()) {
        product.setAmountSales(productSold.getAmountSales());
        return;
      }
    }
    this.productsSold.add(productSold);
  }
}
