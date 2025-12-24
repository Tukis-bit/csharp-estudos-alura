namespace ScreenSound.models;


class Podcast
{
    List <Episodio> episodios = new();

    public Podcast(string host, string nome)
    {
        Host = host;
        Nome = nome;
    }
    public string Host { get;  }
    public string Nome { get; }
    public int TotalEpisodios => episodios.Count;

    public void AdicionarEpisodios(Episodio ep)
    {
        episodios.Add(ep);
    }

    public void ExibirDetalhes()
    {
        Console.WriteLine($@"O podcast {Nome}, feito por {Host} tem um total de {TotalEpisodios} episodios");
        foreach(Episodio ep in episodios.OrderBy(e => e.Ordem))
        {
             Console.WriteLine(ep.Resumo);
        }

    }

    


}