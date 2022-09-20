#include <iostream>
#include <fstream>
#include <string>
#include <map>
#include <vector>
#include <utility>
#include <sstream>
#include <iomanip>

using namespace std;

// FUNCTION HEADERS
std::vector<int> explode(std::string const & s, char delim);

/**
 * Type to define products
 * 
 * map["product id"][0] - QtCO
 * map["product id"][1] - QtMin
 * map["product id"][2] - QtVendas
 * map["product id"][3] - Estq.apos Vendas
 * map["product id"][4] - Necess
 * map["product id"][5] - Transf. de Arm p/ CO
*/
typedef std::map<int, std::array<int, 6> > Products;

int main(int argc, char *argv[]){

    string path1{};
    string path2{};

    Products productList{};

    // GET ARGUMENTS IN INICIALIZATION
    if (argc == 3){
        // A ORDEM DE INSERCAO REFLETE NO FUNCIONAMENTO, OS ARGUMENTOS DEVEM SER RESPECTIAMENTE PRODUTOS E VENDAS.
        path1 = argv[1];
        path2 = argv[2];
    }else{
        cout << "As entradas deverão ser os caminhos dos PRODUTOS.txt e VENDAS.txt" << endl;
        return 0;
    }

    // Put read data file into a stream
    ifstream streamProducts(path1);
    ifstream streamSales(path2);

    string product;
    string sell;

    std::vector<string> products;
    std::vector<string> divergences; // Transformar em um stream
    
    /*
        0: Representante comercial 
        1: Website 
        2: Aplicativo móvel Ansdroid 
        3: Aplicativo móvel iPhone
    */
    int salesBySector[4][1]{}; // Vendas por setor

    // PUT PRODUCTS INTO A MAP AND FILL ANOTHER ATTRIBUTES WITH ZERO
    if (streamProducts.is_open()){
        while( getline(streamProducts, product)){
            auto tempArray = explode(product, ';');
            
            // INSERT PRODUCTS INTO MAP
            productList.insert(std::pair<int, std::array<int, 6>>(tempArray[0], {tempArray[1], tempArray[2], 0, 0, 0, 0}));
        }

        streamProducts.close();

    }else{
        cout << "File products is not open" << endl; 
        return 0;
    }

    // SALES PROCESSOR
    if (streamSales.is_open()){
        int line{1};
        while( getline(streamSales, sell)){

            auto tempArray = explode(sell, ';');

            if (tempArray[2] == 100 || tempArray[2] == 102) {
                if (productList.find(tempArray[0]) != productList.end()){
                    productList[tempArray[0]][2] +=  tempArray[1]; // UPDATE SALES QUANTITY
                    productList[tempArray[0]][3] =  productList[tempArray[0]][0] - productList[tempArray[0]][2]; // UPDATE INVENTORY
                    if (productList[tempArray[0]][3] < productList[tempArray[0]][1]){
                        productList[tempArray[0]][4] = productList[tempArray[0]][1] - productList[tempArray[0]][3];
                    }

                    if(productList[tempArray[0]][4] <= 0){
                        productList[tempArray[0]][5] = 0;
                    }else if(productList[tempArray[0]][4] <= 10) {
                        productList[tempArray[0]][5] = 10;
                    }else {
                        productList[tempArray[0]][5] = productList[tempArray[0]][4];
                    }
                }

                // UPDATE SALES BY CHANNEL
                switch (tempArray[3])
                {
                case 1:
                    salesBySector[0][0]+=tempArray[1];
                    break;
                case 2:
                    salesBySector[1][0]+=tempArray[1];
                    break;
                case 3:
                    salesBySector[2][0]+=tempArray[1];
                    break;
                case 4:
                    salesBySector[3][0]+=tempArray[1];
                    break;
                default:
                    break;
                }

            }
            
            if (tempArray[2] == 135) {
                divergences.push_back("Linha "+ std::to_string(line) +" – Venda cancelada");
            }

            if (tempArray[2] == 190) {
                divergences.push_back("Linha "+ std::to_string(line) +" – Venda não finalizada");
            }

            if (tempArray[2] == 999) {
                divergences.push_back("Linha "+ std::to_string(line) +" – Erro desconhecido. Acionar equipe de TI");
            }

            else if (productList.find(tempArray[0]) == productList.end()){
                string stringToPush;
                stringToPush = "Linha " + std::to_string(line) + " – Código de Produto não encontrado " + std::to_string(tempArray[0]);
                divergences.push_back(stringToPush);
            }
 
            ++line;
        }
    }else{
        cout << "streamProducts is not open" << endl; 
        return 0;
    }

    // GENERATE DIVERGENCIAS.txt

    ofstream diverencesStream;
    diverencesStream.open("../Outputs/DIVERGENCIAS.txt");

    for (auto it = divergences.begin(); it != divergences.end(); ++it){
        diverencesStream << *it << endl;
    }
    diverencesStream.close();
    
    // GENERATE TOTCANAIS.txt

    ofstream totCanalStream;
    totCanalStream.open("../Outputs/TOTCANAIS.txt");

    totCanalStream << "Quantidades de Vendas por canal" << endl;
    totCanalStream << endl;
    totCanalStream << "Canal                  QtVendas" << endl;
    totCanalStream << "1 - Representantes          " <<  salesBySector[0][0] << endl;
    totCanalStream << "2 - Website                 " <<  salesBySector[1][0] << endl;
    totCanalStream << "3 - App móvel Android       " <<  salesBySector[2][0] << endl;
    totCanalStream << "4 - App móvel iPhone         " <<  salesBySector[3][0] << endl;

    totCanalStream.close();

    // GENERATE transfere.txt
    ofstream transfereStream;
    transfereStream.open("../Outputs/transfere.txt");

    transfereStream << "Necessidade de Transferência Armazém para CO" << endl << endl;
    transfereStream << "Produto  QtCO  QtMin  QtVendas  Estq.após  Necess.  Transf. de" << endl;
    transfereStream << "                                   Vendas            Arm p/ CO" << endl;

    for (auto it = productList.begin(); it != productList.end(); ++it){
        auto code = it->first;
        auto arr = it->second;
        transfereStream << code << setw(8) << arr[0] << setw(7) << arr[1] << setw(9) << arr[2]<< setw(12) << arr[3]<< setw(8) << arr[4]<< setw(13) << arr[5] << endl;
    }

     transfereStream.close();

    return 0;
}

//To get archive line and separate in an array by ';'
std::vector<int> explode(std::string const & s, char delim)
{
    std::vector<int> result;
    std::istringstream iss(s);

    for (std::string token; std::getline(iss, token, delim); )
    {
        result.push_back(std::move(std::stoi( token )));
    }

    return result;
}

