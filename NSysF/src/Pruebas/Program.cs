using Pruebas.persistencia.infra;
using System.Reflection;

Console.WriteLine(typeof(ClaseDummy).Assembly.FullName);
var migrationsAssembly = typeof(contexto).AssemblyQualifiedName;
Console.WriteLine("Migration = " + migrationsAssembly);

class ClaseDummy
{

}
