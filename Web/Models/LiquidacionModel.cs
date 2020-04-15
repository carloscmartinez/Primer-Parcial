using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class LiquidacionInputModel
    {
        public string NumeroContrato { get; set; }
        public string ObjetoContrato { get; set; }
        public decimal ValorContrato { get; set; }
        public string ApoyaEmergencia { get; set; }
        
    }
    
    public class LiquidacionViewModel : LiquidacionInputModel
    {
        public LiquidacionViewModel()
        {

        }
        public LiquidacionViewModel(Liquidacion liquidacion)
        {
            NumeroContrato = liquidacion. NumeroContrato;
            ObjetoContrato = liquidacion.ObjetoContrato;
            ValorContrato = liquidacion.ValorContrato;
            ApoyaEmergencia = liquidacion.ApoyaEmergencia;
            ValorEstampilla = liquidacion.ValorEstampilla;
            
        }
        public decimal ValorEstampilla { get; set; }
    }
}