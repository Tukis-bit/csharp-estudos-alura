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




// ExibirPlaylist(musicas);

var legiaoUrbana = new Playlist() { Nome = "Mais populares da Legião" };
legiaoUrbana.Add(musica1);
legiaoUrbana.Add(musica2);
legiaoUrbana.Add(musica4);
legiaoUrbana.Add(musica5);
 
// ExibirPlaylist(legiaoUrbana);

PlayerDeReproducao player = new();

player.AdicionarNaLista(musica1);
player.AdicionarNaLista(legiaoUrbana);

ExibirFila(player);
ExibirHistorico(player);

var proxima = player.ProximaMusicaDaFila();
Console.WriteLine("\nProxima musica na lista: \n");
if(proxima is not null)
{
    Console.WriteLine($"\t - {proxima.Titulo}");
}else
{
    Console.WriteLine("\nA lista de reprodução acabou");
}


ExibirFila(player);
ExibirHistorico(player);


var anterior = player.UltimaMusicaOuvida();
Console.WriteLine("\nUltima musica Ouvida: \n");
if(anterior is not null)
{
    Console.WriteLine($"\t - {anterior.Titulo}");
}else
{
    Console.WriteLine("\nHistórico de rreprodução vazio!!");
}



void ExibirHistorico(PlayerDeReproducao player)
{
    Console.WriteLine($"\nExibindo historico de reprodução: ");
    foreach(var musica in player.Historico())
    {
        
        Console.WriteLine($"\t - {musica.Titulo} ");
    }
}

void ExibirFila(PlayerDeReproducao play)
{
    Console.WriteLine($"\n  Musicas na fila de reprodução: ");
    foreach(var mus in player.Fila())
    {
        Console.WriteLine($"\t {mus.Titulo}");
    }   
    }

void ExibirMaiosTocadas(Playlist p1, Playlist p2)
{
    //Musica(key/identificador) int(value/valor)
    Dictionary<Musica, int> ranking = [];

    foreach(var mu in p1 )
    {
        ranking.Add(mu, 1);
    }

    foreach(var mu in p2)
    {
        // verifica se existe essa key e dá um nome para o valor (retorna booleano)
        if(ranking.TryGetValue(mu, out int contagem))
        {
            contagem++;
            ranking[mu] = contagem;
        } else
        {
            ranking[mu] = 1;
        }
    }
    // ainda não dá pra listar as com maior valor, então vamos criar uma classe com Icomparable
    List<KeyValuePair<Musica, int>> top = new(ranking);
    top.Sort(new PorContagem());

    Console.WriteLine("\nMusicas mais ouvidas nas playlists: ");
    int contador = 1;
    foreach(var mu in top)
    {
        Console.WriteLine($"\t{mu.Key.Titulo}");
        contador++;

        if(contador > 3) break;
    }
}




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

public class PorContagem : IComparer<KeyValuePair<Musica, int>>
{
    public int Compare(KeyValuePair<Musica, int> x, KeyValuePair<Musica, int> y)
    {
        
        return y.Value.CompareTo(x.Value);
    
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

class PlayerDeReproducao
{
    private Queue<Musica> lista = []; //primeiro a entrar e primeiro a sair(FIFO)
    private Stack<Musica> pilha = []; //ultimo a entrar e primairo a sair(LIFO)
    public void AdicionarNaLista(Musica musica)
    {
        lista.Enqueue(musica);
    }

    public void AdicionarNaLista(Playlist pĺaylist)
    {
        foreach(var musica in pĺaylist)
        {
            lista.Enqueue(musica);
        }
    }

    public Musica? ProximaMusicaDaFila()
    {
        if (lista.Count() <= 0) return null;
        var musica = lista.Dequeue();
        pilha.Push(musica);
        return musica;
         
    }

    public Musica? UltimaMusicaOuvida()
    {
        if(pilha.Count == 0) return null;
        return pilha.Pop();
    }

    public IEnumerable<Musica> Fila()
    {
        foreach(var musica in lista)
        {
            yield return musica;
        }
    }

    public IEnumerable<Musica> Historico()
    {
        foreach(var musica in pilha)
        {
            yield return musica;
        }
    }
}