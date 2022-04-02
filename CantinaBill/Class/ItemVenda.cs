namespace CantinaBill.Class
{
    class ItemVenda
    {
        public string NomeItem { get; set; }
        public int idproduto { get; set; }
        public decimal PVenda { get; set; }
        public decimal Quantidade { get; set; }
        public decimal TotalItem { get; set; }

        public ItemVenda(int idProduto, string nomeItem, decimal pVenda, decimal totalItem, decimal quantidade)
        {
            idproduto = idProduto;
            NomeItem = nomeItem;
            PVenda = pVenda;
            TotalItem = totalItem;
            Quantidade = quantidade;
        }

        public ItemVenda()
        {
        }
    }
}
