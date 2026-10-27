Random zar = new Random();

int tutulanSayi = zar.Next(1, 101);



while(true)
{
    int tahmin = SayiAl("Tahmininizi girin (1-100): ");

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
        Console.WriteLine("Bildiniz Tebrikler");
        break;
    }
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
