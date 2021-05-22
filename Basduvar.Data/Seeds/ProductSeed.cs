using Basduvar.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basduvar.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _ids;
        public ProductSeed(int[] ids)
        {
            _ids = ids;
        }
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product { Id=1,Name="Pilot Kalem",Price=7.5m,Stock=21,CategoryId=_ids[0]},
                new Product { Id=2,Name="Kurşun Kalem",Price=75.5m,Stock=210,CategoryId=_ids[0]},
                new Product { Id=3,Name="Tükenmez Kalem",Price=100m,Stock=500,CategoryId=_ids[0]},
                new Product { Id=4,Name="Küçük Boy Defter",Price=25.50m,Stock=50,CategoryId=_ids[1]},
                new Product { Id=5,Name="Orta Boy Defter",Price=30m,Stock=75,CategoryId=_ids[1]},
                new Product { Id=6,Name="Büyük Boy Defter",Price=50m,Stock=40,CategoryId=_ids[1]}
                );
        }
    }
}
