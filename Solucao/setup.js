const ReadData = require('./src/ReadData');
const CleanData = require('./src/CreateFileContent');
const NewFile = require('./src/NewFile');

const brute_data = ReadData();
const filescontent = CleanData.CreateFileContent(brute_data);
try {
    NewFile.CreateTransfere("TRANSFERE.txt", filescontent.vendas);
    NewFile.CreateTotCanais("TOTCANAIS.txt", filescontent.canais);
    NewFile.CreateDivergencias("DIVERGENCIAS.txt", filescontent.divergencias);
} catch (error) {
    console.log(error);
}

