Random zar = new Random();

int tutulanSayi = zar.Next(1, 101);

int denemeSayisi = 0;
int hakSayisi = 7;

Console.WriteLine(hakSayisi + " Deneme Hakkınız Var");

while (true)
{
    int tahmin = SayiAl("Tahmininizi girin (1-100): ");

    if (tahmin < 1 || tahmin > 100)
    {
        Console.WriteLine("Lütfen 1 ila 100 arası sayı giriniz");
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
