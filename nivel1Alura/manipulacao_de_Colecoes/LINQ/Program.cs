Console.Clear();

var arquivos = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);

//o using serve para abrir e fachar o arquivo enquanto ele está sendo lido
using var arquivo = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);//transforma os bytes do arquivo em um "texto"
using var stream = new StreamReader(arquivo);//Lê esse texto linha a linha 

void operacaoDeVerificacaodeExistencia(StreamReader stream)
{
    var musicas = ObterMusicas(stream);

    var artistas = musicas
    .GroupBy(m => m.Artista)
    .Where(g => g.Any(m => m.Duracao > 480)); //verifica e retorna se existe alguma musica com mais de 8 minutos

    var reggae = musicas
    .GroupBy(m => m.Artista)
    .Where(g => g.Any(m => m.Genero.Contains("Reggae"))); //verifica e retorna se existe alguma artista que tenha uma musica de reggae 
}

void ArtistaComMaiorQtde (StreamReader stream)
{
   var artista = ObterMusicas(stream)
    .GroupBy(m => m.Artista)
    .Select(g =>  new { Artista = g.Key, Musicas = g, Total = g.Count() }) //cria um objeto pra cada gupo retornado pelo groupby 
    .MaxBy(a => a.Total); //pega o artista com mais musicas

    if(artista is not null)
    Console.WriteLine($"Artista com mais musicas - {artista.Artista} - {artista.Total} musicas");
}

void OperacaoDeObtencaoDeElementos(StreamReader stream)
{
    var musicas = ObterMusicas(stream).ToList();
    var primeiraMusica = musicas.First();
    Console.WriteLine($"Primaira musica - {primeiraMusica.Titulo}");


    var maiorMusica = musicas.MaxBy(m => m.Duracao); // pega a musica com a maior duração 
    if(maiorMusica is not null)
    Console.WriteLine($"Maior musica - {maiorMusica.Titulo}");
}


void OperacoesDeAgrupamento(StreamReader stream)
{
   var artistas = ObterMusicas(stream)
    .GroupBy(m => m.Artista);

    foreach(var artista in artistas)
    {
        Console.WriteLine(artista.Key);
        foreach(var musica in artista)
        {
            Console.WriteLine($"\t - {musica.Titulo}");
        }
    }
 
}

void EstatisticasDeMusicas(StreamReader stream)
{
    var musicas = ObterMusicas(stream).ToList();
    Console.WriteLine($"\nExistem {musicas.Count()} músicas na coleção.");
    Console.WriteLine($"\nExistem {musicas.Count(m => m.Duracao > 600)} músicas com mais do que 10 minutos na coleção.");
    Console.WriteLine($"\nA música com menor duração da coleção leva {musicas.Min(m => m.Duracao)} segundos."); // pega a menor duração da lista
    Console.WriteLine($"\nA música com maior duração da coleção leva {musicas.Max(m => m.Duracao)} segundos.");// pega a maior duracao de uma lista 
    Console.WriteLine($"\nA duração média das músicas da coleção é {musicas.Average(m => m.Duracao)} segundos.");
    Console.WriteLine($"\nVocê vai levar {musicas.Sum(m => m.Duracao) / (3600 * 24) } dias para ouvir toda a coleção!");
}


void OperacoesDeProjecao2(StreamReader stream)
{
    var generos = ObterMusicas(stream)
.SelectMany(m => m.Genero)
.Distinct()
.OrderBy(g => g);

Console.WriteLine("Generos diferentes: ");
foreach(var genero in generos)
{
    Console.WriteLine(genero);
}
}


void OperacoesDeProjecao(StreamReader stream)
{
    var artistas = ObterMusicas(stream)
    .Select(m => m.Artista)//transforma em uma lista de artistas
    .Distinct()//pega os diferentes
    .OrderBy(a => a);//orderna os elementos por eles (alfabetico)

    Console.WriteLine("Artistas: ");

    foreach(var artista in artistas)
    {
        Console.WriteLine(artista);
    }
}


void OperacoesDeFiltro(StreamReader stream)
{
    var musicas = ObterMusicas(stream);

        var could =
    ObterMusicas(stream) //1. Obteros dados
    .Where(m => m.Artista == "Coldplay")//2. filtrar eles  //where é a mesma coisa que o "FiltrarPor" que nós fizemos manualmente
    .Where(m => m.Duracao >= 300)//a Func<Musica, bool> permite que nós coloquemos a condição dessa forma
    .OrderBy(m => m.Titulo)
    .ThenBy(m => m.Duracao)
    .Take(5);

    ExibirMusicas(could);
}

void ExibirMusicas(IEnumerable<Musica> musicas)
{
    int contador = 1;
    Console.WriteLine("\nMusicas da lista:  ");
    foreach(Musica musica in musicas)
    {
        Console.WriteLine($"\t - {musica.Titulo} - {musica.Artista} - {musica.Duracao}");
    }
}


IEnumerable<Musica> ObterMusicas(StreamReader stream)
{
    var linha = stream.ReadLine();
    while(linha is not null)
    {
        var partes = linha.Split(';');
        Musica musica = new()
        {
            Titulo = partes[0],
            Artista = partes[1],
            Duracao = Convert.ToInt32(partes[2]),//convert.Toint vai  converter pra 0 se o valor for null
            Genero = partes[3].Split(',').Select(g => g.Trim())//separa os generos diferentes
        };
        yield return musica;
        linha = stream.ReadLine();//pula pra próxima musica 
    }
}

class Musica
{
    public string? Titulo { get; set; }
    public string? Artista { get; set; }
    public int Duracao { get; set; }
    public IEnumerable<string> Genero { get; set; } //uma musica tem mais de um genero 
}

