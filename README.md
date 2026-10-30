# 🎯 Sayı Tahmin Oyunu

C# ile yazılmış basit bir konsol tahmin oyunu. C# öğrenme sürecimdeki ikinci projem.

## Ne yapıyor?

Oyuncu adını girer, bir zorluk seçer, bilgisayar o aralıkta rastgele bir sayı tutar, oyuncu bu sayıyı sınırlı hakla tahmin etmeye çalışır.

- Oyuncunun adını sorar ve onu adıyla karşılar
- Üç zorluk seviyesi var:
  - Kolay: 1-10 arası, 3 hak
  - Orta: 1-100 arası, 7 hak
  - Zor: 1-1000 arası, 14 hak
- Yanlış tahminde iki ipucu verir:
  - Yön: "Daha büyük" ya da "Daha küçük"
  - Yakınlık: "Çok Sıcak", "Sıcak", "Soğuk" ya da "Çok Soğuk" (her zorlukta aralığa göre ayarlanır)
- Her yanlış tahminden sonra kalan hakkı gösterir
- Bilinirse kaç denemede bulunduğunu, hak biterse tutulan sayıyı söyler
- Oyun bitince tekrar oynamak isteyip istemediğini sorar
- En az denemeyle bilinen oyunu en iyi skor olarak hatırlar, yeni rekor kırılınca haber verir
- En iyi skor bir dosyaya (enIyiSkor.txt) kaydedilir, program kapatılıp açılsa bile hatırlanır
- Oyunun kuralları `Oyun` sınıfında, oyuncunun bilgileri (ad, en iyi skor) `Oyuncu` sınıfında tutulur
- Yanlış girişte program kapanmaz:
  - Sayı yerine harf girilirse tekrar sorar
  - Aralık dışında bir sayı girilirse uyarır (bu durumda hak düşmez)
  - Geçersiz zorluk seçilirse Orta zorlukla başlar ve bunu söyler

