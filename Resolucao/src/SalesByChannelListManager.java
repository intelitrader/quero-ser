import java.util.ArrayList;

public class SalesByChannelListManager {
  ArrayList<SalesByChannel> salesByChannels;

  public SalesByChannelListManager() {
    this.salesByChannels = new ArrayList<>();
  }

  public ArrayList<SalesByChannel> getSalesByChannels() {
    return salesByChannels;
  }

  public void addSalesByChanel(SalesByChannel salesByChannel) {
    for (SalesByChannel sale : this.salesByChannels) {
      if (sale.getChannelNumber() == salesByChannel.getChannelNumber()) {
        sale.setAmountSales(salesByChannel.getAmountSales());
        return;
      }
    }
    this.salesByChannels.add(salesByChannel);
  }
}
