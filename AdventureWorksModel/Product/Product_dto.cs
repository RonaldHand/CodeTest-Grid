using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksModel.Product
{
    public class Product_dto : ModelBase
    {
        public int? ProductID { get; set; }

        [Required]
        [Display(Name = "Product Name", Description = "Product Name")]
        [DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[Enter Product Name]")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Product Number", Description = "Product Number")]
        public string ProductNumber { get; set; }
        public bool? MakeFlag { get; set; }
        public bool? FinishedGoodsFlag { get; set; }
        public string Color { get; set; }

        public Int16? SafetyStockLevel { get; set; }
        [Required]
        [Display(Name = "Reorder Point", Description = "Reorder Point")]
        [Range(1, 9999)]
        public Int16? ReorderPoint { get; set; }

        [Required]
        [Display(Name = "Standard Cost", Description = "Standard Cost")]
        [UIHint("Integer")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public Decimal? StandardCost { get; set; }
        [Required]
        [Display(Name = "List Price", Description = "List Price")]
        [UIHint("Integer")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:C}")]
        public Decimal? ListPrice { get; set; }
        public string Size { get; set; }
        public string SizeUnitMeasureCode { get; set; }
        public string WeightUnitMeasureCode { get; set; }
        public Decimal? Weight { get; set; }
        public int? DaysToManufacture { get; set; }
        public string ProductLine { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public int? ProductSubcategoryID { get; set; }
        public int? ProductModelID { get; set; }
        public DateTime? SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
        public Guid? rowguid { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
