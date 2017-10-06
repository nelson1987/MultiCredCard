using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiCredCard.Domain.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesteValidador()
        {
            var um = 1;
            Assert.AreEqual(um, 1);
        }

        [TestMethod]
        public void TesteValidadorErro()
        {
            var um = 1;
            Assert.AreEqual(um, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TesteValidadorException()
        {
            throw new Exception("ERRO");
        }
    }
}
