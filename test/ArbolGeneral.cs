using System;
using System.Collections.Generic;

namespace DeepSpace
{
	public class ArbolGeneral<T>
	{
		
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
	
		public int altura() {
			int altura = 0;
			if (esHoja())
			{
				//retorna cero porque altura es cero
				return altura;
			}
			else
			{
				int altura_del_hijo;
				//tiene hijo
				foreach (ArbolGeneral<T> recorrehijo in getHijos())
				{
					altura_del_hijo = recorrehijo.altura();
					if (altura < altura_del_hijo)
					{
						altura = altura_del_hijo;
					}
				}

				return altura + 1;
				//return altura;
			}


		}


		public int nivel(T dato) {
			if (getDatoRaiz().Equals(dato))
			{
				return 0;
			}
			else
			{
				//-1 si no esta el dato
				int nivel = 1;
				List<ArbolGeneral<T>> hijos = getHijos();
				List<ArbolGeneral<T>> Siguiente_nivel_hijos;
				do
				{
					Siguiente_nivel_hijos = new List<ArbolGeneral<T>>();
					foreach (ArbolGeneral<T> Obtener_hijo in hijos)
					{
						if (Obtener_hijo.getDatoRaiz().Equals(dato)) { return nivel; }
						foreach (ArbolGeneral<T> hijo in Obtener_hijo.getHijos())
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


		//Esta Funcion lo agregue porque creo que la necesito es una lista preorden
		private List<ArbolGeneral<T>> listaPruebaPre = new List<ArbolGeneral<T>>();
		public List<ArbolGeneral<T>> CadaArboltieneSupropiopreOrden()
		{

			listaPruebaPre.Add(this);

			foreach (ArbolGeneral<T> hijo in this.hijos)
			{
				List<ArbolGeneral<T>> listaPreordenHijo = hijo.CadaArboltieneSupropiopreOrden();
				foreach (ArbolGeneral<T> agregarALista in listaPreordenHijo)
				{
					
					listaPruebaPre.Add(agregarALista);
				}

			}
			
			return listaPruebaPre;
		}
	}
}