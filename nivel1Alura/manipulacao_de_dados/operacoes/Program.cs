using System.Collections;
using System.Collections.Generic;

Console.Clear();

var musica1 = new Musica { Titulo = "Que Pais é Esse?", Artista = "Legião Urbana", Duracao = 350 };
var musica2 = new Musica { Titulo = "Tempo Perdido", Artista = "Legião Urbana", Duracao = 455 };
var musica3 = new Musica { Titulo = "Pro Dia Nascer Feliz", Artista = "Barão Vermelho", Duracao = 345 };
var musica4 = new Musica { Titulo = "Eduardo e Mônica", Artista = "Legião Urbana", Duracao = 530 };
var musica5 = new Musica { Titulo = "Geração Coca-Cola", Artista = "Legião Urbana", Duracao = 350 };


Playlist musicas = new();
musicas.Add(musica1);
musicas.Add(musica2);
musicas.Add(musica3);
musicas.Add(musica4);
musicas.Add(musica5);




ExibirPlaylist(musicas);

musicas.OrdenarPorDuracao();
Console.WriteLine();

ExibirPlaylist(musicas);







void ExibirPlaylist(Playlist playlist)
{
    Console.WriteLine($"Playlist: {playlist.Nome}");
    foreach (var mus in playlist)
    {
        Console.WriteLine($"\t - {mus.Titulo} - {mus.Duracao} segundos");
    }
}

void RemoverPorTitulo()
{
    var musicaEncontrada = musicas.ObterPorNome("Pro Dia Nascer Feliz");
    if (musicaEncontrada is not null)
    {
        musicas.Remove(musicaEncontrada);
    }
    else
    {
        Console.WriteLine("Musica não encontrada");
    }
}

void ObterAleatoria()
{
    var musicaAleatoria = musicas.ObterAleatorio();
    if (musicaAleatoria is not null)
    {
        Console.WriteLine($"\nMusica aleatória: {musicaAleatoria.Titulo}");
    }
    else
    {
        Console.WriteLine("Musica não encontrada");
    }
}

public class Musica : IComparable
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }

    public int CompareTo(object? obj)
    {
        if (obj is null) return -1;
        if(obj is Musica outramusica) return this.Duracao.CompareTo(outramusica.Duracao);
        return -1;
    }

    public override bool Equals(object? obj)
    {
        if(obj is null) return false;
        if(obj is Musica outra)
        return this.Artista.Equals(outra.Artista) &&
            this.Titulo.Equals(outra.Titulo);
        return false;
    }
                        //hashCode funciona como um id unico
    public override int GetHashCode()
    {
        // isso combina o id de um com o id de outro e retorna um unico id combinado
        return this.Titulo.GetHashCode() ^ this.Artista.GetHashCode();
    }
}

public class PorArtista : IComparer<Musica>
{
    public int Compare(Musica? x, Musica? y)
    {
        if(x is null || y is null) return -0;
        if(x is null ) return 1;
        if(y is null) return -1;
        return x.Artista.CompareTo(y.Artista);
    }
  
}


public class PorTitulo : IComparer<Musica>
{
    public int Compare(Musica? x, Musica? y)
    {
        if(x is null || y is null) return -0;
        if(x is null ) return 1;
        if(y is null) return -1;
        return x.Titulo.CompareTo(y.Titulo);
    }
  
}

public class Playlist : ICollection<Musica>
{
    //hashset é uma coleção que não recebe valor repetido, então dá pra usar ele pra filtrar como serão adicionadas as musicas
    //observe isso em this.Add  
    private HashSet<Musica> set = [];
    private List<Musica> musicas = [];
    public string Nome { get; set; }

    public int Count => musicas.Count;

    public bool IsReadOnly => false;

    public void Add(Musica musica)
    {
        //o add do hashset retorna um boolean
        // ex: true se a musica for adicionada, ou seja, se ela não existir ainda
        if(set.Add(musica))
        {
            
        musicas.Add(musica);
        }
    }


    public Musica? ObterPorNome(string nome)
    {
        foreach (var mu in musicas)
        {
            if (mu.Titulo == nome) return mu;
        }

        return null;
    }

    public Musica? ObterAleatorio()
    {
        if (musicas.Count == 0) return null;

        Random random = new();
        int numerAleatorio = random.Next(0, musicas.Count - 1);
        return musicas[numerAleatorio];
    }
    public void Clear()
    {
        musicas.Clear();
    }

    public void OrdenarPorDuracao()
    {
        musicas.Sort();//duracao???
    }
    
    public void OrdenarPorArtista()
    {
        musicas.Sort(new PorArtista());
    }

    public void OrdenarPorTitulo()
    {
        musicas.Sort(new PorTitulo());
    }

    public bool Contains(Musica item)
    {
        return musicas.Contains(item);
    }
    public void CopyTo(Musica[] array, int arrayIndex)
    {
        musicas.CopyTo(array, arrayIndex);
    }


    public IEnumerator<Musica> GetEnumerator()
    {
        return musicas.GetEnumerator();
    }


    public bool Remove(Musica item)
    {
        return musicas.Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


}