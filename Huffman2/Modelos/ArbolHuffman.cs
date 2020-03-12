using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffman2.Modelos
{
    public class ArbolHuffman
    {

        public Stack<Nodo> arbolhuffman { get; set; }
        public const int TamañoBuffer = 1024;
    

      public void CrearArbol(Stack<Nodo> Listado)
        {
            arbolhuffman = Listado;
            while (arbolhuffman.Count > 1)
            {
                Nodo Temp = new Nodo();
                Nodo Mayor = new Nodo();
                Nodo Menor = new Nodo();
                ArbolBinario arbolBin = new ArbolBinario();
                Menor = arbolhuffman.Pop();
                Mayor = arbolhuffman.Pop();

                Temp.data.Probabilidad = Menor.data.Probabilidad + Mayor.data.Probabilidad;
                arbolBin.Insertar(Temp, 0);
                arbolBin.Insertar(Menor, 2);
                arbolBin.Insertar(Mayor, 1);

                arbolhuffman.Push(arbolBin.Retornar());
                arbolhuffman = OrdenarPila(arbolhuffman);
            }
 
        }

        public Stack<Nodo> Ordenar(List<Nodo> Ordenar)
        {
            Stack<Nodo> ListaOrdenada = new Stack<Nodo>();
            IEnumerable<Nodo> OrdenarLista = Ordenar.OrderByDescending(Probabilidad => Probabilidad.data.Probabilidad);
            

            foreach (var item in OrdenarLista)
            {
                Nodo Temp = new Nodo();
                Temp.data = item.data;
                ListaOrdenada.Push(Temp);

            }

            return ListaOrdenada;

        }

        public Stack<Nodo> OrdenarPila(Stack<Nodo> Ordenar)
        {
            Stack<Nodo> ListaOrdenada = new Stack<Nodo>();
            List<Nodo> ListaAordenar = new List<Nodo>();

            //Recorrer la pila
            foreach (var item in Ordenar)
            {
                ListaAordenar.Add(item);
            }

            IEnumerable<Nodo> OrdenarLista = ListaAordenar.OrderByDescending(Probabilidad => Probabilidad.data.Probabilidad);

            foreach (var item in OrdenarLista)
            {
                ListaOrdenada.Push(item);
            }
           

            return ListaOrdenada;

        }

        public Nodo Retornar()
        {
            Nodo Temp = new Nodo();
            Temp = arbolhuffman.Peek();
            AsignarPrefijo("", Temp);
            return Temp;
        }

        public Nodo AsignarPrefijo(string codigoPrefijo, Nodo Root)
        {
            if(Root == null)
            {
                return null;
            }
            else if((Root.Derecho == null)  && (Root.Izquierdo == null))
            {
                Root.data.CodigoPrefijo = codigoPrefijo;
                return Root;
            }

            Root.Izquierdo = AsignarPrefijo(codigoPrefijo + "0", Root.Izquierdo);
            Root.Derecho = AsignarPrefijo(codigoPrefijo + "1", Root.Derecho);

            return Root;
        }

        public void InOrden(Nodo Root)
        {
            if(Root != null)
            {
                InOrden(Root.Izquierdo);
                Console.WriteLine(Root.data.Caracter + "->" + Root.data.CodigoPrefijo);
                InOrden(Root.Derecho);
            }
        }

        public void Comprimir()
        {
        }



        /*
       public void EnviarNodo(Nodo Root)
       {
           if(Root != null)
           {
               Nodo Temp = new Nodo();
               Temp = Root;
               PreOrder(Temp, "");
           }
       }




               public void PreOrder(Nodo Root, string Pa)
               {

                   if (Root != null)
                   {

                       if(Root.Izquierdo != null)
                       {
                           Pa += "0";
                           PreOrder(Root.Izquierdo, Pa);

                       }
                       Console.WriteLine(" " + Root.data.Caracter + " -> " + Pa);

                       if (Root.Derecho != null)
                       {
                           Pa += "1";
                           PreOrder(Root.Derecho, Pa);

                       }

                   }

               }
               public void InOrder(Nodo Root)
               {
                   if(Root != null)
                   {

                   }
               }
               */


        /*public string PreOrder(Nodo Root, string Palabra, char BuscarCar)
        {
            string Pa = "";

            if (Root != null)
            {
                Pa += Palabra;
                if (Root.data.Caracter == BuscarCar)
                {
                    return Pa;
                }
                PreOrder(Root.Izquierdo, Pa + "0", BuscarCar);
                PreOrder(Root.Derecho, Pa + "1", BuscarCar);
            }

            return Pa;

        }*/
    }
}
