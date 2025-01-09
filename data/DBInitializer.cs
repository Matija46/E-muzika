using web.Models;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace web.Data
{
    public static class DBInitializer
    {
        public static void Initialize(EmuzikaContext context)
        {
            context.Database.EnsureCreated();

            var izvajalci = new Izvajalec[]
            {
                new Izvajalec{ID=0,Ime="Metallica", Opis="Ena najbolj vplivnih thrash metal skupin vseh časov, znana po albumih kot so Master of Puppets in The Black Album.", poslusalci=120000000},
                new Izvajalec{ID=1,Ime="Iron Maiden", Opis="Legendarna britanska heavy metal skupina, prepoznavna po ikoničnem maskotu Eddu in albumih, kot sta The Number of the Beast in Powerslave.", poslusalci=80000000},
                new Izvajalec{ID=2,Ime="Rammstein", Opis="Nemška industrial metal skupina, znana po eksplozivnih nastopih in pesmih, kot so Du Hast in Sonne.", poslusalci=50000000},
                new Izvajalec{ID=3,Ime="AC/DC", Opis="Avstralska hard rock skupina, ki je svetovno znana po hitih, kot sta Highway to Hell in Back in Black.", poslusalci=100000000},
                new Izvajalec{ID=4,Ime="Black Sabbath", Opis="Pionirji heavy metala iz 70-ih, s pesmimi, kot so Paranoid in War Pigs.", poslusalci=60000000},
                new Izvajalec{ID=5,Ime="Slipknot", Opis="Ameriška nu-metal skupina, prepoznavna po svojih maskah in energičnih nastopih; njihova glasba je temačna in agresivna.", poslusalci=55000000},
                new Izvajalec{ID=6,Ime="Deep Purple", Opis="Britanska rock skupina, znana po pesmih, kot so Smoke on the Water in Highway Star.", poslusalci=45000000},
                new Izvajalec{ID=7,Ime="Foo Fighters", Opis="Ameriška rock skupina, ki jo je ustanovil Dave Grohl po razpadu Nirvane.", poslusalci=65000000},
                new Izvajalec{ID=8,Ime="Led Zeppelin", Opis="Ikonična rock skupina, ki je definirala hard rock in pesmi, kot so Stairway to Heaven in Kashmir.", poslusalci=80000000},
                new Izvajalec{ID=9,Ime="Pantera", Opis="Ameriška groove metal skupina, znana po albumih Cowboys from Hell in Vulgar Display of Power.", poslusalci=35000000},
                new Izvajalec{ID=10,Ime="Avenged Sevenfold", Opis="Ameriška metal skupina, znana po pesmih, kot so Nightmare in Hail to the King.", poslusalci=45000000}            
            };
            /*foreach (Izvajalec i in izvajalci)
            {
                context.Izvajalci.Add(i);
            }*/
            context.Izvajalci.AddRange(izvajalci);
            context.SaveChanges();

            var albumi = new Album[]
            {
                new Album{ID=1, Ime="Metallica", Opis="The Black Album, največji komercialni uspeh Metallice.", DatumIzdaje=new DateTime(1991, 8, 12), IzvajalecID=0},
                new Album{ID=2, Ime="Master of Puppets", Opis="Ikoničen album Metallice, ki je definiral thrash metal.", DatumIzdaje=new DateTime(1986, 3, 3), IzvajalecID=0},
                new Album{ID=3, Ime="Piece of Mind", Opis="Četrti studijski album skupine Iron Maiden.", DatumIzdaje=new DateTime(1983, 5, 16), IzvajalecID=1},
                new Album{ID=4, Ime="The Number of the Beast", Opis="Legendarni album Iron Maiden z naslovnim hitom.", DatumIzdaje=new DateTime(1982, 3, 22), IzvajalecID=1},
                new Album{ID=5, Ime="Sehnsucht", Opis="Drugi studijski album Rammstein z uspešnico Du Hast.", DatumIzdaje=new DateTime(1997, 8, 25), IzvajalecID=2},
                new Album{ID=6, Ime="Mutter", Opis="Tretji album Rammstein, ki vsebuje uspešnico Sonne.", DatumIzdaje=new DateTime(2001, 4, 2), IzvajalecID=2},
                new Album{ID=7, Ime="Back in Black", Opis="Najbolj prodajan album skupine AC/DC.", DatumIzdaje=new DateTime(1980, 7, 25), IzvajalecID=3},
                new Album{ID=8, Ime="Highway to Hell", Opis="Zadnji album z Bon Scottom.", DatumIzdaje=new DateTime(1979, 7, 27), IzvajalecID=3},
                new Album{ID=9, Ime="Paranoid", Opis="Klasičen album skupine Black Sabbath.", DatumIzdaje=new DateTime(1970, 9, 18), IzvajalecID=4},
                new Album{ID=10, Ime="Vol. 3: (The Subliminal Verses)", Opis="Tretji album skupine Slipknot.", DatumIzdaje=new DateTime(2004, 5, 25), IzvajalecID=5},
                new Album{ID=11, Ime="All Hope Is Gone", Opis="Četrti album Slipknot z uspešnico Psychosocial.", DatumIzdaje=new DateTime(2008, 8, 20), IzvajalecID=5},
                new Album{ID=12, Ime="Machine Head", Opis="Klasičen album Deep Purple z uspešnico Smoke on the Water.", DatumIzdaje=new DateTime(1972, 3, 25), IzvajalecID=6},
                new Album{ID=13, Ime="The Colour and the Shape", Opis="Uspešen album Foo Fighters z uspešnico Everlong.", DatumIzdaje=new DateTime(1997, 5, 20), IzvajalecID=7},
                new Album{ID=14, Ime="There Is Nothing Left to Lose", Opis="Tretji album Foo Fighters.", DatumIzdaje=new DateTime(1999, 11, 2), IzvajalecID=7},
                new Album{ID=15, Ime="Led Zeppelin IV", Opis="Najbolj znan album Led Zeppelin z Stairway to Heaven.", DatumIzdaje=new DateTime(1971, 11, 8), IzvajalecID=8},
                new Album{ID=16, Ime="Physical Graffiti", Opis="Dvojni album Led Zeppelin z uspešnico Kashmir.", DatumIzdaje=new DateTime(1975, 2, 24), IzvajalecID=8},
                new Album{ID=17, Ime="Cowboys from Hell", Opis="Prvi večji uspeh Pantere.", DatumIzdaje=new DateTime(1990, 7, 24), IzvajalecID=9},
                new Album{ID=18, Ime="Vulgar Display of Power", Opis="Najbolj priljubljen album Pantere.", DatumIzdaje=new DateTime(1992, 2, 25), IzvajalecID=9},
                new Album{ID=19, Ime="Nightmare", Opis="Uspešen album Avenged Sevenfold.", DatumIzdaje=new DateTime(2010, 7, 27), IzvajalecID=10},
                new Album{ID=20, Ime="Hail to the King", Opis="Šesti album Avenged Sevenfold.", DatumIzdaje=new DateTime(2013, 8, 23), IzvajalecID=10}
            };

            /*foreach (Album a in albumi)
            {
                context.Albumi.Add(a);
            }*/
            context.Albumi.AddRange(albumi);
            context.SaveChanges();




            /*if (context.Izvajalci.Any())
            {
                return;
            }*/
            
            var pesmi = new Pesem[]
            {
                new Pesem{ID=0, Naslov="Enter Sandman", AlbumID=1, Dolzina=331, Ocena=5},
                new Pesem{ID=1, Naslov="Master of Puppets", AlbumID=2, Dolzina=515, Ocena=5},
                new Pesem{ID=2, Naslov="The Trooper", AlbumID=3, Dolzina=243, Ocena=5},
                new Pesem{ID=3, Naslov="Run to the Hills", AlbumID=4, Dolzina=231, Ocena=4},
                new Pesem{ID=4, Naslov="Du Hast", AlbumID=5, Dolzina=235, Ocena=5},
                new Pesem{ID=5, Naslov="Sonne", AlbumID=6, Dolzina=269, Ocena=5},
                new Pesem{ID=6, Naslov="Back in Black", AlbumID=7, Dolzina=255, Ocena=5},
                new Pesem{ID=7, Naslov="Highway to Hell", AlbumID=8, Dolzina=207, Ocena=5},
                new Pesem{ID=8, Naslov="Paranoid", AlbumID=9, Dolzina=172, Ocena=5},
                new Pesem{ID=9, Naslov="War Pigs", AlbumID=9, Dolzina=476, Ocena=5},
                new Pesem{ID=10, Naslov="Duality", AlbumID=10, Dolzina=255, Ocena=5},
                new Pesem{ID=11, Naslov="Psychosocial", AlbumID=11, Dolzina=283, Ocena=5},
                new Pesem{ID=12, Naslov="Smoke on the Water", AlbumID=12, Dolzina=340, Ocena=5},
                new Pesem{ID=13, Naslov="Highway Star", AlbumID=12, Dolzina=374, Ocena=4},
                new Pesem{ID=14, Naslov="Everlong", AlbumID=13, Dolzina=250, Ocena=5},
                new Pesem{ID=15, Naslov="Learn to Fly", AlbumID=14, Dolzina=238, Ocena=4},
                new Pesem{ID=16, Naslov="Stairway to Heaven", AlbumID=15, Dolzina=482, Ocena=5},
                new Pesem{ID=17, Naslov="Kashmir", AlbumID=16, Dolzina=515, Ocena=5},
                new Pesem{ID=18, Naslov="Cemetery Gates", AlbumID=17, Dolzina=431, Ocena=5},
                new Pesem{ID=19, Naslov="Walk", AlbumID=18, Dolzina=305, Ocena=5},
                new Pesem{ID=20, Naslov="Nightmare", AlbumID=19, Dolzina=371, Ocena=5},
                new Pesem{ID=21, Naslov="Hail to the King", AlbumID=20, Dolzina=336, Ocena=5}
            };


            /*foreach (Pesem p in pesmi)
            {
                context.Pesmi.Add(p);
            }*/
            context.Pesmi.AddRange(pesmi);
            context.SaveChanges();

            var izvajalecPesmi = new IzvajalecPesem[]
            {
            new IzvajalecPesem{IzvajalecID=0,PesemID=0},
            new IzvajalecPesem{IzvajalecID=0,PesemID=1},
            new IzvajalecPesem{IzvajalecID=1,PesemID=2},
            new IzvajalecPesem{IzvajalecID=1,PesemID=3},
            new IzvajalecPesem{IzvajalecID=2,PesemID=4},
            new IzvajalecPesem{IzvajalecID=2,PesemID=5},
            new IzvajalecPesem{IzvajalecID=3,PesemID=6},
            new IzvajalecPesem{IzvajalecID=3,PesemID=7},
            new IzvajalecPesem{IzvajalecID=4,PesemID=8},
            new IzvajalecPesem{IzvajalecID=4,PesemID=9},
            new IzvajalecPesem{IzvajalecID=5,PesemID=10},
            new IzvajalecPesem{IzvajalecID=5,PesemID=11},
            new IzvajalecPesem{IzvajalecID=6,PesemID=12},
            new IzvajalecPesem{IzvajalecID=6,PesemID=13},
            new IzvajalecPesem{IzvajalecID=7,PesemID=14},
            new IzvajalecPesem{IzvajalecID=7,PesemID=15},
            new IzvajalecPesem{IzvajalecID=8,PesemID=16},
            new IzvajalecPesem{IzvajalecID=8,PesemID=17},
            new IzvajalecPesem{IzvajalecID=9,PesemID=18},
            new IzvajalecPesem{IzvajalecID=9,PesemID=19},
            new IzvajalecPesem{IzvajalecID=10,PesemID=20},
            new IzvajalecPesem{IzvajalecID=10,PesemID=21},

            
            };
            /*foreach (IzvajalecPesem ip in izvajalecPesmi)
            {
                context.IzvajalecPesems.Add(ip);
            }*/
            context.IzvajalecPesems.AddRange(izvajalecPesmi);
            context.SaveChanges();
        }
    }
}