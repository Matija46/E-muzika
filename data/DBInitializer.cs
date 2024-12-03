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

            if (context.Izvajalci.Any())
            {
                return;
            }



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
            foreach (Izvajalec i in izvajalci)
            {
                context.Izvajalci.Add(i);
            }
            context.SaveChanges();
            var pesmi = new Pesem[]
            {
            new Pesem{ID=0,Naslov="Enter Sandman", Album="Metallica", Dolzina=331, Ocena=5},
            new Pesem{ID=1,Naslov="Master of Puppets", Album="Master of Puppets", Dolzina=515, Ocena=5},
            new Pesem{ID=2,Naslov="The Trooper", Album="Piece of Mind", Dolzina=243, Ocena=5},
            new Pesem{ID=3,Naslov="Run to the Hills", Album="The Number of the Beast", Dolzina=231, Ocena=4},
            new Pesem{ID=4,Naslov="Du Hast", Album="Sehnsucht", Dolzina=235, Ocena=5},
            new Pesem{ID=5,Naslov="Sonne", Album="Mutter", Dolzina=269, Ocena=5},
            new Pesem{ID=6,Naslov="Back in Black", Album="Back in Black", Dolzina=255, Ocena=5},
            new Pesem{ID=7,Naslov="Highway to Hell", Album="Highway to Hell", Dolzina=207, Ocena=5},
            new Pesem{ID=8,Naslov="Paranoid", Album="Paranoid", Dolzina=172, Ocena=5},
            new Pesem{ID=9,Naslov="War Pigs", Album="Paranoid", Dolzina=476, Ocena=5},
            new Pesem{ID=10,Naslov="Duality", Album="Vol. 3: (The Subliminal Verses)", Dolzina=255, Ocena=5},
            new Pesem{ID=11,Naslov="Psychosocial", Album="All Hope Is Gone", Dolzina=283, Ocena=5},
            new Pesem{ID=12,Naslov="Smoke on the Water", Album="Machine Head", Dolzina=340, Ocena=5},
            new Pesem{ID=13,Naslov="Highway Star", Album="Machine Head", Dolzina=374, Ocena=4},
            new Pesem{ID=14,Naslov="Everlong", Album="The Colour and the Shape", Dolzina=250, Ocena=5},
            new Pesem{ID=15,Naslov="Learn to Fly", Album="There Is Nothing Left to Lose", Dolzina=238, Ocena=4},
            new Pesem{ID=16,Naslov="Stairway to Heaven", Album="Led Zeppelin IV", Dolzina=482, Ocena=5},
            new Pesem{ID=17,Naslov="Kashmir", Album="Physical Graffiti", Dolzina=515, Ocena=5},
            new Pesem{ID=18,Naslov="Cemetery Gates", Album="Cowboys from Hell", Dolzina=431, Ocena=5},
            new Pesem{ID=19,Naslov="Walk", Album="Vulgar Display of Power", Dolzina=305, Ocena=5},
            new Pesem{ID=20,Naslov="Nightmare", Album="Nightmare", Dolzina=371, Ocena=5},
            new Pesem{ID=21,Naslov="Hail to the King", Album="Hail to the King", Dolzina=336, Ocena=5},

            
            };
            foreach (Pesem p in pesmi)
            {
                context.Pesmi.Add(p);
            }
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
            foreach (IzvajalecPesem ip in izvajalecPesmi)
            {
                context.IzvajalecPesems.Add(ip);
            }
            context.SaveChanges();
        }
    }
}