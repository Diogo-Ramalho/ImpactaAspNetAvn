using System.Collections.Generic;

namespace Poker.Dominio
{
    public class Mesa // lugar para o jogador
    {
        public List<Posicao> Posicoes { get; set; }

        public TipoJogo TipoJogo { get; set; }

        public Baralho Baralho { get; set; }
    }
}
//carta
//baralho - embaralhar
//mãos