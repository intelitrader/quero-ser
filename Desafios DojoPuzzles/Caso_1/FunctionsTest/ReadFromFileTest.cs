using Xunit;
using Functions;


namespace FunctionsTest
{
    public class ReadFromFileTest
    {
        [Fact]
        public void Test1()
        {
            //ReadFromFile.file(fileLines);
            Assert.Equal("37273-83783", ReadFromFile.expression("FRASE-TESTE"));
        }

        [Fact]
        public void Test2()
        {
            //ReadFromFile.file(fileLines);
            Assert.Equal("68876 83783", ReadFromFile.expression("OUTRO TESTE"));
        }

        [Fact]
        public void Test3()
        {
            //ReadFromFile.file(fileLines);
            Assert.Equal("Expressão incorreta, uma expressão deve ser composta por letras maiúsculas (A-Z), hifens (-) e os números 1 e 0.", 
                ReadFromFile.expression("!-Testando frase error"));
        }
    }
}

