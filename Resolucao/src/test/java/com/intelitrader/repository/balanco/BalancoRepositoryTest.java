package com.intelitrader.repository.balanco;

import com.intelitrader.entity.balanco.Balanco;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;

public class BalancoRepositoryTest {
    @Test
    public void makeFileTest() throws IOException {
        Collection<Balanco> balancos = new ArrayList<Balanco>();
        BalancoRepository repository = new BalancoRepository();
        repository.saveAll(balancos);
        File file = new File(repository.getFilepath()+"/transfere.txt");
        Assertions.assertTrue(file.exists());
    }
}
