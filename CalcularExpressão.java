package principal;

import java.util.Scanner;
import java.util.Stack;

/*
 * 
 * desafio: Avaliando expressões matemáticas
 * url: https://dojopuzzles.com/problems/avaliando-expressoes-matematicas/
 * 
 */

public class CalcularExpressão {

	public static String infixaParaPosfixa(String expressao) {

		expressao += ".";
		char[] exp = expressao.toCharArray();
		
		int i = 0;
		char op;
		Stack<Character> stack = new Stack<Character>();
		String convertido = "";

		while (exp[i] != '.') {
			op = exp[i];

			if (operador(op)) {

				if (stack.isEmpty()) {

					if (op == '(') {
						while (op != ')') {

							if (operador(op)) {
								if (stack.isEmpty() || stack.peek() == '(' || prioridade(stack.peek()) < prioridade(op)) {
									stack.push(op);
								} else {
									convertido += stack.peek();
									stack.pop();
									stack.push(op);
								}
							} else {
								convertido += op;
							}
							i++;
							op = exp[i];

						}
						stack.push(op);
						i++;
					} else {
						stack.push(op);
						i++;
					}
				} else {

					if (prioridade(stack.peek()) < prioridade(op) && op != ')' || op == '(') {
						if (op == '(') {
							while (op != ')') {

								if (operador(op)) {
									if (stack.isEmpty() || stack.peek() == '('
											|| prioridade(stack.peek()) < prioridade(op)) {
										stack.push(op);
									} else {
										convertido += stack.peek();
										stack.pop();
										stack.push(op);
									}
								} else {
									convertido += op;
								}
								i++;
								op = exp[i];

							}
							stack.push(op);
							i++;
						} else {
							stack.push(op);
							i++;
						}

					} else {
						if (stack.peek() == ')') {
							while (stack.peek() != '(') {
								if (stack.peek() != ')') {
									convertido += stack.peek();
								}
								stack.pop();
							}
							stack.pop();
							stack.push(op);
							i++;
						} else {
							if (stack.peek() != '(' && stack.peek() != ')') {
								convertido += stack.peek();
							}
							stack.pop();
							if (op != ')') {
								stack.push(op);
							}

							i++;
						}

					}

				}

			} else {

				convertido += op;
				i++;
			}

		}

		while (!stack.isEmpty()) {
			if (stack.peek() != ')' && stack.peek() != '(') {
				convertido += stack.peek();
			}
			stack.pop();
		}

		return convertido;
	}

	public static double calcExpressaoInfixa(String expressao) {
		
		expressao = expressao.replaceAll(" ", "");
		expressao = infixaParaPosfixa(expressao);
		expressao += ".";
		char[] exp = expressao.toCharArray();

		int i = 0;
		char op;
		String transforma;
		int aux = 0;
		int soma = 0;
		Stack<Character> stack = new Stack<Character>();

		while (exp[i] != '.') {
			op = exp[i];

			if (!operador(op)) {
				stack.push(op);
				i++;
			} else {
				while (operador(op)) {

					aux = conversor(stack.pop());
					switch (op) {
					case '+':
						soma = conversor(stack.peek()) + aux;
						break;
					case '-':
						soma = conversor(stack.peek()) - aux;
						break;
					case '*':
						soma = conversor(stack.peek()) * aux;
						break;
					case '/':
						soma = conversor(stack.peek()) / aux;
						break;
					case '^':
						soma = (int) Math.pow(conversor(stack.peek()), aux);
						break;
					}
					stack.pop();
					stack.push((char) soma);
					i++;
					op = exp[i];
				}
			}
		}
		
		stack.pop();
		
		if(!stack.isEmpty()) {
			return soma + stack.pop();
		}
				
		return soma;
	}
	
	public static boolean operador(char s) {
		return (s == '+' || s == '-' || s == '(' || s == ')' || s == '*' || s == '/' || s == '^' || s == '¬' || s == '∧' || s == 'v' || s == '↔');
	}

	public static int prioridade(char s) {

		switch (s) {
		case '+':
			return 1;
		case '-':
			return 2;

		case '*':
			return 3;
			
		case '/':
			return 4;
			
		case '^':
		    return 5;
		case 'v':
			return 6;
		case '∧':
			return 7;
		case '¬':
			return 8;
		case '↔':
			return 9;
		case '(':
		case ')':
			return 10;
		}
		return 0;
	}
	
	public static int conversor(char topo) {

		int convertido;

		try {
			convertido = Integer.parseInt(topo + "");
		} catch (Exception e) {
			convertido = (int) topo;
		}

		return convertido;
	}
	
	public static void main(String[] args) {
		
		try (Scanner scn = new Scanner(System.in)) {
			
			System.out.print("Escreva a expressão para calcular seu valor: ");
			String expressaoInfixa = scn.nextLine();
			
			System.out.println(expressaoInfixa + " = " + calcExpressaoInfixa(expressaoInfixa));
			
			
		}catch (Exception e) {
			System.out.println("Escreva uma expressão válida.");
		}
		
		
	}
}
