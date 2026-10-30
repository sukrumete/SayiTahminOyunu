
Oyun oyun = new Oyun();
Oyuncu oyuncu = new Oyuncu();
List<Oyuncu> skorlar = new List<Oyuncu>();
oyuncu.EnIyiSkor = 1001;
bool tekrar = true;

if (File.Exists("enIyiSkor.txt"))
{
    string kayit = File.ReadAllText("enIyiSkor.txt");
    int.TryParse(kayit, out oyuncu.EnIyiSkor);
}

Console.Write("Adınızı girin: ");
oyuncu.Ad = Console.ReadLine() ?? "";
Console.WriteLine($"Hoş geldiniz {oyuncu.Ad}!");

while (tekrar)
{


    int secim = SayiAl("Zorluk seçin (1:Kolay, 2:Orta, 3:Zor): ");
    oyun.Baslat(secim);

    Console.WriteLine(oyun.HakSayisi + " Deneme Hakkınız Var");

    while (true)
    {
        int tahmin = SayiAl($"Tahmininizi girin (1-{oyun.UstSinir}): ");

        if (tahmin < 1 || tahmin > oyun.UstSinir)
        {
            Console.WriteLine($"Lütfen 1 ila {oyun.UstSinir} arası sayı giriniz");
            continue;
        }

        if (oyun.TahminKontrolEt(tahmin))
        {
            Console.WriteLine("Bildiniz Tebrikler: " + oyun.DenemeSayisi + " denemede buldunuz");

            if (oyun.DenemeSayisi < oyuncu.EnIyiSkor)
            {
                oyuncu.EnIyiSkor = oyun.DenemeSayisi;
                Console.WriteLine("Yeni Rekor!");
                File.WriteAllText("enIyiSkor.txt", oyuncu.EnIyiSkor.ToString());
            }

            Oyuncu yeniKart = new Oyuncu();
            yeniKart.Ad = oyuncu.Ad;
            yeniKart.EnIyiSkor = oyun.DenemeSayisi;
            skorlar.Add(yeniKart);

            break;
        }



        if (oyun.DenemeSayisi == oyun.HakSayisi)
        {
            Console.WriteLine("Deneme Hakkınız Bitti. Tutulan Sayı: " + oyun.TutulanSayi);
            break;
        }
        Console.WriteLine((oyun.HakSayisi - oyun.DenemeSayisi) + " hakkınız kaldı");
    }


    if (oyuncu.EnIyiSkor != 1001)
    {
        Console.WriteLine("En iyi skorunuz: " + oyuncu.EnIyiSkor + " deneme");
    }

    foreach (Oyuncu kart in skorlar.OrderBy(k => k.EnIyiSkor).Take(5))
    {
        Console.WriteLine(kart.Ad + " - " + kart.EnIyiSkor + " deneme");
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

class Oyun
{
    public int UstSinir;
    public int HakSayisi;
    public int TutulanSayi;
    public int DenemeSayisi;

    Random zar = new Random();
    public void Baslat(int secim)
    {
        UstSinir = 100;
        HakSayisi = 7;
        switch (secim)
        {
            case 1:
                UstSinir = 10;
                HakSayisi = 3;
                break;
            case 2:
                UstSinir = 100;
                HakSayisi = 7;
                break;
            case 3:
                UstSinir = 1000;
                HakSayisi = 14;
                break;
            default:
                Console.WriteLine("Geçersiz seçim, Orta zorluk seçildi.");
                break;
        }
        TutulanSayi = zar.Next(1, UstSinir + 1);
        DenemeSayisi = 0;
    }

    public bool TahminKontrolEt(int tahmin)
    {
        DenemeSayisi++;
        if (tahmin == TutulanSayi)
        {
            return true;
        }
        int uzaklik = tahmin - TutulanSayi;
        uzaklik = Math.Abs(uzaklik);
        int yuzde = uzaklik * 100 / UstSinir;

        if (tahmin < TutulanSayi)
        {
            Console.WriteLine("Daha Büyük Sayı Giriniz");
        }
        else
        {
            Console.WriteLine("Daha Küçük Sayı Giriniz");
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
        return false;
    }

    public bool HakBittiMi()
    {
        if (DenemeSayisi == HakSayisi)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}

class Oyuncu
{
    public string Ad;
    public int EnIyiSkor;
}