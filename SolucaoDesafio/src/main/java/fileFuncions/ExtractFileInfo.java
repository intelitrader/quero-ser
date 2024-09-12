package main.java.fileFuncions;

import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;
import java.util.*;

public class ExtractFileInfo {

    public static List<AbstractMap<String, String>> readProductData(String productsPath) throws IOException {
        List<AbstractMap<String, String>> products = new ArrayList<>();
        AbstractMap<String, String> prod = new HashMap<>();

        BufferedReader buffRead = new BufferedReader(new FileReader(productsPath));
        String line;

        while (true) {
            line = buffRead.readLine();

            if (line != null) {
                String[] data = line.split(";");

                prod.put("codProd", data[0]);
                prod.put("qtStock", data[1]);
                prod.put("minimalQt", data[2]);

                products.add(prod);
                prod = new HashMap<>();
            } else break;
        }
        buffRead.close();

        return products;
    }

    public static List<List<String>> filterCofirmedSales(String salesPath) throws IOException {
        List<List<String>> sales = new ArrayList<>();
        List<String> sale = new ArrayList<>();
        List<String> possibleSales = new ArrayList<>(List.of(new String[]{"100", "102"}));

        BufferedReader buffRead = new BufferedReader(new FileReader(salesPath));
        String line;

        while (true) {
            line = buffRead.readLine();

            if (line != null) {
                String[] data = line.split(";");

                if (!possibleSales.contains(data[2])) continue;

                sale.add(data[0]);
                sale.add(data[1]);
                sale.add(data[2]);
                sale.add(data[3]);

                sales.add(sale);
                sale = new ArrayList<>();
            } else break;
        }
        buffRead.close();

        return sales;
    }

    public static List<String> getOnlyProductsIds(List<AbstractMap<String, String>> products) {
        List<String> productsIds = new ArrayList<>();
        for (AbstractMap<String, String> p : products) {
            productsIds.add(p.get("codProd"));
        }

        return productsIds;
    }

    public static Map<String, Integer> getSalesAmount(List<List<String>> sales) {
        Map<String, Integer> total = new HashMap<>();

        for (List<String> sale : sales) {
            total.put(sale.get(0), 0);
        }

        for (List<String> sale : sales) {
            Integer currentSaleValue = Integer.valueOf(sale.get(1));
            Integer subtotal = total.get(sale.get(0));

            total.put(sale.get(0), subtotal + currentSaleValue);
        }

        return total;
    }
}
