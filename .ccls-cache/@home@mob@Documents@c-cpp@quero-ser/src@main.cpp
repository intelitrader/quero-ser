#include "include/intelitrader.hpp"
#include <iostream>

int main ( int argc, char *argv[] )
{
  Analytics analysis;

  const char *Vpath = argv[1];
  const char *Ppath = argv[2];

  try
  {
    if ( argc > 2 )
    {
      analysis.setFilesAnalytics ( Vpath, Ppath );
      std::cout << "\nAnalytics completed, verify files ANALYTICS/TOTCANAIS.txt, ANALYTICS/DIVERGENCIAS.txt,  ANALYTICS/TRANSFERE.txt" << std::endl;
    }
    else
      std::cerr << "Execute: " << argv[0] << " <vendas.txt>  <produtos.txt>" << std::endl;
  }
  catch ( std::exception &error )
  {
    if ( std::string ( error.what() ) == "stoul" )
      std::cerr << argv[0] << " : Error in syntax, verify archives syntax correct \n\ttip:\n\t1: check for unnecessary line breaks\n\t2: make sure there are no empty keys\n\t3: if not to unnecessary spaces\n";
    else
      std::cerr << argv[0] << " : " << error.what() << std::endl;
  }

  return EXIT_SUCCESS;
}
