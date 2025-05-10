using demoFinal.entity;

namespace demoFinal.Repository.IRepository
{
    public interface ICategoriaRepository
    {
        ICollection<Categoria> GetCategoria();
        Categoria GetCategoria(int CategoriaId);
        bool DoesCategoryExist(int categoriaId);
        bool DoesCategoryExist(string nombre);
        bool CreateCategoria(Categoria categoria);
        bool UpdateCategoria(Categoria categoria);
        bool DeleteCategoria(Categoria categoria);
        bool Save();

    }
}
