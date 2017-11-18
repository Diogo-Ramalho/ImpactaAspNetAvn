namespace Poker.Dominio
{
    public class Carta
    {
        public Carta(Face face, Naipe naipe)
        {
            Face = face;
            Naipe = naipe;
        }

        public Naipe Naipe { get; set; }
        public Face Face { get; set; }
    }
}