using Functions;
using Xunit;

namespace TestFunctions
{
    public class TestFunctionQL
    {

        [Fact]
        public void TestFunctionValidaTrue()
        {
            Assert.True(FunctionQL.valida("FRASE TESTE", 6));
        }

        [Fact]
        public void TestFunctionValidaFalse()
        {
            //O valor da coluna precisa ser maior do que o tamanho da maior palavra
            Assert.False(FunctionQL.valida("FRASE TESTE", 4));
        }

        [Fact]
        public void Test1()
        {
            string[] linhas = FunctionQL.quebraLinha("Um pequeno jabuti xereta viu dez cegonhas felizes.", 20);
            Assert.Equal("Um pequeno jabuti",linhas[0]);
            Assert.Equal("xereta viu dez", linhas[1]);
            Assert.Equal("cegonhas felizes.", linhas[2]);
        }

        [Fact]
        public void Test2()
        {
            string[] linhas = FunctionQL.quebraLinha("ESSA AQUI É UMA FRASE TESTE", 8);
            Assert.Equal("ESSA", linhas[0]);
            Assert.Equal("AQUI É", linhas[1]);
            Assert.Equal("UMA", linhas[2]);
            Assert.Equal("FRASE", linhas[3]);
            Assert.Equal("TESTE", linhas[4]);
        }

        [Fact]
        public void Test3()
        {
            string[] linhas = FunctionQL.quebraLinha("TESTE PARA DESENVOLVEDOR", 13);
            Assert.Equal("TESTE PARA", linhas[0]);
            Assert.Equal("DESENVOLVEDOR", linhas[1]);
        }
    }
}




