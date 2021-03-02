package Entities.NumerosFelizes;

public class HappyNumbers {

	public char[] transformArray;
	public int[] convert;
	public int soma = 0;

	public String quadArray(int number) {
		String transformNumber = "";
		if (number != 1 || number > 1) {
			int checkNumber = (int) Math.pow(number, 2);
			transformNumber = Integer.toString(checkNumber);

			TransformArrayInChar(transformNumber);

		}
		return transformNumber;

	}

	public void TransformArrayInChar(String arrayInString) {
		transformArray = null;
		transformArray = arrayInString.toCharArray();

		transformInIntegerArray(transformArray);

	}

	public void transformInIntegerArray(char[] transformArryChar) {
		convert = null;
		convert = new int[transformArryChar.length];

		for (int i = 0; i < transformArryChar.length; i++) {

			convert[i] = Integer.parseInt(String.valueOf(transformArryChar[i]));

		}
		sumNumbers(convert);
	}

	public int[] allNumbers() {

		return convert;

	}

	public void sumNumbers(int[] numbers) {
		soma = 0;
		for (int i : numbers) {
			soma += (int) Math.pow(i, 2);
			// System.out.println("Soma dos números: " + soma);
			if (soma != 1) {
				quadArrayInt(soma);
			}

		}

	}

	public String quadArrayInt(int number) {
		String transformNumber = "";

		transformNumber = Integer.toString(number);

		System.out.println("String do número: " + transformNumber);
		TransformInChar(transformNumber);
		return transformNumber;

	}

	public void TransformInChar(String arrayInString) {
		transformArray = null;
		transformArray = arrayInString.toCharArray();

		transformInInteger(transformArray);

	}

	public void transformInInteger(char[] transformArryChar) {
		convert = null;
		convert = new int[transformArryChar.length];
		try {
			for (int i = 0; i < transformArryChar.length; i++) {

				convert[i] = Integer.parseInt(String.valueOf(transformArryChar[i]));
				// System.out.println(convert[i]);

			}

		} catch (StackOverflowError e) {
			System.out.println(e.getMessage());
		}

	}

}
