package com.intelitrader.valueObject.canal;

public enum CanalVenda {
    REPRESENTANTE_COMERCIAL(1, "Representante comercial"),
    WEBSITE(2, "Website"),
    APLICATIVO_MOVEL_ANDROID(3, "Aplicativo móvel Android"),
    APLICATIVO_MOVEL_IPHONE(4, "Aplicativo móvel iPhone");

    private final int codigo;
    private final String texto;

    CanalVenda(int codigo, String texto){
        this.codigo = codigo;
        this.texto = texto;
    }

    public int getCodigo(){
        return this.codigo;
    }

    public String getTexto(){ return this.texto; }
}
