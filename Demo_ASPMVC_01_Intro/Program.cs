// Configuration de l'application
var builder = WebApplication.CreateBuilder(args);

// - Config des services
builder.Services.AddControllersWithViews();

// - Build de l'app
var app = builder.Build();

// Config et démarrage de l'App
// → Basé sur le principe des middlewares (Pattern chaine de responsabilité)

//  - Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// - Exemple de middleware (Intergiciel pour les Français) pour la démo
app.Use(async (context, next) =>
{
    // Debut du middleware
    DateTime start = DateTime.Now;

    // On passe au middleware suivant
    await next(context);

    // Fin du middleware (Quand les middlewares suivants ont terminés)
    DateTime end = DateTime.Now;

    string url = context.Request.Path.Value ?? "N/A";
    TimeSpan requestDuration = end - start;

    Console.WriteLine($"{url} - {requestDuration.TotalMilliseconds} ms");
});

// - Config de l'app
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();



// - Mecanisme de routing
//   Custom → /B/...
app.MapControllerRoute(
    name: "blog",
    pattern: "B/{*slug}",
    defaults: new { Controller = "Blog", Action = "Article" });


//   Default
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();


