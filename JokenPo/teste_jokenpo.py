# -*- coding: utf-8 -*-

from jokenpo import jokenpo
import types

def test_should_be_a_function():
    assert isinstance(jokenpo, types.FunctionType)

def test_should_return_a_string():
    assert type(jokenpo('Pedra', 'Pedra')) == str

def test_should_pedra_vencedor():
    assert jokenpo('Pedra', 'Tesoura') == 'Ganhador: Pedra'

def test_should_tesoura_vencedor():
    assert jokenpo('Tesoura', 'Papel') == 'Ganhador: Tesoura'

def test_should_papel_vencedor():
    assert jokenpo('Papel', 'Pedra') == 'Ganhador: Papel'

def test_reverso ():
    assert jokenpo('Pedra', 'Papel') == 'Ganhador: Papel'
    
def test_should_return_mensagem_de_erro():
    assert jokenpo('Alumínio', 'Pedra') == 'OOpção inválida!! Tente Pedra, Papel ou Tesoura!'

def test_should_return_mensagem_empate():
    assert jokenpo('Pedra', 'Pedra') == 'Empatou!!'