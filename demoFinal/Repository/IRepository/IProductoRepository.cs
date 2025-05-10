using demoFinal.entity;

namespace demoFinal.Repository.IRepository
{
    public interface IProductoRepository
    {
        ICollection<Producto> GetProduct();
        ICollection<Producto> GetProductByCategory(int categoryId);
        IEnumerable<Producto> SearchProduct(string name);
         
        Producto GetProduct(int productId);
        bool DoesProductExist(int productId);
        bool DoesProductExist(string name);
        bool CreateProduct(Producto product);
        bool UpdateProduct(Producto product);
        bool DeleteProduct(Producto product);
        bool Save();

    }
}
