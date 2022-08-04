using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class Datos
    {
        private SqlConnection conexion = new SqlConnection("Server=.;Database=Curso;User id=sa;password=12345");

        public void conectar()
        {
            try
            {
                conexion.Open();
            }
            catch (Exception)
            {

                throw;
            }  
        }
        public void desconectar()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public DataTable Mostrar()
        {
            try
            {
                conectar();
                DataTable tabla = new DataTable();
                string query = "select * from persona";
                SqlDataAdapter datos = new SqlDataAdapter(query, conexion);
                datos.Fill(tabla);
                desconectar();
                return tabla;
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public int Agregar(string Nombre,string Nacionalidad,string Fecha) 
        {
            int FilasA = 0;
            try
            {
                conectar();
                string query = $"Insert into Persona values('{Nombre}','{Nacionalidad}','{Fecha}')";
                SqlCommand comando = new SqlCommand(query, conexion);
                FilasA = comando.ExecuteNonQuery();
                desconectar();
                return FilasA;
            }
            catch (Exception)
            {
                return FilasA;
            }       
        }

        public int Actualizar(int id,string Nombre, string Nacionalidad, string Fecha)
        {
            int FilasA = 0;
            try
            {
                conectar();
                string query = $"update persona set Nombre='{Nombre}',Nacionalidad='{Nacionalidad}',Fecha='{Fecha}' where id={id}";
                SqlCommand comando = new SqlCommand(query, conexion);
                FilasA = comando.ExecuteNonQuery();
                desconectar();
                return FilasA;
            }
            catch (Exception)
            {
                return FilasA;
            }
        }

        public int borrar(int id)
        {
            int FilasA = 0;
            try
            {
                conectar();
                string query = $"delete persona where id={id}";
                SqlCommand comando= new SqlCommand(query, conexion);
                FilasA = comando.ExecuteNonQuery();
                desconectar();
                return FilasA;
            }
            catch (Exception)
            {
                return FilasA;
            }
        }

        public DataTable BuscarById(int id)
        {
           
            try
            {
                conectar();
                DataTable tabla = new DataTable();
                string query = $"select * from persona where id={id}";
                SqlDataAdapter comando = new SqlDataAdapter(query, conexion);
                comando.Fill(tabla);
                desconectar();
                return tabla;
            }
            catch (Exception)
            {

                return new DataTable();
            }
        }
    }
}
