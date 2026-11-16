using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

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

// 1. Hány olyan termékünk van összesen, aminek az ára kevesebb mint 10 000 Ft?
var f001 = products.Count(p => p.PriceHUF < 10000);
Console.WriteLine($"001: 10K alatti aru termekek szama: {f001} db");

// 2. Melyik a legdrágább termék a teljes kínálatban? (Válaszként a teljes objektumra van szükség.)
var f002 = products.MaxBy(p => p.PriceHUF);
Console.WriteLine($"002: legdragabb termek:\n{f002}");

// 3. Keresd meg a listában azt az egyetlen terméket, amelynek az Id-ja pontosan 42!
var f003 = products.Single(p => p.Id == 42);
Console.WriteLine($"003: 42es azonositoju termek:\n{f003}");

// 4. Van-e egyáltalán olyan termék a teljes kínálatban, aminek az ára meghaladja az 1 000 000 Ft-ot?
var f004 = products.Any(p => p.PriceHUF > 1000000);
Console.WriteLine($"{(f004 ? "VAN" : "NINCS")} olyan termek, aminek az arra meghaladja az 1M HUF-t");

// 5. Mennyi az összes termékünk átlagos értékelése a webshopban (a teljes listát nézve)?
var f005 = products.Average(p => p.Rating);
Console.WriteLine($"webshop kinalatanak atlagos ertekelese: {f005:0.000}");

// 6. Keresd meg az első "Quantum" gyártmányú okostelefont, amelynek az ára 200 000 Ft alatt van! (Ha nincs ilyen, az eredmény legyen null).
var f006 = products.FirstOrDefault(p => p.Brand == "Quantum" && p.Category == "Okostelefon" && p.PriceHUF < 200000);
Console.WriteLine(f006 is null
    ? "nincs Quantum okostelefon 200K HUF alatt"
    : $"az elso Quantum okostelefon 200K HUF alatt:\n{f006}");

// 7. Keresd meg a lista legutolsó olyan termékét, amiből pontosan 0 darab van raktáron! (Ha nincs ilyen, az eredmény legyen null).
var f007 = products.LastOrDefault(p => p.StoctQty == 0);
Console.WriteLine(f007 is null
    ? "nincs olyan termek, amibol pontosan 0 db vanb raktaron"
    : $"a kinalatban az utolso olyan termek, amibol 0 db van raktaron:\n{f007}");

// 8. Igaz-e az az állítás, hogy a kínálatunkban lévő összes termék értékelése eléri a 3.0-t?
var f008 = products.All(p => p.Rating >= 3);
Console.WriteLine(f008 
    ? "MINDEN termék értékelése eléri a 3.0-t" : 
    "NEM MINDEN termék értékelése éri el a 3.0-t");

// 9. Melyik termékből van a legnagyobb darabszám készleten a teljes raktárat figyelembe véve?
var f009 = products.MaxBy(p => p.StoctQty);
Console.WriteLine($"a legnagyobb darabszammal raktaron levo termek:\n{f009}");

// 10. Keresd meg a fájl szerinti legelső "Tablet" kategóriájú terméket!
var f010 = products.First(p => p.Category == "Tablet");
Console.WriteLine($"elso tablet kategoriaju termek:\n{f010}");

// 11. Hány darab "Okostelefon" kategóriájú termék található a listában?
var f011 = products.Count(p => p.Category == "Okostelefon");
Console.WriteLine($"okostelefon kategoriaju termekek szama: {f011} db");

// 12. Mennyi a teljes raktárkészletünk darabszáma összesen (az összes termékből együttesen)?
var f012 = products.Sum(p => p.StoctQty);
Console.WriteLine($"a raktarban levo terkekek szama: {f012:N0} db");

// 13. Keresd meg a listában a "Foldable Z2" modellnevű terméket (biztosak vagyunk benne, hogy pontosan egy ilyen van)!
var f013 = products.Single(p => p.Model == "Foldable Z2");
Console.WriteLine($"Foldable Z2 osszes adata:\n{f013}");

// 14. Létezik-e legalább egy olyan termék a rendszerben, amiből több mint 300 darab porosodik a raktáron?
var f014 = products.Any(p => p.StoctQty > 300);
Console.WriteLine($"{(f014 ? "VAN" : "NINCS")} olyan termek, amibol tobb, mint 300 van raktaron");

// 15. Melyik a legutolsó "Monitor" kategóriájú termék a lista sorrendje alapján?
var f015 = products.Last(p => p.Category == "Monitor");
Console.WriteLine($"a kinalat utolso monitora:\n{f015}");

