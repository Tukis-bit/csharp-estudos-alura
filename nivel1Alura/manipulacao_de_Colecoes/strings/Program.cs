using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;

Console.Clear();

using var arquivo = new FileStream("musicas.csv", FileMode.Open, FileAccess.Read);
using var stream = new StreamReader(arquivo);

var musicas = ObterMusicas(stream)
.Take(20);

ExibirMusicasEmTabela(musicas);

void Interning()
{

    var a1 = "Coldplay";
    var a2 = "Coldplay";
    var a3 = new string("Coldplay");
    var a4 = "COLDPLAY";
    var a5 = string.Intern(a1.ToUpper()); //força o .NET a usar a mesma referência de string do pool de strings

    Console.WriteLine(a1 == a2); //true
    Console.WriteLine(ReferenceEquals(a1, a2)); //true
    Console.WriteLine(ReferenceEquals(a1,a3)); //False
    Console.WriteLine(ReferenceEquals(a5,a4)); //true
    
}

void ComparandoStrings(StreamReader stream)
{
    var musicas = ObterMusicas(stream)
    .Where(m => m.Artista.Equals("COLDPLAY", StringComparison.OrdinalIgnoreCase))// o stringcomparison ignora maiusculas e minusculas e ele só funciona usando o equals
    //.Where(m => m.Artista.ToUpper() == "COLDPLAY") dessa forma é menos performatico pq cria uma nova string
    .Take(20);

    // métodos que utilizam StringComparison
    "Coldplay".Equals("coldplay", StringComparison.OrdinalIgnoreCase);
    "Coldplay".StartsWith("cold", StringComparison.OrdinalIgnoreCase);
    "Coldplay".EndsWith("coldplay", StringComparison.OrdinalIgnoreCase);
    "Coldplay".IndexOf("coldplay", StringComparison.OrdinalIgnoreCase);
    "Coldplay".Contains("OLD", StringComparison.OrdinalIgnoreCase);
    "Coldplay".Replace("cold", "warm", StringComparison.OrdinalIgnoreCase);

    ExibirMusicasEmTabela(musicas);
    
}

void AlterandoOTitulo(StreamReader stream)
{
    var musica = ObterMusicas(stream)
    .Where(m => m.Titulo.StartsWith('T'))
    .FirstOrDefault();

if (musica is not null)
{
    Console.WriteLine($"Titulo: {musica.Titulo}");

    musica.Titulo = musica.Titulo.Replace("The", "");//como o objeto é imutavel ele só pode ser trocado dessa forma "Adicionando um novo valor"

    Console.WriteLine($"Titulo: {musica.Titulo}");

}
}


void VerificandoSenhaAny()
{
    var senha = "Arthur123@";

    var temMaiuscula = senha.Any(c => char.IsUpper(c)); //verifica se tem pelo menos um caractere maiusculo
    var temMinuscula = senha.Any(c => char.IsLower(c)); //verifica se tem pelo menos um caractere minusculo
    var temNumero = senha.Any(c => char.IsDigit(c)); //verifica se tem pelo menos um digito
    var temSimbolo = senha.Any(c => !char.IsLetterOrDigit(c)); //verifica se tem pelo menos um simbolo
    bool temOitoOuMais = senha.Length >= 8; //verifica se tem 8 ou mais caracteres

    if (temMaiuscula && temMinuscula && temNumero && temSimbolo && temOitoOuMais)
    {
        Console.WriteLine("Senha forte");
    }
    else
    {
        Console.WriteLine("Senha fraca");
    }
}

void VerificacaoDeSenha()
{
    var senha = "Arthur123@"; 

    var quantidadeMaiuscula = senha.Count(c => char.IsUpper(c)); //retorna a quantidade de caracteres maiusculos
    var quantidadeMinuscula = senha.Count(c => char.IsLower(c)); //retorna a quantidade de caracteres minusculos
    var quantidadeNumeros = senha.Count(c => char.IsDigit(c)); //retorna a quantidade de digitos)
    var quantidadeSimbolos = senha.Count(c => !char.IsLetterOrDigit(c)); //retorna a quantidade de simbolos
    

    if (quantidadeMaiuscula == 0 
        || quantidadeMinuscula == 0 
        || quantidadeNumeros == 0 
        || quantidadeSimbolos == 0 
        || senha.Length < 8)
    {
        Console.WriteLine("Senha fraca");
    }
    else
    {
        Console.WriteLine("Senha forte");
    }



}

void stringIsArray()
{
    //uma string é um IEnumerable<char> portanto podemos usar LINQ nela
    //char[] string = "olá"
    var texto = "Olá eu estou estudando Strings";
    foreach (var letra in texto)
    {
        Console.WriteLine(letra);
    }
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
        
        if(partes.Length == 5){
            // int duracao = 350;
            // bool sucesso = int.TryParse(partes[2] ,out duracao); //tenta converter a string para int, se conseguir retorna true e atribui o valor a variavel duracao, se não conseguir retorna false e duracao recebe 0
            var musica = new Musica
            {
                Titulo = string.IsNullOrWhiteSpace(partes[0]) ? "Titulo Não Encontrado" : partes[0], //verifica se a string é nula ou vazia, se for atribui "Titulo Não Encontrado", se não atribui o valor da string
                Artista = string.IsNullOrWhiteSpace(partes[1]) ? "Artista Não Encontrado" : partes[1],
                Duracao = int.TryParse(partes[2] ,out int duracao) ? duracao : 350, //se conseguir converter atribui o valor a duracao, se não atribui 350
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
