using ScreenSound.models;
namespace ScreenSound.Menus;

internal class MenuExibirMediaAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandas)
    {
        base.Executar(bandas);
         EscreverTitulo("Exibir Média dos Álbuns");
    Console.Write("Escreva o nome da banda que você quer ter a média dos álbuns: ");
    string bandaNome = Console.ReadLine()!;

    Console.WriteLine();
    if (bandas.ContainsKey(bandaNome))
    {
        Banda banda = bandas[bandaNome];
        Console.WriteLine($"Média de nota dos álbuns da banda {bandaNome}: \n");
        foreach(Album album in banda.albuns)
            {
                Console.WriteLine($"{album.Nome}: {album.Media}");
            }

        Console.Write("\nDigite uma tecla para voltar ao menu:");
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