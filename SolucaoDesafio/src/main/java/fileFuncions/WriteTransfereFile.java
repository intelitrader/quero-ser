package main.java.fileFuncions;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.*;

public class WriteTransfereFile {
    private static void writeHeader(String outputPath) throws IOException {
        BufferedWriter buffWrite = new BufferedWriter(new FileWriter(outputPath, true));

        buffWrite.append("Necessidade de Transferência Armazém para CO\n\n");
        buffWrite.append("Produto    QtCO    QtMin    QtVendas    Estq.após    Necess.    Transf. de\n");
        buffWrite.append("                                        Vendas                  Arm p/ CO\n\n");
        buffWrite.close();
    }


    private static void writeInfoInFile(AbstractMap<String, String> prod, String outputPath) throws IOException {
        BufferedWriter buffWrite = new BufferedWriter(new FileWriter(outputPath, true));

        String codProd = prod.get("codProd");
        String qtCo = prod.get("qtCO");
        String qtMin = prod.get("qtMin");
        String qtVendas = prod.get("qtVendas");
        String estPosVenda = prod.get("estPosVenda");
        String necess = prod.get("necess");
        String transf = prod.get("transf");

        // Calc spaces after column
        int spaces;
        buffWrite.append(codProd).append("      ");

        spaces = 8 - qtCo.length();
        buffWrite.append(qtCo).append(String.join("", Collections.nCopies(spaces, " ")));

        spaces = 9 - qtMin.length();
        buffWrite.append(qtMin).append(String.join("", Collections.nCopies(spaces, " ")));

        spaces = 12 - qtVendas.length();
        buffWrite.append(qtVendas).append(String.join("", Collections.nCopies(spaces, " ")));

        spaces = 13 - estPosVenda.length();
        buffWrite.append(estPosVenda).append(String.join("", Collections.nCopies(spaces, " ")));

        spaces = 11 - necess.length();
        buffWrite.append(necess).append(String.join("", Collections.nCopies(spaces, " ")));

        buffWrite.append(transf).append("\n");

        buffWrite.close();
    }

    public static void writeTransfereFile(String productsPath, String salesPath, String outputPath) throws IOException {
        BufferedWriter buffWrite = new BufferedWriter(new FileWriter(outputPath));

        List<AbstractMap<String, String>> dadosProdutos = ExtractFileInfo.readProductData(productsPath);

        List<List<String>> confirmedSales = ExtractFileInfo.filterCofirmedSales(salesPath);
        Map<String, Integer> salesAmount = ExtractFileInfo.getSalesAmount(confirmedSales);

        writeHeader(outputPath);

        for (AbstractMap<String, String> prod : dadosProdutos) {
            AbstractMap<String, String> finalProd = new HashMap<>();
            String currentProd = prod.get("codProd");

            finalProd.put("codProd", prod.get("codProd"));
            finalProd.put("qtCO", prod.get("qtStock"));

            // QtMin
            Integer qtMin = Integer.valueOf(prod.get("minimalQt"));
            finalProd.put("qtMin", String.valueOf(qtMin));

            // QtVendas
            finalProd.put("qtVendas", String.valueOf(salesAmount.get(currentProd)));

            // QO
            Integer qo = Integer.valueOf(prod.get("qtStock"));
            Integer estPosVenda = qo - salesAmount.get(currentProd);
            finalProd.put("estPosVenda", String.valueOf(estPosVenda));

            //Necess.
            Integer necess = 0;

            if (estPosVenda < qtMin) {
                necess = qtMin - estPosVenda;
                finalProd.put("necess", String.valueOf(necess));
            } else {
                finalProd.put("necess", String.valueOf(necess));
            }

            //Transf. de Arm p/ CO
            int transf = necess;
            if (necess > 1 && necess < 10) transf = 10;
            finalProd.put("transf", String.valueOf(transf));

            writeInfoInFile(finalProd, outputPath);
        }

        buffWrite.close();
    }
}
