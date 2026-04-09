namespace GestorPista.Entidades
{
    /// <summary>
    /// Entidad que instanciaremos en main para comprobar su uso
    /// </summary>
    class Pista
    {
        #region Atributos
        private List<Surtidor> surtidores;
        #endregion

        #region Getter y Setter
        public List<Surtidor> Surtidores
        {
            get
            {
                return surtidores;
            }
        }
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
        public void CrearSurtidores(int numSurtidores)
        {
            if (numSurtidores < 0)
            {
                throw new Exception("No puedes crear surtidores negativos ni igual a 0");
            }
            for (int i = 1; i <= numSurtidores; i++)
            {
                Surtidor surtidor = new Surtidor(i);
                this.surtidores.Add(surtidor);
            }

        }

        /// <summary>
        /// Esta función es para darle verbosidad, realmente accederia desde el programa al atributo "surtidores" (Tiene un GET)
        /// </summary>
        /// <returns> El atributo de la clase "surtidores" </returns>
        public List<Surtidor> ObtenerEstado()
        {
            return surtidores;
        }
        

        /// <summary>
        /// Función que recorre todos los Surtidores y va añadiendo en una lista llamada "listaCompletaSuministros" todos los suministros a ella.
        /// </summary>
        /// <returns> List<Suministro> listaCompletaSuministros </returns>
        private List<Suministro> ObtenerListaCompletaSuministros()
        {
            List<Suministro> listaCompletaSuministros = new List<Suministro>();

            foreach (Surtidor surtidor in surtidores)
            {
                foreach (Suministro suministro in surtidor.HistorialSuministro)
                {
                    listaCompletaSuministros.Add(suministro);
                }
            }
            return listaCompletaSuministros;
        }
        /// <summary>
        /// Función que ordena la lista de Suministros que obtenemos de "ObtenerListaCompletaSuministros"
        /// </summary>
        /// <returns>List<Suministro> listaOrdenada </returns>
        /// <exception cref="Exception"> Si la lista está vacía lanzará la excepcion que se recoge en main</exception>
        public List<Suministro> ObtenerListaOrdenadaSuministros()
        {
            /*Lista ficticia para poder comprobar la función "ObtenerListaCompletaSuministros"
             * List<Suministro> listaPrueba = new List<Suministro>
            {
                new Suministro(1,2,new DateTime(2026,4,8),50,50),
                new Suministro(2,2,new DateTime(2026,4,8),150,150),
                new Suministro(3,2,new DateTime(2026,4,8),0,475),
                new Suministro(4,2,new DateTime(2026,8,9),0,475),
                
            };
            List<Suministro> listaOrdenar = listaPrueba;*/
            List<Suministro> listaOrdenar = ObtenerListaCompletaSuministros(); // Para comprobar con esos valores comenta esta linea y descomenta el anterior

            if (listaOrdenar.Count() == 0)
            {
                throw new Exception("No se puede ordenar la lista si está vacía");
            }
            listaOrdenar = listaOrdenar.OrderByDescending(suministro => suministro.ImporteSurtido)
                .ThenByDescending(suministro => suministro.FechaSuministro)
                .ToList();


            return listaOrdenar;
        }

        #endregion

    }
}
