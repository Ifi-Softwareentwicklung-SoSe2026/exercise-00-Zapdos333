
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mission startet...");
        var körper = Himmelskörper.Parse(args);
        Console.WriteLine(körper.ToString());
    }
}


class Himmelskörper
{
    public required string Name { get; set; }
    public required uint KatalogNummer { get; set; }
    public required HimmelskörperTyp Typ { get; set; }
    public Spektralklasse? Spectral { get; set; }
    public float? ScheinbareHelligkeit { get; set; }
    public float? Umlaufzeit { get; set; }
    public uint? ZentralkörperKatalogNummber { get; set; }
    public static Himmelskörper Parse(string[] args)
    {
        return new Himmelskörper()
        {
            Name = args[0],
            KatalogNummer = uint.Parse(args[1]),
            Typ = Enum.Parse<HimmelskörperTyp>(args[2]),
            Spectral = Enum.TryParse<Spektralklasse>(args[3], out var spektral) ? spektral : null,
            ScheinbareHelligkeit = float.TryParse(args[4], out var scheinbareHelligkeit) ? scheinbareHelligkeit : null,
            Umlaufzeit = float.TryParse(args[5], out var umlaufzeit) ? umlaufzeit : null,
            ZentralkörperKatalogNummber = uint.TryParse(args[6], out var zentralkörperKatalogNummber) ? zentralkörperKatalogNummber : null
        };
    }
    public override string ToString()
    {
        string output = $"Himmelskörper: {Name}, Katalog-Nummer: {KatalogNummer}, Typ: {Typ}, ";
        if (Spectral.HasValue)
            output += $"Spektralklasse: {Spectral.Value}, Scheinbare Helligkeit: {ScheinbareHelligkeit.Value}";
        if (Umlaufzeit.HasValue)
            output += $"Umlaufzeit: {Umlaufzeit.Value} Erdjahre, Zentralkörper-Katalog-Nummer: {ZentralkörperKatalogNummber.Value}";
        return output;
    }
}

enum Spektralklasse
{
    O,
    B,
    A,
    F,
    G,
    K,
    M
}
enum HimmelskörperTyp
{
    Stern,
    Planet,
    Mond
}
