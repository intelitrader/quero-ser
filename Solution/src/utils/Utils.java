package utils;

import java.io.BufferedReader;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;

public class Utils {
	public static ArrayList<String[]> readInputFile(String path) throws IOException {
		BufferedReader bf = 
				Files.newBufferedReader(Paths.get(path));
		
		ArrayList<String[]> lines = new ArrayList<String[]>();
		
		while(bf.ready()) {
			lines.add(bf.readLine().split(";"));
		}
		
		bf.close();
		return lines;
	}
}
