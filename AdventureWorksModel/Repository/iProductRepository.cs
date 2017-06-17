using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksModel.Repository
{
    public interface iProductRepository
    {
        IEnumerable<Product.Product_dto> GetProducts();
        Product.Product_dto Get_ByKey(int key);
        Product.Product_dto Save(Product.Product_dto product);

    }
}
