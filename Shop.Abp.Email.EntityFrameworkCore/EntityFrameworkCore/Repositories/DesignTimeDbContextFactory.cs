using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;
using Utility.Config;
using Utility.Ef;

namespace Shop.EntityFrameworkCore.Repositories
{
    public class DesignTimeDbContextFactory : AbstractDesignTimeDbContextFactory<EmailDbContext>
    {
        public override EmailDbContext CreateDbContext(string[] args)
        {
            DbConfig.Flag = DbFlag.MySql;
            var bulder = new DbContextOptionsBuilder<EmailDbContext>();
            string key = $"ShopEmail/{DbConfig.Flag}ConnectionString";
            //An error occurred using the connection to database mysql ip 写错了
            //Option 'integrated security' not supported.
            //Integrated Security=False;
            var connectionString = ConfigManager.GetByConsul(key);
            Console.WriteLine(connectionString);
            bulder = Parse(DbConfig.Flag, connectionString, bulder);
            return new EmailDbContext(bulder.Options);

            //return new EmailDbContext(new DbContextOptions<EmailDbContext>());
        }
      
    }
}
