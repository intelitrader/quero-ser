package com.intelitrader.valueObject.status;

public enum SituacaoVenda {
    CONFIRMADA_E_PAGA(100, "venda confirmada e com pagamento ok"),
    CONFIRMADA(102, "venda confirmada, mas com pagamento pendente"),
    CANCELADA(135, "venda cancelada"),
    NAO_FINALIZADA(190, "venda não finalizada no canal de vendas"),
    ERRO_NAO_IDENTIFICADO(999, "erro não identificado");

    private final int codigo;
    private final String texto;

    SituacaoVenda(int codigo, String texto){
        this.codigo = codigo;
        this.texto = texto;
    }

    public int getCodigo() {
        return codigo;
    }

    public String getTexto() {
        return texto;
    }
}
