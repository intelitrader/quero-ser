package com.intelitrader.repository.conflito;

import com.intelitrader.entity.balanco.Balanco;
import com.intelitrader.entity.conflito.Conflito;
import com.intelitrader.repository.Write;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

public class ConflitoRepository implements Write<Conflito> {
    private final String filepath;

    public ConflitoRepository() throws IOException {
        this.filepath = "./output";
    }

    @Override
    public void saveAll(Collection<Conflito> objects) {
        Collection<String> lines = getLines(objects);
        createDir();
        try(BufferedWriter writer = new BufferedWriter(new FileWriter(this.filepath+"/divergencias.txt"))){
            for(String line: lines)
                writer.append(line).append("\n");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    public String getFilepath(){
        return this.filepath;
    }

    private void createDir(){
        File file = new File(this.filepath);
        if(!file.exists())
            file.mkdirs();
    }

    private List<String> getLines(Collection<Conflito> objects){
        return objects.stream()
                .map(this::createFormattedString)
                .collect(Collectors.toList());
    }

    private String createFormattedString(Conflito conflito){
        return String.format("Linha %s - %s", conflito.linha(), conflito.descricao());
    }
}
