using System;
using System.Collections.Generic;
using System.Text;

namespace GestorPista.Entidades
{
    class Suministro
    {
        #region Atributos
        private int idSuministro;
        private int idSurtidor;
        private int importePrefijado;
        private int importeSurtido;
        private DateTime fechaSuministro;
        #endregion

        #region Getters y Setters
        public int IdSuministro
        {
            get { return idSuministro; }
        }
        public int IdSurtidor
        {
            get { return idSurtidor; }
        }
        public int ImportePrefijado
        {
            get { return importePrefijado; }
            set {  importePrefijado = value; }
        }
        public int ImporteSurtido
        {
            get { return importeSurtido; }
            set { importeSurtido = value; }
        }
        public DateTime FechaSuministro
        {
            get { return fechaSuministro; }
        }
        #endregion

        #region Constructor
       
        public Suministro(int id, int surtidorId, DateTime fecha, int importePrefijado = 0, int importeSurtido = 0)
        {
            this.idSuministro = id;
            this.idSurtidor = surtidorId;
            this.importePrefijado = importePrefijado;
            this.importeSurtido = importeSurtido;
            this.fechaSuministro = fecha;
        }
        #endregion
    }
}
