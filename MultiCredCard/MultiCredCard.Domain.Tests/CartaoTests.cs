using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiCredCard.Domain.Tests
{
    [TestClass]
    public class CartaoTests
    {
        /// <summary>
        /// Como você é uma pessoa que está sempre pensando em facilitar a sua vida, percebeu 
        /// que essa quantidade de cartões na sua carteira era um desperdício de espaço.
        /// Além de ser difícil de guardar todos, você percebeu que cada cartão tem uma data mensal para você pagar o que 
        /// consumiu em crédito no último mês.
        /// Por exemplo, um cartão tem que ser pago todo dia 03 do mês e outro todo dia 15.
        /// Um detalhe importante é que você pode pagar o cartão antes da data de vencimento para liberar crédito.
        /// </summary>
        [TestMethod]
        public void PagarCartao()
        {
            Cartao mestreCard = new Cartao("1234567890123456", 1000, 1000);
            PagamentoFaturaService pagamento = new PagamentoFaturaService(mestreCard, 100);

            Assert.AreEqual(mestreCard.Numero, "1234567890123456");
            Assert.AreEqual(mestreCard.Limite, 1000);
            Assert.AreEqual(mestreCard.LimiteDisponivel, 1100);
        }
    }
}
