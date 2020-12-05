
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			string texto = "";
			/*Calcula y retorna un texto con la distancia que existe entre la raíz y el nodo del árbol que es enviado como
parámetro que contiene el planeta más cercano perteneciente al Bot."*/
			//arbol.nivel(arbol);
			
			return "Implementar1";
		}


		public String Consulta2( ArbolGeneral<Planeta> arbol)
		{
			//return "Implementar2";
			Cola<ArbolGeneral<Planeta>> q = new Cola<ArbolGeneral<Planeta>>();
			q.encolar(arbol);
			int nivel = 0;
			String mensaje = "";
			while (!q.esVacia())
			{
				//int elementos = q.cantElementos;
				nivel++;
				int cantidadPorNivel = 0;
				//while (elementos-- > 0)
				while(!q.esVacia())
				{
					ArbolGeneral<Planeta> nodoActual = q.desencolar();

					if (nodoActual.getDatoRaiz().Poblacion() > 10)
					{
						cantidadPorNivel++;
					}

					foreach (ArbolGeneral<Planeta> hijo in nodoActual.getHijos())
					{
						q.encolar(hijo);
					}
				}
				mensaje += "Nivel " + nivel + ": " + cantidadPorNivel + "\n";
			}
			return mensaje;

		}


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			return "Implementar3";
		}
		
		public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
		{
			//Implementar
			
			return null;
		}
	}
}
