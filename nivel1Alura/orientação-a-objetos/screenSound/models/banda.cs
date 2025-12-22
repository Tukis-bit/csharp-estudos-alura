using System.Runtime.InteropServices;

class Banda
{
    private List<Album> albuns = new List<Album>();
    public string Nome { get; set; }

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