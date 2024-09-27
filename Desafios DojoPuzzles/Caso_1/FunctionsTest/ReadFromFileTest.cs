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
            Assert.Equal("Express�o incorreta, uma express�o deve ser composta por letras mai�sculas (A-Z), hifens (-) e os n�meros 1 e 0.", 
                ReadFromFile.expression("!-Testando frase error"));
        }
    }
}

