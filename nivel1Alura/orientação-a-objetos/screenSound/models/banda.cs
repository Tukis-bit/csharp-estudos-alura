namespace ScreenSound.models;

internal class Banda : Iavaliavel
{
    public List<Album> albuns = new List<Album>();
    private List <Avaliacao> notas = new();

    public Banda(string nome)
    {
        Nome =  nome;
    }
    public string Nome { get; }
    public double Media
    {
        get
        {
            if(notas.Count == 0) return 0;
            else return notas.Average(n => n.Nota);
        }
    }

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine("Discografia do álbum:\n");
    albuns.ForEach(album => Console.WriteLine(@$"Álbum: {album.Nome} ({album.DuracaoTotal})"));
    }

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }

}