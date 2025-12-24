namespace ScreenSound.models;

class Banda
{
    private List<Album> albuns = new List<Album>();

    public Banda(string nome)
    {
        Nome =  nome;
    }
    public string Nome { get; }

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine("Discografia do álbum:\n");
    albuns.ForEach(album => Console.WriteLine(@$"Álbum: {album.Nome} ({album.DuracaoTotal})"));
    }

}