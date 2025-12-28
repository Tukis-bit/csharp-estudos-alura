namespace produto.produto;

class ProdutoDigital : Produto, IExpiravel
{
    private string imagem;
    private string linkDownload;
    private DateTime DataCompra;

    public ProdutoDigital(string imagem, string nome, string descricao, decimal preco,string linkDownload)
    :base(imagem,nome,descricao,preco)
    {
       this.linkDownload = linkDownload;
       this.DataCompra = DateTime.Now;
    }


    public string LinkDownload
    {
        get
        {
            return linkDownload;
        }
        set
        {
            if (value.Length > 0)
            {
                this.linkDownload = value;
            }
        }
    }

    public bool EstaExpirado()
    {
        return DateTime.Now > DataCompra.AddYears(2);
    }
}