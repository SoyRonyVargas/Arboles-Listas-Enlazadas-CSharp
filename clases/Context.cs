using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Manejo_de_archivos_con_arboles_y_listas_ligadas.clases
{
    internal class Context
    {

        // PARA QUE LA RAIZ QUE ES SECTOR 0 ESTE OCUPADO;

        public static Arbol? estado_raiz = null;
        private const string OCUPADO = "OCUPADO";
        public static int columnasState = 0;
        public static int filasState = 0;
        public static int MaxValues = 20;
        public static int MultiplosRestantes = MaxValues;

        public static List<Sector> crearSectores(decimal tamano = 0)
        {
            List<Sector> sectores = new List<Sector>();
           
            //decimal size = tamano / 512;
            
            //int totalInstancias = (int)Math.Ceiling(size);

            //decimal contador = tamano; // 600
            //for (int i = 0; i < totalInstancias; i++)
            //{
            //    Sector nuevo_secotr = new Sector();
            //    nuevo_secotr.espacio = contador;
            //    sectores.Add(nuevo_secotr);
            //    if (contador >= 512)
            //    {
            //        contador -= 512;
            //    }
            //    Context.MultiplosRestantes--;
            //}

            for (int i = 0; i < tamano; i++)
            {
                Sector nuevo_secotr = new Sector();
                
                nuevo_secotr.espacio = 512;

                sectores.Add(nuevo_secotr);

                Context.MultiplosRestantes--;

            }

            return sectores;

        }

        public static Arbol agregarNodo(Arbol nodo, string nombre_archivo, decimal tamaño, bool _default = false)
        {
            //Debugger.Break();

            if (nodo == null && _default)
            {
                List<Sector> sectores = crearSectores(1);
                nodo = new Arbol();
                nodo.sectores = sectores;
                nodo.nombre_archivo = OCUPADO;
                return agregarNodo(nodo, nombre_archivo, tamaño);
            }

            if (nodo == null && !_default)
            {
                List<Sector> sectores = crearSectores(tamaño);
                nodo = new Arbol();
                nodo.sectores = sectores;
                nodo.nombre_archivo = nombre_archivo;
                nodo.tamaño = tamaño;
                return nodo;
            }

            int comparacion = string.Compare(nombre_archivo, nodo.nombre_archivo);

            if (comparacion < 0)
            {
                nodo.izquierdo = agregarNodo(nodo.izquierdo, nombre_archivo, tamaño);
            }
            else if (comparacion > 0)
            {
                nodo.derecha = agregarNodo(nodo.derecha, nombre_archivo, tamaño);
            }

            return nodo;

        }


        //public static void agregarNodo(ref Arbol? nodo, string nombre_archivo, decimal tamaño, bool _default = false)
        //{

        //    Debugger.Break();

        //    if (nodo == null && _default)
        //    {

        //        List<Sector> lista = new List<Sector>();

        //        nodo = new Arbol();

        //        nodo.sectores = lista;

        //        nodo.nombre_archivo = OCUPADO;

        //        agregarNodo(ref nodo, nombre_archivo, tamaño);

        //        return;
        //        //estado_raiz.izquierdo = new Arbol();

        //        //estado_raiz.izquierdo.nombre_archivo = nombre_archivo;

        //        //estado_raiz.izquierdo.tamaño = tamaño;

        //        //List<Sector> sectores = crearSectores(tamaño);

        //        //estado_raiz.izquierdo.sectores = sectores;

        //        //estado_raiz.nombre_archivo = nombre_archivo;
        //        //decimal size = tamaño / 512;
        //        //int totalInstancias = (int)Math.Ceiling(size);

        //        //decimal contador = tamaño; // 600
        //        //for (int i = 0; i < totalInstancias; i++)
        //        //{
        //        //    Sector nuevo_secotr = new Sector();
        //        //    nuevo_secotr.espacio = i;
        //        //    lista.Add(nuevo_secotr);
        //        //    if (contador >= 512)
        //        //    {
        //        //        contador -= 512;
        //        //    }
        //        //}

        //        //estado_raiz.sectores.Add()

        //        //return;

        //    }
        //    if (nodo == null && !_default)
        //    {

        //        List<Sector> sectores = crearSectores(tamaño);

        //        nodo = new Arbol();

        //        nodo.sectores = sectores;

        //        nodo.nombre_archivo = nombre_archivo;

        //        nodo.tamaño = tamaño;

        //        //return nodo;

        //    }

        //    int comparacion = string.Compare(nombre_archivo, nodo.nombre_archivo);
        //    //nodo.izquierdo = new Arbol();
        //    //nodo.derecha = new Arbol();
        //    if (comparacion < 0)
        //    {
        //        //nodo.izquierdo = null;
        //        // nombre_archivo es menor al actual
        //        nodo.izquierdo = new Arbol();
        //        agregarNodo(ref nodo?.izquierdo, nombre_archivo, tamaño);
        //        return;
        //    }
        //    if (comparacion > 0)
        //    {
        //        // nombre_archivo es mayor al actual
        //        //return agregarNodo(nodo.derecha, nombre_archivo, tamaño);
        //    }

        //    return;

        //}
    }
}
