package Solucao;

import java.io.File;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;



public class App {
	
	private static List<String> read(String url) {
		File myFile = null;
		Scanner myReader = null;
		List<String> lines = new ArrayList<>();
		try{
			
			myFile = new File(url);
			myReader = new Scanner(myFile);
		
			while(myReader.hasNextLine()) {
				lines.add(myReader.nextLine());
			}
		}catch(Exception ex) {
			System.out.println("Erro na leitura do arquivo!");
		}
		finally {
			if (myReader != null)
				myReader.close();
		}
		return lines;
	}
	
	private static List<Venda> montarVendas(String filename){
		var values = read(filename);
		//Montando a lista de Vendas
		List<Venda> vendas = new ArrayList<>();
		for(var value: values) {
			String[] ret = value.split(";");
			//---------------------------------------------------------------------------//
			int codProduto = Integer.parseInt(ret[0]);
			//---------------------------------------------------------------------------//
			int quantVendida = Integer.parseInt(ret[1]);
			//---------------------------------------------------------------------------//
			int sitVenda = Integer.parseInt(ret[2]);
			SituacaoVenda situacaoVenda = SituacaoVenda.getCanalVenda(sitVenda);
			//---------------------------------------------------------------------------//
			int canVenda = Integer.parseInt(ret[3]);
			CanalVenda canalVenda = CanalVenda.getCanalVenda(canVenda);
			//---------------------------------------------------------------------------//
			vendas.add(new Venda(codProduto, quantVendida, situacaoVenda, canalVenda));
			
		}
		
		return vendas;
	}
	
	private static List<Produto> montarProdutos(String filename) {
		var values = read(filename);
		
		List<Produto> produtos = new ArrayList<>();
		//Montando a lista de Produtos
		for(var value: values) {
			String[] ret = value.split(";");
			//---------------------------------------------------------------------------//
			int codProduto = Integer.parseInt(ret[0]);
			//---------------------------------------------------------------------------//
			int quantEstoque = Integer.parseInt(ret[1]);
			//---------------------------------------------------------------------------//
			int quantMin = Integer.parseInt(ret[2]);
			//---------------------------------------------------------------------------//
			produtos.add(new Produto(codProduto, quantEstoque, quantMin));
			
		}
		
		return produtos;
	}
	
	
	

	public static void main(String[] args){
		// TODO Auto-generated method stub

		Empresa empresa = new Empresa();
		
		String filenameProd = args.length > 0 && args[0] != null? args[0] : "../Caso de teste 1/c1_produtos.txt";
		String filenameVend = args.length > 1 && args[1] != null? args[1] : "../Caso de teste 1/c1_vendas.txt";

		var produtos = montarProdutos(filenameProd) ;
		var vendas = montarVendas(filenameVend);
		
		empresa.setCod(1);
		
		empresa.setProdutos(produtos);
		
		empresa.setVendas(vendas);
		
		empresa.run();

		
	}

}
