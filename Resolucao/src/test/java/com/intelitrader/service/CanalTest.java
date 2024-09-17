package com.intelitrader.service;

import com.intelitrader.entity.canal.MetaCanal;
import com.intelitrader.entity.conflito.Conflito;
import com.intelitrader.repository.Write;
import com.intelitrader.valueObject.canal.CanalVenda;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestInstance;
import org.mockito.Mock;
import org.mockito.Mockito;

import java.util.Arrays;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class CanalTest {
    @Mock
    Write<MetaCanal> repository;

    @BeforeAll
    public void inicializador(){
        repository = mock(Write.class);
    }

    @Test
    public void processaTest(){
        Assertions.assertNotNull(repository);

        Collection<MetaCanal> canais = Arrays.stream(CanalVenda.values())
                .map(canalVenda -> new MetaCanal(canalVenda, 0))
                .collect(Collectors.toList());

        Canal canal = new Canal(List.of(), repository);
        canal.processa();


        verify(repository, Mockito.times(1)).saveAll(canais);
    }
}
