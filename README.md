# StudentGradeManagementSystem.CRUD

Study Grade Management System loyihasida siz C# dasturlash tilidagi Massiv (Array) hamda Klassni tashkil etuvchi a'zolardan foydalangan holda CRUD operatsiyasini ko'rishingiz mumkin.


## 0.0 Loyihaning dastlabki ko'rinishi

Loyiha O'quv baholarini boshqarish ma'lumotlarini massivga yozadi, o'chiradi, o'qiydi,topadi,hisoblaydi,qidiradi va yangilaydi.


```
 PrintMenuItem("1", "Talaba qo'shish");
 PrintMenuItem("2", "Talabalarni ko'rish");
 PrintMenuItem("3", "Baho qo'shish");
 PrintMenuItem("4", "O'rtacha bahoni hisoblash");
 PrintMenuItem("5", "Eng yaxshi talabani topish");
 PrintMenuItem("6", "Failed studentlar");
 PrintMenuItem("7", "Talaba qidirish");
 ```

## 0.1 Dasturda 7 xil holat mavjud.

1. Talaba qo'shish
2. Talabalarni ko'rish
3. Baho qo'shish
4. O'rtacha bahoni hisoblash
5. Eng yaxshi talabani topish
6. Failed studentlar
7. Talaba qidirish


## 1.0 Yangi o'quv bahosini yaratish

Yangi o'quv bahosi yaratilayotganda, agar baho ma'lumotlari ma'lumotlar bazasida (massivda) mavjud bo'lmasa, u yaratiladi, aks holda bu ma'lumot mavjudligi haqida ogohlantiradi.

### 1.1 Agar bu ma'lumot ma'lumotlar bazasida mavjud bo'lsa

Ushbu ma'lumot mavjudligi haqida ogohlantiradi va "false" qiymat qaytaradi.

### Run Code
![Dasturni ishga tushirish](/student%20grade%20system%20333/guruh/gifs/one-run-code.gif)

### 1.2 Agar ism va baho ma'lumotlari ma'lumotlar bazasida mavjud bo'lmasa

Ushbu jarayonda, kiruvchi ma'lumotlar asosiy ma'lumotlar bazasida (massivda) mavjud bo'lmasa, yangi ma'lumot sifatida yuqoridagi bo'sh joyga yoziladi va "true" qiymat qaytaradi.

### Run Code
![Dasturni ishga tushirish](/student%20grade%20system%20333/guruh/rasmlar/RASM%202.jpg)

## 2.0 Talabalarni ko'rish

Ushbu bo'limda ma'lumotlar bazasidagi (massivdagi) barcha ro'yxatdan o'tgan talabalar va ularning ma'lumotlari ekranga chiqariladi.

### 2.1 Agar ma'lumotlar bazasida talabalar mavjud bo'lsa

Tizim massivni aylanib chiqadi va undagi barcha talabalarning ismi hamda baholarini ro'yxat shaklida ko'rsatadi va "true" qiymat qaytaradi.

### Run Code
![Dasturni ishga tushirish](/student%20grade%20system%20333/guruh/rasmlar/RASM%203.jpg)

## 3.0 Baho qo'shish

