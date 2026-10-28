Random zar = new Random();

int secim = SayiAl("Zorluk seçin (1:Kolay, 2:Orta, 3:Zor): ");

int ustSinir = 100;
int hakSayisi = 7;

switch (secim)
{
    case 1:
        ustSinir = 10;
        hakSayisi = 3;
        break;
    case 2:
        ustSinir = 100;
        hakSayisi = 7;
        break;
    case 3:
        ustSinir = 1000;
        hakSayisi = 14;
        break;
    default:
        Console.WriteLine("Geçersiz seçim, Orta zorluk seçildi.");
        break;
}

int tutulanSayi = zar.Next(1, ustSinir + 1);

int denemeSayisi = 0;


Console.WriteLine(hakSayisi + " Deneme Hakkınız Var");

while (true)
{
    int tahmin = SayiAl($"Tahmininizi girin (1-{ustSinir}): ");

    if (tahmin < 1 || tahmin > ustSinir)
    {
        Console.WriteLine($"Lütfen 1 ila {ustSinir} arası sayı giriniz");
        continue;
    }

    denemeSayisi++;

    if (tahmin < tutulanSayi)
    {
        Console.WriteLine("Daha büyük bir sayı giriniz");
    }
    else if (tahmin > tutulanSayi)
    {
        Console.WriteLine("Daha küçük bir sayı giriniz");
    }
    else
    {
        Console.WriteLine("Bildiniz Tebrikler: " + denemeSayisi + " denemede buldunuz");
        break;
    }
    if (denemeSayisi == hakSayisi)
    {
        Console.WriteLine("Deneme Hakkınız Bitti. Tutulan Sayı: " + tutulanSayi);
        break;
    }
    Console.WriteLine((hakSayisi - denemeSayisi) + " hakkınız kaldı");
}

int SayiAl(string mesaj)
{
    while (true)
    {
        Console.Write(mesaj);
        string giris = Console.ReadLine() ?? "";

        if (int.TryParse(giris, out int sayi))
        {
            return sayi;
        }

        Console.WriteLine("Uygun bir sayı giriniz");
    }
}
