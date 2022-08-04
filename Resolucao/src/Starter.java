import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.ArrayList;

public class Starter {
  public static void main(String [] args) {
    File products = new File("./Inputs/PRODUCTS.txt");
    File sales = new File("./Inputs/SALES.txt");
    RegisteredProducts registeredProducts = new RegisteredProducts();
    ProductsSold productsSold = new ProductsSold();

    Starter starter = new Starter();
    starter.saveRegisteredProducts(products, registeredProducts);
    starter.saveProductsSold(sales, productsSold, registeredProducts);
    System.out.println(productsSold.getProductsSold());
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
          System.out.println(row);
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
        if (row != null) {
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
    Product productObj = getProductByCode(code, registeredProducts);

    int startingAmount = productObj.getStartingAmount();
    int minimumQuantityCO = productObj.getMinimumQuantityCO();

    return new ProductSold(code, startingAmount, minimumQuantityCO, amountSales);
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
}
