using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using conexion;

namespace capaN
{
    public class Nempleado
    {
        //metodo insertar, llama al metodo insertar de la capa de conexion

        public static string Insertar(string nombre, string apellidop, string apellidom, DateTime fecha_nac, string domicilio, string telefono, string sexo, string curp, string rfc, double salario)
        {
            dempleados Obj = new dempleados();
            Obj.Nombre = nombre;
            Obj.Apellidop = apellidop;
            Obj.Apellidom = apellidom;
            Obj.Fecha_nac = fecha_nac;
            Obj.Domicilio = domicilio;
            Obj.Telefono = telefono;
            Obj.Sexo = sexo;
            Obj.Curp = curp;
            Obj.Rfc = rfc;
            Obj.Salario_dia = salario;

            return Obj.Insertar(Obj);

        }

        public static string Editar(int idempleado, string nombre, string apellidop, string apellidom, DateTime fecha_nac, string domicilio, string telefono, string sexo, string curp, string rfc, double salario)
        {
            dempleados Obj = new dempleados(idempleado, nombre, apellidop, apellidom, fecha_nac, domicilio, telefono, sexo, curp, rfc, salario);
            /*Obj.Id_empleado = idempleado;
            Obj.Nombre = nombre;
            Obj.Apellidop = apellidop;
            Obj.Apellidom = apellidom;
            Obj.Fecha_nac = fecha_nac;
            Obj.Domicilio = domicilio;
            Obj.Telefono = telefono;
            Obj.Sexo = sexo;
            Obj.Curp = curp;
            Obj.Rfc = rfc;
            ObJ.Salario_dia = salario;*/

            return Obj.Editar(Obj);
        }

        public static string Eliminar(int idempleado)
        {
            dempleados Obj = new dempleados();
            Obj.Id_empleado = idempleado;
            return Obj.Eliminar(Obj);
        }

        public static DataTable Mostrar()
        {
            return new dempleados().Mostrar();
        }
    }
}
