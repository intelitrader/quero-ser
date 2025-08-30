package main.java.fileFuncions;

import java.io.File;

public class FilesPaths {
    public static String basePath = new File("").getAbsolutePath() + "/src/main/java";

    // Caso de teste 1
    public static String productsPathCase1 = basePath + "/CasoDeTeste1/c1_produtos.txt";
    public static String salesPathCase1 = basePath + "/CasoDeTeste1/c1_vendas.txt";

    // Output files
    public static String transferePathCase1 = basePath + "/OutputFilesCase1/transfere.txt";
    public static String divergencePathCase1 = basePath + "/OutputFilesCase1/DIVERGENCIAS.txt";
    public static String totChannelsPathCase1 = basePath + "/OutputFilesCase1/TOTCANAIS.txt";

    // Caso de teste 2
    public static String productsPathCase2 = basePath + "/CasoDeTeste2/c2_produtos.txt";
    public static String salesPathCase2 = basePath + "/CasoDeTeste2/c2_vendas.txt";

    // Output files
    public static String transferePathCase2 = basePath + "/OutputFilesCase2/transfere.txt";
    public static String divergencePathCase2 = basePath + "/OutputFilesCase2/DIVERGENCIAS.txt";
    public static String totChannelsPathCase2 = basePath + "/OutputFilesCase2/TOTCANAIS.txt";

}
