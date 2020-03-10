using System;
using System.Collections.Generic;
using System.Linq;

namespace Huffman2.Modelos
{
    public class ArbolHuffman
    {

        public Stack<Nodo> arbolhuffman { get; set; }

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



    }
}
