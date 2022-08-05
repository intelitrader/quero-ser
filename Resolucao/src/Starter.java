import java.io.*;
import java.util.ArrayList;
import java.util.Collections;

public class Starter {
  public static void main(String [] args) {
    File products = new File("./Inputs/PRODUCTS.txt");
    File sales = new File("./Inputs/SALES.txt");
    File output = new File("./Output");
    RegisteredProducts registeredProducts = new RegisteredProducts();
    ProductsSold productsSold = new ProductsSold();

    Starter starter = new Starter();
    starter.saveRegisteredProducts(products, registeredProducts);
    starter.saveProductsSold(sales, productsSold, registeredProducts);

    starter.generateTransferNeedReport(output, productsSold);
  }

  public void generateTransferNeedReport(File output, ProductsSold productsSold) {
    try {
      ArrayList<ProductSold> productSoldList = productsSold.getProductsSold();
      Collections.sort(productSoldList, ((o1, o2) -> o1.getCode() - o2.getCode()));

      File file = new File(output, "transfere.txt");
      file.createNewFile();

      FileWriter writer = new FileWriter(file);
      BufferedWriter buffWriter = new BufferedWriter(writer);

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
           .append("    ")
           .append(formatProductData(startingAmount))
           .append("    ")
           .append(formatProductData(minimumQuantityCO))
           .append("    ")
           .append(formatProductData(amountSales))
           .append("    ")
           .append(formatProductData(stockAfterSales))
           .append("    ")
           .append(formatProductData(transferNeed))
           .append("    ")
           .append(formatProductData(transferStorage));

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

  public void saveProductsSold(File sales, ProductsSold productsSold, RegisteredProducts registeredProducts) {
    try {
      FileReader reader = new FileReader(sales);
      BufferedReader buffReader = new BufferedReader(reader);

      String row = buffReader.readLine();
      productsSold.addProductSold(createProductSoldObject(row, registeredProducts));

      while (row != null) {
        row = buffReader.readLine();
        if (row != null && isProductRegistered(row, registeredProducts)) {;
          checkDivergences(row, registeredProducts, buffReader);
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

  public boolean checkDivergences(String row, RegisteredProducts registeredProducts, BufferedReader buffReader) {
    String [] productSoldInfos = row.split(";");
    int code = Integer.parseInt(productSoldInfos[0]);
      for (Product product : registeredProducts.getProducts()) {
        if (product.getCode() != code) {
          return false;
        }
      }
    return true;
  }

  public boolean isProductRegistered(String row, RegisteredProducts registeredProducts) {
    String [] productInfos = row.split(";");
    int code = Integer.parseInt(productInfos[0]);

    for (Product product : registeredProducts.getProducts()) {
      if (product.getCode() == code) {
        return true;
      }
    }
    return false;
  }

  public String formatProductData(int data) {
    short columnWidth = 5;
    if (String.valueOf(data).length() >= columnWidth) {
      return "" + data;
    } else {
      return String.format("%5s", data);
    }
  }
}
