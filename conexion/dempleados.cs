using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace conexion
{
    public class dempleados
    {
        //Variables
        private int _id_empleado;
        private string _nombre;
        private string _apellidop;
        private string _apellidom;
        private DateTime _fecha_nac;
        private string _domicilio;
        private string _telefono;
        private string _sexo;
        private string _curp;
        private string _rfc;
        private double _salario_dia;

        public int Id_empleado { get => _id_empleado; set => _id_empleado = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Apellidop { get => _apellidop; set => _apellidop = value; }
        public string Apellidom { get => _apellidom; set => _apellidom = value; }
        public DateTime Fecha_nac { get => _fecha_nac; set => _fecha_nac = value; }
        public string Domicilio { get => _domicilio; set => _domicilio = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Sexo { get => _sexo; set => _sexo = value; }
        public string Curp { get => _curp; set => _curp = value; }
        public string Rfc { get => _rfc; set => _rfc = value; }
        public double Salario_dia { get => _salario_dia; set => _salario_dia = value; }

        //Constructores

        public dempleados()
        {

        }

        public dempleados(int idempleado, string nombre, string apellidop, string apellidom, DateTime fecha_nac, string domicilio, string telefono, string sexo, string curp, string rfc, double salario)
        {
            this.Id_empleado = idempleado;
            this.Nombre = nombre;
            this.Apellidop = apellidop;
            this.Apellidom = apellidom;
            this.Fecha_nac = fecha_nac;
            this.Domicilio = domicilio;
            this.Telefono = telefono;
            this.Sexo = sexo;
            this.Curp = curp;
            this.Rfc = rfc;
            this.Salario_dia = salario;
        }

        //metodos

        public string Insertar(dempleados empleados)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = conexion.Cn;
                Sqlcon.Open();
                //Establecer el comando;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "spinsertar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridempleado = new SqlParameter();
                Paridempleado.ParameterName = "@id_empleado";
                Paridempleado.SqlDbType = SqlDbType.Int;
                Paridempleado.Direction = ParameterDirection.Output;
                SqlCmd.Parameters.Add(Paridempleado);

                SqlParameter Parnombre = new SqlParameter();
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = empleados.Nombre;
                SqlCmd.Parameters.Add(Parnombre);

                SqlParameter Parapellidop = new SqlParameter();
                Parapellidop.ParameterName = "@apellido_paterno";
                Parapellidop.SqlDbType = SqlDbType.VarChar;
                Parapellidop.Size = 50;
                Parapellidop.Value = empleados.Apellidop;
                SqlCmd.Parameters.Add(Parapellidop);

                SqlParameter Parapellidom = new SqlParameter();
                Parapellidom.ParameterName = "@apellido_materno";
                Parapellidom.SqlDbType = SqlDbType.VarChar;
                Parapellidom.Size = 50;
                Parapellidom.Value = empleados.Apellidom;
                SqlCmd.Parameters.Add(Parapellidom);

                SqlParameter Parfechanac = new SqlParameter();
                Parfechanac.ParameterName = "@fecha_nac";
                Parfechanac.SqlDbType = SqlDbType.Date;
                //Parfechanac.Size = 50;
                Parfechanac.Value = empleados.Fecha_nac;
                SqlCmd.Parameters.Add(Parfechanac);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@domicilio";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = empleados.Domicilio;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 15;
                ParTelefono.Value = empleados.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter Parsexo = new SqlParameter();
                Parsexo.ParameterName = "@sexo";
                Parsexo.SqlDbType = SqlDbType.VarChar;
                Parsexo.Size = 1;
                Parsexo.Value = empleados.Sexo;
                SqlCmd.Parameters.Add(Parsexo);

                SqlParameter Parcurp = new SqlParameter();
                Parcurp.ParameterName = "@curp";
                Parcurp.SqlDbType = SqlDbType.VarChar;
                Parcurp.Size = 20;
                Parcurp.Value = empleados.Curp;
                SqlCmd.Parameters.Add(Parcurp);

                SqlParameter Parrfc = new SqlParameter();
                Parrfc.ParameterName = "@rfc";
                Parrfc.SqlDbType = SqlDbType.VarChar;
                Parrfc.Size = 20;
                Parrfc.Value = empleados.Rfc;
                SqlCmd.Parameters.Add(Parrfc);

                SqlParameter Parsalario = new SqlParameter();
                Parsalario.ParameterName = "@salario";
                Parsalario.SqlDbType = SqlDbType.Money;
                Parsalario.Value = empleados.Salario_dia;
                SqlCmd.Parameters.Add(Parsalario);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Ingreso el Registro";

            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();
            }
            return rpta;
        }

        //metodo editar

        public string Editar(dempleados empleados)
        {
            string rpta = "";
            SqlConnection Sqlcon = new SqlConnection();
            try
            {
                Sqlcon.ConnectionString = conexion.Cn;
                Sqlcon.Open();
                //Establecer el comando;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = Sqlcon;
                SqlCmd.CommandText = "speditar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridempleado = new SqlParameter();
                Paridempleado.ParameterName = "@id_empleado";
                Paridempleado.SqlDbType = SqlDbType.Int;
                Paridempleado.Value = empleados.Id_empleado;
                SqlCmd.Parameters.Add(Paridempleado);

                SqlParameter Parnombre = new SqlParameter();
                Parnombre.ParameterName = "@nombre";
                Parnombre.SqlDbType = SqlDbType.VarChar;
                Parnombre.Size = 50;
                Parnombre.Value = empleados.Nombre;
                SqlCmd.Parameters.Add(Parnombre);

                SqlParameter Parapellidop = new SqlParameter();
                Parapellidop.ParameterName = "@apellido_paterno";
                Parapellidop.SqlDbType = SqlDbType.VarChar;
                Parapellidop.Size = 50;
                Parapellidop.Value = empleados.Apellidop;
                SqlCmd.Parameters.Add(Parapellidop);

                SqlParameter Parapellidom = new SqlParameter();
                Parapellidom.ParameterName = "@apellido_materno";
                Parapellidom.SqlDbType = SqlDbType.VarChar;
                Parapellidom.Size = 50;
                Parapellidom.Value = empleados.Apellidom;
                SqlCmd.Parameters.Add(Parapellidom);

                SqlParameter Parfechanac = new SqlParameter();
                Parfechanac.ParameterName = "@fecha_nac";
                Parfechanac.SqlDbType = SqlDbType.VarChar;
                Parfechanac.Size = 50;
                Parfechanac.Value = empleados.Fecha_nac;
                SqlCmd.Parameters.Add(Parfechanac);

                SqlParameter ParDireccion = new SqlParameter();
                ParDireccion.ParameterName = "@domicilio";
                ParDireccion.SqlDbType = SqlDbType.VarChar;
                ParDireccion.Size = 100;
                ParDireccion.Value = empleados.Domicilio;
                SqlCmd.Parameters.Add(ParDireccion);

                SqlParameter ParTelefono = new SqlParameter();
                ParTelefono.ParameterName = "@telefono";
                ParTelefono.SqlDbType = SqlDbType.VarChar;
                ParTelefono.Size = 15;
                ParTelefono.Value = empleados.Telefono;
                SqlCmd.Parameters.Add(ParTelefono);

                SqlParameter Parsexo = new SqlParameter();
                Parsexo.ParameterName = "@sexo";
                Parsexo.SqlDbType = SqlDbType.VarChar;
                Parsexo.Size = 1;
                Parsexo.Value = empleados.Sexo;
                SqlCmd.Parameters.Add(Parsexo);

                SqlParameter Parcurp = new SqlParameter();
                Parcurp.ParameterName = "@curp";
                Parcurp.SqlDbType = SqlDbType.VarChar;
                Parcurp.Size = 20;
                Parcurp.Value = empleados.Curp;
                SqlCmd.Parameters.Add(Parcurp);

                SqlParameter Parrfc = new SqlParameter();
                Parrfc.ParameterName = "@rfc";
                Parrfc.SqlDbType = SqlDbType.VarChar;
                Parrfc.Size = 20;
                Parrfc.Value = empleados.Rfc;
                SqlCmd.Parameters.Add(Parrfc);

                SqlParameter Parsalario = new SqlParameter();
                Parsalario.ParameterName = "@salario";
                Parsalario.SqlDbType = SqlDbType.Money;
                Parsalario.Value = empleados.Salario_dia;
                SqlCmd.Parameters.Add(Parsalario);

                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";
            }catch(Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (Sqlcon.State == ConnectionState.Open) Sqlcon.Close();

            }
            return rpta;
        }

        //metodo eliminaar

        public string Eliminar(dempleados empleados)
        {
            string rpta = "";
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                //Código
                SqlCon.ConnectionString = conexion.Cn;
                SqlCon.Open();
                //Establecer el Comando
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "speliminar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@idempleado";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = empleados.Id_empleado;
                SqlCmd.Parameters.Add(ParIdtrabajador);


                //Ejecutamos nuestro comando

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Elimino el Registro";


            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return rpta;
        }

        //metodo mostrar

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("empleados");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_empleado";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter SqlDat = new SqlDataAdapter(SqlCmd);
                SqlDat.Fill(DtResultado);

            }
            catch (Exception)
            {
                DtResultado = null;
            }
            return DtResultado;

        }
    }
}
