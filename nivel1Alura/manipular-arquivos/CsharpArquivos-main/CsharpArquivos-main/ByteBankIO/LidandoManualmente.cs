using System.Text;
internal class LidandoStream
{
    static void Executar()
    {
      // guardar o arquivo dentro da pasta de executavel(bin/debug/net8.0) para conseguir manipular ele melhor, assim fica menor o nome do caminho até ele 

Console.Clear();

//esse par garante que o caminho esteja sempre correto de acordo com o caminho do diretório raiz do projeto
var enderecoBase = AppContext.BaseDirectory;
var enderecoDoArquivo = Path.Combine(enderecoBase,"contas.txt");

//possibilita que o código funcione enquanto ele está sendo usado 
using(var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
{
   var numeroDeBytesLidos = -1;

// abre o arquivo de acordo com o caminho até ele 


var buffer = new byte[1024]; //1 KB


//vai ler o arquivo da posição 0 até a 1024
while(numeroDeBytesLidos != 0)
{
numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024);    
EscreverBuffer(buffer,numeroDeBytesLidos);
}
 
}

static void EscreverBuffer(byte[] buffer,int bytesLidos)
{
// o UTF8 "traduz" o numero do byte para o simbolo/caracter correspondente a ele,
//  então nós estamos pegando o buffer que é a lista dos bytes do arquivo e retransformando em texto 
    var utf8 = new UTF8Encoding();
    var texto = utf8.GetString(buffer,0,bytesLidos);
    Console.Write(texto);

    // foreach (var meubyte in buffer)
    // {
    //     Console.Write(meubyte);
    //     Console.Write(" ");
    // }
}
    }
}