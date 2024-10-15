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
        return new F
        {
            i1 = int.Parse(values[0]),
            i2 = int.Parse(values[1]),
            i3 = int.Parse(values[2]),
            i4 = int.Parse(values[3]),
            i5 = int.Parse(values[4])
        };
    }
}