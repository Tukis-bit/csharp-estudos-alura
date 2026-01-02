using System.Text.Json;

namespace screenSound.Modelos;

internal class MusicasPreferidas
{
    public string? Nome { get; set; }
    public List<Musica> ListaDeFavoritas {get;}

    public MusicasPreferidas(string nome)
    {
        Nome = nome;
        ListaDeFavoritas = new List<Musica>();
    }

    public void AdicionarMusicas(Musica musica)
    {
        ListaDeFavoritas.Add(musica);
    }

    public void ExibirFavoritas()
    {
        Console.Write($"Essas são as musicas Favoritas: {Nome}\n");
        ListaDeFavoritas.ForEach(m => Console.WriteLine($"{m.Nome} de {m.Artista}"));
        
    }

    public void GerarJson()
    {
        string json = JsonSerializer.Serialize( new
        {
            nome = Nome,
            musicas  = ListaDeFavoritas
        });

        string nomeDoArquivo = $"musicas-favoritas-{Nome}.json";
        File.WriteAllText(nomeDoArquivo, json);

        Console.WriteLine("O arquivo Json foi criado com sucesso \n");
    }

}