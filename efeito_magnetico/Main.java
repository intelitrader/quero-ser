package efeito_magnetico;

/* Link do desafio: https://dojopuzzles.com/problems/efeito-magnetico/
 * Em programas vários programas gráficos baseados em vetores, uma ferramenta muito útil para auxiliar no 
 * desenho é o magneto. Resumidamente, uma pequena área da tela, ao redor de "pontos importantes" são 
 * magnéticos. Por exemplo, se movermos o cursor do mouse próximo o suficiente de um desses pontos e 
 * começarmos a desenhar, o desenho vai ser iniciado no ponto magnético ao invés do ponto onde o cursor 
 * se encontra. Porém, quando o cursor está distante de um desses pontos, o início do desenho é no próprio 
 * ponto.
 * 
 * Alguns exemplos:
 * 
 * Se existe um ponto magnético na coordenada (50, 50) e o raio de efeito magnético é 5, quando o curso é 
 * movido para a posição (49,50), o efeito magnético atua e força com que o desenho seja feito a partir do 
 * ponto (50,50);
 * 
 * Se existe um ponto magnético em (50, 50), o raio de efeito magnético é 5 e o cursor está em (0, 0), não 
 * ocorre o efeito magnético;
 * 
 * Se existem dois pontos magnéticos em (50, 50) e (100, 50), quando o mouse está em (101, 48), o efeito 
 * magnético faz com que você comece a desenhar em (100, 50);
 * 
 * Se os pontos magnéticos são (50, 50) e (51, 51) e o mouse está em (51, 52), o desenho se inicia em (51, 51)
 * 
 * Implemente este efeito magnético, informando a localização dos pontos magnéticos, o raio do efeito 
 * magnético e o ponto onde o cursor se encontra no momento. COm esses dados, seu programa deverá informar 
 * qual o ponto onde o desenho irá começar realmente.
 * 
 * Authir
 * */

import java.util.ArrayList;
import java.util.Scanner;

public class Main {
	static Scanner input = new Scanner(System.in);
	public static void main(String[] args) {
		//Define a quantidade de pontos magnéticos (x, y) haverão. 
		int nQuantidadePontos = quantidadePontos(0);
		ArrayList<PontoMagnetico> pontosMagneticos = new ArrayList<PontoMagnetico>();
		
		for(int i = 0; i < nQuantidadePontos; i ++) {
			int xMag, yMag, r;
			System.out.println("Entre o valor de x do " + (i + 1) + "º ponto magnético: ");
			xMag = input.nextInt();
			System.out.println("Entre o valor de y do " + (i + 1) + "º ponto magnético: ");
			yMag = input.nextInt();
			System.out.println("Entre o valor do raio do " + (i + 1) + "º ponto magnético: ");
			r = input.nextInt();
			PontoMagnetico ponto = new PontoMagnetico(xMag, yMag, r);
			pontosMagneticos.add(ponto);
		}
		

		for(int	i =	0; i < pontosMagneticos.size();	i++)	{
			PontoMagnetico p = (PontoMagnetico) pontosMagneticos.get(i);	
			System.out.println("(" + p.getX() + ", " + p.getY() + ") raio: " + p.getRaio());
		}
		
		int xMouse, yMouse;
		System.out.println("Ponto x do mouse: ");
		xMouse = input.nextInt();
		System.out.println("Ponto y do mouse: ");
		yMouse = input.nextInt();
		PontoMouse pontoMouse = new PontoMouse(xMouse, yMouse);
		
		PontoMouse pontoInicio = new PontoMouse();
		pontoInicio = desenhoInicio(pontoMouse, pontosMagneticos);
	
		System.out.println("O mouse iniciará nos pontos (" + pontoInicio.getX() + ", " + pontoInicio.getY() + ")");
	}
	
	public static int quantidadePontos(int n) {
		do {
			System.out.println("Entre a quantidade de pontos magnéticos [1] a [5]");
			n = input.nextInt();
			if(n < 1 || n > 5)
				System.out.println("Você digitou um número fora dos limites. Digite uma quantidade de 0 a 5");
		}while(n < 1 || n > 5);
		
		return n;
	}
	
	public static PontoMouse desenhoInicio(PontoMouse ponto, ArrayList<PontoMagnetico> list) {
		int distanciaX, distanciaY;
		PontoMouse comparar = new PontoMouse(999999999, 999999999);
		PontoMouse pontoInicio = new PontoMouse();
		boolean entrada = false;
		for(int	i =	0; i < list.size();	i++)	{
			PontoMagnetico p = (PontoMagnetico) list.get(i);	
			distanciaX = Math.abs(p.getX() - ponto.getX());
			distanciaY = Math.abs(p.getY() - ponto.getY());
			if(distanciaX > p.getRaio() || distanciaY > p.getRaio())
				continue;
			else {
				if(comparar.getX() > distanciaX && comparar.getY() > distanciaY) {
					comparar.setX(distanciaX);
					comparar.setY(distanciaY);
					pontoInicio = p;
					entrada = true;
				}
			}
		}
		if(!entrada) 
			return ponto;
		else
			return pontoInicio;
	}
}
