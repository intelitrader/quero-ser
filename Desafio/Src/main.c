#include <stdio.h>
#include <stdlib.h>
#include <memory.h>

#define TABLE_DEFAULT_CAP 1024

enum
{
    ORDER_OK = 100,
    ORDER_PENDING = 102,
    ORDER_CANCELED = 135,
    ORDER_FAILED = 190,
    ORDER_PRODUCTID_NOT_FOUND = 998,
    ORDER_UNKNOWN_ERROR = 999
};

enum
{
    PLATFORM_PERSON = 1,
    PLATFORM_WEB,
    PLATFORM_ANDROID,
    PLATFORM_IOS
};

typedef struct Product
{
    int Id;
    int Quantity;
    int MinimumQuantity;
    int SalesQuantity;
    
} Product;

typedef struct ProductTable
{
    int Count;
    int Capacity;
    
    int OrdersPerson;
    int OrdersWeb;
    int OrdersAndroid;
    int OrdersIOS;
    
    Product *Products;
} ProductTable;

static void RegisterOrder(ProductTable *ProductList, int ProductIndex, int QuantitySold, int SalePlatform)
{
    if (ProductIndex != -1)
    {
        ProductList->Products[ProductIndex].SalesQuantity += QuantitySold;
    }
    
    // Register sales platform
    switch (SalePlatform)
    {
        case PLATFORM_PERSON:
        {
            ProductList->OrdersPerson += QuantitySold;
            break;
        }
        case PLATFORM_WEB:
        {
            ProductList->OrdersWeb += QuantitySold;
            break;
        }
        case PLATFORM_ANDROID:
        {
            ProductList->OrdersAndroid += QuantitySold;
            break;
        }
        case PLATFORM_IOS:
        {
            ProductList->OrdersIOS += QuantitySold;
            break;
        }
    }
}

void LogDivergence(FILE *LogFile, int Status, int Line, int ProductId)
{
    if (Status == ORDER_CANCELED)
    {
        fprintf(LogFile, "Linha %d - Venda cancelada\n", Line);
    }
    else if (Status == ORDER_FAILED)
    {
        fprintf(LogFile, "Linha %d - Venda não finalizada\n", Line);
    }
    else if (Status == ORDER_PRODUCTID_NOT_FOUND)
    {
        fprintf(LogFile, "Linha %d - Código de Produto não encontrado %d\n", Line, ProductId);
    }
    else if (Status == ORDER_UNKNOWN_ERROR)
    {
        fprintf(LogFile,"Linha %d - Erro desconhecido. Acionar equipe de TI\n", Line);
    }
}

