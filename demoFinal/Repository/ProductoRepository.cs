using demoFinal.Data;
using demoFinal.entity;
using demoFinal.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace demoFinal.Repository
{

    public class ProductoRepository : IProductoRepository
    {
        public readonly AplicationDbContext _bd;

        public ProductoRepository(AplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool CreateProduct(Producto producto)
        {
            producto.FechaCreacion = DateTime.UtcNow;
            _bd.Add(producto);
            return Save();
        }

        public bool DeleteProduct(Producto producto)
        {
            _bd.Remove(producto);
            return Save();
        }

        public bool DoesProductExist(int productoId)
        {
            return _bd.Categoria.Any(c =>  c.Id == productoId);
        }

        public bool DoesProductExist(string nombre)
        {
      
            bool valor = _bd.Producto.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public ICollection<Producto> GetProduct()
        {
            return _bd.Producto.OrderBy(c => c.Nombre).ToList();
        }

        public Producto GetProduct(int ProductoId)
        {
            return _bd.Producto.FirstOrDefault(c => c.Id == ProductoId);
        }

        public ICollection<Producto> GetProductByCategory(int categoryId)
        {
            return _bd.Producto.Include(ca => ca.Categoria).Where(ca => ca.CategoriaId == categoryId).ToList();
        }

        public bool Save()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public IEnumerable<Producto> SearchProduct(string name)
        {
            IQueryable<Producto> query = _bd.Producto;
            if(!string.IsNullOrEmpty(name))
            {
                query = query.Where(e =>
                e.Nombre.ToLower().Contains(name.ToLower()) ||
                e.Descripcion.ToLower().Contains(name.ToLower()));
            }
            return query.ToList();
        }

        public bool UpdateProduct(Producto producto)
        {
            producto.FechaCreacion = DateTime.UtcNow;
            _bd.Update(producto);
            return Save();
        }


    }
}
