
using System;
using System.Collections.Generic;
namespace DeepSpace
{

    class Estrategia
    {


        public String Consulta1(ArbolGeneral<Planeta> arbol)
        {
            int distancia = Distancia_Raiz(arbol);

            if (distancia < 1)
            {
                return "El bot Esta en la Raiz";
            }
            return "La distancia que existe entre el bot a la Raiz es " + distancia;

        }


        public String Consulta2(ArbolGeneral<Planeta> arbol)
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

                    if (Obtener_hijo.getDatoRaiz().Poblacion() > 10)
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



            return texto + "\n";
        }


        public String Consulta3(ArbolGeneral<Planeta> arbol)
        {
            /*Calcula y retorna en un texto el promedio poblacional por nivel del árbol que es enviado como parámetro. */
            string texto = "\n";
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
                texto += "\nEl nivel " + nivel + " tiene en promedio poblicional : " + promedio; //+ "\n";
                texto += "\ncant. nodo " + cant_nodoNivel + " cant. poblacion total " + cant_Poblacion + "\n";

                Lista_hijos = Siguiente_nivel_hijos;
                nivel++;
            } while (Siguiente_nivel_hijos.Count > 0);

            return texto;
        }

        public Movimiento CalcularMovimiento(ArbolGeneral<Planeta> arbol)
        {
            Movimiento probar = enviarMovimiento(arbol);
            return probar;
            /*
            ArbolGeneral<Planeta> raiz = arbol;
            //suponemos que estan en la raiz cosa que al iniciar el do while va a cambiar
            ArbolGeneral<Planeta> nodoIA = raiz;
            ArbolGeneral<Planeta> nodoUsuario = raiz;
            ArbolGeneral<Planeta> nodoPadreIA = raiz;

            int nivel = 1;
            List<ArbolGeneral<Planeta>> Lista_hijos = new List<ArbolGeneral<Planeta>>();
            Lista_hijos.Add(arbol);
                //arbol.getHijos();
            List<ArbolGeneral<Planeta>> Siguiente_nivel_hijos;
            do
            {
                ArbolGeneral<Planeta> nodopadre;
                //lista vacia que tendra los nodos por nivel
                Siguiente_nivel_hijos = new List<ArbolGeneral<Planeta>>();

                foreach (ArbolGeneral<Planeta> Obtener_hijo in Lista_hijos)
                {
                    nodopadre = Obtener_hijo;

                    //obtengo los hijos del nodo obtener hijos y lo agrego a la lista de nodos que tiene siguiente nivel
                    foreach (ArbolGeneral<Planeta> hijo in Obtener_hijo.getHijos())
                    {
                        if (hijo.getDatoRaiz().EsPlanetaDeLaIA())
                        {
                            nodoIA = hijo;
                            nodoPadreIA = nodopadre;
                        }
                        if (hijo.getDatoRaiz().EsPlanetaDelJugador())
                        {
                            nodoUsuario = hijo;
                        }
                        Siguiente_nivel_hijos.Add(hijo);
                    }
                }
                Lista_hijos = Siguiente_nivel_hijos;
                nivel++;
            } while (Siguiente_nivel_hijos.Count > 0);


            //Movimiento(Planeta origen, Planeta destino)
            Movimiento mover = new Movimiento(nodoIA.getDatoRaiz(), nodoPadreIA.getDatoRaiz()); 
            return mover; */
            
        }


        public Movimiento enviarMovimiento(ArbolGeneral<Planeta> arbol)
        {
            List<ArbolGeneral<Planeta>> ListaPreorden = arbol.ListaPreOrden();
            List<ArbolGeneral<Planeta>> ListaDeNodosIA = new List<ArbolGeneral<Planeta>>();
            List<ArbolGeneral<Planeta>> ListaDeNodosUsuario = new List<ArbolGeneral<Planeta>>();
            foreach (ArbolGeneral<Planeta> nodo in ListaPreorden)
            {
                if (nodo.getDatoRaiz().EsPlanetaDeLaIA())
                {
                    ListaDeNodosIA.Add(nodo);
                }
                if (nodo.getDatoRaiz().EsPlanetaDelJugador())
                {
                    ListaDeNodosUsuario.Add(nodo);
                }
            }

            int menordistancia = -20;
            ArbolGeneral<Planeta> nodoIAaMover = arbol;
            foreach (ArbolGeneral<Planeta> nodoU in ListaDeNodosUsuario)
            {
                foreach (ArbolGeneral<Planeta> nodoIA in ListaDeNodosUsuario)
                {

                    int distancia = Distancia_Nodo(arbol, nodoIA, nodoU);
                    if (Math.Abs(distancia) < menordistancia)
                    {
                        nodoIAaMover = nodoIA;
                    }
                }
            }

            Movimiento mover = obtengoCamino(arbol, nodoIAaMover, menordistancia);

            return mover;
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
                    {   //cuando encuentro un nodo que es ia retorno el nivel
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

        public int Distancia_Nodo(ArbolGeneral<Planeta> arbol, ArbolGeneral<Planeta> ia, ArbolGeneral<Planeta> Usuario)
        {
            int nivel = 0;
            int nivelIA = -1;
            int nivelUsuario = -1;
            int horizontal = 0;
            int horizontalIA = -1;
            int horizontalUsuario = -1;
            ArbolGeneral<Planeta> raiz = arbol;
            ArbolGeneral<Planeta> nodoIA = ia;
            ArbolGeneral<Planeta> nodoUsuario = Usuario;
            List<ArbolGeneral<Planeta>> Lista_hijos = new List<ArbolGeneral<Planeta>>();
            Lista_hijos.Add(arbol);
            List<ArbolGeneral<Planeta>> Siguiente_nivel_hijos;
            do
            {
                //lista vacia que tendra los nodos por nivel
                Siguiente_nivel_hijos = new List<ArbolGeneral<Planeta>>();

                foreach (ArbolGeneral<Planeta> Obtener_hijo in Lista_hijos)
                {   //cuando encuentro un nodo que es ia retorno el nivel
                    horizontal = 0;
                    //obtengo los hijos del nodo obtener hijos y lo agrego a la lista de nodos que tiene siguiente nivel
                    foreach (ArbolGeneral<Planeta> hijo in Obtener_hijo.getHijos())
                    {
                        Siguiente_nivel_hijos.Add(hijo);
                        horizontal++;
                        //if (hijo.getDatoRaiz().EsPlanetaDeLaIA())
                        if (hijo.getDatoRaiz().Equals(nodoIA))
                        {
                            // nodoIA = hijo;
                            nivelIA = nivel;
                            horizontalIA = horizontal;
                        }
                        //if (hijo.getDatoRaiz().EsPlanetaDelJugador())
                        if (hijo.getDatoRaiz().Equals(nodoUsuario))
                        {
                            //nodoUsuario = hijo;
                            nivelUsuario = nivel;
                            horizontalUsuario = horizontal;
                        }
                        Siguiente_nivel_hijos.Add(hijo);
                    }
                }
                Lista_hijos = Siguiente_nivel_hijos;
                nivel++;
            } while (Siguiente_nivel_hijos.Count > 0);

            int restahorizontal = horizontalUsuario - horizontalIA;
            int diferenciaDenivel = -20;
            if (restahorizontal == 0)
            {
                diferenciaDenivel = nivelIA - nivelUsuario;
            }


            //si es -20 significa que estan en otro camino de nodo
            // si me da un numero positivo usuario esta arriba si me da negativo usuario esta abajo de 

            return diferenciaDenivel;

        }

        public Movimiento OpcionMover2ARaiz(ArbolGeneral<Planeta> arbol)
        {
           
            ArbolGeneral<Planeta> raiz = arbol;
            //suponemos que estan en la raiz cosa que al iniciar el do while va a cambiar
            ArbolGeneral<Planeta> nodoIA = raiz;
            ArbolGeneral<Planeta> nodoUsuario = raiz;
            ArbolGeneral<Planeta> nodoPadreIA = raiz;

            int nivel = 1;
            List<ArbolGeneral<Planeta>> Lista_hijos = new List<ArbolGeneral<Planeta>>();
            Lista_hijos.Add(arbol);
                //arbol.getHijos();
            List<ArbolGeneral<Planeta>> Siguiente_nivel_hijos;
            do
            {
                ArbolGeneral<Planeta> nodopadre;
                //lista vacia que tendra los nodos por nivel
                Siguiente_nivel_hijos = new List<ArbolGeneral<Planeta>>();

                foreach (ArbolGeneral<Planeta> Obtener_hijo in Lista_hijos)
                {
                    nodopadre = Obtener_hijo;

                    //obtengo los hijos del nodo obtener hijos y lo agrego a la lista de nodos que tiene siguiente nivel
                    foreach (ArbolGeneral<Planeta> hijo in Obtener_hijo.getHijos())
                    {
                        if (hijo.getDatoRaiz().EsPlanetaDeLaIA())
                        {
                            nodoIA = hijo;
                            nodoPadreIA = nodopadre;
                            break;
                        }
                        if (hijo.getDatoRaiz().EsPlanetaDelJugador())
                        {
                            nodoUsuario = hijo;
                        }
                        Siguiente_nivel_hijos.Add(hijo);
                    }
                }
                Lista_hijos = Siguiente_nivel_hijos;
                nivel++;
            } while (Siguiente_nivel_hijos.Count > 0);


            //Movimiento(Planeta origen, Planeta destino)
            Movimiento mover = new Movimiento(nodoIA.getDatoRaiz(), nodoPadreIA.getDatoRaiz()); 
            return mover;

        }



        public Movimiento obtengoCamino(ArbolGeneral<Planeta> arbol, ArbolGeneral<Planeta> ia, int sentido)
        {
            List<ArbolGeneral<Planeta>> ListaPreorden = arbol.ListaPreOrden();
            Movimiento mover = null;
            Planeta origen;
            Planeta destino;
            int posicioIA = -1;

            for (int y = 0; y < ListaPreorden.Count; y++)
            {
                if (ListaPreorden[y].Equals(ia))
                {
                    posicioIA = y;
                }
            }
            if (sentido == -20)
            {//ir a raiz
                //Es hijo de la raiz
                if (posicioIA - 1 % 3 == 0 || posicioIA == 1)
                {
                    //si posicion-1 es divisible por 3 se que es uno de los nodos hijos de la raiz
                    origen = ListaPreorden[posicioIA].getDatoRaiz();
                    destino = ListaPreorden[0].getDatoRaiz();
                    mover = new Movimiento(origen, destino);
                }
                else
                {
                    //no es hijo de la raiz
                    origen = ListaPreorden[posicioIA].getDatoRaiz();
                    destino = ListaPreorden[posicioIA - 1].getDatoRaiz();

                    mover = new Movimiento(origen, destino);
                    mover = OpcionMover2ARaiz(arbol);
                }

            }
            else if (sentido > 0)
            {
                //me muevo para arriba
                if (posicioIA - 1 % 3 == 0 || posicioIA == 1)
                {
                    //si posicion-1 es divisible por 3 se que es uno de los nodos hijos de la raiz
                    origen = ListaPreorden[posicioIA].getDatoRaiz();
                    destino = ListaPreorden[0].getDatoRaiz();
                    mover = new Movimiento(origen, destino);
                }
                else
                {
                    //no es hijo de la raiz
                    origen = ListaPreorden[posicioIA].getDatoRaiz();
                    destino = ListaPreorden[posicioIA - 1].getDatoRaiz();
                    mover = new Movimiento(origen, destino);

                }
            }
            else
            {
                //me muevo para abajo
                if (posicioIA - 1 % 3 == 0 || posicioIA == 1)
                {
                    //si posicion-1 es divisible por 3 se que es uno de los nodos hijos de la raiz
                    origen = ListaPreorden[posicioIA].getDatoRaiz();
                    destino = ListaPreorden[posicioIA + 3].getDatoRaiz();
                    mover = new Movimiento(origen, destino);
                }
                else
                {
                    //no es hijo de la raiz
                    origen = ListaPreorden[posicioIA].getDatoRaiz();
                    destino = ListaPreorden[posicioIA + 1].getDatoRaiz();
                    mover = new Movimiento(origen, destino);

                }
            }

           

            return mover;
        }
       
        


    }
}