/* Parses the Product File and build a list with all the products */
ProductTable BuildProductList(char *FileBuffer, int FileSize)
{
    ProductTable ProductList = {0};
    
    int ProductId = 0;
    int Quantity = 0;
    int MinimumQuantity = 0;
    int SalesQuantity = 0;
    
    int ProductCount = 0;
    int ProductCapacity = TABLE_DEFAULT_CAP;
    
    Product *Products = (Product *)calloc(ProductCapacity, sizeof(Product));
    
    if (!Products) return ProductList;
    
    char *BeginStr = &FileBuffer[0];
    
    printf("Criando lista de produtos - ");
    
    int Success = 1;
    
    // Parse the products buffer and build products table
    int i = 0;
    while (i <= FileSize)
    {
        char c0 = FileBuffer[i];
        char c1 = FileBuffer[i + 1];
        
        // end of file
        if (c1 == '\0')
        {
            MinimumQuantity = atoi(BeginStr);
            
            // Reallocate
            if (ProductCount >= ProductCapacity)
            {
                ProductCapacity *=  2;
                Product *OldProducts = Products;
                Products = (Product *)realloc(Products, ProductCapacity * sizeof(Product));
                
                if (Products == NULL)
                {
                    free(OldProducts);
                    break;
                    Success = 0;
                }
            }
            // Make entry into the products table
            Products[ProductCount].Id = ProductId;
            Products[ProductCount].Quantity = Quantity;
            Products[ProductCount].MinimumQuantity = MinimumQuantity;
            Products[ProductCount].SalesQuantity = 0;
            
            ProductCount++;
            
            break;
        }
        // Windows EOL
        else if ((c0 == '\r') && (c1 == '\n'))
        {
            // EOL is the third delimiter
            FileBuffer[i] = '\0';
            i += 2;
            
            MinimumQuantity = atoi(BeginStr);
            BeginStr = &FileBuffer[i];
            
            // Reallocate
            if (ProductCount >= ProductCapacity)
            {
                ProductCapacity *= 2;
                Product *OldProducts = Products;
                Products = (Product *)realloc(Products, ProductCapacity * sizeof(Product));
                
                if (Products == NULL)
                {
                    free(OldProducts);
                    break;
                    Success = 0;
                }
            }
            // Make entry into the products table
            Products[ProductCount].Id = ProductId;
            Products[ProductCount].Quantity = Quantity;
            Products[ProductCount].MinimumQuantity = MinimumQuantity;
            Products[ProductCount].SalesQuantity = 0;
            
            ProductCount++;
            
            ProductId = 0;
            Quantity = 0;
            MinimumQuantity = 0;
        }
        // Unix EOL
        else if (c0 == '\n')
        {
            FileBuffer[i++] = '\0';
            MinimumQuantity = atoi(BeginStr);
            BeginStr = &FileBuffer[i];
            
            // Reallocate
            if (ProductCount >= ProductCapacity)
            {
                ProductCapacity *= 2;
                Product *OldProducts = Products;
                Products = (Product *)realloc(Products, ProductCapacity * sizeof(Product));
                
                if (Products == NULL)
                {
                    free(OldProducts);
                    break;
                    Success = 0;
                }
            }
            // Make entry into the products table
            Products[ProductCount].Id = ProductId;
            Products[ProductCount].Quantity = Quantity;
            Products[ProductCount].MinimumQuantity = MinimumQuantity;
            Products[ProductCount].SalesQuantity = 0;
            
            ProductCount++;
            ProductId = 0;
            Quantity = 0;
            MinimumQuantity = 0;
        }
        // delimiter
        else if (c0 == ';')
        {
            FileBuffer[i++] = '\0';
            
            // ProductId is set to 0, hit first delimiter
            if (!ProductId)
            {
                ProductId = atoi(BeginStr);
            }
            // hit second delimiter
            else
            {
                Quantity = atoi(BeginStr);
            }
            BeginStr = &FileBuffer[i];
        }
        else
        {
            i++;
        }
    }
    
    printf("%s - %d produtos encontrados\n", Success ? "SUCESSO" : "FALHA", ProductCount);
    
    ProductList.Count = ProductCount;
    ProductList.Capacity = ProductCapacity;
    ProductList.Products = Products;
    
    return ProductList;
}

/* Search for an product id in the product list.
  *  Returns the index of the product if found, -1 otherwise
*/
int SearchProductTable(ProductTable *Table, int ProductId)
{
    int Min = 0;
    int Max = Table->Count;
    
    int Index = -1;
    
    while (Min <= Max)
    {
        int Middle = (Max + Min) / 2;
        
        // update and set found var
        if (ProductId == Table->Products[Middle].Id)
        {
            Index = Middle;
            break;
        }
        else if (ProductId < Table->Products[Middle].Id)
        {
            Max = Middle - 1;
        }
        else if (ProductId > Table->Products[Middle].Id)
        {
            Min = Middle + 1;
        }
    }
    return Index;
}

