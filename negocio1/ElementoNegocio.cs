﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dominio1;

namespace negocio1
{
    public class ElementoNegocio
    {
        public List<Elemento> Listar()
        {
			List<Elemento>lista = new List<Elemento>();
			AccesoDatos datos = new AccesoDatos();
			try
			{
				datos.SetearConsulta("Select Id, Descripcion from ELEMENTOS");
				datos.ejecutarLectura();

				while (datos.Lector.Read())
				{
					Elemento aux = new Elemento();
					aux.Id = (int)datos.Lector["Id"];
					aux.Descripcion = (string)datos.Lector["Descripcion"];

					lista.Add(aux);
				}
				return lista;
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				datos.cerrarConexion();
			}
        }
    }
}
