using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.Dominio.Tests
{
    [TestClass()]
    public class BaralhoTests
    {
        [TestMethod()]
        public void MontarBaralhoTest()
        {
            // Arrange + Act
            var baralho = new Baralho();
            var ouros = baralho.Cartas.Where(c => c.Naipe == Naipe.Ouros).ToList();
            var naipes = baralho.Cartas.GroupBy(n => n.Naipe);

            // Assert
            Assert.IsTrue(baralho.Cartas.Count == 52);
            Assert.IsTrue(ouros.Count == 13);
            Assert.IsTrue(naipes.Count() == 4);

            var face = 1;
            foreach (var ouro in ouros)
            {
                Assert.IsTrue((int)ouro.Face == face++);
            }
        }


    }
}