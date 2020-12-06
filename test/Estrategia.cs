
using System;
using System.Collections.Generic;
namespace DeepSpace
{

	class Estrategia
	{
		
		
		public String Consulta1( ArbolGeneral<Planeta> arbol)
		{
			int distancia = Distancia_Raiz(arbol);

			if (distancia<1)
            {
				return "El bot Esta en la Raiz";
            }
			return "La distancia que existe entre el bot a la Raiz es " + distancia;
			
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



		public int Distancia_Raiz(ArbolGeneral<Planeta> arbol)
		{
			if (arbol.getDatoRaiz().EsPlanetaDeLaIA())
			{
				return 0;
			}
			else
			{
				//-1 si no esta el dato
				int nivel = 1;
				List<ArbolGeneral<Planeta>> hijos = arbol.getHijos();
				List<ArbolGeneral<Planeta>> Siguiente_nivel_hijos;
				do
				{
					Siguiente_nivel_hijos = new List<ArbolGeneral<Planeta>>();
					foreach (ArbolGeneral<Planeta> Obtener_hijo in hijos)
					{
						if (Obtener_hijo.getDatoRaiz().EsPlanetaDeLaIA()) { return nivel; }
						foreach (ArbolGeneral<Planeta> hijo in Obtener_hijo.getHijos())
						{
							Siguiente_nivel_hijos.Add(hijo);
						}
					}
					hijos = Siguiente_nivel_hijos;
					nivel++;
				} while (Siguiente_nivel_hijos.Count > 0);
				//-1 si no esta el dato
				return -1;
			}
		}

		

	}
}
