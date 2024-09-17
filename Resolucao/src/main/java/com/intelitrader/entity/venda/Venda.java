package com.intelitrader.entity.venda;

import com.intelitrader.valueObject.canal.CanalVenda;
import com.intelitrader.valueObject.status.SituacaoVenda;

public record Venda(long codigoProduto,
                    long quantidadeVendida,
                    SituacaoVenda situacao,
                    CanalVenda canal){}