using ScreenSound.models;
namespace ScreenSound.Menus;

internal class MenuMostrarListaBandas : Menu
{
    public override void Executar(Dictionary<string, Banda> bandas)
    {
        base.Executar(bandas);
         EscreverTitulo("Lista Das Bandas");
    if (bandas.Keys.Count < 1)
    {
        Console.WriteLine("\nVocê ainda não registrou nenhuma banda, Voltando ao menu \n");
        Thread.Sleep(2000);
        Console.Clear();
        
    }
    else
    {
        Console.WriteLine("Exibir bandas:\n");
        foreach (string banda in bandas.Keys)
        {
            Console.WriteLine($"Banda: {banda} ");
        }
    }
    Console.Write("Digite qualquer tecla para voltar para o menu:");
    Console.ReadKey();
    Thread.Sleep(2000);
    Console.Clear();
    }
}