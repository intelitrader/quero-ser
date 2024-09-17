package com.intelitrader.helper;

import org.junit.jupiter.api.*;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Collection;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class FileManipulatorTest {
    private String filepath;

    @BeforeAll
    public void iniciador(){
        this.filepath = criarArquivoVazio();
    }

    @AfterAll
    public void finalizador(){
        deletaArquivo();
    }

    @Test
    public void readLineEmptyTest(){
        Collection<String> lines = FileManipulator.readFile(this.filepath);
        Assertions.assertEquals(lines.size(), 0);
    }

    @Test
    public void readLineTest(){
        writeFile();
        Collection<String> lines = FileManipulator.readFile(this.filepath);
        Assertions.assertEquals(lines.size(), 5);
    }

    private void writeFile(){
        try{
            String path = "./resources/fileTest.txt";
            FileWriter file = new FileWriter(path);
            file.write("\n");
            file.append("\n");
            file.append("\n");
            file.append("\n");
            file.append("\n");
            file.close();
        }catch (IOException e){
            System.err.println(e.getMessage());
        }
    }

    private String criarArquivoVazio(){
        try{
            String path = "./resources/fileTest.txt";
            FileWriter file = new FileWriter(path);
            file.write("");
            file.close();
            return path;
        }catch (IOException e){
            System.err.println(e.getMessage());
            return null;
        }
    }

    private void deletaArquivo(){
        File file = new File(this.filepath);
        file.delete();
    }
}
