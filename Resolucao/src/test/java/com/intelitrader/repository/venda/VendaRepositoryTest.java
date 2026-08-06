package com.intelitrader.repository.venda;

import com.intelitrader.entity.venda.Venda;
import org.junit.jupiter.api.*;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class VendaRepositoryTest {
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
    public void getAllTest(){
        VendaRepository repository = new VendaRepository(this.filepath);
        List<Venda> vendas = repository.getAll();
        Assertions.assertNotNull(vendas);
    }

    private String criarArquivoVazio(){
        try{
            String path = "C:\\Users\\c101136\\projects\\quero-ser\\resources\\fileTest.txt";
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
