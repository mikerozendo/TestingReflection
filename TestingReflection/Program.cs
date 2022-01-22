using System;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Options());
            int? control = Convert.ToInt32(Console.ReadLine());

            while (control != 3 && control is not null)
            {
                var assembly = Assembly.LoadFile(@"C:\Users\junior\Documents\Projetos\TestingReflection\TestingReflection.Domain\bin\Debug\net5.0\TestingReflection.Domain.dll");
                var entity = Activator.CreateInstance(assembly.GetType("TestingReflection.Domain.Person"));
                int yearsOld = (int)assembly.GetType("TestingReflection.Domain.Person").GetProperty("YearsOld").GetValue(entity, null);

                if (control == 1)
                    if ((bool)assembly.GetType("TestingReflection.Domain.Person").InvokeMember("IsOldEnough", BindingFlags.InvokeMethod, null, entity, new object[] { yearsOld }))
                        Console.WriteLine(entity.ToString());

                if (control == 2)
                    if ((bool)assembly.GetType("TestingReflection.Domain.Person").InvokeMember("IsOldEnough", BindingFlags.InvokeMethod, null, entity, new object[] { yearsOld }))
                        Console.WriteLine(JsonSerializer.Serialize(entity));

                Console.WriteLine("Press Enter to continue");
                Console.ReadKey();
                Console.WriteLine(Options());
                control = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
            }
        }

        public static string Options()
        {
            StringBuilder sb = new();
            sb.AppendLine("=======================================");
            sb.AppendLine("1) See default values");
            sb.AppendLine("2) See values as json");
            sb.AppendLine("3) exit");
            sb.AppendLine("=======================================");
            return sb.ToString();
        }
    }
}
