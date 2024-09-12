package main.java.fileFuncions;

import java.io.*;
import java.util.*;

public class WriteTotChannelsFile {
    public static void writeTotChannelsFile(String salesPath, String outputPath) throws IOException {
        BufferedReader buffRead = new BufferedReader(new FileReader(salesPath));
        BufferedWriter buffWrite = new BufferedWriter(new FileWriter(outputPath));

        Map<String, Integer> totalChannelSales = new HashMap<>();
        totalChannelSales.put("1", 0);
        totalChannelSales.put("2", 0);
        totalChannelSales.put("3", 0);
        totalChannelSales.put("4", 0);

        List<String> validSales = new ArrayList<>(List.of(new String[]{"100", "102"}));

        buffWrite.append("Quantidades de Vendas por canal").append("\n\n");
        buffWrite.append("Canal                      QtVendas\n").append("\n");

        String line;

        while (true) {
            line = buffRead.readLine();

            if (line != null) {
                String[] data = line.split(";");

                if (!validSales.contains(data[2])) continue;

                int subtotalOfSales = totalChannelSales.get(data[3]) + Integer.parseInt(data[1]);

                switch (data[3]) {
                    case "1" -> totalChannelSales.put("1", subtotalOfSales);
                    case "2" -> totalChannelSales.put("2", subtotalOfSales);
                    case "3" -> totalChannelSales.put("3", subtotalOfSales);
                    case "4" -> totalChannelSales.put("4", subtotalOfSales);
                }

            } else break;
        }

        String representants = String.valueOf(totalChannelSales.get("1"));
        buffWrite.append("1 - Representantes").append(String.join("", Collections.nCopies(9, " ")))
                .append(representants).append("\n");

        String website = String.valueOf(totalChannelSales.get("2"));
        buffWrite.append("2 - Website").append(String.join("", Collections.nCopies(16, " ")))
                .append(website).append("\n");

        String appMobile = String.valueOf(totalChannelSales.get("3"));
        buffWrite.append("3 - App móvel Android").append(String.join("", Collections.nCopies(6, " ")))
                .append(appMobile).append("\n");

        String appIphone = String.valueOf(totalChannelSales.get("4"));
        buffWrite.append("4 - App móvel iPhone").append(String.join("", Collections.nCopies(7, " ")))
                .append(appIphone).append("\n");

        buffWrite.close();
    }
}
