package main.java.fileFuncions;

import java.io.*;
import java.util.AbstractMap;
import java.util.List;

public class WriteDivergenceFile {
    public static void writeDivergenciaFile(String productsPath, String salesPath, String outputPath) throws IOException {
        List<AbstractMap<String, String>> dadosProdutos = ExtractFileInfo.readProductData(productsPath);
        List<String> productsIds = ExtractFileInfo.getOnlyProductsIds(dadosProdutos);

        // verificar produtos divergentes
        BufferedReader buffRead = new BufferedReader(new FileReader(salesPath));
        BufferedWriter buffWrite = new BufferedWriter(new FileWriter(outputPath));

        String line;
        int lineNumber = 0;
        while (true) {
            line = buffRead.readLine();
            lineNumber += 1;

            if (line != null) {
                String[] data = line.split(";");

                // Produto não encontrado
                if (data[2].equals("999")) {
                    String message = "Linha " + lineNumber + " – Erro desconhecido. Acionar equipe de TI";
                    buffWrite.append(message).append("\n");
                    continue;
                }

                if (!productsIds.contains(data[0])) {
                    String message = "Linha " + lineNumber + " – Código de Produto não encontrado " + data[0];
                    buffWrite.append(message).append("\n");
                    continue;
                }

                if (data[2].equals("135")) {
                    String message = "Linha " + lineNumber + " – Venda cancelada";
                    buffWrite.append(message).append("\n");
                    continue;
                }

                if (data[2].equals("190")) {
                    String message = "Linha " + lineNumber + " – Venda não finalizada";
                    buffWrite.append(message).append("\n");
                }

            } else break;
        }

        buffWrite.close();
    }
}
