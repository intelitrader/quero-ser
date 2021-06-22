package Entities.caixaeletronico;

import java.text.DecimalFormat;

import Entities.troco.Transaction;

public class CachMachine extends Transaction {
	private double[] banckNotes = { 100.00, 50.0, 10.0, 5.00, 1.00 };
	private int value;
	private int saveWholeValue;
	DecimalFormat df = new DecimalFormat("#,###.00");

	@Override
	public void toCalculeBankNotes(double total) {
		value = (int) total;

		while (value > 0) {

			if (value == (int) total) {
				saveWholeValue = value;
			}

			for (double banckNote : banckNotes) {

				int quantityBankNotes = (int) (value / banckNote);

				double discountValue = quantityBankNotes * banckNote;
				value -= discountValue;

				if (quantityBankNotes > 0) {
					System.out.println("Quantidade de notas de " + df.format(banckNote) + " = " + quantityBankNotes);
				}

			}

		}

		total -= saveWholeValue;

	}

}
