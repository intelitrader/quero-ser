package com.intelitrader.repository.conflito;

import com.intelitrader.entity.conflito.Conflito;
import com.intelitrader.repository.balanco.BalancoRepository;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;

public class ConflitoRepositoryTest {
    @Test
    public void makeFileTest() throws IOException {
        Collection<Conflito> conflitos = new ArrayList<Conflito>();
        ConflitoRepository repository = new ConflitoRepository();
        repository.saveAll(conflitos);
        File file = new File(repository.getFilepath()+"/divergencias.txt");
        Assertions.assertTrue(file.exists());
    }
}
