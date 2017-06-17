using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventureWorksModel.Product;
using AdventureWorksModel.Repository;
using AdventureWorksDAL;

namespace AdventureWorksBLL
{
    public static class ProductController
    {
        private static iProductRepository _context;
        static ProductController()
        {
            //Future Use: Can add build parameters here to specify alternate repositories.
            _context = new AdventureWorksDAL.Repositories.ProductRepo();
        }

        public static List<Product_dto> GetProductList()
        {
            return _context.GetProducts().ToList();
        }

        public static Product_dto GetProduct(int ProductKey)
        {
            return _context.Get_ByKey(ProductKey);
        }
        public static Product_dto Save(Product_dto data)
        {
            return _context.Save(Validate(data));
        }
        private static Product_dto Validate(Product_dto data)
        {
            if (!data.ProductID.HasValue) data.ProductID = 0;
            if (String.IsNullOrEmpty(data.Name)) throw new Exception("Product Name is  a required field");
            if (String.IsNullOrEmpty(data.ProductNumber)) throw new Exception("Product Number is  a required field");
            if (!data.MakeFlag.HasValue) data.MakeFlag = true;
            if (!data.FinishedGoodsFlag.HasValue) data.FinishedGoodsFlag = true;
            if (!data.SafetyStockLevel.HasValue || data.SafetyStockLevel == 0) data.SafetyStockLevel = 1;
            if (!data.ReorderPoint.HasValue) data.ReorderPoint = 0;
            if (!data.StandardCost.HasValue) data.StandardCost = 0;
            if (!data.ListPrice.HasValue) data.ListPrice = 0;
            if (!String.IsNullOrEmpty(data.Size)) data.Size = data.Size.Substring(0, Math.Min(data.Size.Length, 5));
            if (!String.IsNullOrEmpty(data.SizeUnitMeasureCode)) data.SizeUnitMeasureCode = data.SizeUnitMeasureCode.Substring(0, Math.Min(data.SizeUnitMeasureCode.Length, 3));
            if (!String.IsNullOrEmpty(data.WeightUnitMeasureCode)) data.WeightUnitMeasureCode = data.WeightUnitMeasureCode.Substring(0, Math.Min(data.WeightUnitMeasureCode.Length, 3));
            if (!data.Weight.HasValue || data.SafetyStockLevel == 0) data.Weight = 1;
            if (!data.DaysToManufacture.HasValue) data.DaysToManufacture = 0;
            if (!String.IsNullOrEmpty(data.ProductLine)) data.ProductLine = data.ProductLine.Substring(0, Math.Min(data.ProductLine.Length, 2));
            if (!String.IsNullOrEmpty(data.Class)) data.Class = data.Class.Substring(0, Math.Min(data.Class.Length, 2));
            if (!String.IsNullOrEmpty(data.Style)) data.Style = data.Style.Substring(0, Math.Min(data.Style.Length, 2));
            if (!data.SellStartDate.HasValue) data.SellStartDate = DateTime.UtcNow;
            if (!data.rowguid.HasValue) data.rowguid = Guid.NewGuid();
            if (data.IsDirty || data.IsNew) data.ModifiedDate = DateTime.UtcNow;
            return data;
        }
    }
}
