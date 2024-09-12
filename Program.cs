using Microsoft.Spark.Sql;

namespace SparkHelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear una sesión de Spark
            SparkSession spark = SparkSession
                .Builder()
                .AppName("Spark Hola Mundo")
                .Master("spark://192.168.0.13:7077")  // Dirección del maestro
                .GetOrCreate();

            // Crear un DataFrame de ejemplo
            DataFrame dataFrame = spark.Sql("SELECT 'Hola, mundo!' AS Saludo");

            // Mostrar el DataFrame
            dataFrame.Show();

            // Detener la sesión de Spark
            spark.Stop();
        }
    }
}
