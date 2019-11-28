using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using conexion;

namespace capaN
{
    public class Nhorario
    {
        public static string Insertar(int id_empleado, string hora_entrada, string inicio_entrada, string fin_entrada, string inicio_salida, string fin_salida)
        {
            Dhorario Obj = new Dhorario(id_empleado, hora_entrada, inicio_entrada, fin_entrada, inicio_salida, fin_salida);
            return Obj.Insertar(Obj);
        }

        public static string Editar(int id_empleado, string hora_entrada, string inicio_entrada, string fin_entrada, string inicio_salida, string fin_salida)
        {
            Dhorario Obj = new Dhorario(id_empleado, hora_entrada, inicio_entrada, fin_entrada, inicio_salida, fin_salida);
            return Obj.Editar(Obj);
        }

        public static string Eliminar(int id_empleado)
        {
            Dhorario Obj = new Dhorario();
            Obj.Id_empleado = id_empleado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new Dhorario().Mostrar();
        }
    }
}
