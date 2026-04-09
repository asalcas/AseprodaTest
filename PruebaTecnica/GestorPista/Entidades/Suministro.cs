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
        private string importePrefijado;
        private string importeSurtido;
        private DateTime fechaSuministro;
        #endregion

        #region Getters y Setters

        #endregion

        #region Constructor

        public Suministro(int id, int surtidorId, string importeFijado, string importeSurtido)
        {
            this.idSuministro = id;
            this.idSurtidor = surtidorId;
            this.importePrefijado = importeFijado;
            this.importeSurtido = importeSurtido;
            this.fechaSuministro = DateTime.Now;
        }
        #endregion
    }
}
