package myProject;

public enum SituacaoVenda {

	VENDA_CONFIRMADA_PAG_OK(100, "venda confirmada e com pagamento ok"), 
	VENDA_CONFIRMADA_PAG_PENDENTE(102, "venda confirmada, mas com pagamento pendente"),
	VENDA_CANCELADA(135, "venda cancelada"),
	VENDA_NAO_FINALIZADA_CANAL_VENDAS(190, "venda nao finalizada no canal de vendas"),
	ERRO_DESCONHECIDO(999, "erro nao identificado");
	
	private int cod;
	private String desc;
	
	private SituacaoVenda(int cod, String desc) {
		this.cod = cod;
		this.desc = desc;
	}
	
	public int getCod() {
		return this.cod;
	}
	
	public String getDesc() {
		return this.desc;
	}
	
	public static SituacaoVenda getCanalVenda(int cod) {
		for(SituacaoVenda situacaoVenda: SituacaoVenda.values()) {
			if(situacaoVenda.cod == cod) {
				return situacaoVenda;
			}
		}
		
		return null;
	}
	
}
