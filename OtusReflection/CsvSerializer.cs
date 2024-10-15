using System.Reflection;


public class CsvSerializer
{
    public string Serialize<T>(T obj)
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        var values = new List<string>();

        foreach (var prop in properties)
        {
            var value = prop.GetValue(obj)?.ToString();
            values.Add(value ?? string.Empty);
        }

        return string.Join(",", values);
    }
}
