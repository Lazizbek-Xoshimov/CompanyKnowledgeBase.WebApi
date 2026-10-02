using System.Reflection;

namespace Menus;

public static class TablePrinter
{
    // Bitta dona obyekt (masalan, bitta User) uchun overload
    public static void Print<T>(T singleSource)
    {
        Print(new[] { singleSource });
    }

    // Ko'pchilik (IEnumerable<T>, masalan, List<User>) uchun asosiy metod
    public static void Print<T>(IEnumerable<T>? source)
    {
        var list = source?.ToList();
        if (list == null || !list.Any())
        {
            Console.WriteLine("📭 Ma'lumot mavjud emas.");
            return;
        }

        PropertyInfo[] props = typeof(T).GetProperties();
        
        // Har bir ustunning maksimal kengligini hisoblaymiz    
        var colWidths = props.ToDictionary(
            p => p.Name,
            p => Math.Max(
                p.Name.Length, 
                list.Max(item => (p.GetValue(item)?.ToString() ?? "").Length)
            ) + 2 // padding uchun +2 joy tashlaymiz
        );

        // Yuqori ramka
        PrintBorder(props, colWidths, "┌", "┬", "┐", '─');

        // Header (Sarlavha)
        Console.Write("│");
        foreach (var prop in props)
        {
            Console.Write($" {prop.Name.PadRight(colWidths[prop.Name] - 1)}│");
        }
        Console.WriteLine();

        // Header ajratuvchi liniya
        PrintBorder(props, colWidths, "├", "┼", "┤", '─');

        // Qatorlar (Rows)
        foreach (var item in list)
        {
            Console.Write("│");
            foreach (var prop in props)
            {
                var val = prop.GetValue(item)?.ToString() ?? "";
                Console.Write($" {val.PadRight(colWidths[prop.Name] - 1)}│");
            }
            Console.WriteLine();
        }

        // Pastki ramka
        PrintBorder(props, colWidths, "└", "┴", "┘", '─');
        Console.WriteLine();
    }

    private static void PrintBorder(PropertyInfo[] props, Dictionary<string, int> widths, string left, string mid, string right, char fill)
    {
        Console.Write(left);
        for (int i = 0; i < props.Length; i++)
        {
            Console.Write(new string(fill, widths[props[i].Name]));
            Console.Write(i == props.Length - 1 ? right : mid);
        }
        Console.WriteLine();
    }
}