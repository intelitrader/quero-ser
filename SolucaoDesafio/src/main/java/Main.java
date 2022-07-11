package main.java;

import main.java.fileFuncions.FilesPaths;
import main.java.fileFuncions.WriteDivergenceFile;
import main.java.fileFuncions.WriteTotChannelsFile;
import main.java.fileFuncions.WriteTransfereFile;

import java.io.*;

public class Main {

    public static void main(String[] args) throws IOException {
        WriteTransfereFile.writeTransfereFile(FilesPaths.productsPathCase1, FilesPaths.salesPathCase1, FilesPaths.transferePathCase1);
        WriteTransfereFile.writeTransfereFile(FilesPaths.productsPathCase2, FilesPaths.salesPathCase2, FilesPaths.transferePathCase2);

        WriteDivergenceFile.writeDivergenciaFile(FilesPaths.productsPathCase1, FilesPaths.salesPathCase1, FilesPaths.divergencePathCase1);
        WriteDivergenceFile.writeDivergenciaFile(FilesPaths.productsPathCase2, FilesPaths.salesPathCase2, FilesPaths.divergencePathCase2);

        WriteTotChannelsFile.writeTotChannelsFile(FilesPaths.salesPathCase1, FilesPaths.totChannelsPathCase1);
        WriteTotChannelsFile.writeTotChannelsFile(FilesPaths.salesPathCase2, FilesPaths.totChannelsPathCase2);
    }


}
