
using GestorPista.Entidades;

namespace GestorPista
{
    class GestorPista
    {
        /// <summary>
        /// Función Main para comprobar el uso de la DLL, posteriormente se eliminará y se probará en un proyecto ageno
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            Pista pistaPrueba = new Pista();

            
            pistaPrueba.crearSurtidores(4);
            pistaPrueba.verEstadoSurtidores();
        }
    }

}