int main(int argc, char **argv)
{
    // Usage
    if (argc != 3)
    {
        printf("Uso: %s [VENDAS.TXT] [PRODUTOS.TXT]\n", argv[0]);
        return 1; 
    }
    char *OrdersFilename   = argv[1];
    char *ProductsFilename = argv[2];
    
    FILE *OrdersFileHandle = fopen(OrdersFilename, "rb");
    if (OrdersFileHandle == NULL)
    {
        printf("Erro ao abrir arquivo (%s)\n", OrdersFilename);
        return 1;
    }
    
    FILE *ProductsFileHandle = fopen(ProductsFilename, "rb");
    if (ProductsFileHandle == NULL)
    {
        printf("Erro ao abrir arquivo (%s)\n", ProductsFilename);
        return 1;
    }
    
    // getting the size of the PRODUTOS.TXT file
    fseek(ProductsFileHandle, 0, SEEK_END);
    int ProductsFilesize  = ftell(ProductsFileHandle);
    fseek(ProductsFileHandle, 0, SEEK_SET);
    
    // getting the size of the VENDAS.TXT file
    fseek(OrdersFileHandle, 0, SEEK_END);
    int OrdersFilesize  = ftell(OrdersFileHandle);
    fseek(OrdersFileHandle, 0, SEEK_SET);
    
    char *ProductsBuffer = (char *)malloc(ProductsFilesize + 1);
    if (ProductsBuffer == NULL)
    {
        printf("Erro inesperado\n");
        return 1;
    }
    ProductsBuffer[ProductsFilesize] = '\0';
    
    char *OrdersBuffer = (char *)malloc(OrdersFilesize + 1);
    if (OrdersBuffer == NULL)
    {
        printf("Erro inesperado\n");
        return 1;
    }
    
    OrdersBuffer[OrdersFilesize] = '\0';
    
    fread(ProductsBuffer, 1, ProductsFilesize, ProductsFileHandle);
    fclose(ProductsFileHandle);
    
    // Build the products table 
    ProductTable ProductList = BuildProductList(ProductsBuffer, ProductsFilesize);
    
    int ProductId = 0;
    int QuantitySold = 0;
    int SaleStatus = 0;
    int SalePlatform = 0;
    int CurrentLine = 1;
    
    // parse the orders buffer and search and update the products table
    fread(OrdersBuffer, 1, OrdersFilesize, OrdersFileHandle);
    fclose(OrdersFileHandle);
    
    char *BeginStr = &OrdersBuffer[0];
    
    FILE *DivergenciasFile = fopen("divergencias.txt", "w");
    if (!DivergenciasFile)
    {
        printf("Erro: Falha na criacao de arquivo divergências.txt\n");
        return 1;
    }
    
    printf("Gerando Arquivo de Divergências.\n");
    
    int i = 0;
    while (i <= OrdersFilesize)
    {
        char c0 = OrdersBuffer[i];
        char c1 = OrdersBuffer[i + 1];
        
        // end of file
        if (c1 == '\0')
        {
            SalePlatform = atoi(BeginStr);
            
            if ((SaleStatus == ORDER_OK) || (SaleStatus == ORDER_PENDING))
            {
                int Index = SearchProductTable(&ProductList, ProductId);
                RegisterOrder(&ProductList, Index, QuantitySold, SalePlatform);
                
                // Could not find product
                if (Index == -1)
                {
                    LogDivergence(DivergenciasFile, ORDER_PRODUCTID_NOT_FOUND, CurrentLine, ProductId);
                }
            }
            else
            {
                LogDivergence(DivergenciasFile, SaleStatus, CurrentLine, 0);
            }
            
            break;
        }
        // Windows EOL ('\r''\n')
        else if ((c0 == '\r') && (c1 == '\n'))
        {
            // EOL is the  delimiter
            OrdersBuffer[i] = '\0';
            i += 2;
            
            SalePlatform = atoi(BeginStr);
            BeginStr = &OrdersBuffer[i];
            
            if ((SaleStatus == ORDER_OK) || (SaleStatus == ORDER_PENDING))
            {
                int Index = SearchProductTable(&ProductList, ProductId);
                RegisterOrder(&ProductList, Index, QuantitySold, SalePlatform);
                
                // Could not find product
                if (Index == -1)
                {
                    LogDivergence(DivergenciasFile, ORDER_PRODUCTID_NOT_FOUND, CurrentLine, ProductId);
                }
            }
            else
            {
                LogDivergence(DivergenciasFile, SaleStatus, CurrentLine, 0);
            }
            
            ProductId = 0;
            QuantitySold = 0;
            SaleStatus = 0;
            SalePlatform = 0;
            CurrentLine++;
        }
        
        // UNIX EOL ('\n')
        else if (c0 == '\n')
        {
            // EOL is the  delimiter
            OrdersBuffer[i++] = '\0';
            
            SalePlatform = atoi(BeginStr);
            
            if ((SaleStatus == ORDER_OK) || (SaleStatus == ORDER_PENDING))
            {
                int Index = SearchProductTable(&ProductList, ProductId);
                RegisterOrder(&ProductList, Index, QuantitySold, SalePlatform);
                
                // Could not find product
                if (Index == -1)
                {
                    LogDivergence(DivergenciasFile, ORDER_PRODUCTID_NOT_FOUND, CurrentLine, ProductId);
                }
            }
            else
            {
                LogDivergence(DivergenciasFile, SaleStatus, CurrentLine, 0);
            }
            
            BeginStr = &OrdersBuffer[i];
            
            ProductId = 0;
            QuantitySold = 0;
            SaleStatus = 0;
            SalePlatform = 0;
            CurrentLine++;
        }
        // delimiter
        else if (c0 == ';')
        {
            OrdersBuffer[i++] = '\0';
            
            // ProductId is set to 0, hit first delimiter
            if (!ProductId)
            {
                ProductId = atoi(BeginStr);
            }
            // hit second delimiter
            else if (!QuantitySold)
            {
                QuantitySold = atoi(BeginStr);
            }
            // third delimiter
            else
            {
                SaleStatus = atoi(BeginStr);
            }
            BeginStr = &OrdersBuffer[i];
        }
        else
        {
            i++;
        }
    }
    
    fclose(DivergenciasFile);
    
    // Log Total of orders across platforms
    FILE *TransfereFile = fopen("transfere.txt", "w");
    if (!TransfereFile)
    {
        printf("Erro: Falha na criação de arquivo transfere.txt\n");
        return 1;
    }
    
    printf("Gerando tranferencias\n");
    
    fprintf(TransfereFile, "Necessidade de Transferência Armazém para CO\n\n");
    
    fprintf(TransfereFile,
            "Produto    QtCO    QtMin    QtVendas    Estq.após    Necess.    Transf. de\n");
    fprintf(TransfereFile,
            "                                                     Vendas     Arm p/ CO\n");
    
    for (int i = 0; i < ProductList.Count; i++)
    {
        int Id = ProductList.Products[i].Id;
        int QtCO = ProductList.Products[i].Quantity;
        int QtMin = ProductList.Products[i].MinimumQuantity;
        int QtVendas = ProductList.Products[i].SalesQuantity;
        int EstAposVendas = QtCO - QtVendas;
        
        int TransferQuantity = 0;
        
        if (EstAposVendas < 0)
        {
            TransferQuantity = abs(EstAposVendas) + QtMin;
        }
        else if (EstAposVendas < QtMin)
        {
            TransferQuantity = QtMin - EstAposVendas;
        }
        
        int TransferToOP = TransferQuantity;;
        if ((TransferQuantity > 0) && TransferQuantity < 10)
        {
            TransferToOP = 10;
        }
        
        fprintf(TransfereFile,
                "%5d     %5d    %5d       %5d        %5d      %5d        %5d\n",
                Id, QtCO, QtMin, QtVendas, EstAposVendas, TransferQuantity, TransferToOP);
    }
    
    fclose(TransfereFile);
    
    // Log Total of orders across platforms
    FILE *TotalCanalFile = fopen("totcanal.txt", "w");
    if (!TotalCanalFile)
    {
        printf("Erro: Falha na criação de arquivo totcanal.txt\n");
        return 1;
    }
    
    printf("Gerando total de vendas por canal\n");
    
    fprintf(TotalCanalFile, "Quantidade de Vendas por canal\n\n");
    fprintf(TotalCanalFile, "Canal                    QtVendas\n");
    fprintf(TotalCanalFile,  "1 - Representantes          %5d\n", ProductList.OrdersPerson);
    fprintf(TotalCanalFile,  "2 - Website                 %5d\n", ProductList.OrdersWeb);
    fprintf(TotalCanalFile,  "3 - App móvel Android       %5d\n", ProductList.OrdersAndroid);
    fprintf(TotalCanalFile,  "4 - App móvel iPhone        %5d\n",   ProductList.OrdersIOS);
    
    fclose(TotalCanalFile);
    
    return 0;
}
