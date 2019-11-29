using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using conexion;

namespace capaN
{
    public class nentrada
    {
        public static string Insertar(int id_empleado, DateTime fecha, string hora)
        {
            DateTime hora_registro = Convert.ToDateTime(hora);
            DateTime entrada = Convert.ToDateTime(Class1.hora_entrada);
            DateTime inicio = Convert.ToDateTime(Class1.inicio_entrada);
            DateTime fin = Convert.ToDateTime(Class1.fin_entrada);
            if (hora_registro<inicio)
            {
                return "LLegas pronto, no se registro la entrada";
            }
            if (hora_registro >= inicio && hora_registro < entrada)
            {
                Dentrada Obj = new Dentrada(id_empleado, fecha, hora, "Puntual");
                return Obj.Insertar(Obj);
            }
            if (hora_registro >= entrada && hora_registro <= entrada.AddMinutes(5))
            {
                Dentrada Obj = new Dentrada(id_empleado, fecha, hora, "Justo");
                return Obj.Insertar(Obj);
            }
            if (hora_registro >= entrada.AddMinutes(5) && hora_registro <= fin)
            {
                Dentrada Obj = new Dentrada(id_empleado, fecha, hora, "Retardo");
                return Obj.Insertar(Obj);
            }
            if (hora_registro > fin)
            {
                return ("Llegas tarde, no se registro la entrada");
            }
            return "";
            
        }

        public static DataTable Mostrar()
        {
            return new Dentrada().Mostrar();
        }
    }
}
