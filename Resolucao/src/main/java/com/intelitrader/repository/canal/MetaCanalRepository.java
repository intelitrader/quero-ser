package com.intelitrader.repository.canal;

import com.intelitrader.entity.balanco.Balanco;
import com.intelitrader.entity.canal.MetaCanal;
import com.intelitrader.repository.Write;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

public class MetaCanalRepository implements Write<MetaCanal> {
    private final String filepath;

    public MetaCanalRepository() throws IOException {
        this.filepath = "./output";
    }

    @Override
    public void saveAll(Collection<MetaCanal> objects) {
        Collection<String> lines = getLines(objects);
        createDir();
        try(BufferedWriter writer = new BufferedWriter(new FileWriter(this.filepath+"/totcanais.txt"))){
            writer.write("Quantidades de Vendas por canal\n");
            writer.append("\n");
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

    private List<String> getLines(Collection<MetaCanal> objects){
        return objects.stream()
                .map(this::createFormattedString)
                .collect(Collectors.toList());
    }

    private String createFormattedString(MetaCanal metaCanal){
        return String.format("%1s - %-25s %20s",metaCanal.canal().getCodigo(), metaCanal.canal().getTexto(), metaCanal.total());
    }
}