```
Adınızı girin: mete
Hoş geldiniz mete!
Zorluk seçin (1:Kolay, 2:Orta, 3:Zor): 2
7 Deneme Hakkınız Var
Tahmininizi girin (1-100): 50
Daha Büyük Sayı Giriniz
Sıcak!
6 hakkınız kaldı
Tahmininizi girin (1-100): 60
Bildiniz Tebrikler: 2 denemede buldunuz
En iyi skorunuz: 2 deneme
Tekrar oynamak ister misiniz? (E/H)
h
Görüşmek üzere!
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

### Versiyon 5

- Tutulan sayı 63 iken 50 ve 70 tahminlerinin uzaklığını (13 ve 7) kendim buldum. Çıkarma işleminin eksi sonuç verebildiğini (50 - 63 = -13) yapay zekânın sorularıyla gördüm. Eksiyi atan `Math.Abs` metodunu notlarıma bakarak kendim buldum
- İlk denemede `Math.Abs(uzaklik);` yazdım ama sonucu kutuya koymadım → yapay zekâ sonucun havada kaldığını açıkladı, `uzaklik = Math.Abs(uzaklik);` olarak düzelttim
- Uzaklığın her tahminde hesaplanması için döngünün içinde olması gerektiğini kendim düşündüm. Döngünün en üstüne koymayı düşündüm → yapay zekâ orada tahminin henüz olmadığını açıkladı, doğru yeri gösterdi
- Dört seviyeli (çok sıcak, sıcak, soğuk, çok soğuk) ipucu fikri benimdi. Sınır değerlerini yapay zekâ önerdi, ben kabul ettim
- Zor modda 1000 tutulan sayıya 970 tahmininin ne diyeceğini sordum → bu soruyla sabit sınırların her zorlukta doğru çalışmadığını fark ettik. Uzaklığı yüzdeye çevirmeyi ve formülü (`uzaklik * 100 / ustSinir`) yapay zekâ önerdi ve sınav notu benzetmesiyle anlattı. Tam sayılarda önce çarpıp sonra bölmek gerektiğini de yapay zekâdan öğrendim
- Dört seviyeli if / else if / else zincirini kendim yazdım
- Doğru bilince de "Çok Sıcak!" yazdığını yapay zekâ fark ettirdi. Zinciri "Bildiniz" bloğunun altına taşıdım (oraya sadece yanlış tahminde ulaşılıyor). Yerini yapay zekâ gösterdi
- Üç zorlukta da ve doğru bilme durumunda ayrı ayrı test ettim

### Versiyon 6

- Yeni oyunda hangi satırların tekrar çalışması gerektiği sorusuna "hepsi" dedim → yapay zekâ Random nesnesinin bir kere oluşturulmasının yeterli olduğunu ve deneme sayacının her oyunda sıfırlanması gerektiğini açıkladı
- Hesap makinesinde tekrar sorusu için yazdığım metodu hatırlayamadım, yapay zekâ hatırlattı. Bu projede yeni bir metot yazdım, adını (TekrarEt) kendim seçtim. Yapay zekânın sorusu üzerine evet / hayır cevabı için dönüş türünün `bool` olması gerektiğini kendim buldum
- Metodun başlığını ilk denemede `bool;` ve `TekrarEt()` diye ayrı satırlara yazdım → yapay zekâ tür ile adın yan yana yazıldığını hatırlattı. Cevabı okuyan satırı yazamadım, yapay zekâ SayiAl'daki benzer satırı ipucu olarak gösterdi
- if / else kısmını boşluk doldurma ile yazdım. `" e"` diye fazladan boşluk bıraktım. Önce `return cevap;`, sonra `return TekrarEt;` yazdım → yapay zekâ bool metodun yazı döndüremeyeceğini ve metodun adını kendi içinde döndürdüğümü fark ettirdi. `true` / `false` değerlerini ipucuyla buldum
- `true` ile `false`'u ters yazsam ne olacağını sordum → Visual Studio'nun sadece yazım kurallarını kontrol ettiğini, mantık hatalarının ancak testle yakalandığını öğrendim
- Bütün oyunu ikinci bir döngüye aldım (iç içe döngü). İlk denemede `bool tekrar = 0` yazdım → yapay zekâ bool'a sayı konamayacağını hatırlattı. Dış döngünün yapısını yapay zekâ hesap makinesindeki örnekle gösterdi
- İlk denemede `tekrar = TekrarEt();` satırını unuttum ve fazladan iki satır yazdım → yapay zekâ fark ettirdi. Program kapanırken veda mesajı eklemeyi yapay zekâ önerdi
- En iyi skor kutusunun her oyunda değişebileceği için dış döngünün içinde olması gerektiğini düşündüm → yapay zekâ çetele defteri benzetmesiyle kutunun içeride oluşturulursa her oyunda unutulacağını açıkladı. Bunun üzerine dışarıda olması gerektiğini söyledim
- Başlangıç değeri 0 olursa hiçbir skorun rekor olamayacağını yapay zekânın sorusuyla gördüm. Başlangıç değeri olarak 1001'i kendim önerdim
- Rekorun sadece kazanılan oyunda güncellenmesi gerektiğini yapay zekâ söyledi, kazanılan yeri ("Bildiniz" bloğu) kendim buldum. Yeni kodun `break`'ten önce olması gerektiğini yapay zekâ hatırlattı. İlk denemede karşılaştırmayı ters yazdım ve kutuyu güncellemeyi unuttum → yapay zekâ fark ettirdi, güncelleme satırını boşluk doldurma ile yazdım
- Hiç kazanılmamışsa ekranda "1001 deneme" yazacağını yapay zekâ sordu. "En az bir kere kazanmışsa göster" kuralını yapay zekâ açıkladı. Koşulu önce `enIyiSkor < 1001` diye kendim yazdım, sonra ipucuyla `!=` kullandım. Kafam karışınca bu bloğun yerini yapay zekâ gösterdi
- Kazanma, kaybetme ve tekrar kaybetme durumlarını art arda test ettim, rekorun korunduğunu gördüm

### Versiyon 7

- Yapay zekânın önerdiği testle (kazan, programı kapat, tekrar aç) rekorun unutulduğunu gördüm: Önceki rekorum 3 iken 4 denemeyle bilince yine "Yeni Rekor!" çıktı. Bunun kutunun sıfırlanmasından olduğunu kendim söyledim; yapay zekâ kutuların geçici hafızada durduğunu ve başlangıç değerine (1001) döndüğünü açıkladı
- Dosyayla programın hangi anlarında işlem yapılacağını ilk başta anlamadım → yapay zekâ rekor defteri benzetmesiyle anlattı: açılışta defteri okumak, yeni rekor kırılınca deftere yazmak
- Yazma işinin yerini önce skoru gösteren blokta aradım → yapay zekâ rekorun kırıldığı bloğu gösterdi
- Sadece tek bir sayı saklayacağımız için `File.AppendAllText` değil `File.WriteAllText` (silip baştan yazar) kullanılması gerektiğini kendim söyledim
- Yazma satırında önce dosya adı ile değişkeni aynı tırnağın içine yazdım, sonra virgülü tırnağın içinde bıraktım → yapay zekâ fark ettirdi. Kayıt için `denemeSayisi` yerine `enIyiSkor` kullanmayı yapay zekâ önerdi
- "cannot convert from 'int'..." hatası aldım → yapay zekâ dosyaya sadece yazı yazılabildiğini açıkladı ve V1'de ters yönde önerdiğim ToString metodunu hatırlattı. Nokta ve parantezi ipucuyla ekledim
- Yapay zekânın önerisiyle `bin\Debug\net10.0` klasöründeki `enIyiSkor.txt` dosyasını açtım, içinde son rekorun (4) yazdığını kendim kontrol ettim
- Dosya yokken okumaya çalışmanın programı çökerteceğini yapay zekâ hatırlattı. `File.Exists` adını ipucuyla buldum. İlk denemede küçük harfle ve if olmadan yazdım, if satırında bir parantez eksikti → yapay zekâ fark ettirdi
- Okuma satırının kalıbını (`string kayit = File.ReadAllText(...)`) yapay zekâ verdi. İçine dosya adını yazmakta zorlandım (önce WriteAllText'i, sonra değişkenin adını önerdim), ipuçlarıyla buldum. `File.` ön ekini unutmamı ve `ReadALlText` yazım hatamı yapay zekâ fark ettirdi
- Okunan yazıyı sayıya çevirmek için TryParse kullanmayı ipucuyla kendim buldum. İlk denemede değerlerin sırasını ters yazdım, sonra `out int enIyiSkor` yazdım → yapay zekâ `int` yazınca aynı isimde yeni bir kutu oluşacağını açıkladı
- Metot adlarını sık unuttuğumu söyledim → yapay zekâ ezberlemek yerine Visual Studio'nun önerilerini (nokta koyunca açılan liste) kullanmamı önerdi
- Program açılınca kayıttaki rekorun (4) göründüğünü, daha iyi skorda yeni rekorun (2) kaydedildiğini ve program kapanıp açılınca da hatırlandığını test ettim
- Yapay zekâ bir eksiği fark ettirdi: Dosyanın içi bozulursa (ör. "abc" yazılırsa) TryParse rekoru 0 yapar ve hiçbir skor rekor olamaz. Bunu sonraki adımlara ekledim

### Versiyon 8

- Bir oyunun "özellikleri" ne olabilir sorusuna "skor, sayılar, semboller" dedim → yapay zekâ sembollerin bizim oyunda olmadığını söyledi ve kodumdaki dört kutuyu (`ustSinir`, `hakSayisi`, `tutulanSayi`, `denemeSayisi`) gösterdi. Hepsinin bir oyuna ait olduğunu "oyun kâğıdı" benzetmesiyle açıkladı. Bunların sınıfın özellikleri olacağını sonra kendim söyledim
- Oyunun ne yaptığını (zorluk seçimi, hak, rastgele sayı, tahmin, sıcak / soğuk, tekrar) kendi cümlelerimle anlattım → yapay zekâ bunu üç metoda çevirdi ve isimlerini (`Baslat`, `TahminKontrolEt`, `HakBittiMi`) önerdi. Döngünün ana programda kalması gerektiğini de yapay zekâ söyledi
- İlk sınıf denemesinde sınıfa `Oyuncu` adını verdim ve hesap makinesindeki `List` satırını kopyaladım. Sonra özellik yerine metot adlarını (`Baslat`, `TahminKontrolEt`...) özellik gibi yazdım → yapay zekâ özellik (bilgi) ile metot (iş) farkını hatırlattı (V12'de de karıştırmıştım). Dört özelliği küçük harfle ve `;` unutarak yazdım → büyük harf ve `;` kuralını yapay zekâ hatırlattı. "Bunlar sınıf değil, sınıfın içindeki özellikler" diyerek farkı kendim kavradım
- Baslat için dışarıdan neye ihtiyaç olduğunu sorulunca hak sayısını da saydım → yapay zekâ sadece zorluk seçiminin dışarıdan gelmesi gerektiğini, hakkı metodun kendisinin belirleyeceğini aşçı benzetmesiyle açıkladı. `int secim` parametresini kendim yazdım. `void` kelimesini ipucuyla buldum ama önce süslü parantezin içine yazdım → yapay zekâ yerini düzeltti. `public` yazmam gerektiğini hesap makinesindeki `Hesapla` örneğinden ipucuyla çıkardım
- Ana programdaki switch'i Baslat'a taşıdım: Büyük harfli özelliklerle kendim yazdım. Hiçbir case uymazsa özelliklerin boş kalacağını, bu yüzden switch'in üstüne başlangıç değerleri koymam gerektiğini yapay zekâ hatırlattı
- Oyunun kendi `Random zar` nesnesini, bir yorumda görmüştüm, kendim ekledim. `TutulanSayi = zar.Next(1, UstSinir + 1);` satırını yapay zekâ boşluk doldurma ile verdi, ben doldurdum. `DenemeSayisi = 0;` satırını kendim yazdım
- `Oyun oyun = new Oyun();` satırını kendim yazdım. Nesnenin döngünün dışında olması gerektiğini yapay zekâ önerdi (ben içinde olsun demiştim; yapay zekâ ikisinin de çalışacağını söyledi). `oyun.Baslat(secim);` çağrısında önce tür yazdım, sonra soru mesajını, sonra yanlış değerleri verdim → doğru satırı yapay zekâ gösterdi ve "tanımda kaç parametre varsa çağırırken o kadar değer verilir" kuralını anlattı
- Eski hazırlık kodunu silince 17 kırmızı çizgi çıktı. Yapay zekâ Bul ve Değiştir'i önerdi, ben her yeri tek tek elle `oyun.UstSinir`, `oyun.HakSayisi` gibi değiştirmeyi seçtim
- TahminKontrolEt için dışarıdan tahmine ihtiyacı olduğunu kendim buldum. Geri vereceği şey olarak tutulan sayıyı önerdim → yapay zekâ oyuncunun sayıyı görmemesi gerektiğini, ana programın sadece "bildi mi?" bilgisine ihtiyacı olduğunu açıkladı. `bool` türünü bu sorudan sonra buldum. Başlığa `void` kopyalamıştım, düzelttim
- Metodun içine `oyun.DenemeSayisi++` yazdım → yapay zekâ sınıfın içinden kendi özelliğine `oyun.` olmadan ulaşıldığını açıkladı. `if (tahmin = TutulanSayi)` ve `Console.WriteLine` yazmıştım → yapay zekâ `==` ve cevap vermek gerektiğini söyledi, `return true` satırını ve metodun orada bittiğini anladım. `uzaklik` ve `yuzde` satırlarını ana programdan uyarladım, ama onları da özellik sandım → yapay zekâ bunların geçici hesap kutuları olduğunu açıkladı
- Büyük / küçük kontrolü için switch kullanılıp kullanılamayacağını sordum → yapay zekâ switch'in sabit değerler, karşılaştırmaların if için olduğunu açıkladı. `else`'e yine koşul yazdım (V2'deki hata) → yapay zekâ fark ettirdi. Sıcak / soğuk zincirini kopyalayarak taşıdım. Hak bitti ve kalan hak satırlarını da koymuştum → yapay zekâ `break`'in metodun içinde çalışmayacağını ve bunun ayrı bir metot (`HakBittiMi`) işi olduğunu açıkladı. `return false;` satırını kendim yazdım
- Ana programda `if (oyun.TahminKontrolEt(tahmin))` satırını yapay zekânın boşluk doldurma kalıbıyla yazdım, satırı soldan sağa kendim açıkladım. Eski "Bildiniz" bloğunun içini yeni `if`'in içine taşıdım ve eski kodu yapay zekânın listesine göre sildim
- HakBittiMi için ihtiyaç duyduğu bilgileri (`DenemeSayisi`, `HakSayisi`) söyledim → yapay zekâ bunların zaten oyunun özellikleri olduğunu, bu yüzden parantezin boş kalacağını açıkladı. Başlığı yazdım (sonunda `;` ile), içinde yanlış isim (`DenemeHakki`) ve `Console.WriteLine` kullandım → yapay zekâ ipucu verdi, `return true/false` ile düzelttim. Kapanış `}` eksikti. Ana programdaki `if (oyun.HakBittiMi())` satırını ve son kodun tamamını yapay zekâ verdi. Metodu anlamakta çok zorlandım, yapay zekâ satır satır ve otopark benzetmesiyle açıkladı
- Oyuncu sınıfı için "ad ve soyad" dedim → yapay zekâ tek `Ad` özelliği önerdi. İkinci özelliğin en iyi skor olduğunu, ana programdaki satırı gösterince buldum. Türleri (`string`, `int`) kendim buldum; İngilizce `Name` ve `score` yazmıştım, Türkçe isimleri yapay zekâ önerdi. `Oyuncu oyuncu = new Oyuncu();` satırını kendim yazdım
- Oyuncunun adını sorma: iki işi tek satırda birleştirmiştim → yapay zekâ ayırdı. `Console.Write` satırını ve `?? ""` kalıbını yapay zekâ verdi. `oyuncu.Ad` yerine önce `oyuncu.string` yazdım, ipucuyla buldum. Selamlama satırını (`$"Hoş geldiniz {oyuncu.Ad}!"`) denemelerim yanlıştı, doğrusunu yapay zekâ gösterdi. `?? ""` olmazsa ne olacağını sordum, yapay zekâ açıkladı
- En iyi skoru oyuncunun kartına taşımayı yapay zekâ önerdi. `oyuncu.EnIyiSkor = 1001;` satırını kendim yazdım, yerini yapay zekâ gösterdi. `enIyiSkor` geçen yerlerin listesini yapay zekâ çıkardı, hepsini ben `oyuncu.EnIyiSkor` ile değiştirdim ve eski kutuyu sildim. `int.TryParse(kayit, out oyuncu.EnIyiSkor);` satırını zaten doğru yazmıştım
- Testleri (kolay / orta / zor, geçersiz seçim, aralık dışı sayı, kaybetme, tekrar oynama, ad sorma, rekorun dosyada kalması) yapay zekâ önerdi, hepsini ben çalıştırdım
- OOP benim için hâlâ en zor konu, özellikle sınıfın içinden kendi özelliklerine ulaşmak ve hangi bilginin özellik, hangisinin geçici kutu olduğu. Tekrar ederek oturtmaya devam edeceğim
- `Oyuncu` sınıfı şimdilik sadece ad ve en iyi skoru tutuyor, skor tablosunda (sonraki adım) kullanılacak

## Sonraki adımlar

- [x] Bilgisayar sayı tutar, kullanıcı tahmin eder
- [x] "Daha büyük / daha küçük" ipucu
- [x] Deneme sayacı ve hak sınırı
- [x] 1-100 dışındaki tahminlere uyarı (aralık kontrolü)
- [x] Zorluk seçimi: Kolay (1-10), Orta (1-100), Zor (1-1000)
- [x] "Sıcak / soğuk" ipucu
- [x] Tekrar oyna ve en iyi skor
- [x] En iyi skoru dosyaya kaydetmek
- [x] OOP: Oyun ve Oyuncu sınıfları
- [ ] Kayıt dosyası bozuksa rekoru güvenli şekilde sıfırlamak
- [ ] Skor tablosu: en iyi 5 oyuncu (zorluğa göre ayrı)
- [ ] Ters mod: Ben sayı tutarım, bilgisayar tahmin eder (ikili arama)
