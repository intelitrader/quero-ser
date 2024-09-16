from autores import autores
import types

def test_should_be_a_function():
    assert isinstance(autores, types.FunctionType)

def test_should_return_a_string():
    assert type(autores ('')) == str

def test_should_return_maiusculo():
    assert autores ('Guimaraes') == 'GUIMARAES'
    assert autores('ana') == 'ANA'
    assert autores('mArIa') == 'MARIA'

def test_primeiro_autor():
    assert autores('Joao Silva') == 'SILVA, Joao'
    assert autores ('joao silva') == 'SILVA, Joao'
    assert autores ('JOAO SILVA') == 'SILVA, Joao'

def test_segundo_autor():
    assert autores('Paulo Coelho') == 'COELHO, Paulo'
    assert autores('paulo coelho') == 'COELHO, Paulo'
    assert autores('PAULO COELHO') == 'COELHO, Paulo'

def test_terceiro_autor():
    assert autores('Celso de Araujo') == 'ARAUJO, Celso de'
    assert autores('celso de araujo') == 'ARAUJO, Celso de'
    assert autores('CELSO DE ARAUJO') == 'ARAUJO, Celso de'

def test_quarto_autor():
    assert autores('Maria Pereira da Silva') == 'SILVA, Maria Pereira da'
    assert autores('maria pereira da silva') == 'SILVA, Maria Pereira da'
    assert autores('MARIA PEREIRA DA SILVA') == 'SILVA, Maria Pereira da'

def test_quinto_autor():
    assert autores('Maria do Carmo') == 'CARMO, Maria do'
    assert autores('maria do carmo') == 'CARMO, Maria do'
    assert autores('MARIA DO CARMO') == 'CARMO, Maria do'

def test_contem_nomepai():
    assert autores('João Filho') == 'FILHO, João'
    assert autores('joão filho') == 'FILHO, João'

def test_contem_nomevovo():
    assert autores('João Neto') == 'NETO, João'
    assert autores('joão neto') == 'NETO, João'
    assert autores('João Silva Neto') == 'SILVA NETO, João'
    assert autores('joão silva neto') == 'SILVA NETO, João'
    assert autores('João da Silva Neto') == 'SILVA NETO, João da'
    assert autores('joão da silva neto') == 'SILVA NETO, João da'

def test_contem_nomemae():
    assert autores('Maria Filha') == 'FILHA, Maria'
    assert autores('maria filha') == 'FILHA, Maria'
    assert autores('MARIA FILHA') == 'FILHA, Maria'
    assert autores('Maria Novaes Filha') == 'NOVAES FILHA, Maria'
    assert autores('maria novaes filha') == 'NOVAES FILHA, Maria'

def test_contem_nomevo():
    assert autores('Cecilia Neta') == 'NETA, Cecilia'
    assert autores('cecilia neta') == 'NETA, Cecilia'
    assert autores('CECILIA NETA') == 'NETA, Cecilia'
    assert autores('Cecilia Oliveira Neta') == 'OLIVEIRA NETA, Cecilia'
    assert autores('cecilia oliveira neta') == 'OLIVEIRA NETA, Cecilia'

def test_contem_nometio():
    assert autores('Augusto Sobrinho') == 'SOBRINHO, Augusto'
    assert autores('augusto sobrinho') == 'SOBRINHO, Augusto'
    assert autores('AUGUSTO SOBRINHO') == 'SOBRINHO, Augusto'
    assert autores('Augusto Moraes Sobrinho') == 'MORAES SOBRINHO, Augusto'
    assert autores('augusto moraes sobrinho') == 'MORAES SOBRINHO, Augusto'

def test_contem_nometia():
    assert autores ('Alessandra Sobrinha') == 'SOBRINHA, Alessandra'
    assert autores ('alessandra sobrinha') == 'SOBRINHA, Alessandra'
    assert autores ('ALESSANDRA SOBRINHA') == 'SOBRINHA, Alessandra'
    assert autores ('Alessandra Lessa Sobrinha') == 'LESSA SOBRINHA, Alessandra'
