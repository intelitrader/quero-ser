package Solucao;

import java.util.ArrayList;
import java.io.FileWriter; 
import java.io.IOException;
import java.util.List;
import java.util.Objects;

public class Empresa {
	
	private int cod;
	private List<Produto> produtos = new ArrayList<>();
	private List<Venda> vendas = new ArrayList<>();
	
	public List<Produto> getProdutos() {
		return produtos;
	}
	public void setProdutos(List<Produto> produtos) {
		this.produtos = produtos;
	}
	public List<Venda> getVendas() {
		return vendas;
	}
	public void setVendas(List<Venda> vendas) {
		this.vendas = vendas;
	}
	
	public int getCod() {
		return cod;
	}
	public void setCod(int cod) {
		this.cod = cod;
	}
	@Override
	public int hashCode() {
		return Objects.hash(cod);
	}
	@Override
	public boolean equals(Object obj) {
		if (this == obj)
			return true;
		if (obj == null)
			return false;
		if (getClass() != obj.getClass())
			return false;
		Empresa other = (Empresa) obj;
		return cod == other.cod;
	}
	
	private boolean existCodProduto(int codProduto) {
		
		for(Produto prod: produtos) {
			if (prod.getCodProduto() == codProduto) {
				return true;
			}
		}
		return false;
	}
	
	private List<String> getDivergencias() {
		
		List<String> divergencias = new ArrayList<String>();
		for(int indice = 0; indice < vendas.size(); indice++) {
			Venda venda = vendas.get(indice);
			if (!existCodProduto(venda.getCodProduto())) {
				divergencias.add("Linha - " + (indice+1) + " Codigo de Produto nao encontrado " + venda.getCodProduto());
			}
			
			if (venda.getSituacaoVenda() == SituacaoVenda.VENDA_CONFIRMADA_PAG_OK || 
					venda.getSituacaoVenda() == SituacaoVenda.VENDA_CONFIRMADA_PAG_PENDENTE) continue;
			
			divergencias.add("Linha - "+(indice+1)+" " +venda.getSituacaoVenda().getDesc()+ " "+ venda.getCodProduto());
		}	
		return divergencias;
	}
	

	
	private List<String> getCanaisVendas(){
		
		List<String> canaisVendas = new ArrayList<>();
		for(CanalVenda canalVenda: CanalVenda.values()) {
			int total = 0;
			
			for(Venda venda: vendas) {
				if (venda.getSituacaoVenda() != SituacaoVenda.VENDA_CONFIRMADA_PAG_OK && 
						venda.getSituacaoVenda() != SituacaoVenda.VENDA_CONFIRMADA_PAG_PENDENTE) continue;
				
				if (venda.getCanalVenda().equals(canalVenda)) {
					total += venda.getQuantVendida();
				}
			}
			
			canaisVendas.add(canalVenda.getCod() +" - "+ canalVenda.getDesc() +" "+ total);
		}
		return canaisVendas;
	}
	
	private List<Transfere> getTransfere() {
		
		List<Transfere> transfere = new ArrayList<>();

		for(Produto produto: produtos) {
			int qtCO = 0;
			int qtMin = 0;
			int qtVendas = 0;
			for(Venda venda: vendas) {
				
				if (venda.getSituacaoVenda() != SituacaoVenda.VENDA_CONFIRMADA_PAG_OK && 
						venda.getSituacaoVenda() != SituacaoVenda.VENDA_CONFIRMADA_PAG_PENDENTE) continue;
				
				if(venda.getCodProduto() == produto.getCodProduto()) {
					qtVendas += venda.getQuantVendida();
				}

			}
			qtCO += produto.getQuantEstoque();
			qtMin += produto.getQuantMin();
			int necess = qtMin - (qtCO - qtVendas) < 0 ? 0 : qtMin - (qtCO - qtVendas);
			int transfer = (necess > 1 && necess < 10) ? 10: necess;
			transfere.add(new Transfere(produto.getCodProduto(), qtCO, qtMin, qtVendas, qtCO - qtVendas, necess, transfer));
		}
		return transfere;
	}
	
	private void save(String filename, List<?> list) {
	    try {
	        FileWriter myWriter = new FileWriter(filename);
	        for(var line: list)
	        	myWriter.write(line.toString() +"\n");
	        myWriter.close();
	        System.out.println("Arquivo \""+ filename + "\" criado!");
	      } catch (IOException e) {
	        System.out.println("Ocorreu um erro");
	        e.printStackTrace();
	      }
	}
	
	private void getPrint(List<?> list, String title) {
		System.out.println(title);
		System.out.println();
		for(var line: list) {
			System.out.println(line);
		}
		System.out.println();
	}
	
	
	public void run() {
		
		
		getPrint(getTransfere(),"Transfere");
		getPrint(getDivergencias(), "Divergencias");
		getPrint(getCanaisVendas(), "Canais de Vendas");
		
		save("TRANSFERE.txt", getTransfere());
		save("DIVERGENCIAS.txt", getDivergencias());
		save("TOTCANAIS.txt", getCanaisVendas());
		
		
	}

}
