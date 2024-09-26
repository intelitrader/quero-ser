public class ProductSold extends Product {
  private int amountSales;
  private int statusSale;

  public ProductSold(int code, int startingAmount, int minimumQuantityCO, int amoutSales, int statusSale) {
    super(code, startingAmount, minimumQuantityCO);
    this.amountSales = amoutSales;
    this.statusSale = statusSale;
  }

  public int getAmountSales() {
    return amountSales;
  }

  public void setAmountSales(int amountSales) {
    this.amountSales += amountSales;
  }

  public int getStatusSale() {
    return statusSale;
  }

  public void setStatusSale(int statusSale) {
    this.statusSale = statusSale;
  }
}