// 16. Melyik a legrosszabbra értékelt termék az egész raktárban?
var f016 = products.MinBy(p => p.Rating);
Console.WriteLine($"legrosszabb ertekelesu termek:\n{f016}");

// 17. Mekkora a teljes árukészletünk összértéke (ár × készlet) az összes kategóriát egybevéve?
var f017 = products.Sum(p => p.PriceHUF * p.StoctQty);
Console.WriteLine($"teljes arukeszlet erteke: {f017:C0}");

// 18. Igaz-e, hogy az összes raktáron lévő termékünk ára 1 000 000 Ft alatt van?
var f018 = products.All(p => p.PriceHUF < 1000000);
Console.WriteLine(f018
    ? "MINDEN termek ara 1 000 000 HUF alatt van"
    : "NEM MINDEN termek ara van 1 000 000 HUF alatt");

// 19. Keresd meg a "Gamer Pro 19" nevű modellt! A program fusson tovább hiba nélkül akkor is, ha ilyen termék még nem létezik a rendszerben.
var f019 = products.SingleOrDefault(p => p.Model == "Gamer Pro 19");
Console.WriteLine(f019 is null
    ? "meg NINCS 'Gamer Pro 19' nevű termek a kinalatban"
    : $"'Gamer Pro 19' orrszes adata:\n{f019}");

// 20. Mi az átlagos ára a kínálatunkban szereplő 80 db terméknek?
var f020 = products.Average(p => p.PriceHUF);
Console.WriteLine($"a termekek aranak atlaga: {f020:C2}");

// 21. Keresd meg a listában azt a "Cyber" gyártmányú terméket, aminek az értékelése hajszálpontosan 3.8! (Tegyük fel, hogy nem tudjuk, hány ilyen van, de az elsőt kérjük).
var f021 = products.FirstOrDefault(p => p.Brand == "Cyber" && p.Rating == 3.8F);
Console.WriteLine(f021 is null
    ? "nincs olyan Cyber termek, aminek az ertekelese 3.8"
    : $"az elso Cyber termek, aminek az ertekelese 3.8:\n{f021}");

// 22. Igaz-e az az állítás, hogy az összes "Kiegeszito" kategóriájú termékből van legalább 10 db raktáron?
var f022 = products.Where(p => p.Category == "Kiegeszito").All(p => p.StoctQty >= 10);
Console.WriteLine(f022
    ? "MINDEN kiegeszitobol van legalabb 10 db raktaron"
    : "NEM MINDEN kiegeszitobol van raktaron legalabb 10 db");

// 23. Hány olyan termékünk van, aminek a gyártója "Apex" és az ára 20 000 Ft felett van?
var f023 = products.Count(p => p.Brand == "Apex" && p.PriceHUF > 20000);
Console.WriteLine($"20K HUF ot meghalado Apex termekek szama: {f023} db");

// 24. Melyik az az egyetlen termék, aminek az azonosítója (Id) pontosan 80?
var f024 = products.Single(p => p.Id == 80);
Console.WriteLine($"80as azonositoju termek:\n{f024}");

// 25. Mennyi az átlagos készletszint (darabszám) a "NextGen" márkájú termékek esetében?
var f025 = products.Where(p => p.Brand == "NextGen").Average(p => p.StoctQty);
Console.WriteLine($"NextGen termekek atlagos keszletszintje: {f025:0.00} db");

// 26. Melyik a legolcsóbb "Monitor" a jelenlegi kínálatunkban?
var f026 = products.Where(p => p.Category == "Monitor").MinBy(p => p.PriceHUF);
Console.WriteLine($"legolcsobb monitor:\n{f026}");

// 27. Van-e olyan "Laptop" a listában, amiből több mint 100 darab porosodik a raktáron?
var f027 = products.Where(p => p.Category == "Laptop").Any(p => p.StoctQty > 100);
Console.WriteLine($"{(f027 ? "VAN" : "NINCS")} olyan laptop, amibol tobb, mint 100 van raktaron");

// 28. Mennyi a "Tablet" kategóriájú termékek értékelésének átlaga?
var f028 = products.Where(p => p.Category == "Tablet").Average(p => p.Rating);
Console.WriteLine($"tabletek atlagos ertekelese: {f028:0.00}");

// 29. Keresd meg a lista legelső olyan termékét, aminek az ára pontosan 45 000 Ft!
var f029 = products.FirstOrDefault(p => p.PriceHUF == 45000);
Console.WriteLine(f029 is null
    ? "NINCS olyan termek, aminek az ara pontosan 45K HUF"
    : $"az elso termek 45K HUF-ert:\n{f029}");

