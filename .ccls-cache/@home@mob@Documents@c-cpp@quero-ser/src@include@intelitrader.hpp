#ifndef ANALYTICS_HPP
#define ANALYTICS_HPP

#include <fstream>
#include <unordered_map>
#include <stack>

#define SALE_NOT_FINALIZED 190
#define SALE_CANCELED 135
#define PAYMENT_OK 100
#define PAYMENT_PENDENT 102
#define ERROR_UNKNOWN 999

enum CHANNEL
{
  Representative = 1,
  Website,
  Appmovel,
  Appiphone
};


// @brief: Open file for analysis securely
class FileDescriptor
{
 private:
  std::fstream m_fs; // stream for write and read
  char *m_FileBlock; // allocation buffer file
  int m_FileSize; // size file

 public:
  FileDescriptor();
  ~FileDescriptor();

  // TODO: possbile parser in block for analisys
  void openFile ( const char *, std::ios_base::openmode  ); // open file for read
  char *readFile(); // read buffer file and allocate
  void writeFile ( const char*,const char *, std::ios_base::openmode ); // write file
  int sizeFile(); // return file size
};


// Parser file for analisys archives
class Analytics : public FileDescriptor
{
 private:
  // Struct to parser Sales
  struct Sale
  {
    int64_t Code,
        Amount,
        Situation,
        Canal,
        Line = 0;
        
  } m_StatusSale;
  std::stack<Sale> m_SalesStack; // store sales in stack
  

  // Struct to parser Products
  struct Product
  {
    int64_t Code,
        AmountIventory,
        AmountMinimum,
        AmountIventorySales,
        AmountNecess = 0,
        AmountTrans ,
        AmountSales = 0;
              
  } m_StatusProduct;
  std::unordered_map<int, Product> m_productsMap; // store products in hashmap

  void parserFileSales(); // parser file Sales
  void parserFileProducts(); // parser file Products
  
  void analisysArchive();
  std::string m_buffer_str; // buffer in string style C++ for parser 
  
 public:
  Analytics();
  ~Analytics();
  
  // set archives for valid and parser
  void setFilesAnalytics ( const char *, const char * );
};


#endif // ANALYTICS_HPP
