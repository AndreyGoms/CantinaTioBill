namespace CantinaBill.Class
{
    class ItemVenda
    {
        public int iditem { get; set; }
        public string NomeItem { get; set; }
        public int idproduto { get; set; }
        public decimal PVenda { get; set; }
        public decimal Quantidade { get; set; }
        public decimal TotalItem { get; set; }

        public ItemVenda(int idItem, int idProduto, string nomeItem, decimal pVenda, decimal totalItem, decimal quantidade)
        {
            iditem = idItem;
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
