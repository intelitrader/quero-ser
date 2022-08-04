public class ProductSold extends Product {
  private int amountSales;

  public ProductSold(int code, int startingAmount, int minimumQuantityCO, int amoutSales) {
    super(code, startingAmount, minimumQuantityCO);
    this.amountSales = amoutSales;
  }

  public int getAmountSales() {
    return amountSales;
  }

  public void setAmountSales(int amountSales) {
    this.amountSales += amountSales;
  }
}
