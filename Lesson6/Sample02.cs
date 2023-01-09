using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Orders.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    internal class Sample02
    {
        static void Main(string[] args)
        {
            var serviceBuilder = new ServiceCollection();

            #region Configure EF DBContext Service

            serviceBuilder.AddDbContext<OrdersDbContext>(options =>
            {
                options.UseSqlServer("data source=DESKTOP-FMP2IHA\\SQLEXPRESS;initial catalog=OrdersDatabase;" +
                    "User Id=OrdersUser;Password=12345;" +
                    "MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=true;");
            });

            #endregion

            var serviceProvider = serviceBuilder.BuildServiceProvider();

            var context = serviceProvider.GetRequiredService<OrdersDbContext>();

            foreach (var buyer in context.Buyers)
            {
                Console.WriteLine($"{buyer.LastName} {buyer.Name} {buyer.Patronymic} {buyer.Birthday.ToShortDateString()}");
            }

            Console.ReadKey(true);
        }
    }
}
