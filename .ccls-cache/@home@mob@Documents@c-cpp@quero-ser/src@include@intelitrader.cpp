#ifdef DEBUG
  #include <iostream>
#endif
#include <sys/stat.h>
#include <unordered_map>
#include <algorithm>
#include <math.h>
#include <sstream>
#include "intelitrader.hpp"

// ========== Manipulation Files ===========
FileDescriptor::FileDescriptor() : m_FileBlock ( nullptr ),
  m_FileSize ( 0 )
{

}

FileDescriptor::~FileDescriptor()
{
  if ( m_fs.is_open() )
    m_fs.close();

  if ( m_FileBlock != nullptr )
    delete[] m_FileBlock;

}

void FileDescriptor::openFile ( const char *p_path, std::ios_base::openmode mode = std::ios::in )
{
  if ( m_fs.is_open() )
    m_fs.close();

  m_fs.open ( p_path, mode );

  if ( !m_fs.is_open() )
    throw std::runtime_error ( std::string ( " path not found, verify path file '" ) + p_path + "'" );

  if ( !m_fs.good() )
    throw std::runtime_error ( std::string ( " Not possible opened file '" ) + p_path + "'" );

  // get size file
  m_fs.seekg ( 0, m_fs.end );
  m_FileSize = m_fs.tellg();
  m_fs.seekg ( 0, m_fs.beg );

}

char *FileDescriptor::readFile()
{
  if ( m_FileBlock != nullptr )
  {
    delete [] m_FileBlock;
    m_FileBlock = nullptr;
  }

  m_FileBlock = new char[m_FileSize * sizeof ( char )];

  m_fs.read ( m_FileBlock, m_FileSize );

  if ( !m_fs )
    throw std::runtime_error ( std::string ( " Not possible read file size " ) + std::to_string ( m_FileSize ) );

  return m_FileBlock;
}

void FileDescriptor::writeFile ( const char *p_path, const char *p_buffer, std::ios_base::openmode mode = std::ios::ate )
{
  openFile ( p_path, std::ios::out | mode );

  m_fs << p_buffer;

  m_fs.close();
}

int FileDescriptor::sizeFile()
{
  return m_FileSize;
}


// ========= Analytics Files ===========


Analytics::Analytics()
{

}

Analytics::~Analytics()
{
  m_buffer_str.clear();
}

void Analytics::parserFileSales()
{
#ifdef DEBUG
  std::cout << "[DEBUG] Parsing Files Sales\n\n";
#endif

  // TODO: find a suitable data structure for the products
  // parser flow o(n²)
  //
  //                   ↓          <-       <-         <-         <-
  // ptr  -> [ key;key;key;key ] -> [pass] -> [store] ->  [delete] ↑
  //         [ key;key;key;key ] ->        ->         ->     ->    ↑
  //                ...
  // OBS : the same flow goes for the product parser
  do
  {
    if ( m_buffer_str.size() < 5 )
      break;


    // [ parser ]
    m_StatusSale.Code = std::stoul ( m_buffer_str.substr ( 0, 5 ) ); // code position
    m_StatusSale.Amount = std::stoul ( m_buffer_str.substr ( 6 ) ); // amount position
    int lenghtAmount = log10 ( m_StatusSale.Amount ) + 2;
    m_StatusSale.Situation = std::stoul ( m_buffer_str.substr ( 6 + lenghtAmount ) ); // situation position
    int lenghtSituation = log10 ( m_StatusSale.Situation ) + 2;
    int positionCanal = 6 + lenghtAmount + lenghtSituation;
    m_StatusSale.Canal = std::stoul ( m_buffer_str.substr ( positionCanal ) ); // channel position

    m_StatusSale.Line++; // count lines

    // [ store ]
    m_SalesStack.push ( std::move ( m_StatusSale ) );

    // [ delete ]
    m_buffer_str.erase ( 0, positionCanal + log10 ( m_StatusSale.Canal ) + 2 );

    // debug parser
#ifdef DEBUG
    std::cout << "\tCode " << m_StatusSale.Code <<
              std::endl << "\tAmount " << m_StatusSale.Amount <<
              std::endl << "\tSituation " << m_StatusSale.Situation <<
              std::endl << "\tCanal " << m_StatusSale.Canal <<
              std::endl << "\tLine " << m_StatusSale.Line <<  "\n\n";

#endif

  } while ( m_buffer_str.size() > 7 );
}

void Analytics::parserFileProducts()
{
#ifdef DEBUG
  std::cout << "[DEBUG] Parsing File Products\n\n";
#endif

  int line = 0;

  do
  {
    int lenghtAmount = 0;
    line++;


    // [ parser ]
    m_StatusProduct.Code =  std::stoul ( m_buffer_str.substr ( 0, 5 ) );
    m_StatusProduct.AmountIventory = std::stoul ( m_buffer_str.substr ( 6 ) );
    lenghtAmount = log10 ( m_StatusProduct.AmountIventory ) + 2;
    m_StatusProduct.AmountMinimum = std::stoul ( m_buffer_str.substr ( 6 + lenghtAmount ) );

    // [ store ]
    std::pair<std::unordered_map<int, Product>::iterator, bool> ret;
    ret = m_productsMap.insert ( std::make_pair ( std::move ( m_StatusProduct.Code ), std::move ( m_StatusProduct ) ) );

    if ( ret.second == false )
      std::printf ( "[WARNING] Product duplicate, LINE %i CODE %li \n", line,  m_StatusProduct.Code );

    // [ delete ]
    m_buffer_str.erase ( 0, 6 + lenghtAmount + log10 ( m_StatusProduct.AmountMinimum ) + 2 );


    // debug parser
#ifdef DEBUG
    std::cout << "\tCode " << m_StatusProduct.Code <<
              std::endl << "\tIventary " << m_StatusProduct.AmountIventory <<
              std::endl << "\tMinimum " << m_StatusProduct.AmountMinimum << "\n\n";
#endif


  } while ( m_buffer_str.size() > 7 );

}

