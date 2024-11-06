using System.Reflection;


public class CsvSerializer
{
    public string Serialize<T>(T obj)
    {
        if (obj is null)
            return string.Empty;

        var values = new List<string>();

        // Если объект примитивный или строка, просто возвращаем его в строке
        if (obj.GetType().IsPrimitive || obj is string)
        {
            values.Add(obj.ToString());
        }
        else
        {
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                //var value = prop.GetValue(obj)?.ToString();
                //values.Add(value ?? string.Empty);
                var value = prop.GetValue(obj);
                var valueString = value?.ToString() ?? string.Empty;
                values.Add($"{prop.Name} - {valueString}");
            }
        }

        var str = string.Join(",", values);

        return str;
    }
}
