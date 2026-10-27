# 🎯 Sayı Tahmin Oyunu

C# ile yazılmış basit bir konsol tahmin oyunu. C# öğrenme sürecimdeki ikinci projem.

## Ne yapıyor?

Bilgisayar 1 ile 100 arasında rastgele bir sayı tutar, kullanıcı bu sayıyı tahmin etmeye çalışır.

- Bilgisayar her oyunda farklı bir sayı tutar
- Yanlış tahminde ipucu verir: "Daha büyük" ya da "Daha küçük"
- Kullanıcı doğru bilene kadar tahmin etmeye devam eder
- Yanlış girişte program kapanmaz, kullanıcıdan tekrar ister (sayı yerine harf girilirse)

```
Tahmininizi girin (1-100): 50
Daha küçük bir sayı giriniz
Tahmininizi girin (1-100): elma
Uygun bir sayı giriniz
Tahmininizi girin (1-100): 25
Daha büyük bir sayı giriniz
Tahmininizi girin (1-100): 37
Bildiniz Tebrikler
```

## Kullanılanlar

- C#
- .NET 10

## Nasıl çalıştım?

- Bu projeyi de yapay zekâ ile soru-cevap şeklinde ilerleyerek yapıyorum. Her adımda yapay zekâ bana sorular soruyor, ipuçları veriyor ve kavramları açıklıyor.
- Kod satırlarını kendim yazıyorum. Takıldığım yerde önce küçük ipucu, sonra boşluk doldurma şeklinde yardım istiyorum. Bazı yerlerde çözümü yapay zekâ gösterdi, bunları aşağıda açıkça yazdım.
- Planı ve fikirleri birlikte oluşturduk. README metinlerini de yapay zekâ ile birlikte düzenledim.
- Her değişiklikten sonra programı kendim test ettim.

## Bu projede öğrendiklerim

### Versiyon 1

- Rastgele sayı için Random sınıfını kullandım: `Random zar = new Random();` Yapay zekâ Random sınıfını gösterdi; nesne oluşturmayı hesap makinesindeki `new` bilgimle kendim yazdım. İlk denemede `new random()` diye küçük harf yazdım, ipucuyla düzelttim
- `zar.Next(1, 101)` ile 1-100 arası sayı tutturdum. İkinci sayının dahil olmadığını yapay zekâ anlattı, 100'ün de gelmesi için 101 yazmam gerektiğini kendim buldum
- İlk denemede değişkeni string yaptım ve metodu nokta olmadan çağırmaya çalıştım → yapay zekâ boşluk doldurma kalıbı verdi, ben doldurdum
- Kullanıcıdan sayı almak için hesap makinesindeki SayiAl metodunu kullanma fikri benimdi. Bu projede double yerine int döndürecek şekilde yeniden yazdım
- Metodun içi için süslü parantez yerine tırnak kullandım, mesajı tırnakla sabit yazdım → yapay zekâ parametrenin dışarıdan geldiğini postacı benzetmesiyle anlattı, `Console.Write(mesaj)` olarak düzelttim
- Klavyeden gelen her şeyin önce yazı (string) olduğunu ve sonra sayıya çevrilmesi gerektiğini öğrendim
- int.TryParse ve out kelimesini yapay zekâ anlattı. TryParse yerine önce try/catch ve ToString düşündüm; ToString'in ters yönde çevirdiğini öğrendim
- "Not all code paths return a value" hatası aldım → yapay zekâ metodun her durumda sayı döndürmesi gerektiğini açıkladı
- Doğru sayı girilene kadar tekrar sormak için while (true) ve return kullanmayı yapay zekâ gösterdi. return'ün metodu ve döngüyü birlikte bitirdiğini öğrendim
- Hata mesajını return'ün altına, if'in içine yazmıştım (bu satır hiç çalışmazdı) → yapay zekâ fark ettirdi. Düzeltilmiş metodu yapay zekâ verdi; yapıştırmadan önce "elma" yazılınca kodun hangi satırlardan geçtiğini kendim adım adım takip ettim
- Tahmini tutulan sayıyla karşılaştırırken if parantezine önce zar, mesaj ve SayiAl(mesaj) yazdım → son satırı (`if (tutulanSayi == tahmin)`) yapay zekâ gösterdi. SayiAl'ı tekrar çağırmanın kullanıcıya ikinci kez soracağını öğrendim

### Versiyon 2

- Tahmin 50, tutulan sayı 63 iken ilk önce "daha küçük" demek gerektiğini düşündüm → yapay zekâ asansör benzetmesiyle sordu (50. kattasın, arkadaşın 63. katta), "daha büyük" olması gerektiğini kendim buldum
- "Daha büyük" ipucunun koşulunu (`tahmin < tutulanSayi`) kendim yazdım
- Üç durumu (küçük, büyük, eşit) if / else if / else ile yazdım. İlk denemelerde `else (...)` ve `if else` yazdım → yapay zekâ ipucu verdi, `else if` olarak düzelttim. Son else'e koşul yazılmadığını (geriye sadece "eşit" kaldığı için) yapay zekâ anlattı
- Yanlış tahminde if bloğunun tekrar çalışması gerektiğini ve bunun için while kullanılabileceğini kendim düşündüm
- İlk önce bütün satırların döngüye girmesi gerektiğini düşündüm → yapay zekâ sayı tutma satırı döngüye girerse her turda yeni sayı tutulacağını ve ipuçlarının anlamsız olacağını açıkladı. Bir kere olacak şeyler döngüden önce, her turda tekrar eden şeyler içeride
- Döngünün tahmin tutulan sayıya eşit olunca bitmesi gerektiğini kendim buldum. while (true) ve else içinde break ile çıkmayı yapay zekâ önerdi
- SayiAl metodunu da döngünün içine koymuştum ve tahmin satırını dışarıda bırakmıştım → yapay zekâ düzeltilmiş yerleşimi gösterdi. Metodun her zaman dosyanın en altında durduğunu, döngüye sadece onu çağıran satırın girdiğini öğrendim
- Testte 340 ve 350 gibi aralık dışı sayıların da kabul edildiğini gördüm (yapay zekâ fark ettirdi) → sonraki adımlara ekledim

## Sonraki adımlar

- [x] Bilgisayar sayı tutar, kullanıcı tahmin eder
- [x] "Daha büyük / daha küçük" ipucu
- [ ] Deneme sayacı ve hak sınırı
- [ ] 1-100 dışındaki tahminlere uyarı (aralık kontrolü)
- [ ] Zorluk seçimi: Kolay (1-10), Orta (1-100), Zor (1-1000)
- [ ] "Sıcak / soğuk" ipucu
- [ ] Tekrar oyna ve en iyi skor
- [ ] Skorları dosyaya kaydetmek
- [ ] OOP: Oyun ve Oyuncu sınıfları
- [ ] Skor tablosu: en iyi 5 oyuncu
- [ ] Ters mod: Ben sayı tutarım, bilgisayar tahmin eder (ikili arama)
