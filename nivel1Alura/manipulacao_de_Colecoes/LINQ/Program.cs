Console.Clear();

var arquivos = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);

//o using serve para abrir e fachar o arquivo enquanto ele está sendo lido
using var arquivo = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);//transforma os bytes do arquivo em um "texto"
using var stream = new StreamReader(arquivo);//Lê esse texto linha a linha 

var generos = ObterMusicas(stream)
.SelectMany(m => m.Genero)
.Distinct()
.OrderBy(g => g);

Console.WriteLine("Generos diferentes: ");
foreach(var genero in generos)
{
    Console.WriteLine(genero);
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

