namespace produto.produto;

abstract class Produto
{
    private string imagem;

   
    public string Nome {get;}
    public string Descricao { get; }
    public decimal Preco { get; private set; }
      public Produto(string imagem, string nome, string descricao, decimal preco)
    {
        imagem = imagem;
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
    }

 public string Imagem
    {
        get
        {
            return imagem;
        }
        set
        {
            if (value.Length > 0)
            {
                this.imagem = value;
            }
        }
    }
    public void AlterarPrecoComDesconto(decimal desconto)
{
    Preco = Preco * (1 - desconto/100);
}

   
}