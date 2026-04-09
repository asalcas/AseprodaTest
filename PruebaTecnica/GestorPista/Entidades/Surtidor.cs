using GestorPista.Utils;

namespace GestorPista.Entidades
{
    /// <summary>
    /// Clase 
    /// </summary>
    class Surtidor
    {
        public enum estadosSurtidor
        {
            Bloqueado = 1,
            Activo = 2,
        };

        #region Atributos
        private int idSurtidor;
        private estadosSurtidor estado;
        #endregion

        #region Getters y Setters
        public int IdSurtidor
        {
            get { return this.idSurtidor; }
        }
        
        public estadosSurtidor Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion

        #region Constructores

        public Surtidor(int id)
        {
            this.idSurtidor = id;
            this.estado = estadosSurtidor.Bloqueado;
        }

        #endregion

        #region Funciones
        // TODO: Funciones relacionadas al surtidor: Abrir, cerrar
     
        public void verEstadoSurtidor()
        {
            Console.WriteLine($"Surtidor: {this.idSurtidor} Estado: {this.Estado}");
        }

        #endregion
    }
}
