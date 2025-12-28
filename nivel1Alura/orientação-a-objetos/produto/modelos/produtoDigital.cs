namespace produto.produto;

class ProdutoDigital : Produto
{
    private string imagem;
    private string linkDownload;

    public ProdutoDigital(string imagem, string nome, string descricao, decimal preco,string linkDownload)
    :base(imagem,nome,descricao,preco)
    {
       this.linkDownload = linkDownload;
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





}