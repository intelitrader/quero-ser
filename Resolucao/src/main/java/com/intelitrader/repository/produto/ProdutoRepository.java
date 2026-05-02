package com.intelitrader.repository.produto;

import com.intelitrader.entity.produto.Produto;
import com.intelitrader.repository.Read;

import java.util.List;
import java.util.stream.Collectors;

import static com.intelitrader.helper.FileManipulator.readFile;

public class ProdutoRepository implements Read<Produto> {
    private final String filePath;

    public ProdutoRepository(String filePath){
        this.filePath = filePath;
    }

    @Override
    public List<Produto> getAll() {
        return readFile(this.filePath)
                .stream()
                .map((line) -> parse(line))
                .collect(Collectors.toList());
    }

    private Produto parse(String serialized){
        String[] splited = serialized.split(";", serialized.length());
        long codigo = Long.parseLong(splited[0]);
        long quantidadeEstoque = Long.parseLong(splited[1]);
        long quantidadeEstoqueMinima = Long.parseLong(splited[2]);

        return new Produto(codigo, quantidadeEstoque, quantidadeEstoqueMinima);
    }
}
