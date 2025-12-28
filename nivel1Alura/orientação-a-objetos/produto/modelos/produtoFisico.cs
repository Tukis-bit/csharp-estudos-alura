namespace produto.produto;

class ProdutoFisico : Produto
{
  
    public ProdutoFisico(string imagem, string nome, string descricao, decimal preco,int estoque)
    :base (imagem,nome,descricao,preco)
    {
       this.Estoque = estoque;
        
    }

    public int Estoque { get; }

    public bool EstaDisponivel()
    {
        return Estoque > 0;
    }

  
   
}