using screenSound.Modelos;

namespace screenSound.Filtros;

internal class LinqFilter
{
    public static void FiltrarGenerosMusicais(List <Musica> musicas)
    {
     var GenerosMusicais = musicas.Select(m => m.Genero).Distinct().ToList();   
     GenerosMusicais.ForEach(g => Console.WriteLine($"- {g}")); 
    }

    public static void FiltrarArtistaPorGenero(List<Musica> musicas, string genero)
    {
        var artistasPorGenero = musicas.Where(m => m.Genero!.Contains(genero)).Select(m => m.Artista).Distinct().ToList();
        Console.WriteLine($"Artistas do gênero {genero}:\n");
        artistasPorGenero.ForEach(a => Console.WriteLine(a));
    }

    public static void FiltrarMusicarPorArtista(List<Musica> musicas, string artista)
    {
        var musicasPorArtista = musicas.Where(m => m.Artista!.Equals(artista)).Select(m => m.Nome).Distinct().ToList();
        Console.WriteLine($"Musicas do artista {artista}: \n");
        musicasPorArtista.ForEach(m => Console.WriteLine(m));
    }

    public static void FiltrarTonalidade(List<Musica> musicas)
    {
        var musicasTonalidade = musicas.Where(m => m.key.Equals(1)).ToList();
        Console.WriteLine("Musicas com a tonalidade C#");
        musicasTonalidade.ForEach(m => Console.WriteLine($"Musica: {m.Nome}, {m.Tonalidade}"));
    }
}