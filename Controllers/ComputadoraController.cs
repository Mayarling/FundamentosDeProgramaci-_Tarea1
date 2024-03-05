using Microsoft.AspNetCore.Mvc;
using Tarea.LogicaDeNegocio;
using Tarea.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tarea.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputadoraController : ControllerBase
    {
        private readonly BSComputadora ServicioComputadora = new();

        // GET: api/<ComputadoraController>
        [HttpGet]
        public IEnumerable<Computadora> Get()
        {
            return ServicioComputadora.ObtenerTodos();
        }

        // GET api/<ComputadoraController>/5
        [HttpGet("{id}")]
        public Computadora Get(int id)
        {
            return ServicioComputadora.Obtener(id);
        }

        // POST api/<ComputadoraController>
        [HttpPost]
        public void Post([FromBody] Computadora computadora)
        {
            ServicioComputadora.Agregar(computadora);
        }

        // PUT api/<ComputadoraController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Computadora computadora)
        {
            ServicioComputadora.Actualizar(computadora);
        }

        // DELETE api/<ComputadoraController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ServicioComputadora.Borrar(id);
        }

        // POST api/<ComputadoraController>/1/paisesVenta
        [HttpPost("{idComputadora}/paisesVenta")]
        public void AgregarPaisVenta([FromRoute] int idComputadora, [FromBody] Pais pais)
        {
            ServicioComputadora.AgregarPaisVenta(idComputadora, pais);
        }

        // POST api/<ComputadoraController>/1/paisesProhibicion
        [HttpPost("{idComputadora}/paisesProhibicion")]
        public void AgregarPaisVentaProhibida([FromRoute] int idComputadora, [FromBody] Pais pais)
        {
            ServicioComputadora.AgregarPaisProhibido(idComputadora, pais);
        }

        // PUT api/<ComputadoraController>/1/paisesVenta
        [HttpPut("{idComputadora}/paisesVenta/{idPais}")]
        public void ActualizarPaisVenta([FromRoute] int idComputadora, [FromRoute] int idPais, [FromBody] Pais pais)
        {
            pais.Id = idPais;
            ServicioComputadora.ActualizarPaisVenta(idComputadora, pais);
        }
        // PUT api/<ComputadoraController>/1/paisesProhibicion
        [HttpPut("{idComputadora}/paisesProhibicion/{idPais}")]
        public void ActualizarpaisesProhibicion([FromRoute] int idComputadora, [FromRoute] int idPais, [FromBody] Pais pais)
        {
            pais.Id = idPais;
            ServicioComputadora.ActualizarPaisProhibido(idComputadora, pais);
        }

        // GET api/<ComputadoraController>/1/paisesVenta
        [HttpGet("{idComputadora}/paisesVenta")]
        public List<Pais> ListarPaisVenta([FromRoute] int idComputadora)
        {
            Computadora computadora = ServicioComputadora.Obtener(idComputadora);
            return computadora.Paises_venta;
        }

        // GET api/<ComputadoraController>/1/paisesProhibicion
        [HttpGet("{idComputadora}/paisesProhibicion")]
        public List<Pais> ListarPaisesProhibicion([FromRoute] int idComputadora)
        {
            Computadora computadora = ServicioComputadora.Obtener(idComputadora);
            return computadora.Paises_Prohibida_venta;
        }
    }
}
