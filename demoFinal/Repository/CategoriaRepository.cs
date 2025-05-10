using demoFinal.Data;
using demoFinal.entity;
using demoFinal.Repository.IRepository;

namespace demoFinal.Repository
{

    public class CategoriaRepository : ICategoriaRepository
    {
        public readonly AplicationDbContext _bd;

        public CategoriaRepository(AplicationDbContext bd)
        {
            _bd = bd;
        }

        public bool CreateCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.UtcNow;
            _bd.Add(categoria);
            return Save();
        }

        public bool DeleteCategoria(Categoria categoria)
        {
            _bd.Remove(categoria);
            return Save();
        }

        public bool DoesCategoryExist(int categoriaId)
        {
            return _bd.Categoria.Any(c =>  c.Id == categoriaId);
        }

        public bool DoesCategoryExist(string nombre)
        {
      
            bool valor = _bd.Categoria.Any(c => c.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            return valor;
        }

        public ICollection<Categoria> GetCategoria()
        {
            return _bd.Categoria.OrderBy(c => c.Nombre).ToList();
        }

        public Categoria GetCategoria(int CategoriaId)
        {
            return _bd.Categoria.FirstOrDefault(c => c.Id == CategoriaId);
        }

        public bool Save()
        {
            return _bd.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            categoria.FechaCreacion = DateTime.UtcNow;
            _bd.Update(categoria);
            return Save();
        }
    }
}
