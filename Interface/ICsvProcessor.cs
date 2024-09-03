namespace crudNet.Interface
{
   
        public interface ICsvProcessor
        {
            /// <summary>
            /// Procesa el archivo CSV cargado y lo inserta en la base de datos.
            /// </summary>
            /// <param name="filePath">La ruta del archivo CSV.</param>
            /// <returns>Una tarea que representa la operación asincrónica.</returns>
            Task ProcessCsvAsync();
        }
}
