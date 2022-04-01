using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CantinaBill.Class
{
    class ItemVenda
    {
        public string NomeItem { get; set; }
        public decimal PVenda { get; set; }
        public int     Quantidade { get; set; }
        public decimal TotalItem { get; set; }

        public ItemVenda(string nomeItem, decimal pVenda, decimal totalItem, int quantidade)
        {
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
