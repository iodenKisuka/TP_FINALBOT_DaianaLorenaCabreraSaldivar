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
			return 0;
		}
	
	}
}