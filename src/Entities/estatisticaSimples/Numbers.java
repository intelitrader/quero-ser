package Entities.estatisticaSimples;

import java.util.List;

public class Numbers {
	private int max;
	private int min;
	private int numbersQuantity;
	private double average;

	public Numbers() {

	}

	public Numbers(int max, int min, int numbersQuantity, double average) {

		this.max = max;
		this.min = min;
		this.numbersQuantity = numbersQuantity;
		this.average = average;
	}

	public int getMax() {
		return max;
	}

	public void setMax(int max) {
		this.max = max;
	}

	public int getMin() {
		return min;
	}

	public void setMin(int min) {
		this.min = min;
	}

	public int getNumbersQuantity() {
		return numbersQuantity;
	}

	public void setNumbersQuantity(int numbersQuantity) {
		this.numbersQuantity = numbersQuantity;
	}

	public double getAverage() {
		return average;
	}

	public void setAverage(double average) {
		this.average = average;
	}

	public void minValue(List<Integer> numbers) {
		int min = 0;
		for (Integer number : numbers) {
			if (min == 0) {
				min = number;
			}

			if (number <= min) {

				min = number;

				setMin(min);

			}

		}

	}

	public void maxValue(List<Integer> numbers) {
		int max = 0;
		for (Integer number : numbers) {
			if (max == 0) {
				max = number;
			}

			if (number > max) {
				max = number;
				setMax(max);
			}

		}

	}

	public void quantitynumbers(List<Integer> numbers) {
		setNumbersQuantity(numbers.size());

	}

	public void averageNumbers(List<Integer> numbers) {
		double soma = 0;
		for (Integer number : numbers) {

			soma += number;

		}

		double avarage = soma / numbers.size();

		setAverage(avarage);

	}

}
