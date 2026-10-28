# 🎯 Sayı Tahmin Oyunu

C# ile yazılmış basit bir konsol tahmin oyunu. C# öğrenme sürecimdeki ikinci projem.

## Ne yapıyor?

Kullanıcı bir zorluk seçer, bilgisayar o aralıkta rastgele bir sayı tutar, kullanıcı bu sayıyı sınırlı hakla tahmin etmeye çalışır.

- Üç zorluk seviyesi var:
  - Kolay: 1-10 arası, 3 hak
  - Orta: 1-100 arası, 7 hak
  - Zor: 1-1000 arası, 14 hak
- Yanlış tahminde ipucu verir: "Daha büyük" ya da "Daha küçük"
- Her yanlış tahminden sonra kalan hakkı gösterir
- Bilinirse kaç denemede bulunduğunu, hak biterse tutulan sayıyı söyler
- Yanlış girişte program kapanmaz:
  - Sayı yerine harf girilirse tekrar sorar
  - Aralık dışında bir sayı girilirse uyarır (bu durumda hak düşmez)
  - Geçersiz zorluk seçilirse Orta zorlukla başlar ve bunu söyler

```
Zorluk seçin (1:Kolay, 2:Orta, 3:Zor): 1
3 Deneme Hakkınız Var
Tahmininizi girin (1-10): 15
Lütfen 1 ila 10 arası sayı giriniz
Tahmininizi girin (1-10): 6
Daha büyük bir sayı giriniz
2 hakkınız kaldı
Tahmininizi girin (1-10): 8
Daha büyük bir sayı giriniz
1 hakkınız kaldı
Tahmininizi girin (1-10): 9
Bildiniz Tebrikler: 3 denemede buldunuz
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

### Versiyon 3

- Deneme sayacı için ilk önce kutunun döngünün içinde olması gerektiğini düşündüm → yapay zekâ çetele defteri benzetmesiyle sordu. Kutuyu oluşturmanın döngüden önce, artırmanın döngünün içinde olması gerektiğini kendim söyledim. Başlangıç değerinin 0 olması gerektiğini de kendim buldum
- Sayacı artırmak için önce `SayiAl + 1` yazdım → yapay zekâ artacak şeyin sayaç olduğunu hatırlattı, `denemeSayisi++` olarak kendim yazdım
- Tebrik mesajına deneme sayısını `+` ile ekledim. İlk denemede `+` tırnağın içinde kalmıştı ve bir `+` eksikti → yapay zekâ fark ettirdi. Testte `9denemede` diye yapışık çıktığını kendim gördüm, tırnağın içine boşluk koymayı yapay zekâ gösterdi
- Hak sınırı için deneme sayısına bakmamız gerektiğini kendim buldum. Kontrolü SayiAl'a koymayı düşündüm → yapay zekâ SayiAl'ın sadece sayı sorduğunu, oyun kurallarının ana döngüde olduğunu açıkladı
- Koşulu yazarken iki kez `==` yerine `=` yazdım. İlkinde yapay zekâ fark ettirdi, ikincisini kendim fark ettim
- Hak kontrolünü if / else bloğunun altına koymayı yapay zekâ önerdi (bilinince break çalıştığı için oraya sadece bilemeyince ulaşılıyor). break'i if'in dışına yazmıştım (her turda oyun biterdi) → yapay zekâ fark ettirdi
- Kullanıcıya kaç hakkı olduğunu söylememiz gerektiğini kendim fark ettim. Hem başta hem her turda göstermeyi yapay zekâ önerdi
- 7 sayısını üç yerde yazmamak için `hakSayisi` kutusu oluşturmayı yapay zekâ önerdi. İlk denemede `string hakSayisi == 7` yazdım → türün int, koyarken tek `=` olması gerektiğini ipucuyla düzelttim
- Kalan hak hesabını (`hakSayisi - denemeSayisi`) kendim buldum, ama koda ilk yazarken ters yazdım (eksi sonuç çıkardı) → yapay zekâ fark ettirdi
- Hesabı paranteze alırken WriteLine'ın parantezini erken kapattım ve CS0019 hatası aldım → yapay zekâ hata mesajını açıkladı: WriteLine void olduğu için sonucuna yazı eklenemez
- Aralık dışı sayıların hak düşürmemesi gerektiğine kendim karar verdim. Bu yüzden kontrolün sayaç artırma satırının üstünde olması gerektiğini de kendim buldum
- Koşulu (`tahmin < 1 || tahmin > 100`) birkaç denemede yazdım: kutu adını unuttum, yanlış kutuyu (denemeSayisi) kullandım, `||` yerine `|` ve `| |` yazdım → yapay zekâ adım adım ipucu verdi. Turu atlayıp başa dönmek için `continue` kelimesini ipucuyla buldum
- Kazanma, kaybetme, 0 ve 340 girişleriyle ayrı ayrı test ettim

### Versiyon 4

- Zorluk seçiminden önce, 100 sayısının kodda geçtiği yerleri aradım. Üçünü kendim buldum (101 dahil), uyarı mesajındakini yapay zekâ gösterdi. Hepsini `ustSinir` kutusuna bağlamayı yapay zekâ önerdi (`hakSayisi` ile aynı mantık)
- 101 için `ustSinir = 101` yapmayı düşündüm → yapay zekâ mesajlarda ve kontrolde yanlış sayı çıkacağını açıkladı. Sonra `ustSinir++` denedim → yapay zekâ bunun kutunun kendisini kalıcı değiştirdiğini anlattı, `ustSinir + 1` kullanmayı gösterdi
- Yazının içine değişken koymak için `$` ve `{ }` kullanmayı yapay zekâ anlattı. İlk denemede `$` ortada kaldı ve süslü parantezi unuttum → boşluk doldurma ile düzelttim. İkinci mesajı kendim, ipucusuz yazdım
- Satırı değiştirirken yanlışlıkla `int tahmin =` kısmını sildim ve CS0103 hatası aldım → yapay zekâ hatayı açıkladı
- Zorluk seçimini almak için yeni metot yazmam gerektiğini düşündüm → yapay zekâ var olan SayiAl metodunu farklı bir mesajla tekrar kullanabileceğimi hatırlattı
- switch ile seçime göre aralık belirledim. İlk denemede `switch (ustSinir)` yazdım → yapay zekâ kararın neye göre verildiğini sordu, boşluk doldurma kalıbı verdi. `1,10` yazdım ve `;` unuttum, ipucuyla düzelttim
- switch akışını ilk başta tam anlamadım → yapay zekâ kafe sipariş benzetmesiyle anlattı. Sonra 3 seçilince kodun nasıl çalıştığını kendim anlattım
- Testte her zorlukta hakkın 7 olduğunu ve bunun Kolay için fazla, Zor için az olduğunu yapay zekâ fark ettirdi. Hak sayısını da switch'e eklemeyi kendim düşündüm (ayrı bir switch yazmıştım) → yapay zekâ aynı case'lere eklemeyi ve `hakSayisi`'nın switch'ten önce oluşturulması gerektiğini gösterdi
- Geçersiz seçim (5) testini yapay zekâ önerdi. Hiçbir case uymayınca kutuların başlangıç değerinde (Orta) kaldığını öğrendim, default ile kullanıcıya bunu söyledim

## Sonraki adımlar

- [x] Bilgisayar sayı tutar, kullanıcı tahmin eder
- [x] "Daha büyük / daha küçük" ipucu
- [x] Deneme sayacı ve hak sınırı
- [x] 1-100 dışındaki tahminlere uyarı (aralık kontrolü)
- [x] Zorluk seçimi: Kolay (1-10), Orta (1-100), Zor (1-1000)
- [ ] "Sıcak / soğuk" ipucu
- [ ] Tekrar oyna ve en iyi skor
- [ ] Skorları dosyaya kaydetmek
- [ ] OOP: Oyun ve Oyuncu sınıfları
- [ ] Skor tablosu: en iyi 5 oyuncu
- [ ] Ters mod: Ben sayı tutarım, bilgisayar tahmin eder (ikili arama)
