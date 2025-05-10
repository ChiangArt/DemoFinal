using AutoMapper;
using demoFinal.Dto.request;
using demoFinal.Dto.response;
using demoFinal.entity;
using demoFinal.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace demoFinal.Controllers
{
    [Route("api/categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _ctRepo;
        private readonly IMapper _mapper;

        public CategoriasController(ICategoriaRepository ctRepo, IMapper mapper)
        {
            _ctRepo = ctRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetCategorias()
        {
            var listaCategorias = _ctRepo.GetCategoria();
            var listaCategoriasDto = listaCategorias.Select(c => _mapper.Map<CategoriaResponse>(c));
            return Ok(listaCategoriasDto);
        }

        [HttpGet("{categoriaId:int}", Name = "GetCategoria")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetCategoria(int categoriaId)
        {
            var itemCategoria = _ctRepo.GetCategoria(categoriaId);
            if (itemCategoria == null) 
            {
                return NotFound();
            }

            var itemCategoriaDto = _mapper.Map<CategoriaResponse>(itemCategoria);

            return Ok(itemCategoriaDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult CreateCategoria([FromBody]CategoriaRequest categoriaRequest)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            if (categoriaRequest == null) 
            { 
                return BadRequest(ModelState);
            }

            if(_ctRepo.DoesCategoryExist(categoriaRequest.Nombre))
            {
                ModelState.AddModelError("", "La categoria ya existe");
                return StatusCode(404, ModelState);
            }

            var categoria = _mapper.Map<Categoria>(categoriaRequest);
            

            if (!_ctRepo.CreateCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {categoria.Nombre}");
                return StatusCode(400, ModelState);
            }

            return CreatedAtRoute("GetCategoria", new { categoriaId = categoria.Id }, categoria);
        }


        [HttpPut("{categoriaId:int}", Name ="UpdateCategoria")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult UpdateCategoria(int categoriaId, [FromBody] CategoriaRequest categoriaRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (categoriaRequest == null)
            {
                return BadRequest(ModelState);
            }

            if (!_ctRepo.DoesCategoryExist(categoriaId))
            {
                return NotFound($"La categoría con el ID {categoriaId} no fue encontrada.");
            }

            var categoria = _mapper.Map<Categoria>(categoriaRequest);
            categoria.Id = categoriaId;

            if (!_ctRepo.UpdateCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{categoriaId:int}", Name = "DeleteCategoria")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult DeleteCategoria(int categoriaId)
        {
            

            if (!_ctRepo.DoesCategoryExist(categoriaId))
            {
                return NotFound($"La categoría con el ID {categoriaId} no fue encontrada.");
            }

            var categoria = _ctRepo.GetCategoria(categoriaId);
            

            if (!_ctRepo.DeleteCategoria(categoria))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro {categoria.Nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
    }
}
