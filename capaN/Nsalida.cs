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
            Dsalida Obj = new Dsalida(id_empleado, fecha, hora);
            return Obj.Insertar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new Dsalida().Mostrar();
        }
    }
}
