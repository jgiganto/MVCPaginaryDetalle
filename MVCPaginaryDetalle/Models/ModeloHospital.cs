using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#region PROCEDIMIENTOS ALMACENADOS

//CREATE PROCEDURE PAGINAR_HOSPITAL
//(@POSICION INT) AS
//SELECT* FROM
//(SELECT ROW_NUMBER()
//OVER (ORDER BY HOSPITAL_COD)
//AS POSICION, NOMBRE, DIRECCION
//, TELEFONO, NUM_CAMA, HOSPITAL_COD
//FROM HOSPITAL) HOSPITALES
//WHERE POSICION = @POSICION
//GO

#endregion

namespace MVCPaginaryDetalle.Models
{
    public class ModeloHospital
    {
        ContextoHospital contexto;
        public ModeloHospital()
        {
            contexto = new ContextoHospital();
        }
        public PAGINARHOSPITAL_Result GetHospitalPaginado (int posicion)
        {
            var resultado = contexto.PAGINARHOSPITAL(posicion);
            return resultado.FirstOrDefault();
        }
        public int GetNumeroHospitales()
        {
            var consulta = (from datos in contexto.HOSPITAL
                            select datos).Count();
            return consulta;
        }
        public List<DOCTOR> GetDoctoresHospital(string hospitalcod)
        {
            var consulta = from datos in contexto.DOCTOR
                           where datos.HOSPITAL_COD == hospitalcod
                           select datos;

            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.ToList();
            }
        }
       
            
    }
}