public class TransferNeedManager {
  private int stockAfterSales;
  private int transferNeed;
  private int transferStorage;

  public TransferNeedManager(ProductSold productSold) {
    this.stockAfterSales = productSold.getProduct().getStartingAmount() - productSold.getAmountSales();
    if (this.stockAfterSales - productSold.getProduct().getMinimumQuantityCO() > 0) {
      this.transferNeed = 0;
    } else {
      this.transferNeed = productSold.getProduct().getMinimumQuantityCO() - this.stockAfterSales;
    }

    if (this.transferNeed > 1 && this.transferNeed < 10) {
      this.transferStorage = 10;
    } else {
      this.transferStorage = this.transferNeed;
    }
  }

  public int getStockAfterSales() {
    return stockAfterSales;
  }

  public void setStockAfterSales(int stockAfterSales) {
    this.stockAfterSales = stockAfterSales;
  }

  public int getTransferNeed() {
    return transferNeed;
  }

  public void setTransferNeed(int transferNeed) {
    this.transferNeed = transferNeed;
  }

  public int getTransferStorage() {
    return transferStorage;
  }

  public void setTransferStorage(int transferStorage) {
    this.transferStorage = transferStorage;
  }
}
