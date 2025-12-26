using ScreenSound.models;

namespace ScreenSound.Menus;

internal class MenuExibirMedia : Menu
{
    public override void Executar(Dictionary<string, Banda> bandas)
    {
        base.Executar(bandas);
         EscreverTitulo("Exibir Média Da Banda");
    Console.Write("Escreva o nome da banda que você quer ter a média: ");
    string bandaNome = Console.ReadLine()!;

    Console.WriteLine();
    if (bandas.ContainsKey(bandaNome))
    {
        Banda banda = bandas[bandaNome];
        Console.WriteLine($"A média da {banda.Nome} é {banda.MediaDeNotas} ");

        Console.Write("Digite uma tecla para voltar ao menu:");
        Console.ReadKey();

     

    }
    else
    {
        Console.WriteLine($"\nBanda {bandaNome} não encontrada na lista de bandas registradas");
        Console.Write("Digite uma tecla para voltar ao menu:");
        Console.ReadKey();

       

    }
    }
}