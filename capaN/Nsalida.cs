using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using conexion;

namespace capaN
{
    public class Nsalida
    {
        public static string Insertar(int id_empleado, DateTime fecha, string hora)
        {
            DateTime hora_registro = Convert.ToDateTime(hora);
            DateTime inicio = Convert.ToDateTime(Class1.inicio_salida);
            DateTime fin = Convert.ToDateTime(Class1.fin_salida);
            if (hora_registro < inicio)
            {
                return "Salida Antes de tienpo, no se registro";
            }
            else
            {
                Dsalida Obj = new Dsalida(id_empleado, fecha, hora);
                return Obj.Insertar(Obj);
            }

        }

        public static DataTable Mostrar()
        {
            return new Dsalida().Mostrar();
        }
    }
}
