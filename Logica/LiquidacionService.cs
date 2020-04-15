using Datos;
using Entity;
using System;
using System.Collections.Generic;

namespace Logica
{
    public class LiquidacionService
    {
        private readonly ConnectionManager _conexion;
        private readonly LiquidacionRepository _repositorio;
        public LiquidacionService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new LiquidacionRepository(_conexion);
        }
        public GuardarLiquidacionResponse Guardar(Liquidacion liquidacion)
        {
            try
            {
                liquidacion.CalcularValorEstampilla();
                _conexion.Open();
                _repositorio.Guardar(liquidacion);
                _conexion.Close();
                return new GuardarLiquidacionResponse(liquidacion);
            }
            catch (Exception e)
            {
                return new GuardarLiquidacionResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }
        public List<Liquidacion> ConsultarTodos()
        {
            _conexion.Open();
            List<Liquidacion> liquidaciones = _repositorio.ConsultarTodos();
            _conexion.Close();
            return liquidaciones;
        }
    }

    public class GuardarLiquidacionResponse 
    {
        public GuardarLiquidacionResponse(Liquidacion liquidacion)
        {
            Error = false;
            Liquidacion = liquidacion;
        }
        public GuardarLiquidacionResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Liquidacion Liquidacion { get; set; }
    }
}