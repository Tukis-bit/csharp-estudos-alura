using System.Linq.Expressions;
using ScreenSound.models;
namespace ScreenSound.Menus;

internal class MenuDarNotaAlbum : Menu
{
    public override void Executar(Dictionary<string, Banda> bandas)
    {
        base.Executar(bandas);
        EscreverTitulo("Avaliar Banda");
    Console.Write("Escreva o nome da banda dona do álbum: ");
    string bandaNome = Console.ReadLine()!;

    Console.WriteLine();
    if (bandas.ContainsKey(bandaNome))
    {
        Banda banda = bandas[bandaNome];
        Console.Write("Digite o título do álbum: ");
        string nomeAlbum = Console.ReadLine()!;
        if(banda.albuns.Any(a => a.Nome.Equals(nomeAlbum)))
            {
         Album album = banda.albuns.First(a => a.Nome.Equals(nomeAlbum));
        Console.Write($"Qual nota o {nomeAlbum} merece: ");
         Avaliacao nota = Avaliacao.Parse(Console.ReadLine()!);
        album.AdicionarNota(nota);

        Console.WriteLine($"\nNota {nota.Nota} Registrada para o Album {album.Nome}");
        Thread.Sleep(1500);

            }
            else
            {
               
        Console.WriteLine($"\nAlbum {nomeAlbum} não encontrado na lista de álbuns registrados na banda ");
        Console.Write("Digite uma tecla para voltar ao menu:");
        Console.ReadKey();
 
            }

      
        

    }
    else
    {
        Console.WriteLine($"\nBanda {bandaNome} não encontrada na lista de bandas registradas");
        Console.Write("Digite uma tecla para voltar ao menu:");
        Console.ReadKey();


    }
    }

}