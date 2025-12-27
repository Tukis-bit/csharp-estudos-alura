using System.ComponentModel;

namespace ScreenSound.models;


internal class Album : Iavaliavel
{
    private List<Musica> musicas = new List<Musica>();
    private List<Avaliacao> notas = new();

    public Album(string nome)
    {
        Nome = nome;
        ContadorDeObjetos++;
        
    }
    public string Nome { get; }
    public int DuracaoTotal => musicas.Sum(m => m.Duracao);

    public double Media
    {
        get
        {
            if(notas.Count == 0) return 0;
            else return notas.Average(a => a.Nota);
        }
    }

    public static int ContadorDeObjetos = 0;

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

    public void AdicionarNota(Avaliacao nota)
    {
        notas.Add(nota);
    }
}