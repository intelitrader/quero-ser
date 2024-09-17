package com.intelitrader.valueObject.conflito;

public enum TipoConflito {
    CODIGO_NAO_ENCONTRADO("Código de produto não encontrado"),
    VENDA_CANCELADA("Venda cancelada"),
    VENDA_NAO_FINALIZADA("Venda não finalizada"),
    ERRO_DESCONHECIDO("Erro desconhecido. Acionar equipe de TI");

    private final String texto;

    TipoConflito(String texto){
        this.texto = texto;
    }

    public String getTexto(){
        return texto;
    }
}
