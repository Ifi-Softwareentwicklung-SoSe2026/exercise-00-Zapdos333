
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Mission startet...");
        var körper = Himmelskörper.Parse(args);
        körper.ForceValidate();
        Console.WriteLine(körper);
    }
}


class Himmelskörper
{
    public required string Name
    {
        get;
        set => field = value.Trim();
    }
    public required uint KatalogNummer
    {
        get;
        set
        {
            if (value >= 100000)
                throw new ArgumentException("Katalognummer ist ungültig.");
            field = value;
        }
    }
    public required HimmelskörperTyp Typ { get; set; }
    public Spektralklasse? Spectral
    {
        get;
        set
        {
            if (value.HasValue && Typ != HimmelskörperTyp.Stern)
                throw new ArgumentException("Nur Sterne können eine Spektralklasse haben.");
            if (value == null && Typ == HimmelskörperTyp.Stern)
                throw new ArgumentException("Sterne müssen eine Spektralklasse haben.");
            field = value;
        }
    }
    public float? ScheinbareHelligkeit
    {
        get;
        set
        {
            if (value.HasValue && Typ != HimmelskörperTyp.Stern)
                throw new ArgumentException("Nur Sterne können eine Scheinbare Helligkeit haben.");
            if (value == null && Typ == HimmelskörperTyp.Stern)
                throw new ArgumentException("Sterne müssen eine Scheinbare Helligkeit haben.");
            field = value;
        }
    }
    public float? Umlaufzeit { get; set; }
    public uint? ZentralkörperKatalogNummber
    {
        get;
        set
        {
            if (value >= 100000)
                throw new ArgumentException("Katalognummer ist ungültig.");
            field = value;
        }
    }
    private Himmelskörper() {}
    public Himmelskörper(string name, uint id, float erdJahre, uint zentralKörper)
    {
        Name = name;
        Typ = 0;
        KatalogNummer = id;
        Umlaufzeit = erdJahre;
        ZentralkörperKatalogNummber = zentralKörper;
    }
    public Himmelskörper(string name, uint id, bool isPlanet, Spektralklasse spektralklasse, float scheinbareHelligkeit)
    {
        Name = name;
        Typ = isPlanet ? HimmelskörperTyp.Planet : HimmelskörperTyp.Mond;
        KatalogNummer = id;
        Spectral = spektralklasse;
        ScheinbareHelligkeit = scheinbareHelligkeit;
    }
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
    public void ForceValidate()
    {
        var validationError = Validate();
        if (validationError != null)
            throw validationError;
    }
    public ArgumentException? Validate()
    {
        if (KatalogNummer >= 100000)
            return new ArgumentException("Katalognummer ist ungültig.");
        switch (Typ)
        {
            case HimmelskörperTyp.Stern:
                if (!Spectral.HasValue || !ScheinbareHelligkeit.HasValue)
                    return new ArgumentException("Fehlende Daten für einen Stern.");
                if (ScheinbareHelligkeit.Value < 0.0)
                    return new ArgumentException("Scheinbare Helligkeit ist ungültig.");
                break;
            case HimmelskörperTyp.Planet:
            case HimmelskörperTyp.Mond:
                if (!Umlaufzeit.HasValue || !ZentralkörperKatalogNummber.HasValue)
                    return new ArgumentException("Fehlende Daten für einen Planeten oder Mond.");
                if (Umlaufzeit.Value <= 0.0)
                    return new ArgumentException("Umlaufzeit ist ungültig.");
                if (ZentralkörperKatalogNummber.Value >= 100000)
                    return new ArgumentException("Zentralkörper-Katalognummer ist ungültig.");
                break;
        }
        return null;
    }
    #nullable disable // Static analysis doesn't know/care about Validate()
    public override string ToString()
    {
        string output = $"Himmelskörper: {Name}, Katalog-Nummer: {KatalogNummer}, Typ: {Typ}, ";
        if (Spectral.HasValue)
            output += $"Spektralklasse: {Spectral.Value}, Scheinbare Helligkeit: {ScheinbareHelligkeit.Value}";
        if (Umlaufzeit.HasValue) {
            if (Spectral.HasValue) output += ", ";
            output += $"Umlaufzeit: {Umlaufzeit.Value} Erdjahre, Zentralkörper-Katalog-Nummer: {ZentralkörperKatalogNummber.Value}";
        }
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
