using AutoMapper;
using demoFinal.Dto.request;
using demoFinal.Dto.response;
using demoFinal.entity;
using demoFinal.Repository.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace demoFinal.Controllers
{
    [Route("api/productos")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _proRepo;
        private readonly IMapper _mapper;

        public ProductosController(IProductoRepository proRepo, IMapper mapper)
        {
            _proRepo = proRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetProductos()
        {
            var listaProductos = _proRepo.GetProduct();
            var listaProductoResponse = listaProductos.Select(c => _mapper.Map<ProductoResponse>(c));
            return Ok(listaProductoResponse);
        }

        [HttpGet("{productoId:int}", Name = "GetProducto")]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetCategoria(int productoId)
        {
            var itemProducto = _proRepo.GetProduct(productoId);
            if (itemProducto == null)
            {
                return NotFound();
            }

            var itemProductoResponse = _mapper.Map<ProductoResponse>(itemProducto);

            return Ok(itemProductoResponse);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(ProductoResponse))]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult CreateProducto([FromBody] ProductoRequest productoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productoRequest == null)
            {
                return BadRequest(ModelState);
            }

            if (_proRepo.DoesProductExist(productoRequest.Nombre))
            {
                ModelState.AddModelError("", "El producto ya existe");
                return StatusCode(404, ModelState);
            }

            var producto = _mapper.Map<Producto>(productoRequest);


            if (!_proRepo.CreateProduct(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal guardando el registro {producto.Nombre}");
                return StatusCode(400, ModelState);
            }

            return CreatedAtRoute("GetProducto", new { productoId = producto.Id }, producto);
        }

        [HttpPut("{productoId:int}", Name = "UpdateProducto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult UpdateProducto(int productoId, [FromBody] ProductoRequest productoRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (productoRequest == null)
            {
                return BadRequest(ModelState);
            }

            if (!_proRepo.DoesProductExist(productoId))
            {
                return NotFound($"El producto con el ID {productoId} no fue encontrada.");
            }

            var producto = _mapper.Map<Producto>(productoRequest);
            producto.Id = productoId;

            if (!_proRepo.UpdateProduct(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal actualizando el registro {producto.Nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{productoId:int}", Name = "DeleteProducto")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult DeleteProducto(int productoId)
        {


            if (!_proRepo.DoesProductExist(productoId))
            {
                return NotFound($"El producto con el ID {productoId} no fue encontrado.");
            }

            var producto = _proRepo.GetProduct(productoId);


            if (!_proRepo.DeleteProduct(producto))
            {
                ModelState.AddModelError("", $"Algo salio mal borrando el registro {producto.Nombre}");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpGet("GetProductsByCategory/{productoId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetProductByCategory(int productoId)
        {
            var listaProductos = _proRepo.GetProductByCategory(productoId);

            if (listaProductos == null)
            {
                return NotFound();
            }

            var itemProducto = listaProductos.Select(p => _mapper.Map<ProductoResponse>(p));    



            return Ok(itemProducto);
        }

        [HttpGet("Search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Search(string nombre)
        {

            try
            {
                var resultado = _proRepo.SearchProduct(nombre);
                if (resultado.Any())
                {
                    return Ok(resultado);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al recuperar los datos");
            }

        }


    }
}
