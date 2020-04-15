namespace Entity
{
    public class Liquidacion
    {
        public string NumeroContrato { get; set; }
        public string ObjetoContrato { get; set; }
        public decimal ValorContrato { get; set; }
        public string ApoyaEmergencia { get; set; }
        public decimal ValorEstampilla { get; set; }
        public void CalcularValorEstampilla() 
        {
            if (ApoyaEmergencia.Equals("SI"))
            {
                ValorEstampilla=(ValorContrato * 1) / 100;
            }
            else
            {
                ValorEstampilla=(ValorContrato *2) / 100;
            }
        }

        
    }
}