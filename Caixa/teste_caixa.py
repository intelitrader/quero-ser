from dinheiro_caixa import dinheiro_caixa
import types

def test_should_be_a_function():
    assert isinstance(dinheiro_caixa, types.FunctionType)

def test_should_return_a_list_with_an_item():
    assert len(dinheiro_caixa(10)) == 1

def test_should_return_notade10():
    dinheiro = dinheiro_caixa(10)
    assert len(dinheiro) == 1 and dinheiro.count(10) == 1

def test_should_return_notade20():
    assert dinheiro_caixa(20) == [20]

def test_should_return_notade10e20():
    assert dinheiro_caixa(30) == [20, 10]

def test_should_return_notade10e50():
    assert dinheiro_caixa(60) == [50, 10]

def test_should_return_notade10e20e50():
    assert dinheiro_caixa(80) == [50, 20, 10]

def test_should_return_notade100e20():
    assert dinheiro_caixa(120) == [100, 20]

def test_should_return_notade100e50e20():
    assert dinheiro_caixa(170) == [100, 50, 20]

def test_should_return_notade100e100():
    assert dinheiro_caixa(200) == [100, 100]

def test_should_return_10notasde100():
    dinheiro = dinheiro_caixa(1000)
    assert len(dinheiro) == 10 and dinheiro.count(100) == 10

def test_should_return_18notas():
    dinheiro = dinheiro_caixa(1590)
    assert len(dinheiro) == 18 and dinheiro.count(100) == 15 and dinheiro.count(50) == 1 and dinheiro.count(20) == 2

def test_should_return_mensagem_erro_valornegativo():
    assert dinheiro_caixa(-10) == 'Informe um valor positivo'

def test_should_return_mensagem_erro_valormenorque10():
    assert dinheiro_caixa(9) == 'Saque um valor acima de 10 reais'

def test_should_return_mensagem_erro_valornaodivisivelpor10():
    assert (dinheiro_caixa(11)) == 'Informe um valor válido para o saque'

