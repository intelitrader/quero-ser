package br.com.programadorNube.ControleEntrada;

import java.text.ParseException;
import java.util.Scanner;

import org.joda.time.DateTime;
import org.joda.time.format.DateTimeFormat;
import org.joda.time.format.DateTimeFormatter;

public class ControleEntradaMain {

	public static void main(String[] args) throws ParseException {
		DateTimeFormatter formatter = DateTimeFormat.forPattern("HH:mm:ss");
		
		//criei esse vetor para teste
		String[] entradas = {"00:06:46","00:28:09","00:34:59","01:05:37","01:09:03","01:09:48","01:10:51","01:18:15","01:44:13","01:49:13","02:04:46","02:10:25","02:15:36","02:20:08","02:20:52","02:32:04","02:35:27","02:50:28","03:00:08","03:02:40","03:04:50","03:06:33","03:06:52","03:24:23","03:35:14","03:42:01","03:43:24","03:43:45","03:53:08","04:05:14","04:11:45","04:16:32","04:22:00","04:49:17","04:50:10","04:53:38","05:00:08","05:19:04","05:21:50","05:28:02","05:52:56","06:01:47","06:04:22","06:07:30","06:33:27","06:33:36","06:53:09","07:00:57","07:07:49","07:45:31","07:46:31","07:54:40","08:11:14","08:13:36","08:15:03","08:28:34","08:39:31","08:53:32","09:05:28","09:16:02","09:17:53","09:24:15","09:50:03","10:04:28","10:09:18","10:24:47","10:59:26","11:05:10","11:08:03","11:10:01","11:10:16","11:15:11","11:48:20","11:50:13","12:03:23","12:09:41","12:14:30","12:29:57","12:39:58","12:50:07","13:08:13","13:20:11","13:27:16","13:34:48","13:35:06","13:53:49","14:02:25","14:02:56","14:20:11","14:28:45","14:29:15","14:29:57","14:49:20","14:57:44","15:01:06","15:14:30","15:15:18","15:17:00","15:38:31","15:46:36","15:48:17","15:55:03","16:05:05","16:15:37","16:26:43","16:35:41","16:47:49","16:53:09","16:53:37","17:08:51","17:31:03","18:07:01","18:07:05","18:09:49","18:12:30","18:25:01","18:40:05","18:53:04","18:57:24","19:31:56","19:39:49","19:56:33","20:02:03","20:08:13","20:09:08","20:09:17","20:09:36","20:10:21","20:11:11","20:12:17","20:20:53","20:34:11","20:41:06","21:00:30","21:03:40","21:03:44","21:09:04","21:19:04","21:20:03","21:31:13","21:58:58","22:19:06","22:32:59","22:57:17","23:12:40","23:23:06","23:32:33"}; 
		
		DateTime inicioExpediente = formatter.parseDateTime("10:00:00");
		DateTime fimExpediente = formatter.parseDateTime("16:00:00");
		
		int contagem =0;
		for (int i=0;i< entradas.length; i++) {
			DateTime entrada = formatter.parseDateTime(entradas[i]);
			if (entrada.isAfter(inicioExpediente) && entrada.isBefore(fimExpediente)) {
				contagem++;
							}
		}
		System.out.println("Total de clientes que entraram no banco " + entradas.length );
		System.out.println("Quantidade de clientes que entraram no banco no horário comercial: " + contagem);
		System.out.println("Quantidade de clientes que entraram no banco fora do horário comercial: " + (entradas.length-contagem));
	}

}
