<<<<<<< HEAD
﻿using Microsoft.Spark.Sql;

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
=======
using BlazingPizza.Data;
using BlazingPizza.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient();
builder.Services.AddSqlite<PizzaStoreContext>("Data Source=pizza.db");

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<OrderState>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

// Initialize the database
var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
using (var scope = scopeFactory.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<PizzaStoreContext>();
    if (db.Database.EnsureCreated())
    {
        SeedData.Initialize(db);
    }
}

app.Run();
>>>>>>> 78308e19c80160a7210eadd622aa12587b4f0033