// 30. Melyik az utolsó olyan termék a fájlban, aminek az értékelése tökéletes (5.0)?
var f030 = products.LastOrDefault(p => p.Rating == 5.0F);
Console.WriteLine(f030 is null
    ? "NINCS tokeletes ertekelesu termek"
    : $"a kinalatban utolso tokeletes ertekelesu termek:\n{f030}");

// 31. Hány darab olyan termékünk van összesen, amelynek a nevében (Modell) szerepel a "Pro" szó?
var f031 = products.Count(p => p.Model.Contains("Pro"));
Console.WriteLine($"'Pro' substringet tartalmazo nevu modellek szama: {f031} db");

// 32. Mekkora a "Nova" gyártó összes termékének együttes készletértéke forintban (ár × darab)?
var f032 = products.Where(p => p.Brand == "Nova").Sum(p => p.PriceHUF * p.StoctQty);
Console.WriteLine($"keszleten levo Nova termekek osszerteke: {f032:C0}");

// 33. Melyik az a "SoundWave" termék, amiből a legkevesebb van raktáron?
var f033 = products.Where(p => p.Brand == "SoundWave").MinBy(p => p.StoctQty);
Console.WriteLine($"az a SoundWave termek, amibol a legkevesebb van raktaron:\n{f033}");

// 34. Igaz-e, hogy az összes 500 000 Ft-nál drágább prémium termékünk értékelése legalább 4.5?
var f034 = products.Where(p => p.PriceHUF > 500000).All(p => p.Rating >= 4.5F);
Console.WriteLine(f034
    ? "MINDEN premium termek ertekelese eleri a 4.5-ot"
    : "NEM MINDEN premium termek erteke eri el a 4.5-ot");

// 35. Keresd meg a rendszerben azt az egyetlen terméket, amelynek a modellneve "Pocket 6G"!
var f035 = products.Single(p => p.Model == "Pocket 6G");
Console.WriteLine($"a Pocket 6G osszes adata:\n{f035}");

// 36. Van-e olyan termék a "Kiegeszito" kategóriában, ami drágább, mint 50 000 Ft?
var f036 = products.Where(p => p.Category == "Kiegeszito").Any(p => p.PriceHUF > 50000);
Console.WriteLine($"{(f036 ? "VAN" : "NINCS")} olyan kiegeszito, aminek az ara tobb, mint 50K HUF");

// 37. Keresd meg a legelső olyan "TechPro" márkájú terméket, amelynek az ára még 100 000 Ft alatt van! (Biztosítsd, hogy ne fagyjon le a kód, ha ilyen már nincs).
var f037 = products.FirstOrDefault(p => p.Brand == "TechPro" && p.PriceHUF < 100000);
Console.WriteLine(f037 is null
    ? "NINCS 100K HUF alatt TechPro termek"
    : $"elso 100K HUF alatti aru TechPro termek:\n{f037}");

// 38. Melyik a legmagasabb értékelést kapott "Okostelefon" az egész listában?
var f038 = products.Where(p => p.Category == "Okostelefon").MaxBy(p => p.Rating);
Console.WriteLine($"legjobb ertekelesu okostelefon:\n{f038}");

// 39. Hány darab termékünk van összesen az "Apex" és a "Quantum" gyártóktól együttesen? (Egy lekérdezésben oldd meg!)
var f039 = products.Count(p => p.Brand == "Apex" || p.Brand == "Quantum");
Console.WriteLine($"Apex és Quantum termekek szama osszesen: {f039} db");

// 40. Keresd meg a sorrend szerinti legutolsó olyan terméket a listában, ami "Vision" gyártmányú!
var f040 = products.Last(p => p.Brand == "Vision");
Console.WriteLine($"utolso Vision termek:\n{f040}");

// 41. Rendezd a teljes listát ár szerint növekvő sorrendbe!
var f041 = products.OrderBy(p => p.PriceHUF);
Console.WriteLine("termekek ar szerint novekvoben:");
foreach (var p in f041) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}", -30} {p.PriceHUF,10:C0}");

// 42. Rendezd az "Okostelefon" kategóriájú termékeket értékelés szerint csökkenő sorrendbe!
var f042 = products.Where(p => p.Category == "Okostelefon").OrderByDescending(p => p.Rating);
Console.WriteLine("okortelefonok ertekeles szerint csokkenoben");
foreach (var p in f042) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-25} {p.Rating:0.0}");

// 43. Listázd ki az összes "Nova" terméket raktárkészlet (darabszám) alapján csökkenő sorrendben!
var f043 = products.Where(p => p.Brand == "Nova").OrderByDescending(p => p.StoctQty);
Console.WriteLine("Nova termekek keszletszam szerint csokkeno sorrendben");
foreach (var p in f043) Console.WriteLine($"{$"\t{p.Model} ({p.Category})", -40} {p.StoctQty,3} db");

