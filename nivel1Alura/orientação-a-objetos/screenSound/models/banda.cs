namespace ScreenSound.models;

class Banda
{
    private List<Album> albuns = new List<Album>();
    private List <int> notas = new();

    public Banda(string nome)
    {
        Nome =  nome;
    }
    public string Nome { get; }
    public double MediaDeNotas => 
    notas.Average();

    public void AdicionarAlbum(Album album)
    {
        albuns.Add(album);
    }

    public void ExibirDiscografia()
    {
        Console.WriteLine("Discografia do álbum:\n");
    albuns.ForEach(album => Console.WriteLine(@$"Álbum: {album.Nome} ({album.DuracaoTotal})"));
    }

    public void AdicionarNota(int nota)
    {
        notas.Add(nota);
    }

}