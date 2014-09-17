using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TextSearch.Test
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void TestInvalidPath()
        {
            HighLighter.Print("Neil", "randomPath.txt");
        }
        [TestMethod]
        public void TestEmptyFile()
        {
            HighLighter.Print("Neil", "TestFile2.txt");
        }
        [TestMethod]
        public void TestContainsRegex()
        {
            HighLighter.Print("/**/*//sadasd", "TestFile.txt");
        }
        [TestMethod]
        public void TestContainsNumbers()
        {
            HighLighter.Print("9876543210", "TestFile.txt");
        }

        [TestMethod]
        public void TestContainsCharacters()
        {
            HighLighter.Print("qwertyuiopasdfghjklzxcvbnmæøåQWERTYUIOPASDFGHJKLZXCVBNMÆØÅ", "TestFile.txt");
        }

        [TestMethod]
        public void TestNoArguments()
        {
            HighLighter.Main(new string[0]);
        }
    }
}