// 44. Rendezd a teljes kínálatot először kategória szerint ABC sorrendbe, majd azon belül ár szerint csökkenőbe!
var f044 = products.OrderBy(p => p.Category).ThenByDescending(p => p.PriceHUF);
Console.WriteLine("kategoriak szerint ABC-ben, azon belul Ar szerint csokkenoben:");
foreach (var p in f044) Console.WriteLine($"{$"\t{p.Category}: {p.Brand + " " + p.Model}",-45} {p.PriceHUF,10:C0}");

// 45. Rendezd a termékeket gyártó szerint ABC sorrendbe, azon belül pedig értékelés szerint növekvőbe!
var f045 = products.OrderBy(p => p.Brand).ThenBy(p => p.Rating);
Console.WriteLine("gyarto szerint ABC-ben, azon belul ertekeles szerint novekvoben:");
foreach (var p in f045) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-35} {p.Rating,3:0.0}");

// 46. Listázd ki a "Laptop" kategória termékeit: először értékelés alapján csökkenően, majd (ha ez megegyezik) ár alapján növekvően!
var f046 = products.Where(p => p.Category == "Laptop").OrderByDescending(p => p.Rating).ThenBy(p => p.PriceHUF);
Console.WriteLine("laptopok, ertekeles szerint csokkenoben, azon belul ar szerint novekvoben");
foreach (var p in f046) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-25} {p.Rating,-3:0.0} {p.PriceHUF,15:C0}");

// 47. Melyik a 3 legolcsóbb termékünk a teljes kínálatban? (Használd a Take metódust!)
var f047 = products.OrderBy(p => p.PriceHUF).Take(3);
Console.WriteLine("harom legolcsobb termek:");
foreach (var p in f047) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-30} {p.PriceHUF,8:C0}");

// 48. Keresd meg a 3 legdrágább "Monitor" kategóriájú terméket!
var f048 = products.Where(p => p.Category == "Monitor").OrderByDescending(p => p.PriceHUF).Take(3).OrderBy(p => p.PriceHUF);
Console.WriteLine("harom legdragabb monitor:");
foreach (var p in f048) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-25} {p.PriceHUF,10:C0}");

// 49. Válaszd ki az 5 legjobbra értékelt "Kiegeszito" kategóriájú terméket!
var f049 = products.Where(p => p.Category == "Kiegeszito").OrderByDescending(p => p.Rating).Take(5);
Console.WriteLine("ot legjobb ertekelesu kiegeszito:");
foreach (var p in f049) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-30} {p.Rating,3:0.0}");

// 50. Rendezd a listát készlet szerint növekvőbe, és add vissza a legelsőt a First segítségével! (Ez amúgy megegyezik a MinBy logikájával).
var f050a = products.OrderBy(p => p.StoctQty).First();
var f050b = products.MinBy(p => p.StoctQty);
Console.WriteLine($"legalacsonybb keszletszamu termek:\n{f050a}\nVAGY\n{f050b}");
Console.WriteLine(f050a.Equals(f050b) ? "tényleg ua. mint a minby" : "nem is ugyan az, mint a minby :(");

// 51. Listázd ki a 10 legkevesebb raktárkészlettel rendelkező terméket a teljes rendszerből!
var f051 = products.OrderBy(p => p.StoctQty).Take(10);
Console.WriteLine("10 legkevesebb raktarkeszlettel rendelkezo termek:");
foreach (var p in f051) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-25} {p.StoctQty,3} db");

// 52. Melyek azok a termékek, amik 50 000 Ft alattiak? Rendezd őket értékelés szerint csökkenően!
var f052 = products.Where(p => p.PriceHUF < 50000).OrderByDescending(p => p.Rating);
Console.WriteLine("50K HUF alatt, ertekeles szerint csokkenoben:");
foreach (var p in f052) Console.WriteLine($"{$"\t{p.Brand + " " + p.Model}",-32} {p.PriceHUF,10:C0}  {p.Rating,3:0.0}");

// 53. Listázd az összes 4.5-nél jobb értékelésű "Tablet"-et és "Monitor"-t együttesen, ár szerint növekvő sorrendben!
var f053 = products.Where(p => p.Category == "Tablet" || p.Category == "Monitor").OrderBy(p => p.PriceHUF);
Console.WriteLine("monitorok és tabletek omlesztve, ar szerint novekvoben");
foreach (var p in f053) Console.WriteLine($"{$"\t{p.Category}: {p.Brand + " " + p.Model}",-35} {p.PriceHUF,10:C0}");