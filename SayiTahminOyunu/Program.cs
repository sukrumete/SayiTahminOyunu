Random zar = new Random();
bool tekrar = true;

while (tekrar)
{


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

        int uzaklik = tahmin - tutulanSayi;
        uzaklik = Math.Abs(uzaklik);
        int yuzde = uzaklik * 100 / ustSinir;



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
        if (yuzde <= 5)
        {
            Console.WriteLine("Çok Sıcak!");
        }
        else if (yuzde <= 15)
        {
            Console.WriteLine("Sıcak!");
        }
        else if (yuzde <= 30)
        {
            Console.WriteLine("Soğuk!");
        }
        else
        {
            Console.WriteLine("Çok Soğuk!");
        }
        if (denemeSayisi == hakSayisi)
        {
            Console.WriteLine("Deneme Hakkınız Bitti. Tutulan Sayı: " + tutulanSayi);
            break;
        }
        Console.WriteLine((hakSayisi - denemeSayisi) + " hakkınız kaldı");
    }
    tekrar = TekrarEt();
}

Console.WriteLine("Görüşmek üzere!");

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
bool TekrarEt()
{
    Console.WriteLine("Tekrar oynamak ister misiniz? (E/H)");
    string cevap = Console.ReadLine() ?? "";
    if (cevap == "E" || cevap == "e")
    {
        return true;
    }
    else
    {
        return false;
    }
}

