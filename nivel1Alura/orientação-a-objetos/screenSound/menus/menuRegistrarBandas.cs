using ScreenSound.models;
namespace ScreenSound.Menus;

internal class MenuRegistrarBandas : Menu
{
    public override void Executar(Dictionary<string, Banda> bandas)
    {
        base.Executar(bandas);
        EscreverTitulo("Registros De Bandas");

    Console.Write("Informe o nome da banda que você quer adicionar: ");
    string banda = Console.ReadLine()!;
    bandas.Add(banda, new Banda(banda));

    Console.WriteLine($"Você adicionou a banda {banda} na lista de bandas");
    Thread.Sleep(2000);
    Console.Clear();
    

    }
}