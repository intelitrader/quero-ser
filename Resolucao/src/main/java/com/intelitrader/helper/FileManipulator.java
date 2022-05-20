package com.intelitrader.helper;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;
import java.io.IOException;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;

public class FileManipulator {
    public static Collection<String> readFile(String filePath){
        Stream<String> lines;
        try (FileReader fileReader = new FileReader(filePath)){
            BufferedReader bufferedReader = new BufferedReader(fileReader);
            lines = bufferedReader.lines();
            return  lines.collect(Collectors.toList());
        } catch (IOException e) {
            lines = Stream.of();
            e.printStackTrace();
        }
        return List.of();
    }
}
