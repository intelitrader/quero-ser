import fs from "node:fs";

class Products {
  productCode;
  quantitie;
  QtMin;
  QtSales;
  need;
  transfer;

  constructor(p_productCode, p_quantitie, p_QtMin) {
    this.productCode = p_productCode;
    this.quantitie = p_quantitie;
    this.QtMin = p_QtMin;
    this.QtSales = 0;
    this.need = 0;
    this.transfer = 0;
  }
}

class Sales {
  productCode;
  QtSales;
  sellSituation;
  channel;

  constructor(s_productCode, s_QtSales, s_sellSituation, s_channel) {
    this.productCode = s_productCode;
    this.QtSales = s_QtSales;
    this.sellSituation = s_sellSituation;
    this.channel = s_channel;
  }
}


