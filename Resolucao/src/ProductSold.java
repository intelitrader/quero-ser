public class ProductSold {
  private Product product;
  private int amountSales;

  public ProductSold(Product product, int amoutSales) {
    this.product = product;
    this.amountSales = amoutSales;
  }

  public Product getProduct() {
    return product;
  }

  public void setProduct(Product product) {
    this.product = product;
  }

  public int getAmountSales() {
    return amountSales;
  }

  public void setAmountSales(int amountSales) {
    this.amountSales += amountSales;
  }
}
