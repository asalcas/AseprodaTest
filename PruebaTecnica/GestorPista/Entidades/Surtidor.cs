namespace GestorPista.Entidades
{
    /// <summary>
    /// Clase 
    /// </summary>
    class Surtidor
    {
        public enum EstadosSurtidor
        {
            Bloqueado = 1,
            Libre = 2
        };

        #region Atributos
        private int idSurtidor;
        private EstadosSurtidor estado;
        private Suministro suministroActivo;
        private List<Suministro> historialSuministro = new List<Suministro>();
        #endregion

        #region Getters y Setters
        public int IdSurtidor
        {
            get { return idSurtidor; }
        }

        public EstadosSurtidor Estado
        {
            get { return estado; }
        }
        public Suministro SuministroActivo
        {
            get { return suministroActivo; }
        }

        public List<Suministro> HistorialSuministro
        {
            get { return historialSuministro; }
        }
        #endregion

        #region Constructores

        public Surtidor(int id)
        {
            this.idSurtidor = id;
            this.estado = EstadosSurtidor.Bloqueado;
        }

        #endregion

        #region Funciones


        /// <summary>
        /// Función que recibirá como parametro la cuantia del importe al que queremos prefijar el surtidor
        /// </summary>
        /// <param name="importePrefijado"></param>
        public void PrefijarSurtidor(int importePrefijado = 0)
        {
            InicializarSuministro();
            suministroActivo.ImportePrefijado = importePrefijado;
        }

        /// <summary>
        /// Función para desbloquear la manguera y permitir el suministro (Si anteriormente no se ha prefijado entonces puede llegar a ser un suiministro sin limite)
        /// </summary>
        public void LiberarSurtidor()
        {
            InicializarSuministro();
            // Compruebo que el estado no esta previamente "Libre"
            if (Suministrando())
            {
                throw new Exception("No puedes liberar un surtidor ya liberado.");
            }
            this.estado = EstadosSurtidor.Libre;
        }


        /// <summary>
        /// Función que simulará que ha repostado el combustible del surtidor
        /// </summary>
        public void Repostar(int cantidadARepostar)
        {
            if (cantidadARepostar <= 0)
            {
                throw new Exception("La cantidad tiene que ser superior a 0");
            }
            if (cantidadARepostar > SuministroActivo.ImportePrefijado && suministroActivo.ImportePrefijado != 0)
            {
                throw new Exception("No puedes repostar más de lo que has pagado");
            }

            suministroActivo.ImporteSurtido = cantidadARepostar;

        }

        /// <summary>
        /// Función que bloqueará un Surtidor que anteriormente ha sido liberado
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void BloquearSurtidor()
        {
            if (!Suministrando())
            {
                throw new Exception("No puedes bloquear un surtidor ya bloqueado");
            }
            this.estado = EstadosSurtidor.Bloqueado;
            HistorialSuministro.Add(suministroActivo);
            suministroActivo = null;

        }
        /// <summary>
        /// Función dedicada a instanciar un objeto "Suministro" para realizar las operaciones necesarias en 'suministroActivo'
        /// PRE: None
        /// POST: suministroActivo instanciado
        /// </summary>
        private void InicializarSuministro()
        {
            if (suministroActivo == null)
            {
                suministroActivo = new Suministro(historialSuministro.Count(), this.idSurtidor, DateTime.Now);

            }
        }

        /// <summary>
        /// Función encargada de comprobar el estado del Surtidor antes de liberarlo o
        /// </summary>
        /// <returns></returns>
        private Boolean Suministrando()
        {
            return (this.estado == EstadosSurtidor.Libre);
        }



        #endregion
    }
}
