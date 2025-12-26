using ScreenSound.models;
namespace ScreenSound.Menus;

internal class MenuDarNota : Menu
{
    public override void Executar(Dictionary<string, Banda> bandas)
    {
        base.Executar(bandas);
        EscreverTitulo("Avaliar Banda");
    Console.Write("Escreva o nome da banda que você quer avaliar: ");
    string bandaNome = Console.ReadLine()!;

    Console.WriteLine();
    if (bandas.ContainsKey(bandaNome))
    {
        Banda banda = bandas[bandaNome];
        Console.Write($"Qual nota a {banda.Nome} merece: ");
        Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
        banda.AdicionarNota(nota);

        Console.WriteLine($"\nNota {nota.Nota} Registrada para a banda {banda.Nome}");
        Thread.Sleep(1500);

        

    }
    else
    {
        Console.WriteLine($"\nBanda {bandaNome} não encontrada na lista de bandas registradas");
        Console.Write("Digite uma tecla para voltar ao menu:");
        Console.ReadKey();


    }
    }
}