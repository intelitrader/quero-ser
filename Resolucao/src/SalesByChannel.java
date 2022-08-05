public class SalesByChannel {
  short channelNumber;
  int amountSales;

  public SalesByChannel(short channelNumber, int amountSales) {
    this.channelNumber = channelNumber;
    this.amountSales = amountSales;
  }

  public short getChannelNumber() {
    return channelNumber;
  }

  public void setChannelNumber(short channelNumber) {
    this.channelNumber = channelNumber;
  }

  public int getAmountSales() {
    return amountSales;
  }

  public void setAmountSales(int amountSales) {
    this.amountSales += amountSales;
  }
}
