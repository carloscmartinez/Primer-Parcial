using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LiquidacionController: ControllerBase
    {
        private readonly LiquidacionService _liquidacionService;
        public IConfiguration Configuration { get; }
        public LiquidacionController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _liquidacionService = new LiquidacionService(connectionString);
        }
        // GET: api/Liquidacion
        [HttpGet]
        public IEnumerable<LiquidacionViewModel> Gets()
        {
            var liquidaciones = _liquidacionService.ConsultarTodos().Select(p=> new LiquidacionViewModel(p));
            return liquidaciones;
        }

     

        // POST: api/Liquidacion
        [HttpPost]
        public ActionResult<LiquidacionViewModel> Post(LiquidacionInputModel liquidacionInput)
        {
            Liquidacion liquidacion = MapearLiquidacion(liquidacionInput);
            var response = _liquidacionService.Guardar(liquidacion);
            if (response.Error) 
            {
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Liquidacion);
        }
      

        private Liquidacion MapearLiquidacion(LiquidacionInputModel liquidacionInput)
        {
            var liquidacion = new Liquidacion
            {
               

                NumeroContrato = liquidacionInput. NumeroContrato,
                ObjetoContrato = liquidacionInput.ObjetoContrato,
                ValorContrato = liquidacionInput.ValorContrato,
                ApoyaEmergencia = liquidacionInput.ApoyaEmergencia,
                
                
            };
            return liquidacion;
        }
        
    }
}