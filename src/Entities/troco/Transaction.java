package Entities.troco;

import java.math.BigDecimal;
import java.text.DecimalFormat;

public class Transaction {

	private double[] banckNotes = { 100.00, 50.0, 10.0, 5.00, 1.00 };
	private double[] coins = { 0.50, 0.10, 0.05, 0.01 };
	private double saveWholeValue;
	private int integervalue;
	DecimalFormat df = new DecimalFormat("#,###.00");
	DecimalFormat dfcoins = new DecimalFormat("0.00");
	DecimalFormat dftroco = new DecimalFormat("0.000");

	public void toCalculeBankNotes(double total) {
		integervalue = (int) total;

		while (integervalue > 0) {

			if (integervalue == (int) total) {
				saveWholeValue = integervalue;
			}

			for (double banckNote : banckNotes) {

				int quantityBankNotes = (int) (integervalue / banckNote);

				double discountValue = quantityBankNotes * banckNote;
				integervalue -= discountValue;

				if (quantityBankNotes > 0) {
					System.out.println("Quantidade de notas de " + df.format(banckNote) + " = " + quantityBankNotes);
				}

			}

		}

		total -= saveWholeValue;

		if (total != 0) {
			String convert =dfcoins.format(total).replace(",", ".");
	         total = Double.parseDouble(convert);
			toCalculeCoins(total);
		}
	}

	public void toCalculeCoins(double total) {
	
		
        
        
	
		while (total > 0) {
			for (double coin : coins) {

				int quantityCoins = (int) (total / coin);
               
				double discountValue = quantityCoins * coin;
				total -= discountValue;

				if (quantityCoins > 0) {
					System.out.println("Quantidade de moedas de " + dfcoins.format(coin) + " = " + quantityCoins);
				}

			}

		}

	}

	public void toPerformTransaction(double value, double receivedValue) throws Exception {

		if (value > 0 && receivedValue > 0) {

			if (receivedValue >= value) {
				double totalValue = receivedValue - value;

				System.out.println("Troco: " + df.format(totalValue));
				toCalculeBankNotes(totalValue);
			} else {
				double totalValue = value - receivedValue;
				System.out.println("Valor não é suficiente para pagar, faltam: " + df.format(totalValue));
			}

		} else {
			throw new Exception("Informe um valor maior que '0'");
		}

	}

}
