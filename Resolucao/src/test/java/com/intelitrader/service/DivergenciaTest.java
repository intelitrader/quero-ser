package com.intelitrader.service;

import com.intelitrader.entity.balanco.Balanco;
import com.intelitrader.entity.conflito.Conflito;
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
public class DivergenciaTest {
    @Mock
    Write<Conflito> repository;

    @BeforeAll
    public void inicializador(){
        repository = mock(Write.class);
    }

    @Test
    public void processaTest(){
        Assertions.assertNotNull(repository);
        Divergencia divergencia = new Divergencia(List.of(), List.of(), repository);
        divergencia.processa();
        verify(repository, Mockito.times(1)).saveAll(List.of());
    }
}
