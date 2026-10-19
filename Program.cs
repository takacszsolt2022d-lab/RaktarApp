using RaktarApp;
using System.Data.Common;
using System.IO;

List<Termek> termekek = new List<Termek>();
int hibassorokszama = 0;

foreach (string sor in File.ReadLines("termekek.txt").Skip(1))
{

    if (string.IsNullOrWhiteSpace(sor))
    {
        hibassorokszama++;
        continue;
    }
    string[] adatok = sor.Split('|');
    if (adatok.Length != 4) {
        hibassorokszama++;
        continue;
    }
    if (adatok[0]!="S" && adatok[0] != "G")
    {
        hibassorokszama++;
        continue;
    }
    if(!int.TryParse(adatok[2], out int alapar) || !int.TryParse(adatok[3], out int garancia))
    {
        hibassorokszama++;
        continue;
    }
 
    if (adatok[0] == "S")
    {
        Termek aktualis = new Termek(adatok[0], alapar);
        termekek.Add(aktualis);
    }

    if(adatok[0] == "G")
    {
        TartosTermek aktualis = new TartosTermek(adatok[0], alapar, garancia);
        termekek.Add(aktualis);
    }
    
        
    
}


Console.WriteLine($"Sikeresen beolvasott termékék száma:{termekek.Count} db");
Console.WriteLine($"Hibás sorok száma:{hibassorokszama} db");


foreach (Termek kiir in termekek)
{
    Console.WriteLine(kiir);
}

foreach (Termek kiir in termekek)
    {
    Console.WriteLine(kiir.ErtekSzamitas(10));
}

Console.WriteLine(Termek.OsszesTermekSzama + " db");