void Analytics::analisysArchive()
{
  mkdir ( "ANALYTICS", 0700 );
  // clean and create files
  writeFile ( "ANALYTICS/DIVERGENCIAS.txt", "" );
  writeFile ( "ANALYTICS/TOTCANAIS.txt", "" );
  writeFile ( "ANALYTICS/TRANSFERE.txt", "" );

  int   appiphone = 0,
        website = 0,
        representative = 0,
        appmovel = 0;

  std::string totcanal;
  while ( !m_SalesStack.empty() )
  {
    // [ DIVERGENCIAS ]
    {
      int code = m_SalesStack.top().Code;
      std::string line_str = std::to_string ( m_SalesStack.top().Line );

      if ( m_productsMap[code].Code == false )
      {
        const std::string error = "Linha - " + std::to_string ( m_SalesStack.top().Line ) +
                                  " - Código de Produto não encontrado " + std::to_string ( code ) + "\n";
        writeFile ( "ANALYTICS/DIVERGENCIAS.txt", error.data(), std::ios::ate | std::ios::app );
      }
      else
      {
        const std::string situation = [&]()
        {
          switch ( m_SalesStack.top().Situation )
          {
            case SALE_CANCELED:
              return "Linha - " + line_str + " - Venda cancelada\n";

            case SALE_NOT_FINALIZED:
              return  "Linha - " + line_str + " - Venda não finalizada\n";

            case ERROR_UNKNOWN:
              return "Linha - " + line_str + " - Erro desconhecido. Acionar equipe de TI\n";

            default:
              return std::string ( "\0" );
          }
        }
        ();

        if ( situation != "\0" )
          writeFile ( "ANALYTICS/DIVERGENCIAS.txt", situation.data(), std::ios::app );

        // [TOTCANAIS]
        int8_t canal = m_SalesStack.top().Canal;

        if ( m_SalesStack.top().Situation == PAYMENT_OK ||
             m_SalesStack.top().Situation == PAYMENT_PENDENT )
        {
          if ( canal == Representative )
            representative++;
          else if ( canal == Website )
            website++;
          else if ( canal == Appmovel )
            appmovel++;
          else if ( canal == Appiphone )
            appiphone++;
          else
            std::printf ( "[WARNING] Channel %i is not valid, the sale is counted but the channel is not specified, LINE %li\n", canal, m_SalesStack.top().Line );

        }

        totcanal = "Quantidades de Vendas por canal\n\nCanal\t\t\t QtVendas" +
                               std::string ( "\n 1 - Representantes\t  " ) + std::to_string ( representative ) +
                               "\n 2 - Website\t\t  " + std::to_string ( website ) +
                               "\n 3 - App móvel Android\t " + std::to_string ( appmovel ) +
                               "\n 4 - App móvel IPhone\t  " + std::to_string ( appiphone );

        // [TRANSFERE]
        if ( m_SalesStack.top().Situation == PAYMENT_OK ||
             m_SalesStack.top().Situation == PAYMENT_PENDENT )
        {
          m_productsMap[code].AmountSales = m_productsMap[code].AmountSales + m_SalesStack.top().Amount;
          m_productsMap[code].AmountIventorySales =  m_productsMap[code].AmountIventory - m_productsMap[code].AmountSales;

          if ( m_productsMap[code].AmountIventorySales < m_productsMap[code].AmountMinimum )
            m_productsMap[code].AmountNecess = m_productsMap[code].AmountMinimum - m_productsMap[code].AmountIventorySales;

          m_productsMap[code].AmountTrans  = m_productsMap[code].AmountNecess;

          if ( m_productsMap[code].AmountNecess > 1 && m_productsMap[code].AmountNecess < 10 )
            m_productsMap[code].AmountTrans = 10;
        }
        else if ( situation == "\0" )
          std::printf ( "[WARNING] Situation %li is not identified, check the LINE %li\n", m_SalesStack.top().Situation, m_SalesStack.top().Line );
      }

      // pop stack
      m_SalesStack.pop();
    }
  }

  std::string TransferLog;

  for ( std::unordered_map<int, Product >::const_iterator it = m_productsMap.begin();
        it != m_productsMap.end(); ++it )
  {
    TransferLog += "\n" + std::to_string ( it->second.Code ) +
                   "\t " + std::to_string ( it->second.AmountIventory ) +
                   "\t " + std::to_string ( it->second.AmountMinimum ) +
                   "\t " + std::to_string ( it->second.AmountSales ) +
                   "\t\t" + std::to_string ( it->second.AmountIventorySales ) +
                   "\t\t\t" + std::to_string ( it->second.AmountNecess ) +
                   "\t\t" + std::to_string ( it->second.AmountTrans );

  }


  std::string transfer = "Produto\t QtCO\t QtMin\t QtVendas\t Estq.após\t  Necess.\t  Transf. de \n" +
                         std::string ( "\t\t\t\t\tVendas\t\t\t            Arm p/ CO\n" ) + TransferLog;

  writeFile ( "ANALYTICS/TRANSFERE.txt", transfer.data() );
  writeFile ( "ANALYTICS/TOTCANAIS.txt", totcanal.data() );
}


void Analytics::setFilesAnalytics ( const char *p_vpath, const char *p_ppath )
{

  openFile ( p_vpath );
  {
    m_buffer_str = std::move ( readFile() );

    parserFileSales();

  }

  openFile ( p_ppath );
  {
    m_buffer_str = std::move ( readFile() );

    parserFileProducts();
  }

  analisysArchive();

}
