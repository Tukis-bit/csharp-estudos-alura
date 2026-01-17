using System.Collections;
Console.Clear();
var carrinho = new List<Produto>
{
    new Produto() {Nome = "Leite", Preco = 7.99m},
    new Produto() {Nome = "Biscoito", Preco = 5.99m}

};
DiasDaSemana diasDaSemana = new();
var pares = NumerosParesComYield(1000);
var contador = 0;
foreach(var par in pares)
{
    contador++;
    System.Console.WriteLine(par);

    if(contador >= 5) break;
}

IEnumerable<int> NumerosParesComYield (int limite)
{
    for(var i = 1; i < limite; i++)
    {
        System.Console.WriteLine($"Processando numero {i}");
        yield return i * 2;
        //return yield faz com que a operação ou resultado retornado por ele só seja processado quando ele é chamado  
    }
}

void PercorrendoFor()
{
    for(var i = 0; i < carrinho.Count; i++)
    {
        Console.WriteLine($"Produto: {carrinho[i].Nome}");
    }
}

void PercorrendoForEach()
{
    foreach(var car in carrinho)
    {
        System.Console.WriteLine($"Produto: {car.Nome}");
    }
}

void PercorrendoDiasDasemana()
{
    foreach(string dias in diasDaSemana)
{
    System.Console.WriteLine(dias);
}
}

void PercorrendoComEnumerator()
{
    var enumerator = diasDaSemana.GetEnumerator();
    while(enumerator.MoveNext())
    {
        var dia = enumerator.Current;
        Console.WriteLine(dia);
    }
}
class Produto
{
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
}

//classe Ienumerator(inutil se você utilizar o yield return)
class DiasDaSemanaEnumerator : IEnumerator<string>
{

    private int posicao = -1;
    private string[] dias = {"Domingo","Segunda","Terça","Quarta","Quinta","Sexta","Sabado"};

    public string Current => dias[posicao];

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        posicao++;
        return posicao < dias.Length;
    }

    public void Reset()
    {
        throw new NotImplementedException();
    }
}

    //o jeito de fazer criando uma classe enumerator, parece menor, mas com yield você não precisa criar a classe enumerator
// class DiasDaSemana : IEnumerable<string>
// {
//     public IEnumerator<string> GetEnumerator()
//     {
        
//         return new DiasDaSemanaEnumerator();
//     }

//     IEnumerator IEnumerable.GetEnumerator()
//     {
//         return GetEnumerator();
//     }
// }

class DiasDaSemana : IEnumerable<string>
{
    public IEnumerator<string> GetEnumerator()
    {
        yield return "Domingo";
        yield return "Segunda";
        yield return "Terça";
        yield return "Quarta";
        yield return "Quinta";
        yield return "Sexta";
        yield return "Sabado";
       
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}



