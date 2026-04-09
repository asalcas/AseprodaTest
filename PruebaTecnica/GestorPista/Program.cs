
using GestorPista.Entidades;

namespace GestorPista
{
    class GestorPista
    {
        public static void Main(String[] args)
        {
            Pista pistaPrueba = new Pista();
            Random rnd = new Random();
            int importeAleatorio = rnd.Next(10, 1000);
            int importePrefijado = 10;
            int surtidoresCrear = 3;
            int indiceSurtidor1 = 0;
            int indiceSurtidor2 = 1;
            try
            {
                #region Crear Surtidores
                pistaPrueba.CrearSurtidores(surtidoresCrear);
                Console.WriteLine($"Has creado {pistaPrueba.Surtidores.Count()} surtidores" + "\n");
                #endregion

                #region Obtener estado
                // Opción más sencilla (GETTER)
                foreach (Surtidor surtidor in pistaPrueba.Surtidores)
                {
                    Console.WriteLine($"Surtidor: {surtidor.IdSurtidor} Estado: {surtidor.Estado}");
                }
                /*
                List<Surtidor> surtidoresPrueba = pistaPrueba.obtenerEstado();
                foreach(Surtidor surtidor in surtidoresPrueba)
                {
                    Console.WriteLine($"Surtidor: {surtidor.IdSurtidor} Estado: {surtidor.Estado}");
                }
                */
                #endregion

                #region Prefijar Surtidor
                pistaPrueba.Surtidores[indiceSurtidor1].PrefijarSurtidor(importePrefijado);
                Console.WriteLine($"Has prefijado el surtidor: {importePrefijado}" + "\n");
                #endregion

                #region Liberar surtidor 1
                pistaPrueba.Surtidores[indiceSurtidor1].LiberarSurtidor();
                Console.WriteLine($"\nHas liberado el surtidor {pistaPrueba.Surtidores[indiceSurtidor1].IdSurtidor} ahora puedes sacar la manguera" + "\n");
                #endregion

                #region Obtener estado
                foreach (Surtidor surtidor in pistaPrueba.Surtidores)
                {
                    Console.WriteLine($"Surtidor: {surtidor.IdSurtidor} Estado: {surtidor.Estado}");
                }
                #endregion

                #region Liberar surtidor 2
                pistaPrueba.Surtidores[indiceSurtidor2].LiberarSurtidor();
                Console.WriteLine($"\nHas liberado el surtidor {pistaPrueba.Surtidores[indiceSurtidor2].IdSurtidor} ahora puedes sacar la manguera" + "\n");
                #endregion

                #region Obtener estado
                foreach (Surtidor surtidor in pistaPrueba.Surtidores)
                {
                    Console.WriteLine($"Surtidor: {surtidor.IdSurtidor} Estado: {surtidor.Estado}");
                }
                #endregion

                #region Repostar
                pistaPrueba.Surtidores[indiceSurtidor1].Repostar(importePrefijado);
                Console.WriteLine($"\nHas repostado {pistaPrueba.Surtidores[indiceSurtidor1].SuministroActivo.ImporteSurtido} en el surtidor {pistaPrueba.Surtidores[indiceSurtidor1].IdSurtidor}");


                pistaPrueba.Surtidores[indiceSurtidor2].Repostar(importeAleatorio);
                Console.WriteLine($"Has repostado {pistaPrueba.Surtidores[indiceSurtidor2].SuministroActivo.ImporteSurtido} en el surtidor {pistaPrueba.Surtidores[indiceSurtidor2].IdSurtidor}" + "\n");

                #endregion

                #region Bloquear Surtidor
                pistaPrueba.Surtidores[indiceSurtidor1].BloquearSurtidor();
                Console.WriteLine($"\nHas bloqueado el surtidor {pistaPrueba.Surtidores[indiceSurtidor1].IdSurtidor}");

                pistaPrueba.Surtidores[indiceSurtidor2].BloquearSurtidor();
                Console.WriteLine($"Has bloqueado el surtidor {pistaPrueba.Surtidores[indiceSurtidor2].IdSurtidor}" + "\n");
                #endregion

                #region Obtener estado
                foreach (Surtidor surtidor in pistaPrueba.Surtidores)
                {
                    Console.WriteLine($"Surtidor: {surtidor.IdSurtidor} Estado: {surtidor.Estado}");
                }
                #endregion

                #region Obtener Historial
                List<Suministro> listaSuministro = pistaPrueba.ObtenerListaOrdenadaSuministros();

                foreach(Suministro suministro in listaSuministro)
                {
                    Console.WriteLine($"\nEl suministro: \t{suministro.IdSuministro}");
                    Console.WriteLine($"Del surtidor: \t{suministro.IdSurtidor}");
                    Console.WriteLine($"Importe prefijado: \t{suministro.ImportePrefijado}");
                    Console.WriteLine($"Se le ha surtido: \t{suministro.ImporteSurtido}");
                    Console.WriteLine($"A fecha de: \t{suministro.FechaSuministro}");
                }


                #endregion
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine("El surtidor no existe");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine("Surtidor no instanciado");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
    }

}
