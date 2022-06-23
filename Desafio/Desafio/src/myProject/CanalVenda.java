package myProject;

public enum CanalVenda {

	REPRESENTANTE_COMERCIAL(1, "Representante comercial"),
	WEBSITE(2, "Website"),
	APLICATIVO_MOVEL_ANDROID(3, "Aplicativo movel Android"),
	APLICATIVO_MOVEL_IPHONE(4, "Aplicativo movel iPhone");
	
	private int cod;
	private String desc;
	
	private CanalVenda(int cod, String desc) {
		this.cod = cod;
		this.desc = desc;
	}
	
	
	
	public int getCod() {
		return this.cod;
	}
	
	public String getDesc() {
		return this.desc;
	}
	
	public static CanalVenda getCanalVenda(int cod) {
		for(CanalVenda canalVenda: CanalVenda.values()) {
			if(canalVenda.cod == cod) {
				return canalVenda;
			}
		}
		
		return null;
	}
}
