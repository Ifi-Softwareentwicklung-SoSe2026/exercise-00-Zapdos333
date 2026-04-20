
class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("Mission startet...");
        var eins = new Himmelskörper()
        {
            Name = "Erde",
            KatalogNummer = 1,
            Typ = HimmelskörperTyp.Planet,
            Umlaufzeit = 1.0f,
            ZentralkörperKatalogNummber = 0,
        };
    }
}


public class Himmelskörper
{
    public required string Name { get; set; }
    public required uint KatalogNummer { get; set; }
    public required HimmelskörperTyp Typ { get; set; }
    public Spektralklasse? Spectral { get; set; }
    public float? ScheinbareHelligkeit { get; set; }
    public float? Umlaufzeit { get; set; }
    public uint? ZentralkörperKatalogNummber { get; set; }
}

public enum Spektralklasse
{
    O,
    B,
    A,
    F,
    G,
    K,
    M
}
public enum HimmelskörperTyp
{
    Stern,
    Planet,
    Mond
}
