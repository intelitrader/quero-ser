package com.intelitrader.repository.produto;

import com.intelitrader.entity.produto.Produto;
import org.junit.jupiter.api.*;

import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.List;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class ProdutoRepositoryTest {
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
        ProdutoRepository repository = new ProdutoRepository(this.filepath);
        List<Produto> produtos = repository.getAll();
        Assertions.assertNotNull(produtos);
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
