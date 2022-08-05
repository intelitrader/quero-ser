import java.io.*;
import java.text.MessageFormat;
import java.util.ArrayList;
import java.util.Collections;

public class Starter {
  public static void main(String [] args) {
    File products = new File("./Inputs/PRODUCTS.txt");
    File sales = new File("./Inputs/SALES.txt");
    File output = new File("./Output");
    RegisteredProducts registeredProducts = new RegisteredProducts();
    ProductsSold productsSold = new ProductsSold();
    Divergences divergences = new Divergences();

    Starter starter = new Starter();
    starter.saveRegisteredProducts(products, registeredProducts);
    starter.saveProductsSold(sales, productsSold, registeredProducts, divergences);

    starter.generateTransferNeedReport(output, productsSold);
    starter.generateDivergencesReport(output, divergences);

  }

  public void generateDivergencesReport(File output, Divergences divergences) {
    try {
      ArrayList<Divergence> divergencesList = divergences.getDivergences();

      File file = new File(output, "divergencias.txt");
      file.createNewFile();

      FileWriter writer = new FileWriter(file);
      BufferedWriter buffWriter = new BufferedWriter(writer);

      for (Divergence divergence : divergencesList) {
        int lineNumber = divergence.getLineNumber();
        String saleStatusMessage = divergence.getSaleStatusMessage();
        String row = String.format("Linha %s - %s", lineNumber, saleStatusMessage);
        buffWriter.write(row);
        buffWriter.flush();
        buffWriter.newLine();
      }
    } catch (IOException e) {
      e.printStackTrace();
    }
  }
  public void generateTransferNeedReport(File output, ProductsSold productsSold) {
    try {
      ArrayList<ProductSold> productSoldList = productsSold.getProductsSold();
      Collections.sort(productSoldList, ((o1, o2) -> o1.getCode() - o2.getCode()));

      File file = new File(output, "transfere.txt");
      file.createNewFile();

      FileWriter writer = new FileWriter(file);
      BufferedWriter buffWriter = new BufferedWriter(writer);
      buffWriter.write("Necessidade de Transferência Armazém para CO");
      buffWriter.flush();
      buffWriter.newLine();
      buffWriter.write(" ");
      buffWriter.flush();
      buffWriter.newLine();
      buffWriter.write("Produto  QtCO  QtMin  QtVendas  Estq.após  Necess.  Transf. de");
      buffWriter.flush();
      buffWriter.newLine();
      buffWriter.write("                                   Vendas            Arm p/ CO");
      buffWriter.flush();
      buffWriter.newLine();

      for (ProductSold productSold : productSoldList) {
        TransferNeedManager transferNeedManagerInfos = new TransferNeedManager(productSold);
        int code = productSold.getCode();
        int startingAmount = productSold.getStartingAmount();
        int minimumQuantityCO = productSold.getMinimumQuantityCO();
        int amountSales = productSold.getAmountSales();
        int stockAfterSales = transferNeedManagerInfos.getStockAfterSales();
        int transferNeed = transferNeedManagerInfos.getTransferNeed();
        int transferStorage = transferNeedManagerInfos.getTransferStorage();

        StringBuilder row = new StringBuilder();
        row.append(code)
           .append("   ")
           .append(formatProductData(startingAmount, 5))
           .append("   ")
           .append(formatProductData(minimumQuantityCO, 4))
           .append("   ")
           .append(formatProductData(amountSales, 7))
           .append("   ")
           .append(formatProductData(stockAfterSales, 8))
           .append("   ")
           .append(formatProductData(transferNeed, 6))
           .append("   ")
           .append(formatProductData(transferStorage, 9));

        buffWriter.write(row.toString());
        buffWriter.flush();
        buffWriter.newLine();
      }
    } catch (IOException e) {
      e.printStackTrace();
    }
  }

  public void saveRegisteredProducts(File products, RegisteredProducts registeredProducts) {
    try {
      FileReader reader = new FileReader(products);
      BufferedReader buffReader = new BufferedReader(reader);

      String row = buffReader.readLine();

      registeredProducts.addProduct(createProductObject(row));

      while (row != null) {
        row = buffReader.readLine();
        if (row != null) {
          registeredProducts.addProduct(createProductObject(row));
        }
      }

    } catch (IOException e) {
      e.printStackTrace();
    }
  }

