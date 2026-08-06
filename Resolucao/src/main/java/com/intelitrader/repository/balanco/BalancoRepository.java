package com.intelitrader.repository.balanco;

import com.intelitrader.entity.balanco.Balanco;
import com.intelitrader.repository.Write;

import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

public class BalancoRepository implements Write<Balanco> {
    private final String filepath;

    public BalancoRepository() throws IOException {
        this.filepath = "./output";
    }

    @Override
    public void saveAll(Collection<Balanco> objects) {
        Collection<String> lines = getLines(objects);
        createDir();
        try(BufferedWriter writer = new BufferedWriter(new FileWriter(this.filepath+"/transfere.txt"))){
            writer.write("Necessidade de Transferência Armazém para CO\n");
            writer.append("\n");
            String title = String.format("%-10s %-10s %-10s %-15s %-15s %-15s %-10s\n",
                    "Produto", "QtCO", "QtMin", "QtVendas", "Estq. após", "Necess.", "Transf. de");

            String subTitle = String.format("%55s %34s\n",
                    "Vendas", "Arm p/ CO");
            writer.append(title);
            writer.append(subTitle);

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

    private List<String> getLines(Collection<Balanco> objects){
        return objects.stream()
                .map(this::createFormattedString)
                .collect(Collectors.toList());
    }

    private String createFormattedString(Balanco balanco){
        return String.format("%7s %7s %11s %13s %17s %11s %19s",
                balanco.produto().codigo(),
                balanco.produto().quantidadeEstocada(),
                balanco.produto().quantidadeMinima(),
                balanco.totalVendido(),
                balanco.estoqueRestante(),
                balanco.necessidadeReposicao(),
                balanco.quantidadeAhTransferir()
            );
    }
}
