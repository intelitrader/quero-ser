package com.intelitrader.service;

import com.intelitrader.entity.balanco.Balanco;
import com.intelitrader.repository.Write;
import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.TestInstance;
import org.mockito.Mock;
import org.mockito.Mockito;

import java.util.List;

import static org.mockito.Mockito.mock;
import static org.mockito.Mockito.verify;

@TestInstance(TestInstance.Lifecycle.PER_CLASS)
public class TransfereTest {
    @Mock
    Write<Balanco> repository;

    @BeforeAll
    public void inicializador(){
        repository = mock(Write.class);
    }

    @Test
    public void processaTest(){
        Assertions.assertNotNull(repository);
        Transfere transfere = new Transfere(List.of(), List.of(), repository);
        transfere.processa();
        verify(repository, Mockito.times(1)).saveAll(List.of());
    }
}
