using ScreenSound.models;
namespace ScreenSound.Menus;
internal class Menu
{
    public void EscreverTitulo(string titulo)
    {
      int quantidadeLetras = titulo.Length;
    string asteriscos = string.Empty.PadLeft(quantidadeLetras, '*');

    Console.Clear();
    Console.WriteLine(asteriscos);
    Console.WriteLine(titulo);
    Console.WriteLine(asteriscos + "\n");        
    }

      public virtual void Executar(Dictionary<string, Banda> bandas)
  {
    Console.Clear();
  }
}