using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text.RegularExpressions;

Console.Clear();

using var arquivo = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);
using var stream = new StreamReader(arquivo);

void TitulosComNumerosRomanos(StreamReader stream)
{
    var regex = new Regex(@"\b[IVXLCDM]+\b"); //\b indica limite de palavra, [IVXLCDM] indica os caracteres permitidos (números romanos) e o + indica que pode ter um ou mais caracteres.
    var musicas = ObterMusicas(stream)
        .Where(m => regex.IsMatch(m.Titulo))
        .Take(20);

    ExibirMusicasEmTabela(musicas);
}



void MusicasComLetrasRepetidas(StreamReader stream)
{
    var regex = new Regex(@"(\w)\1{2,}"); //(\w) captura qualquer caractere alfanumérico e o armazena em um grupo. \1 refere-se ao primeiro grupo capturado, {2,} indica que o caractere deve se repetir pelo menos duas vezes consecutivas.
    var musicas = ObterMusicas(stream)
        .Where(m => regex.IsMatch(m.Titulo))
        .Take(20);

    ExibirMusicasEmTabela(musicas);
}


void MusicasQueComecamETerminaoComAMesmaPalavra(StreamReader stream)
{
    
    var regex = new Regex(@"^(\w+).*\1$"); //^ indica o início da string, (\w+) captura a primeira palavra e a armazena em um grupo, .* permite qualquer caractere entre a primeira e a última palavra, \1 refere-se ao primeiro grupo capturado, $ indica o fim da string.
    var musicas = ObterMusicas(stream)
    .Where(m => regex.IsMatch(m.Titulo)) //filtra apenas as músicas cujo titulo da musicacorresponde ao padrão definido na regex
    .Take(20);

    ExibirMusicasEmTabela(musicas);
}

void MusicasComduasPalavras(StreamReader stream)
{
    
    var regex = new Regex(@"^\w+ \w+$"); //^ indica o início da string, \w indica qualquer caractere alfanumérico (letras e números) e o + indica que pode ter um ou mais caracteres. O espaço indica que deve haver um espaço entre as palavras. O $ indica o fim da string.
    var musicas = ObterMusicas(stream)
    .Where(m => regex.IsMatch(m.Titulo)) //filtra apenas as músicas cujo titulo da musicacorresponde ao padrão definido na regex
    .Take(20);

    ExibirMusicasEmTabela(musicas);
}

void ArtistasComCaracterEspecial(StreamReader stream)
{
    
    var regex = new Regex("[^a-zA-Z0-9 ]"); //O ^ dentro dos colchetes indica negação, ou seja, tudo que não for letra maiuscula, minuscula, número ou espaço
    var artistas = ObterMusicas(stream)
        .Where(m => regex.IsMatch(m.Artista)) //pega apenas as musicas cujo nome do artista contém caracteres especiais
        .Select(m => m.Artista)
        .Distinct()
        .OrderBy(a => a);

    artistas.ToList().ForEach(a => Console.WriteLine(a));
}

void ExibirMusicas(IEnumerable<Musica> musicas)
{
    Console.WriteLine("\nMúsicas do arquivo:");
    foreach (var musica in musicas)
    {
        var linha = $"\t- {musica.Titulo} ({musica.Artista}) - {musica.Duracao}s [{musica.Lancamento}]";
        Console.WriteLine(linha);
    }
}

void ExibirMusicasEmTabela(IEnumerable<Musica> musicas)
{
    var titulo = "\nMúsicas do arquivo:";
    Console.WriteLine(titulo);

    var colunaTitulo = "Título".PadRight(40);
    var colunaArtista = "Artista".PadRight(30);
    var colunaDuracao = "Duração ".PadRight(20);
    var colunaLancamento = "Lançada em".PadRight(10);
    Console.WriteLine($"{colunaTitulo}{colunaArtista}{colunaDuracao}{colunaLancamento}");
    var borda = "".PadRight(115, '-');//define qual caracter vai ser usado no PAD
    Console.WriteLine(borda);

    foreach (var musica in musicas)
    {
        var linha = musica.ToString();
        Console.WriteLine(linha);
    }
}

IEnumerable<Musica> ObterMusicas(StreamReader stream)
{
    var linha = stream.ReadLine();
    while (linha is not null)
    {
        var partes = linha.Split(';');

        var duracao = 350;
        //“O Match procura uma expressão dentro da string que eu mandar pra ele.
        // Ele funciona como um Contains, só que para padrões, e além do bool ele também retorna o valor encontrado.”
        var match = Regex.Match(linha, @"(\d?\d):(\d\d)"); //o \d recebe um dígito de 0 a 9 e o ? indica que o dígito é opcional (pode ou não aparecer). O () indica que aquilo é um grupo que pode ser referenciado depois.
        if(match.Success) //Verifica se a expressão desejada foi encontrada
        {
            // foreach(var grupo in match.Groups) //Percorre os grupos encontrados na expressão
            // {
            //     Console.WriteLine($"Grupo: {grupo}");
            // }

            var minutos = int.Parse(match.Groups[1].Value); //Pega o primeiro grupo da expressão (minutos)
            var segundos = int.Parse(match.Groups[2].Value); //Pega o segundo grupo da expressão (segundos)

            duracao = (minutos * 60) + segundos;
        }
        else
        {
            Console.WriteLine("Duração não encontradsa");
        }
        
        if(partes.Length == 5){
            // int duracao = 350;
            // bool sucesso = int.TryParse(partes[2] ,out duracao); //tenta converter a string para int, se conseguir retorna true e atribui o valor a variavel duracao, se não conseguir retorna false e duracao recebe 0
            var musica = new Musica
            {
                Titulo = string.IsNullOrWhiteSpace(partes[0]) ? "Titulo Não Encontrado" : partes[0], //verifica se a string é nula ou vazia, se for atribui "Titulo Não Encontrado", se não atribui o valor da string
                Artista = string.IsNullOrWhiteSpace(partes[1]) ? "Artista Não Encontrado" : partes[1],
                Duracao = duracao,
                Generos = partes[3].Split(',', StringSplitOptions.TrimEntries), //separando os generos por virgula e removendo espaços em branco
                Lancamento = DateTime.TryParse(partes[4],out var data) ? data : DateTime.Today //se conseguir converter atribui o valor a data, se não atribui a data de hoje
            };
            
                yield return musica;
        }
        linha = stream.ReadLine();
    }
}

class Musica
{
    public string Titulo { get; set; }
    public string Artista { get; set; }
    public int Duracao { get; set; }
    public IEnumerable<string> Generos { get; set; }
    public DateTime Lancamento { get; set; }
    public override string ToString()
    {
          var linha = $" {Titulo, -40} {Artista, -30} {Duracao / 60, -20:F2} {Lancamento, -10:dd/MM/yy}"; //definindo o tamanho de cada coluna
        return linha;
    }

}
