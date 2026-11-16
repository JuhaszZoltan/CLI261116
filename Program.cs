List<Product> products = [];

#region read file
#nullable disable

const string FilePath = "..\\..\\..\\data\\arukeszlet.csv";

using StreamReader sr = new(FilePath);
_ = sr.ReadLine();
while (!sr.EndOfStream)
{
    var t = sr.ReadLine().Split(',');
    products.Add(new()
    {
        Id = int.Parse(t[0]),
        Category = t[1],
        Brand = t[2],
        Model = t[3],
        PriceHUF = int.Parse(t[4]),
        StoctQty = int.Parse(t[5]),
        Rating = float.Parse(t[6].Replace('.', ','))
    });
}
//products.ForEach(p => Console.WriteLine($"{p}\n"));
#endregion