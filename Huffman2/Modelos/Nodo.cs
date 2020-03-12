using System;
namespace Huffman2.Modelos
{
    public struct Data
    {
        public char Caracter;
        public int Frecuencia;
        public string CodigoPrefijo;
        public Double Probabilidad;
    }

    public class Nodo
    {
        public Data data;
        public Nodo Derecho;
        public Nodo Izquierdo;

        public Nodo()
        {
            Derecho = Izquierdo = null;
        }

        public int ObtenerFrecuencia()
        {
            return data.Frecuencia;
        }

        public Double ObtenerProbabilidad()
        {
            return data.Probabilidad;
        }

    }
}

