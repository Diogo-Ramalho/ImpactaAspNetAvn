using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Leilao
    {
        public const decimal DescontoMaximo = 0.1m;
        public int Id { get; set; }
        public string NomeLote { get; set; }
        public decimal Preco { get; set; }
        public List<Produto> Produtos { get; set; }

        public List<string> Validar()
        {
            var erros = new List<string>();

            // if (string.IsNullOrEmpty(NomeLote) || string.IsNullOrWhiteSpace(NomeLote))
            if (string.IsNullOrEmpty(NomeLote?.Trim()))
                erros.Add("O nome do lote é obrigatório");

            // https://github.com/JeremySkinner/FluentValidation
            if (Produtos.Count() == 0)
                erros.Add("Produtos deve conter ao menos um item");


            var somaProdutos = Produtos.Sum(p => p.Preco);

            //if (Preco < (Produtos.Select(p => p.Preco).Sum() * 0.9m))
            //if (Preco < somaProdutos*(1 - 0.1m))
            if (somaProdutos - Preco > somaProdutos * DescontoMaximo)
                erros.Add("Desconto máximo excedido");

            return erros;
        }
    }
}
