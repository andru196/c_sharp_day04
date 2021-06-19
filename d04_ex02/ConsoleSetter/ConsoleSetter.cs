using System;
using System.Reflection;
using System.Linq;
using System.ComponentModel;

namespace d04_ex02.ConsoleSetter
{
    public class ConsoleSetter
    {
        public static void SetValues<T>(T input) where T : class
        {
            var type = input.GetType();
            Console.WriteLine($"Let's set {type.Name}!");
            foreach (var prop in type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                
                bool noDisplay = false;
                CustomAttributeData defaultAtt = null;
                CustomAttributeData descAtt = null;
                foreach (var attr in prop.CustomAttributes)
                {
                    if (attr.AttributeType == typeof(d04_ex02.Attributes.NoDisplayAttribute))
                        noDisplay = true;
                    else if (attr.AttributeType == typeof(DefaultValueAttribute))
                        defaultAtt = attr;
                    else if (attr.AttributeType == typeof(DescriptionAttribute))
                        descAtt = attr;
                }
                if (noDisplay)
                    continue;
                string desc = "";
                if (descAtt != null)
                    desc = descAtt.ConstructorArguments.FirstOrDefault().Value as string ?? "";
                Console.WriteLine($"Set {prop.Name} {(desc)}:");
                var inp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inp) && defaultAtt != null)
                    inp = defaultAtt.ConstructorArguments.FirstOrDefault().Value as string;
                prop.SetValue(input, inp);
#if DEBUG
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{prop.GetValue(input) as string}");
                Console.ForegroundColor = ConsoleColor.White;
#endif
            }
            Console.WriteLine("We've set our instance!");
        }
    }
}