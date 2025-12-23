class Album
{
    private List<Musica> musicas = new List<Musica>();

    public Album(string nome)
    {
        Nome = nome;
    }
    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public void AdicionarMusica(Musica musica)
    {
        musicas.Add(musica);
    }

    public void ExibirMusicas()
    {
        Console.WriteLine($"Essas são as musicas do álbum {Nome}");
        musicas.ForEach(musica => Console.WriteLine($"musica: {musica.Nome}"));

        Console.WriteLine($"\nPara ouvir esse álbum inteiro você precisa ouvir {DuracaoTotal} segundos");
    }

    
}