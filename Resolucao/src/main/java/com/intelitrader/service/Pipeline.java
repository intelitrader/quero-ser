package com.intelitrader.service;

import java.util.ArrayList;
import java.util.Collection;

public class Pipeline {
    private Collection<Processo> processos;

    public Pipeline(){
        processos = new ArrayList<>();
    }

    public void addProcesso(Processo processo){
        this.processos.add(processo);
    }

    public void processa(){
        this.processos.forEach(Processo::processa);
    }
}
