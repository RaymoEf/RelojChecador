using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace conexion
{
    public class Dsalida
    {
        private int _Id_empleado;
        private DateTime _Fecha;
        private string _Hora;

        public int Id_empleado { get => _Id_empleado; set => _Id_empleado = value; }
        public DateTime Fecha { get => _Fecha; set => _Fecha = value; }
        public string Hora { get => _Hora; set => _Hora = value; }

        public Dsalida()
        {

        }

        public Dsalida(int id_empleado, DateTime fecha, string hora)
        {
            this.Id_empleado = id_empleado;
            this.Fecha = fecha;
            this.Hora = hora;
        }

        public string Insertar(Dsalida salida)
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
                SqlCmd.CommandText = "spinsertar_salida";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridempleado = new SqlParameter();
                Paridempleado.ParameterName = "@id_empleado";
                Paridempleado.SqlDbType = SqlDbType.Int;
                Paridempleado.Value = salida.Id_empleado;
                SqlCmd.Parameters.Add(Paridempleado);

                SqlParameter Parfecha = new SqlParameter();
                Parfecha.ParameterName = "@fecha";
                Parfecha.SqlDbType = SqlDbType.Date;
                //Parfechanac.Size = 50;
                Parfecha.Value = salida.Fecha;
                SqlCmd.Parameters.Add(Parfecha);

                SqlParameter Parhoraentrada = new SqlParameter();
                Parhoraentrada.ParameterName = "@hora";
                Parhoraentrada.SqlDbType = SqlDbType.VarChar;
                Parhoraentrada.Size = 50;
                Parhoraentrada.Value = salida.Hora;
                SqlCmd.Parameters.Add(Parhoraentrada);

                rpta = SqlCmd.ExecuteNonQuery() == 1 ? "OK" : "NO se Actualizo el Registro";

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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("salidas");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_salida";
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
