using demoFinal.Dto.request;
using demoFinal.entity;

namespace demoFinal.Repository.IRepository
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsuario();
        Usuario GetUsuario(int UsuarioId);

        Task<UsuarioRequest> Login(UsuarioRequest usuarioRequest);
        Task<Usuario> Register(UsuarioRegisterRequest usuarioRegisterRequest);

        bool IsUniqueUser(string username);
    }
}
