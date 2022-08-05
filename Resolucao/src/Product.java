public class Product {
  private int code;
  private int startingAmount;
  private int minimumQuantityCO;

  public Product(int code, int startingAmount, int minimumQuantityCO) {
    this.code = code;
    this.startingAmount = startingAmount;
    this.minimumQuantityCO = minimumQuantityCO;
  }

  public int getCode() {
    return code;
  }

  public void setCode(int code) {
    this.code = code;
  }

  public int getStartingAmount() {
    return startingAmount;
  }

  public void setStartingAmount(int startingAmount) {
    this.startingAmount = startingAmount;
  }

  public int getMinimumQuantityCO() {
    return minimumQuantityCO;
  }

  public void setMinimumQuantityCO(int minimumQuantityCO) {
    this.minimumQuantityCO = minimumQuantityCO;
  }
}
