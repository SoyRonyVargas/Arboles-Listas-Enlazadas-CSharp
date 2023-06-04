using System.Collections.Generic;

namespace Manejo_de_archivos_con_arboles_y_listas_ligadas.clases
{
    internal class Arbol
    {
        public decimal tamaño { get; set; }
        public string nombre_archivo { get; set; }
        public List<Sector> sectores { get; set; }


        public Arbol izquierdo { get; set; }
        public Arbol derecha { get; set; }
    }
}
