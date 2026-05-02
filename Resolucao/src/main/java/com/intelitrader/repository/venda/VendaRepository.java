package com.intelitrader.repository.venda;

import com.intelitrader.entity.venda.Venda;
import com.intelitrader.repository.Read;
import com.intelitrader.valueObject.canal.CanalVenda;
import com.intelitrader.valueObject.status.SituacaoVenda;

import java.util.List;
import java.util.stream.Collectors;

import static com.intelitrader.helper.FileManipulator.readFile;

public class VendaRepository implements Read<Venda> {
    private final String filePath;

    public VendaRepository(String filePath){
        this.filePath = filePath;
    }

    @Override
    public List<Venda> getAll() {
        return readFile(this.filePath)
                .stream()
                .map((line) -> parse(line))
                .collect(Collectors.toList());
    }

    private Venda parse(String serialized){
        String[] splited = serialized.split(";", serialized.length());
        long codigo = Long.parseLong(splited[0]);
        long quantidadeVendida = Long.parseLong(splited[1]);
        SituacaoVenda situacaoVenda = parseSituacaoVenda(Integer.parseInt(splited[2]));
        CanalVenda canalVenda = parseCanalVenda(Integer.parseInt(splited[3]));

        return new Venda(codigo, quantidadeVendida, situacaoVenda, canalVenda);
    }

    private SituacaoVenda parseSituacaoVenda(int codigo){
        SituacaoVenda situacao = SituacaoVenda.ERRO_NAO_IDENTIFICADO;
        for(SituacaoVenda situacaoVenda : SituacaoVenda.values())
            if(situacaoVenda.getCodigo() == codigo) return situacaoVenda;

        return situacao;
    }

    private CanalVenda parseCanalVenda(int codigo){
        CanalVenda canal = CanalVenda.REPRESENTANTE_COMERCIAL;
        for(CanalVenda canalVenda : CanalVenda.values())
            if(canalVenda.getCodigo() == codigo) return canalVenda;

        return canal;
    }
}
