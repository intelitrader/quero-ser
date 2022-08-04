import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class Starter {
  public static void main(String [] args) {
    File products = new File("./Inputs/PRODUCTS.txt");
    File sales = new File("./Inputs/SALES.txt");
    RegisteredProducts registeredProducts = new RegisteredProducts();

    new Starter().saveRegisteredProducts(products, registeredProducts);
    System.out.println(registeredProducts.getProducts());
  }

  public void saveRegisteredProducts(File products, RegisteredProducts registeredProducts) {
    try {
      FileReader reader = new FileReader(products);
      BufferedReader buffReader = new BufferedReader(reader);

      String row = buffReader.readLine();

      registeredProducts.addProduct(createProductObjetct(row));

      while (row != null) {
        row = buffReader.readLine();
        if (row != null) {
          registeredProducts.addProduct(createProductObjetct(row));
        }
      }

    } catch (IOException e) {
      e.printStackTrace();
    }
  }

  public Product createProductObjetct(String row) {
    String [] productInfos = row.split(";");
    int code = Integer.parseInt(productInfos[0]);
    int startingAmount = Integer.parseInt(productInfos[1]);
    int minimumQuantityCO = Integer.parseInt(productInfos[2]);

    return new Product(code, startingAmount, minimumQuantityCO);
  }
}
