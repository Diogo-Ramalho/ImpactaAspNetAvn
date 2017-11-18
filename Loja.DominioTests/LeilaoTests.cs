using Microsoft.VisualStudio.TestTools.UnitTesting;
using Loja.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio.Tests
{
    [TestClass()]
    public class LeilaoTests
    {
        [TestMethod()]
        public void ValidarSucessoTeste()
        {
            // Três A's do Tester
            // Arrange
            var leilao = new Leilao();
            leilao.Id = 1638;
            leilao.NomeLote = "Lote 1638";
            leilao.Preco = 90;
            leilao.Produtos = new List<Produto> {
                new Produto { Nome = "Teste", Preco = 100 }
            };

            // Act
            var erros = leilao.Validar();

            // Assert
            Assert.IsTrue(erros.Count == 0);
        }

        [TestMethod()]
        public void ValidarErroTeste()
        {
            // Arrange
            var leilao = new Leilao();
            leilao.Id = 1638;
            leilao.NomeLote = "Lote 1638";
            leilao.Preco = 89.9m;
            leilao.Produtos = new List<Produto> {
                new Produto { Nome = "Teste", Preco = 100 }
            };

            // Act
            var erros = leilao.Validar();

            // Assert
            Assert.IsTrue(erros.Contains("Desconto máximo excedido"));
        }
    }
}