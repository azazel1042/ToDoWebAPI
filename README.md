### ToDoWebAPI

 **_C#_ kullanılarak yazılmış _asp.net core_ tabanlı uygulamada veritabanı işlemleri için _mysql_ veritabanı kullanılmıştır.
 Projede requestlerin loglarının kayıt altına alınabilmesi için _nlog_ ve _nlog.web.aspnetcore_ kütüphanelerinden yararlanılmıştır.**

Veritabanımızda int veri tipinde primary key ve auto_increment özelliklerde DepartmentId ve varchar(500) türünde DepartmentName isimli 2 adet sütun bulunmaktadır.

| DepartmentId | DepartmentName |
|-------------|-----------------|
|1|IT|
|2|SUPPORT|

# Api'da bulunan özellikler

- [HttpGet]---------------->Get isteği ile tüm verilerin getirilmesi.
- [HttpGet("{id}")]--------->İd ile get isteği uygulanması.
- [HttpPost]--------------->Ekleme metodu.
- [HttpPut]---------------->Güncelleme metodu
- [HttpDelete("{id}")]----->İd ile delete metodu

# Projenin postman ile kullanımı;

[Postman indirmek için tıklayınız.](https://www.postman.com/downloads/)

- # HTTPGET
  * Proje run edildikten sonra get metodu kayıtların tamamını getirmek için devreye girmektedir.
  Tarayıcımızda bulunan URL (http://localhost:29605/api/department) kopyalanır ve postman da adres çubuğuna kopyalanır.Send butonu aracılığıyla isteğimiz gönderilir.
  ![Görseli](https://i.hizliresim.com/ioh5z8p.png)
  
- # [HttpGet("{id}")]
  * Veritabanında kayıtlı olduğu İd ile bir veriyi getirmek istediğimizde http://localhost:29605/api/department url adresinin sonuna /id yazılır ve send ile istek gönderilir.
  Aşağıdaki görselde 1 numaralı id getirilmiştir.
 ![Görseli](https://i.hizliresim.com/qu1mj6f.png)
- # [HttpPost]
  * Post isteği veritabanına kayıt yapmak istediğimizde http://localhost:29605/api/department urlimiz adres çubuğunda iken json formatında DepartmentName alanına
  gerekli bilgi doldurulur ve send ile istek gönderilir.
  !!!İd alanı auto_increment özellikte olduğu için herhangi bir bilgi girişi yapılmamalıdır.!!!
  ![Görseli](https://i.hizliresim.com/onppw7d.png)
- # [HttpPut]
  * Put isteği ile güncelleme yapabilmek için http://localhost:29605/api/department adres çubuğunda iken json formatında DepartmentName alanındaki bilgi 
  güncellenir ve send ile istek gönderilir.
    ![Görseli](https://i.hizliresim.com/2q31cz5.png)
- # [HttpDelete("{id}")]
  * Delete işlemiyle kayıt silinmek istendiğinde [HttpGet("{id}")] işlemindeki gibi urlin sonuna silinmek istenen idnin numarası eklenir.Aşağıdaki görselde gösterilmiştir.
    ![Görseli](https://i.hizliresim.com/9i2hp74.png)

