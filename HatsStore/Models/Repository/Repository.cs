using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HatsStore.Models.Repository
{
    public class Repository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Hat> Hats
        {
            get { return context.Hats; }
        }

        // Чтение данных из таблицы Orders
        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders
                    .Include(o => o.OrderLines.Select(ol => ol.Hat));
            }
        }      

        // Сохранить данные заказа в базе данных
        public void SaveOrder(Order order)
        {
            if (order.OrderId == 0)
            {
                order = context.Orders.Add(order);

                foreach (OrderLine line in order.OrderLines)
                {
                    context.Entry(line.Hat).State
                        = EntityState.Modified;
                }

            }
            else
            {
                Order dbOrder = context.Orders.Find(order.OrderId);
                if (dbOrder != null)
                {
                    dbOrder.Name = order.Name;
                    dbOrder.Line1 = order.Line1;
                    dbOrder.Line2 = order.Line2;
                    dbOrder.Line3 = order.Line3;
                    dbOrder.City = order.City;
                    dbOrder.GiftWrap = order.GiftWrap;
                    dbOrder.Dispatched = order.Dispatched;
                }
            }
            context.SaveChanges();
        }

        public void SaveHat(Hat hat)
        {
            if (hat.HatId == 0)
            {
                hat = context.Hats.Add(hat);
            }
            else
            {
                Hat dbHat = context.Hats.Find(hat.HatId);
                if (dbHat != null)
                {
                    dbHat.Name = hat.Name;
                    dbHat.Description = hat.Description;
                    dbHat.Price = hat.Price;
                    dbHat.Category = hat.Category;
                }
            }
            context.SaveChanges();
        }

        public void DeleteHat(Hat hat)
        {
            IEnumerable<Order> orders = context.Orders
                .Include(o => o.OrderLines.Select(ol => ol.Hat))
                .Where(o => o.OrderLines
                    .Count(ol => ol.Hat.HatId == hat.HatId) > 0)
                .ToArray();

            foreach (Order order in orders)
            {
                context.Orders.Remove(order);
            }
            context.Hats.Remove(hat);
            context.SaveChanges();
        }
    }
}
