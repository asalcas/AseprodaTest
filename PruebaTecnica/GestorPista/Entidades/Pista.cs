namespace GestorPista.Entidades
{
    /// <summary>
    /// Entidad que instanciaremos en main para comprobar su uso
    /// </summary>
    class Pista
    {
        #region Atributos
        private List<Surtidor> surtidores;
        private List<Suministro> suministros;
        #endregion

        #region Getter y Setter
        public List<Surtidor> Surtidores { get; }
        #endregion

        #region Constructores
        public Pista()
        {
            // Inicializamos la lista de surtidores vacía para ofrecer al usuario cuantos surtidores tendrá la pista (para la simulación)
            this.surtidores = new List<Surtidor>();
        }
        #endregion

        #region Funciones
        /// <summary>
        /// Función que crea X instancias de 'Surtidor' para la simulación
        /// PRE: None 
        /// POST: X numero de instancias generadas de tipo 'Surtidor'
        /// </summary>
        /// <param name="numSurtidores"></param>
        public void crearSurtidores(int numSurtidores)
        {
            for (int i = 1; i <= numSurtidores; i++) {
                Surtidor surtidor = new Surtidor(i);
                this.surtidores.Add(surtidor);
            }
        }

        public void verEstadoSurtidores()
        {
            foreach (Surtidor surtidor in this.surtidores)
            {
                Console.WriteLine($"Surtidor: {surtidor.IdSurtidor} Estado: {surtidor.Estado}");
            }
        }
        #endregion
    }
}
