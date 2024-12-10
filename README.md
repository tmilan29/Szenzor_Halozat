# Haladó szoftverfejlesztés - féléves beadandó
**Szenzorhálózat szimulációja, adatfeldolgozás C#-al**

Molnár Gergő - PELVTZ

Takács Milán - EVZ0PN

Az alkalmazás három fő projectből épül fel.

Traffic Class Libary: tartalmazza a Traffic alaposztályt és a hozzá tartozó LINQ lekérdezéseket.
Az osztály tulajdonságai: id, address, day, novehicles, avgspeed és roadblock. Ezek célja megegyezik a felhasználói kézikönyvben leírtakkal.
Az osztályhoz egy esemény tartozik, mely a cím tulajdonsághoz tartozik. Annak értékének megváltozása esetén figyelmezteti a felhasználót a változásról. Az eseménykezelő egyed neve: EventHandler.
1.	Saját vagy felülírt metódusok: ToString(): text szöveges változót adja vissza, melynek tartalma:          
text = $"{id};{address};{day};{novehicles};{avgspeed};{roadblock}";
2.	Sorbarendezés: egy traffic objektumokból álló listát vár paraméterként, egy névtelen osztály listáját adja vissza, mely tartalmazza a szenzor címét, az autók számát és a napot. Az autók száma szerint csökkenő sorrendben adja vissza a listát.
3.	NagyobbVolt: Névtelen osztály egyediből álló listában visszaadja, hogy péntekenként hol volt nagyobb az átlag sebesség, mint 50.
4.	UtzarVolt: Ahol útzár volt, ott visszatér az érintett autók számával. Ha nem volt útzár arról is értesíti a felhasználót.

Adateloallitas Console App: a valósághoz hűen megpróbálja előállítani a mért adatokat. Az adatok elsőnek egy traffic objektumokból álló listába kerül eltárolásra, majd szerializálódik egy JSON állományba.
Szükséges névterek és package(k): Traffic DLL és Newtonsoft.Json

Adatfeldolgozas Console App: az Adateloallitas projectben készült JSON állományt desziralizálja, majd egy traffic egyedekből álló listába tárolja az adatokat.
Feltételezzük, hogy az 1-es ID-jú szenzornál a cím hibásan generálódott, ezért azt cseréljük és feliratkozunk az eseményre.
Az egyes LINQ lekérdezéseket meghívja.
Az apphoz szükséges névterek, package(k): Traffic DLL, Newtonsoft.Json és Microsoft.Data.Sqlite.
