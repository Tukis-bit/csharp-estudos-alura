namespace screenSound.Filtros;
using screenSound.Modelos;

internal class LinqOrder
{
    public static void OrdernarArtistas(List<Musica> musicas)
    {
        var artistasOrdenados = musicas.OrderBy(m => m.Artista).Select(m => m.Artista).Distinct().ToList();

        Console.WriteLine("Lista de artistas ordenados: \n ");
        artistasOrdenados.ForEach(a => Console.WriteLine($"{a}"));
    }
}