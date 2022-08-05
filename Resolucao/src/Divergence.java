public class Divergence {
  int lineNumber;
  String saleStatusMessage;

  public Divergence(int lineNumber, String saleStatusMessage) {
    this.lineNumber = lineNumber;
    this.saleStatusMessage = saleStatusMessage;
  }

  public int getLineNumber() {
    return lineNumber;
  }

  public void setLineNumber(int lineNumber) {
    this.lineNumber = lineNumber;
  }

  public String getSaleStatusMessage() {
    return saleStatusMessage;
  }

  public void setSaleStatusMessage(String saleStatusMessage) {
    this.saleStatusMessage = saleStatusMessage;
  }
}
