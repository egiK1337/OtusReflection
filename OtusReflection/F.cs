public class F
{
    public int i1 { get; set; }
    public int i2 { get; set; }
    public int i3 { get; set; }
    public int i4 { get; set; }
    public int i5 { get; set; }

    public static F Get()
    {
        return new F { i1 = 1, i2 = 2, i3 = 3, i4 = 4, i5 = 5 };
    }

    public static F Deserialize(string csv)
    {
        var values = csv.Split(',');

        var f = new F();

        foreach (var value in values)
        {
            var parts = value.Split(new[] { " - " }, StringSplitOptions.None);

            if (parts.Length == 2)
            {
                var fieldName = parts[0].Trim();
                var fieldValue = int.Parse(parts[1].Trim());

                switch (fieldName)
                {
                    case "i1":
                        f.i1 = fieldValue;
                        break;
                    case "i2":
                        f.i2 = fieldValue;
                        break;
                    case "i3":
                        f.i3 = fieldValue;
                        break;
                    case "i4":
                        f.i4 = fieldValue;
                        break;
                    case "i5":
                        f.i5 = fieldValue;
                        break;
                    default:
                        throw new Exception($"Field name: {fieldName}");
                }
            }
        }

        return f;
    }
}