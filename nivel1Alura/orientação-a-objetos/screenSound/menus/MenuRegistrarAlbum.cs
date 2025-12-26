using ScreenSound.models;
namespace ScreenSound.Menus;

internal class MenuRegistrarAlbum : Menu
{
public override void Executar(Dictionary<string, Banda> bandas) 
{
    base.Executar(bandas);
EscreverTitulo("Registrar Album á Uma Banda");
    Console.Write("Escreva o nome da banda que você quer registrar um álbum: ");
    string bandaNome = Console.ReadLine()!;

    Console.WriteLine();
    if (bandas.ContainsKey(bandaNome))
    {
        Banda banda = bandas[bandaNome];
        Console.WriteLine($"Escreva o nome do álbum que você quer adicionar a banda {banda.Nome}");
        Album album = new(Console.ReadLine()!);

        banda.AdicionarAlbum(album);

        Console.WriteLine($"\nAlbum {album.Nome} adicionado aos albuns da banda {banda.Nome} ");

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