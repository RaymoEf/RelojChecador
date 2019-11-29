using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace conexion
{
    public class Dhorario
    {
        //variables
        private int _Id_empleado;
        private string _Hora_entrada;
        private string _Inicio_entrada;
        private string _Fin_entrada;
        private string _Inicio_salida;
        private string _Fin_salida;

        public int Id_empleado { get => _Id_empleado; set => _Id_empleado = value; }
        public string Hora_entrada { get => _Hora_entrada; set => _Hora_entrada = value; }
        public string Inicio_entrada { get => _Inicio_entrada; set => _Inicio_entrada = value; }
        public string Fin_entrada { get => _Fin_entrada; set => _Fin_entrada = value; }
        public string Inicio_salida { get => _Inicio_salida; set => _Inicio_salida = value; }
        public string Fin_salida { get => _Fin_salida; set => _Fin_salida = value; }

        //constructores
        
        public Dhorario()
        {

        }

        public Dhorario(int id_empleado, string hora_entrada, string inicio_entrada, string fin_entrada, string inicio_salida, string fin_salida)
        {
            this.Id_empleado = id_empleado;
            this.Hora_entrada = hora_entrada;
            this.Inicio_entrada = inicio_entrada;
            this.Fin_entrada = fin_entrada;
            this.Inicio_salida = inicio_salida;
            this.Fin_salida = fin_salida;
        }

        //metodos

        public string Insertar(Dhorario horarios)
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
                SqlCmd.CommandText = "spinsertar_horario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridempleado = new SqlParameter();
                Paridempleado.ParameterName = "@id_empleado";
                Paridempleado.SqlDbType = SqlDbType.Int;
                Paridempleado.Value = horarios.Id_empleado;
                SqlCmd.Parameters.Add(Paridempleado);

                SqlParameter Parhoraentrada = new SqlParameter();
                Parhoraentrada.ParameterName = "@hora_entrada";
                Parhoraentrada.SqlDbType = SqlDbType.VarChar;
                Parhoraentrada.Size = 50;
                Parhoraentrada.Value = horarios.Hora_entrada;
                SqlCmd.Parameters.Add(Parhoraentrada);

                SqlParameter Parinicioentrada = new SqlParameter();
                Parinicioentrada.ParameterName = "@inicio_entrada";
                Parinicioentrada.SqlDbType = SqlDbType.VarChar;
                Parinicioentrada.Size = 50;
                Parinicioentrada.Value = horarios.Inicio_entrada;
                SqlCmd.Parameters.Add(Parinicioentrada);

                SqlParameter Parfinentrada = new SqlParameter();
                Parfinentrada.ParameterName = "@fin_entrada";
                Parfinentrada.SqlDbType = SqlDbType.VarChar;
                Parfinentrada.Size = 50;
                Parfinentrada.Value = horarios.Fin_entrada;
                SqlCmd.Parameters.Add(Parfinentrada);

                SqlParameter Pariniciosalida = new SqlParameter();
                Pariniciosalida.ParameterName = "@inicio_salida";
                Pariniciosalida.SqlDbType = SqlDbType.VarChar;
                Pariniciosalida.Size = 50;
                Pariniciosalida.Value = horarios.Inicio_salida;
                SqlCmd.Parameters.Add(Pariniciosalida);

                SqlParameter Parfinsalida = new SqlParameter();
                Parfinsalida.ParameterName = "@fin_salida";
                Parfinsalida.SqlDbType = SqlDbType.VarChar;
                Parfinsalida.Size = 50;
                Parfinsalida.Value = horarios.Fin_salida;
                SqlCmd.Parameters.Add(Parfinsalida);

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

        public string Editar(Dhorario horarios)
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
                SqlCmd.CommandText = "speditar_horario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter Paridempleado = new SqlParameter();
                Paridempleado.ParameterName = "@id_empleado";
                Paridempleado.SqlDbType = SqlDbType.Int;
                Paridempleado.Value = horarios.Id_empleado;
                SqlCmd.Parameters.Add(Paridempleado);

                SqlParameter Parhoraentrada = new SqlParameter();
                Parhoraentrada.ParameterName = "@hora_entrada";
                Parhoraentrada.SqlDbType = SqlDbType.VarChar;
                Parhoraentrada.Size = 50;
                Parhoraentrada.Value = horarios.Hora_entrada;
                SqlCmd.Parameters.Add(Parhoraentrada);

                SqlParameter Parinicioentrada = new SqlParameter();
                Parinicioentrada.ParameterName = "@inicio_entrada";
                Parinicioentrada.SqlDbType = SqlDbType.VarChar;
                Parinicioentrada.Size = 50;
                Parinicioentrada.Value = horarios.Inicio_entrada;
                SqlCmd.Parameters.Add(Parinicioentrada);

                SqlParameter Parfinentrada = new SqlParameter();
                Parfinentrada.ParameterName = "@fin_entrada";
                Parfinentrada.SqlDbType = SqlDbType.VarChar;
                Parfinentrada.Size = 50;
                Parfinentrada.Value = horarios.Fin_entrada;
                SqlCmd.Parameters.Add(Parfinentrada);

                SqlParameter Pariniciosalida = new SqlParameter();
                Pariniciosalida.ParameterName = "@inicio_salida";
                Pariniciosalida.SqlDbType = SqlDbType.VarChar;
                Pariniciosalida.Size = 50;
                Pariniciosalida.Value = horarios.Inicio_salida;
                SqlCmd.Parameters.Add(Pariniciosalida);

                SqlParameter Parfinsalida = new SqlParameter();
                Parfinsalida.ParameterName = "@fin_salida";
                Parfinsalida.SqlDbType = SqlDbType.VarChar;
                Parfinsalida.Size = 50;
                Parfinsalida.Value = horarios.Hora_entrada;
                SqlCmd.Parameters.Add(Parfinsalida);

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

        public string Eliminar(Dhorario horarios)
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
                SqlCmd.CommandText = "speliminar_horario";
                SqlCmd.CommandType = CommandType.StoredProcedure;

                SqlParameter ParIdtrabajador = new SqlParameter();
                ParIdtrabajador.ParameterName = "@id_empleado";
                ParIdtrabajador.SqlDbType = SqlDbType.Int;
                ParIdtrabajador.Value = horarios.Id_empleado;
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

        public DataTable Mostrar()
        {
            DataTable DtResultado = new DataTable("horarios");
            SqlConnection SqlCon = new SqlConnection();
            try
            {
                SqlCon.ConnectionString = conexion.Cn;
                SqlCommand SqlCmd = new SqlCommand();
                SqlCmd.Connection = SqlCon;
                SqlCmd.CommandText = "spmostrar_horario";
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
