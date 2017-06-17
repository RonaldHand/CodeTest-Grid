using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksModel.Product;

namespace AdventureWorksDAL.Repositories
{
    public class ProductRepo : AdventureWorksModel.Repository.iProductRepository
    {
        public IEnumerable<Product_dto> GetProducts()
        {
            using (var ctx = new AWEntities())
            {
                var results = ctx.Products.AsNoTracking().ToList();
                return results.Select(r => Transform(r)).ToList();
            }
        }

        public Product_dto Get_ByKey(int key)
        {
            using (var ctx = new AWEntities())
            {
                return ctx.Products.Where(x => x.ProductID == key)
                .Select(r => Transform(r)).FirstOrDefault();
            }
        }

        public Product_dto Save(Product_dto data)
        {
            using (var ctx = new AWEntities())
            {
                var efo = Transform(data);
                ctx.Products.Attach(efo);
                ctx.Entry(efo).State = DbContextHelper.GetEntityState(data);
                ctx.SaveChanges();
                return Transform(ctx.Entry(efo).Entity);
            }
        }

        private static Product Transform(Product_dto data)
        {
            //Should throw an error if nullable types do not have values, object should check this first.
            return new Product()
            {
                ProductID = data.ProductID.GetValueOrDefault(),
                Name = data.Name,
                ProductNumber = data.ProductNumber,
                MakeFlag = data.MakeFlag.GetValueOrDefault(),
                FinishedGoodsFlag = data.FinishedGoodsFlag.GetValueOrDefault(),
                Color = data.Color,
                SafetyStockLevel = data.SafetyStockLevel.GetValueOrDefault(),
                ReorderPoint = data.ReorderPoint.GetValueOrDefault(),
                StandardCost = data.StandardCost.GetValueOrDefault(),
                ListPrice = data.ListPrice.GetValueOrDefault(),
                Size = data.Size,
                SizeUnitMeasureCode = data.SizeUnitMeasureCode,
                WeightUnitMeasureCode = data.WeightUnitMeasureCode,
                Weight = data.Weight,
                DaysToManufacture = data.DaysToManufacture.GetValueOrDefault(),
                ProductLine = data.ProductLine,
                Class = data.Class,
                Style = data.Style,
                ProductSubcategoryID = data.ProductSubcategoryID,
                ProductModelID = data.ProductModelID,
                SellStartDate = data.SellStartDate ?? DateTime.UtcNow,
                SellEndDate = data.SellEndDate,
                DiscontinuedDate = data.DiscontinuedDate,
                rowguid = data.rowguid ?? Guid.NewGuid(),
                ModifiedDate = data.ModifiedDate ?? DateTime.UtcNow
            };
        }

        private static Product_dto Transform(Product data)
        {
            return new Product_dto()
            {
                ProductID = data.ProductID,
                Name = data.Name,
                ProductNumber =  data.ProductNumber,
                MakeFlag = data.MakeFlag,
                FinishedGoodsFlag = data.FinishedGoodsFlag,
                Color = data.Color,
                SafetyStockLevel = data.SafetyStockLevel,
                ReorderPoint = data.ReorderPoint,
                StandardCost = data.StandardCost,
                ListPrice = data.ListPrice,
                Size = data.Size,
                SizeUnitMeasureCode = data.SizeUnitMeasureCode,
                WeightUnitMeasureCode = data.WeightUnitMeasureCode,
                Weight = data.Weight,
                DaysToManufacture = data.DaysToManufacture,
                ProductLine = data.ProductLine,
                Class = data.Class,
                Style = data.Style,
                ProductSubcategoryID = data.ProductSubcategoryID,
                ProductModelID = data.ProductModelID,
                SellStartDate = data.SellStartDate,
                SellEndDate = data.SellEndDate,
                DiscontinuedDate = data.DiscontinuedDate,
                rowguid = data.rowguid,
                ModifiedDate = data.ModifiedDate
            };
        }


    }
}