Ushbu bo'limda tizimga kiritilgan talabaga yangi o'quv bahosi biriktiriladi (qo'shiladi).

### 3.1 Agar talaba ma'lumotlar bazasida mavjud bo'lsa

Agar kiritilgan talaba massivda mavjud bo'lsa, uning ma'lumotlariga yangi baho muvaffaqiyatli qo'shiladi va tizim "true" qiymat qaytaradi.

### Run Code
![Bahoni muvaffaqiyatli qo'shish](/student%20grade%20system%20333/guruh/rasmlar/RASM%204.jpg)

### 3.2 Agar talaba ma'lumotlar bazasida mavjud bo'lmasa

Kiritilgan talaba ismi massivdan topilmasa, tizim bunday talaba mavjud emasligi haqida ogohlantiradi va "false" qiymat qaytaradi.

### Run Code
![Talaba topilmagan holat](/student%20grade%20system%20333/guruh/rasmlar/RASM%205.jpg)

## 4.0 O'rtacha bahoni hisoblash

Ushbu bo'limda tizimdagi barcha talabalarning o'lashtirish baholari jamlanib, ularning umumiy o'rtacha qiymati (Average Score) hisoblanadi.

### 4.1 Agar tizimda baholar mavjud bo'lsa

Tizim barcha kiritilgan baholarni hisoblab chiqadi, o'rtacha natijani ekranga ko'rsatadi va muvaffaqiyatli yakunlanib "true" qiymat qaytaradi.


### 4.2 Agar tizimda hali birorta ham baho kiritilmagan bo'lsa

Agar massiv bo'sh bo'lsa yoki baholar hali mavjud bo'lmasa, tizim nolga bo'lish xatoligini oldini olish uchun ogohlantirish xabarini chiqaradi va "false" qiymat qaytaradi.

### Run Code
![Baholar mavjud bo'lmagan holat](/student%20grade%20system%20333/guruh/rasmlar/RASM%206.jpg)


## 5.0 Eng yaxshi talabani topish

Ushbu bo'limda tizim ma'lumotlar bazasidagi (massivdagi) barcha talabalarning baholarini o'zaro solishtiradi va eng yuqori natija ko'rsatgan (Top Student) talabani aniqlaydi.

### 5.1 Agar tizimda talabalar va baholar mavjud bo'lsa

Tizim eng yuqori bahoga ega bo'lgan talabaning ismi va bahosini ekranga chiqaradi hamda "true" qiymat qaytaradi.

### Run Code
![Eng yaxshi talabani topish](/student%20grade%20system%20333/guruh/rasmlar/RASM%207.jpg)

### 5.2 Agar tizimda talabalar ro'yxati bo'sh bo'lsa

Agar massivda hali birorta ham talaba yoki baho mavjud bo'lmasa, tizim eng yaxshi talabani aniqlay olmaydi, bu haqida ogohlantirish xabarini beradi va "false" qiymat qaytaradi.

### Run Code
![Tizim bo'sh bo'lgan holat](/student%20grade%20system%20333/guruh/rasmlar/RASM%2013.jpg)

## 6.0 Failed studentlar

Ushbu bo'limda tizim ma'lumotlar bazasidagi (massivdagi) barcha talabalarning baholarini tekshiradi va belgilangan o'tish balidan past natija ko'rsatgan (yiqilgan) talabalar ro'yxatini aniqlaydi.

### 6.1 Agar tizimda qoniqarsiz baho olgan talabalar mavjud bo'lsa

Tizim o'tish balini bera olmagan barcha talabalarning ismi va baholarini ekranga ro'yxat shaklida chiqaradi hamda "true" qiymat qaytaradi.

### Run Code
![Yiqilgan talabalar ro'yxati](/student%20grade%20system%20333/guruh/rasmlar/RASM%208.jpg)

### 6.2 Agar tizimda yiqilgan talabalar mavjud bo'lmasa (Hamma o'tgan bo'lsa)

Agar barcha talabalar o'tish balidan yuqori natija ko'rsatgan bo'lsa, tizim qoniqarsiz baho olgan talabalar topilmaganligi haqida xabar beradi va "false" qiymat qaytaradi.

### Run Code
![Yiqilganlar topilmagan holat](/student%20grade%20system%20333/guruh/rasmlar/RASM%2012.jpg)
## 7.0 Talaba qidirish

Ushbu bo'limda foydalanuvchi tomonidan kiritilgan talaba ismi bo'yicha ma'lumotlar bazasidan (massivdan) qidiruv amalga oshiriladi.

### 7.1 Agar qidirilgan talaba ma'lumotlar bazasida mavjud bo'lsa

Tizim talabani muvaffaqiyatli topadi, uning ismi va baholarini ekranga chiqaradi hamda "true" qiymat qaytaradi.

### Run Code
![Talaba topilgan holat](/student%20grade%20system%20333/guruh/rasmlar/RASM%2010.jpg)

### 7.2 Agar qidirilgan talaba ma'lumotlar bazasida mavjud bo'lmasa

Kiritilgan ism massivdan topilmasa, tizim bunday talaba ro'yxatda yo'qligi haqida ogohlantirish xabarini beradi va "false" qiymat qaytaradi.

### Run Code
![Talaba topilmagan holat](/student%20grade%20system%20333/guruh/rasmlar/RASM%2011.jpg)

## Muallif va Texnologiya 💻

<<<<<<< HEAD
* **Yaratuvchi:** Ubaydullayev
=======
* **Yaratuvchi:** Ubaydullayev Saidamirxon
>>>>>>> 8eecebaf70af2b6407ccde66a98c2de4fd070ae1
* **Dasturlash tili:** C# (.NET Core)











