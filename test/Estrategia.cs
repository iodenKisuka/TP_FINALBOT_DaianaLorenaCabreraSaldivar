
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
			/*Calcula y retorna en un texto la cantidad de planetas que tienen 
			 * población mayor a 10 en cada nivel del árbol que es enviado como parámetro*/

			string texto = "";
			int cant_nodoNivel;
			int cant_PlanetaMayorA10;
			int nivel = 1;
			List<ArbolGeneral<Planeta>> Lista_hijos = arbol.getHijos();
			List<ArbolGeneral<Planeta>> Siguiente_nivel_hijos;
			do
			{
				cant_nodoNivel = Lista_hijos.Count;
				cant_PlanetaMayorA10 = 0;
				//lista vacia que tendra los nodos por nivel
				Siguiente_nivel_hijos = new List<ArbolGeneral<Planeta>>();
				foreach (ArbolGeneral<Planeta> Obtener_hijo in Lista_hijos)
				{

					if(Obtener_hijo.getDatoRaiz().Poblacion() > 10)
                    {
						cant_PlanetaMayorA10++;
                    }
					//obtengo los nodos hijos del nodo obtener_hijos y lo agrego a la lista de nodos que tiene siguiente nivel
					foreach (ArbolGeneral<Planeta> hijo in Obtener_hijo.getHijos())
					{
						Siguiente_nivel_hijos.Add(hijo);
					}

				}

				//texto += "\nEl nivel " + nivel + " tiene : " + cant_PlanetaMayorA10 + " nodos con una población mayor a 10\n";
				texto += "El nivel " + nivel + " tiene : " + cant_PlanetaMayorA10 + " nodos con una población mayor a 10\n";


				Lista_hijos = Siguiente_nivel_hijos;
				nivel++;
			} while (Siguiente_nivel_hijos.Count > 0);



			return texto+ "\n";
		}


		public String Consulta3( ArbolGeneral<Planeta> arbol)
		{
			/*Calcula y retorna en un texto el promedio poblacional por nivel del árbol que es enviado como parámetro. */
			string texto = "\n"+ "\n";
			int cant_nodoNivel;
			int cant_Poblacion;
			int nivel = 1;
			List<ArbolGeneral<Planeta>> Lista_hijos = arbol.getHijos();
			List<ArbolGeneral<Planeta>> Siguiente_nivel_hijos;
			do
			{
				cant_nodoNivel = Lista_hijos.Count;
				cant_Poblacion = 0;
				//lista vacia que tendra los nodos por nivel
				Siguiente_nivel_hijos = new List<ArbolGeneral<Planeta>>();
				foreach (ArbolGeneral<Planeta> Obtener_hijo in Lista_hijos)
				{
					
					cant_Poblacion += Obtener_hijo.getDatoRaiz().Poblacion();
					//obtengo los hijos del nodo obtener hijos y lo agrego a la lista de nodos que tiene siguiente nivel
					foreach (ArbolGeneral<Planeta> hijo in Obtener_hijo.getHijos())
					{
						Siguiente_nivel_hijos.Add(hijo);
					}
					
				}
				int promedio = 0;
				if (cant_nodoNivel > 0)
				{
					promedio = (cant_Poblacion / cant_nodoNivel);
				}
				texto += "El nivel " + nivel + " tiene en promedio poblicional : " + promedio; //+ "\n";
				texto+= "\ncant. nodo " + cant_nodoNivel+ " cant. poblacion total "+ cant_Poblacion +"\n";

				Lista_hijos = Siguiente_nivel_hijos;
				nivel++;
			} while (Siguiente_nivel_hijos.Count > 0);

			return texto;
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
				int nivel = 1;
				List<ArbolGeneral<Planeta>> Lista_hijos = arbol.getHijos();
				List<ArbolGeneral<Planeta>> Siguiente_nivel_hijos;
				do
				{
					//lista vacia que tendra los nodos por nivel
					Siguiente_nivel_hijos = new List<ArbolGeneral<Planeta>>();

					foreach (ArbolGeneral<Planeta> Obtener_hijo in Lista_hijos)
					{	//cuando encuentro un nodo que es ia retorno el nivel
						if (Obtener_hijo.getDatoRaiz().EsPlanetaDeLaIA()) { return nivel; }
						//obtengo los hijos del nodo obtener hijos y lo agrego a la lista de nodos que tiene siguiente nivel
						foreach (ArbolGeneral<Planeta> hijo in Obtener_hijo.getHijos())
						{
							Siguiente_nivel_hijos.Add(hijo);
						}
					}
					Lista_hijos = Siguiente_nivel_hijos;
					nivel++;
				} while (Siguiente_nivel_hijos.Count > 0);
				//-1 si no esta el dato
				return -1;
			}
		}

		

	}
}
