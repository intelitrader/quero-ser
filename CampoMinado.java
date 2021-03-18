package principal;

/*
 * 
 * desafio: Campo Minado
 * url: https://dojopuzzles.com/problems/campo-minado/
 * 
 */

public class CampoMinado {

	public static void identificarMinas(String[][] campo) {

		String[][] campoIdentificado = copiaAumentada(campo);

		for (int i = 0; i < campo.length; i++) {
			for (int j = 0; j < campo[i].length; j++) {
				if (campo[i][j] == "*") {

					campoIdentificado[i + 1][j + 1] = campo[i][j];

					aplicarIndicacoes(campoIdentificado, i + 1, j + 1);

				}
			}
		}

		exibirCampo(campoIdentificado);
	}


	private static String[][] copiaAumentada(String[][] campo) {
		
		String[][] campoIdentificado = new String[campo.length+2][campo[0].length+2];
		
		for (int i = 0; i < campoIdentificado.length; i++) {
			for (int j = 0; j < campoIdentificado.length; j++) {
				campoIdentificado[i][j] = "0";
			}
		}
	
		return campoIdentificado;
	}


	private static void aplicarIndicacoes(String[][] campoIdentificado, int i, int j) {

		for (int row = -1; row <= 1; row++) {
			for (int column = -1; column <= 1; column++) {
				if (campoIdentificado[i + row][j + column] != "*") {
					campoIdentificado[i + row][j + column] = (Integer.parseInt(campoIdentificado[i + row][j + column]) + 1) + "";
				}
			}
		}

	}

	private static void exibirCampo(String[][] campoIdentificado) {

		for (int i = 1; i < campoIdentificado.length - 1; i++) {
			for (int j = 1; j < campoIdentificado.length - 1; j++) {
				System.out.print(campoIdentificado[i][j]);
			}
			System.out.println();
		}

	}

	public static void main(String[] args) {

		String[][] campoSemIdentificadores = { { "*", ".", ".","." }, { ".", "*", ".","." }, { ".", "*", ".","." },{".",".",".","."} };

		identificarMinas(campoSemIdentificadores);
	}

}
