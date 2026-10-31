# 🎯 Sayı Tahmin Oyunu

C# ile yazılmış basit bir konsol tahmin oyunu. C# öğrenme sürecimdeki ikinci projem.

## Ne yapıyor?

Program açılınca bir oyun modu seçilir:

- **Normal mod:** Bilgisayar bir sayı tutar, oyuncu sınırlı hakla tahmin eder
- **Ters mod:** Oyuncu aklından bir sayı tutar, bilgisayar ikili aramayla (ortadan bölerek) tahmin eder

Normal modda:

- Üç zorluk var: Kolay (1-10, 3 hak), Orta (1-100, 7 hak), Zor (1-1000, 14 hak)
- Yanlış tahminde iki ipucu verir: yön ("Daha büyük / Daha küçük") ve yakınlık ("Çok Sıcak" ... "Çok Soğuk")
- Kalan hakkı gösterir, bilinirse kaç denemede bulunduğunu, hak biterse tutulan sayıyı söyler
- Oyun bitince tekrar oynamak isteyip istemediğini sorar
- En iyi skoru dosyada (enIyiSkor.txt) saklar, program kapanıp açılsa bile hatırlar
- Kazanılan oyunları sıralı bir skor tablosunda (ilk 5) gösterir
- Yanlış girişte kapanmaz: Harf girilirse tekrar sorar, aralık dışı sayıda uyarır (hak düşmez)

Ters modda bilgisayar her seferinde kalan aralığın ortasını tahmin eder, oyuncu "daha büyük (B)", "daha küçük (K)" ya da "doğru (D)" der. Geçersiz harfi tahmin saymaz, cevaplar çelişirse bunu fark edip oyunu bitirir.

```
Oyun Modu Seçiniz (1: Normal, 2: Ters): 1
Adınızı girin: mete
Zorluk seçin (1:Kolay, 2:Orta, 3:Zor): 2
7 Deneme Hakkınız Var
Tahmininizi girin (1-100): 50
Daha Büyük Sayı Giriniz
Sıcak!
6 hakkınız kaldı
Tahmininizi girin (1-100): 60
Bildiniz Tebrikler: 2 denemede buldunuz
En iyi skorunuz: 2 deneme
mete - 2 deneme
```

```
Oyun Modu Seçiniz (1: Normal, 2: Ters): 2
Tahminim: 50
B: daha büyük, K: daha küçük, D: doğru: b
Tahminim: 75
B: daha büyük, K: daha küçük, D: doğru: k
Tahminim: 62
B: daha büyük, K: daha küçük, D: doğru: k
Tahminim: 56
B: daha büyük, K: daha küçük, D: doğru: b
Tahminim: 59
B: daha büyük, K: daha küçük, D: doğru: D
Buldum! 5 tahminde buldum
```

## Kullanılanlar

- C#
- .NET 10

## Nasıl çalıştım?

- Bu projeyi yapay zekâ ile soru-cevap şeklinde ilerleyerek yaptım. Yapay zekâ bana sorular sordu, ipuçları verdi ve kavramları açıkladı.
- Kod satırlarını kendim yazdım. Takıldığım yerde ipucu istedim, hatalarımın nedenini sordum. Bazı yerlerde çözümü yapay zekâ gösterdi.
- Sınıflar (V8), skor tablosu (V9) ve ters mod (V10) bölümlerinde yapay zekâ ilk versiyonlara göre çok daha fazla yönlendirme yaptı. `OrderBy` / `Take` satırlarını ve bazı kalıpları (örneğin `if (mod == 2) { ...; return; }`) yapay zekâ verdi. Bunları gelişim günlüğünde tek tek yazdım.
- Anlamadığım kodu yapıştırmadım. Her değişiklikten sonra programı kendim test ettim.
- Nerede kendim bulduğumu, nerede yardım aldığımı versiyon versiyon [GELISIM.md](https://github.com/sukrumete/SayiTahminOyunu/blob/master/GELISIM.md) dosyasında açıkça yazdım.

## Bu projede öğrendiklerim

- **Temeller:** Random ile rastgele sayı, TryParse ile güvenli sayı alma, return / break / continue farkı
- **Karar yapıları ve döngüler:** if / else if / else, switch, iç içe döngü (her oyun ve her tahmin için ayrı döngü)
- **Metotlar:** SayiAl, TekrarEt, TersModOyna (parametre, dönüş türü, void)
- **Dosyalar:** En iyi skoru kaydetmek ve açılışta okumak (File.Exists, ReadAllText, WriteAllText)
- **OOP:** `Oyun` ve `Oyuncu` sınıfları, özellik ile metot farkı, `List<Oyuncu>` ile kendi sınıfımı listede tutmak
- **İkili arama:** Her tahminde aralığın yarısını eleyen ters mod
- **Tasarım dersi:** Skor kişiye ait değilse tablo yanlış çıkıyor. V9'da bunu testle fark ettik, kapsamı küçültüp düzelttik
- **Alışkanlıklar:** Her değişiklikten sonra test etmek, her versiyonda commit, dürüst README

**En çok zorlandığım konular:** OOP'de sınıfın içinden kendi özelliklerine ulaşmak, hangi bilginin özellik, hangisinin geçici kutu olduğu ve liste içinde nesne kullanmak. Tekrar ederek oturtmaya devam ediyorum.

## Bilinen sınırlamalar

- Skor tablosu program kapanınca silinir ve aynı oyuncu birden fazla satırda görünebilir ("en iyi 5 oyun" gibi çalışır)
- "En iyi skor" dosyadaki tek bir sayı, belirli bir oyuncuya ait değil
- Ters mod tek oyunluk, bitince program kapanır
- `HakBittiMi` metodunu yazdım ama ana programda kullanmadım

👉 Versiyon versiyon detaylı gelişim günlüğü: [GELISIM.md](https://github.com/sukrumete/SayiTahminOyunu/blob/master/GELISIM.md)
