Random zar = new Random();

int tutulanSayi = zar.Next(1, 101);

int tahmin = SayiAl("Tahmininizi girin (1-100): ");

if (tutulanSayi == tahmin)
{
    Console.WriteLine("Bildin");
}
else
{
    Console.WriteLine("Maalesef bilemediniz");
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

// V1: Sayi tutma ve tek tahmin