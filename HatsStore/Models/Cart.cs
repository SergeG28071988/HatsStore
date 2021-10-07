using System.Collections.Generic;
using System.Linq;

namespace HatsStore.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Hat hat, int quantity)
        {
            CartLine line = lineCollection
                .Where(p => p.Hat.HatId == hat.HatId).FirstOrDefault();

            if(line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Hat = hat,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Hat hat)
        {
            lineCollection.RemoveAll(l => l.Hat.HatId == hat.HatId );
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Hat.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }        
    }

    public class CartLine
    {
        public Hat Hat { get; set; }
        public int Quantity { get; set; }
    }
}

