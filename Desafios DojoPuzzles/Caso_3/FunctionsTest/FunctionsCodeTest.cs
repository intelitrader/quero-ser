using Xunit;
using Functions;

namespace FunctionsTest
{
    public class FunctionsCodeTest
    {
        [Fact]
        public void Test1()
        {
            Assert.Equal("77773367_7773302_222337777_777766606660366656667889999_9999555337777", FunctionsCode.transformCode("SEMPRE ACESSO O DOJOPUZZLES"));
        }

        [Fact]
        public void Test2()
        {
            Assert.Equal("8337777833044466833555_555444877723_33777", FunctionsCode.transformCode("TESTE INTELLITRADER"));

        }

        [Fact]
        public void TestError()
        {
            string x = "x";
            for(var i = 0; i < 256; i++)
            {
                x += "x";
            }
            Assert.Equal("Error: Frase superior a 255 caracteres: ", FunctionsCode.transformCode(x));

        }
    }
}