  public Product createProductObject(String row) {
    String [] productInfos = row.split(";");
    int code = Integer.parseInt(productInfos[0]);
    int startingAmount = Integer.parseInt(productInfos[1]);
    int minimumQuantityCO = Integer.parseInt(productInfos[2]);

    return new Product(code, startingAmount, minimumQuantityCO);
  }

  public void saveProductsSold(File sales, ProductsSold productsSold, RegisteredProducts registeredProducts, Divergences divergences) {
    try {
      FileReader reader = new FileReader(sales);
      BufferedReader buffReader = new BufferedReader(reader);

      int lineNumber = 0;

      String row = buffReader.readLine();
      lineNumber += 1;
      checkDivergences(row, lineNumber, registeredProducts, divergences);
      if (isProductRegistered(row, registeredProducts)) {
        productsSold.addProductSold(createProductSoldObject(row, registeredProducts));
      }

      while (row != null) {
        row = buffReader.readLine();
        lineNumber += 1;
        if (row != null) {
          checkDivergences(row, lineNumber, registeredProducts, divergences);
        }
        if (row != null && isProductRegistered(row, registeredProducts)) {;
          productsSold.addProductSold(createProductSoldObject(row, registeredProducts));
        }
      }

    } catch (IOException e) {
      e.printStackTrace();
    }
  }

  public ProductSold createProductSoldObject(String row, RegisteredProducts registeredProducts) {
    String [] productSoldInfos = row.split(";");
    int code = Integer.parseInt(productSoldInfos[0]);
    int amountSales = Integer.parseInt(productSoldInfos[1]);
    int statusSale = Integer.parseInt(productSoldInfos[2]);
    Product productObj = getProductByCode(code, registeredProducts);



    int startingAmount = productObj.getStartingAmount();
    int minimumQuantityCO = productObj.getMinimumQuantityCO();

    return new ProductSold(code, startingAmount, minimumQuantityCO, amountSales, statusSale);
  }

  public Product getProductByCode(int code, RegisteredProducts registeredProducts) {
    ArrayList<Product> products = registeredProducts.getProducts();
    for (Product product : products) {
      if (product.getCode() == code) {
        return product;
      }
    }
    return null;
  }

  public void checkDivergences(String row, int lineNumber, RegisteredProducts registeredProducts, Divergences divergences) {
    String [] productSoldInfos = row.split(";");
    int code = Integer.parseInt(productSoldInfos[0]);
    int saleStatus = Integer.parseInt(productSoldInfos[2]);
    String saleStatusMessage = "";
    Product product = getProductByCode(code, registeredProducts);

    if (saleStatus == 135) {
      saleStatusMessage = "Venda cancelada";
      Divergence divergenceObject = new Divergence(lineNumber, saleStatusMessage);
      divergences.addDivergence(divergenceObject);
      return;
    } else if (saleStatus == 190) {
      saleStatusMessage = "Venda não finalizada";
      Divergence divergenceObject = new Divergence(lineNumber, saleStatusMessage);
      divergences.addDivergence(divergenceObject);
      return;
    } else if (saleStatus == 999) {
      saleStatusMessage = "Erro desconhecido. Acionar equipe de TI";
      Divergence divergenceObject = new Divergence(lineNumber, saleStatusMessage);
      divergences.addDivergence(divergenceObject);
      return;
    }

    if (product == null) {
      saleStatusMessage = "Código de produto não encontrado " + code;
      Divergence divergenceObj = createDivergenceObject(productSoldInfos, lineNumber, saleStatusMessage);
      divergences.addDivergence(divergenceObj);
      return;
    }
  }

  public Divergence createDivergenceObject(String [] productSoldInfos, int lineNumber, String saleStatusMessage) {
    return new Divergence(lineNumber, saleStatusMessage);
  }

  public static boolean isProductRegistered(String row, RegisteredProducts registeredProducts) {
    String [] productInfos = row.split(";");
    int code = Integer.parseInt(productInfos[0]);

    for (Product product : registeredProducts.getProducts()) {
      if (product.getCode() == code) {
        return true;
      }
    }
    return false;
  }

  public String formatProductData(int data, int columnWidth) {
    if (String.valueOf(data).length() >= columnWidth) {
      return "" + data;
    } else {
      return String.format(MessageFormat.format("%{0}s", columnWidth), data);
    }
  }
}
