using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMarket.Models.ViewModels
{
    public class ShoppingCartVM
    {
        public double CartTotal { get; set; }
        public IEnumerable<ShoppingCart> ListCart { get; set; }
        
        //public int Count { get; set; }
    }
}
