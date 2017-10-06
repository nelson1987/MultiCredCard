using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MultiCredCard.Domain.Tests
{
    [TestClass]
    public class PagamentoTests
    {
        /// <summary>
        /// Você prefere usar o cartão que está mais longe de vencer porque terá mais tempo para pagar a conta.
        /// </summary>
        [TestMethod]
        public void PagarComOCartaoQueEstaMaisLonge()
        {

        }
        /// <summary>
        /// Caso os dois cartões vençam no mesmo dia, você prefere usar aquele que tem menor limite para continuar 
        /// tendo um cartão com o limite mais alto.
        /// Lembre-se que cada compra é feita em apenas um cartão, então manter um cartão com limite mais alto 
        /// te dá liberdade de fazer compras grandes.
        /// Somente no caso em que não for possível fazer a compra em um único cartão, o sistema deve dividir 
        /// a compra em mais cartões.
        /// Para isso, você vai preenchendo os cartões usando as mesmas ordens de prioridade já descritas.
        /// Ou seja, você gasta primeiro do cartão que está mais longe de vencer e "completa" com o próximo 
        /// cartão mais longe de vencer.
        /// Caso os cartões vençam no mesmo dia, você gasta primeiro do com menor limite e "completa" com o 
        /// que tem mais limite.
        /// </summary>
        [TestMethod]
        public void PagarComDoisCartoesComMesmoDiaDeVencimento()
        {

        }
    }
}
