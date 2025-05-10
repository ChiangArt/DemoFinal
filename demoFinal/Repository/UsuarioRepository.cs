using demoFinal.Data;
using demoFinal.Dto.request;
using demoFinal.Dto.response;
using demoFinal.entity;
using demoFinal.Repository.IRepository;

namespace demoFinal.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public readonly AplicationDbContext _bd;

        public UsuarioRepository(AplicationDbContext bd)
        {
            _bd = bd;
        }

        public ICollection<Usuario> GetUsuario()
        {
            return _bd.Usuario.OrderBy(u => u.Nombre).ToList();
        }

        public Usuario GetUsuario(int UsuarioId)
        {
            return _bd.Usuario.FirstOrDefault(u => u.Id == UsuarioId);
        }

        public bool IsUniqueUser(string username)
        {
            var usuarioBd = _bd.Usuario.FirstOrDefault(u => u.Nombre == username);
            if (usuarioBd != null)
            {
                return true;
            }
            return false;
        }

        public async Task<UsuarioResponse> Login(UsuarioRequest usuarioRequest)
        {
            var usuario = _bd.Usuario.FirstOrDefault(u => u.Nombre.ToLower() == usuarioRequest.Nombre.ToLower()
                && u.Contrasena == usuarioRequest.Contrasena);

            if (usuario != null)
            {
                return new UsuarioResponse()
                {
                    usuario = null,
                };
            }

            UsuarioResponse usuarioResponse = new UsuarioResponse()
            {
                usuario = usuario
            };
            return usuarioResponse;
        }

        public async Task<Usuario> Register(UsuarioRegisterRequest usuarioRegisterRequest)
        {
            Usuario usuario = new Usuario()
            {
                Nombre = usuarioRegisterRequest.Nombre,
                Contrasena = usuarioRegisterRequest.Contrasena,
                Rol = usuarioRegisterRequest.Rol,
            };

            _bd.Usuario.Add(usuario);
            await _bd.SaveChangesAsync();
            return usuario;
        }
    }
}
