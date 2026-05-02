package com.intelitrader.repository.canal;

import com.intelitrader.entity.balanco.Balanco;
import com.intelitrader.entity.canal.MetaCanal;
import com.intelitrader.repository.balanco.BalancoRepository;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.Test;

import java.io.File;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Collection;

public class MetaCanalTest {
    @Test
    public void makeFileTest() throws IOException {
        Collection<MetaCanal> canais = new ArrayList<MetaCanal>();
        MetaCanalRepository repository = new MetaCanalRepository();
        repository.saveAll(canais);
        File file = new File(repository.getFilepath()+"/totcanais.txt");
        Assertions.assertTrue(file.exists());
    }
}
