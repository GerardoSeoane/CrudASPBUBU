using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocio
{
    public class Negocio
    {
        Datos conexion = new Datos();

        public List<ModelPersonas> Mostrar()
        {
            try
            {
                List<ModelPersonas> Lista = new List<ModelPersonas>();
                DataTable Tabla = conexion.Mostrar();
                foreach (DataRow valor in Tabla.Rows)
                {
                    ModelPersonas p = new ModelPersonas();
                    p.id = Convert.ToInt32(valor["ID"]);
                    p.Nombre = valor["Nombre"].ToString();
                    p.Nacionalidad = valor["Nacionalidad"].ToString();
                    p.Fecha = valor["Fecha"].ToString();
                    Lista.Add(p);
                }
                return Lista;
            }
            catch (Exception)
            {

                return new List<ModelPersonas>();
            }
        }

        public string Agregar(string Nombre, string Nacionalidad, string Fecha)
        {
            int Respuesta = conexion.Agregar(Nombre, Nacionalidad, Fecha);
            if (Respuesta == 1)
            {
                return "Agregado con Exito";
            }
            else
                return "Error al ingresar";
        }

        public string Actualizar(int id, string Nombre, string Nacionalidad, string Fecha)
        {
            int respuesta = conexion.Actualizar(id, Nombre, Nacionalidad, Fecha);
            if (respuesta == 1)
            {
                return "Actualizado exitosamente";
            }
            else
                return "Error al actulizar";
        }

        public string Borrar(int id)
        {
            int respuesta = conexion.borrar(id);
            if (respuesta == 1)
            {
                return "Borrado exitosamente";
            }
            else
                return "Error al Borrar";
        }

        public ModelPersonas BuscarById(int id)
        {
            DataTable respuesta = conexion.BuscarById(id);
            ModelPersonas p = new ModelPersonas();
            foreach (DataRow val in respuesta.Rows)
            {
                p.id = Convert.ToInt32(val["Id"]);
                p.Nombre = val["Nombre"].ToString();
                p.Nacionalidad = val["Nacionalidad"].ToString();
                p.Fecha = val["Fecha"].ToString();
            }
            return p;
        }
    }
}
