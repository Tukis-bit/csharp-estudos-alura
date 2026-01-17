Console.Clear();



var arquivos = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);

//o using serve para abrir e fachar o arquivo enquanto ele está sendo lido
using var arquivo = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);//transforma os bytes do arquivo em um "texto"
using var stream = new StreamReader(arquivo);//Lê esse texto linha a linha 

var musicas = ObterMusicas(stream);
var could =
ObterMusicas(stream) //1. Obteros dados
.Where(m => m.Artista == "Coldplay")//2. filtrar eles  //where é a mesma coisa que o "FiltrarPor" que nós fizemos manualmente
.FiltrarPor(m => m.Duracao >= 300);//a Func<Musica, bool> permite que nós coloquemos a condição dessa forma


ExibirMusicas(could);


void ExibirMusicas(IEnumerable<Musica> musicas)
{
    int contador = 1;
    Console.WriteLine("\nMusicas da lista:  ");
    foreach(Musica musica in musicas)
    {
        Console.WriteLine($"\t - {musica.Titulo} - {musica.Artista} - {musica.Duracao}");

        contador++;
        if(contador > 10) break;
    
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
            Duracao = Convert.ToInt32(partes[2])//convert.Toint vai  converter pra 0 se o valor for null
        };
        yield return musica;
        linha = stream.ReadLine();//pula pra próxima musica 
    }
}

bool FiltrarPorArtista(Musica m) => m.Artista == "Coldplay";
bool FiltrarPorDuracao(Musica m) => m.Duracao >= 400;
bool FiltrarPorTitulo (Musica m) => m.Titulo.Contains("nigth");

Func<Musica, bool> condicao = FiltrarPorTitulo; //delegate = tipos que representão metodos com a mesma assinatura 

class Musica
{
    public string? Titulo { get; set; }
    public string? Artista { get; set; }
    public int Duracao { get; set; }
}

static class MusicasExtension
{
    public static IEnumerable<Musica> FiltrarPor(this IEnumerable<Musica> musicas,Func<Musica, bool> condicao )
{
    foreach(var musica in musicas)
    {
        if(condicao(musica)) yield return musica;
    }
}

}