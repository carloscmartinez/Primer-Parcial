using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class LiquidacionRepository
    {
        private readonly SqlConnection _connection;
        private readonly List<Liquidacion> _Liquidaciones = new List<Liquidacion>();
        public LiquidacionRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }
        public void Guardar(Liquidacion liquidacion)
        {
            using (var command = _connection.CreateCommand())
            {

                command.CommandText = @"Insert Into Liquidacion (NumeroContrato,ObjetoContrato,ValorContrato,ApoyaEmergencia,ValorEstampilla) 
                                        values (@NumeroContrato,@ObjetoContrato,@ValorContrato,@ApoyaEmergencia,@ValorEstampilla)";
                command.Parameters.AddWithValue("@NumeroContrato", liquidacion.NumeroContrato);
                command.Parameters.AddWithValue("@ObjetoContrato", liquidacion.ObjetoContrato);
                command.Parameters.AddWithValue("@ValorContrato", liquidacion.ValorContrato);
                command.Parameters.AddWithValue("@ApoyaEmergencia", liquidacion.ApoyaEmergencia);
                command.Parameters.AddWithValue("@ValorEstampilla", liquidacion.ValorEstampilla);
                var filas = command.ExecuteNonQuery();
            }
        }

        public List<Liquidacion> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Liquidacion> liquidaciones = new List<Liquidacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from liquidacion ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Liquidacion liquidacion = DataReaderMapToLiquidacion(dataReader);
                        liquidaciones.Add(liquidacion);
                    }
                }
            }
            return liquidaciones;
        }

        private Liquidacion DataReaderMapToLiquidacion(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Liquidacion liquidacion = new Liquidacion();
            liquidacion.NumeroContrato = (string)dataReader["NumeroContrato"];
            liquidacion.ObjetoContrato = (string)dataReader["ObjetoContrato"];
            liquidacion.ValorContrato = (decimal)dataReader["ValorContrato"];
            liquidacion.ApoyaEmergencia = (string)dataReader["ApoyaEmergencia"];
            liquidacion.ValorEstampilla = (decimal)dataReader["ValorEstampilla"];
            
            return liquidacion;
        }
    }
}

