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
                //new Pesem{ID=2, Naslov="The Trooper", AlbumID=3, Dolzina=243, Ocena=5},
                //new Pesem{ID=3, Naslov="Run to the Hills", AlbumID=4, Dolzina=231, Ocena=4},
                //new Pesem{ID=4, Naslov="Du Hast", AlbumID=5, Dolzina=235, Ocena=5},
                //new Pesem{ID=5, Naslov="Sonne", AlbumID=6, Dolzina=269, Ocena=5},
                //new Pesem{ID=6, Naslov="Back in Black", AlbumID=7, Dolzina=255, Ocena=5},
                //new Pesem{ID=7, Naslov="Highway to Hell", AlbumID=8, Dolzina=207, Ocena=5},
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
                new Pesem{ID=21, Naslov="Hail to the King", AlbumID=20, Dolzina=336, Ocena=5},


                new Pesem{ID=22, Naslov="Sad But True", AlbumID=1, Dolzina=315, Ocena=5},
                new Pesem{ID=23, Naslov="Holier Than Thou", AlbumID=1, Dolzina=228, Ocena=4},
                new Pesem{ID=24, Naslov="The Unforgiven", AlbumID=1, Dolzina=386, Ocena=5},
                new Pesem{ID=25, Naslov="Wherever I May Roam", AlbumID=1, Dolzina=402, Ocena=5},
                new Pesem{ID=26, Naslov="Don't Tread on Me", AlbumID=1, Dolzina=238, Ocena=4},
                new Pesem{ID=27, Naslov="Through the Never", AlbumID=1, Dolzina=244, Ocena=4},
                new Pesem{ID=28, Naslov="Nothing Else Matters", AlbumID=1, Dolzina=388, Ocena=5},
                new Pesem{ID=29, Naslov="Of Wolf and Man", AlbumID=1, Dolzina=255, Ocena=4},
                new Pesem{ID=30, Naslov="The God That Failed", AlbumID=1, Dolzina=307, Ocena=4},
                new Pesem{ID=31, Naslov="My Friend of Misery", AlbumID=1, Dolzina=408, Ocena=4},
                new Pesem{ID=32, Naslov="The Struggle Within", AlbumID=1, Dolzina=228, Ocena=4},


                new Pesem{ID=33, Naslov="Battery", AlbumID=2, Dolzina=312, Ocena=5},
                new Pesem{ID=34, Naslov="The Thing That Should Not Be", AlbumID=2, Dolzina=396, Ocena=4},
                new Pesem{ID=35, Naslov="Welcome Home (Sanitarium)", AlbumID=2, Dolzina=370, Ocena=5},
                new Pesem{ID=36, Naslov="Disposable Heroes", AlbumID=2, Dolzina=497, Ocena=5},
                new Pesem{ID=37, Naslov="Leper Messiah", AlbumID=2, Dolzina=348, Ocena=4},
                new Pesem{ID=38, Naslov="Orion", AlbumID=2, Dolzina=512, Ocena=5},
                new Pesem{ID=39, Naslov="Damage, Inc.", AlbumID=2, Dolzina=309, Ocena=5},

                new Pesem{ID=40, Naslov="Where Eagles Dare", AlbumID=3, Dolzina=363, Ocena=5},
                new Pesem{ID=41, Naslov="Revelations", AlbumID=3, Dolzina=402, Ocena=5},
                new Pesem{ID=42, Naslov="Flight of Icarus", AlbumID=3, Dolzina=228, Ocena=5},
                new Pesem{ID=43, Naslov="Die With Your Boots On", AlbumID=3, Dolzina=307, Ocena=4},
                new Pesem{ID=44, Naslov="The Trooper", AlbumID=3, Dolzina=243, Ocena=5},
                new Pesem{ID=45, Naslov="Still Life", AlbumID=3, Dolzina=285, Ocena=4},
                new Pesem{ID=46, Naslov="Quest for Fire", AlbumID=3, Dolzina=222, Ocena=3},
                new Pesem{ID=47, Naslov="Sun and Steel", AlbumID=3, Dolzina=184, Ocena=4},
                new Pesem{ID=48, Naslov="To Tame a Land", AlbumID=3, Dolzina=438, Ocena=5},


                new Pesem{ID=49, Naslov="Invaders", AlbumID=4, Dolzina=217, Ocena=4},
                new Pesem{ID=50, Naslov="Children of the Damned", AlbumID=4, Dolzina=272, Ocena=5},
                new Pesem{ID=51, Naslov="The Prisoner", AlbumID=4, Dolzina=366, Ocena=5},
                new Pesem{ID=52, Naslov="22 Acacia Avenue", AlbumID=4, Dolzina=396, Ocena=4},
                new Pesem{ID=53, Naslov="The Number of the Beast", AlbumID=4, Dolzina=289, Ocena=5},
                new Pesem{ID=54, Naslov="Run to the Hills", AlbumID=4, Dolzina=231, Ocena=4},
                new Pesem{ID=55, Naslov="Gangland", AlbumID=4, Dolzina=210, Ocena=3},
                new Pesem{ID=56, Naslov="Hallowed Be Thy Name", AlbumID=4, Dolzina=433, Ocena=5},

                new Pesem{ID=59, Naslov="Sehnsucht", AlbumID=5, Dolzina=234, Ocena=5},
                new Pesem{ID=60, Naslov="Engel", AlbumID=5, Dolzina=271, Ocena=5},
                new Pesem{ID=61, Naslov="Tier", AlbumID=5, Dolzina=242, Ocena=4},
                new Pesem{ID=62, Naslov="Bestrafe Mich", AlbumID=5, Dolzina=221, Ocena=4},
                new Pesem{ID=63, Naslov="Du Hast", AlbumID=5, Dolzina=235, Ocena=5},
                new Pesem{ID=64, Naslov="Büch Dich", AlbumID=5, Dolzina=246, Ocena=5},
                new Pesem{ID=65, Naslov="Spiel Mit Mir", AlbumID=5, Dolzina=265, Ocena=4},
                new Pesem{ID=66, Naslov="Klavier", AlbumID=5, Dolzina=268, Ocena=5},
                new Pesem{ID=67, Naslov="Alter Mann", AlbumID=5, Dolzina=276, Ocena=4},
                new Pesem{ID=68, Naslov="Eifersucht", AlbumID=5, Dolzina=228, Ocena=4},
                new Pesem{ID=69, Naslov="Küss Mich (Fellfrosch)", AlbumID=5, Dolzina=220, Ocena=4},

                new Pesem{ID=70, Naslov="Mein Herz Brennt", AlbumID=6, Dolzina=279, Ocena=5},
                new Pesem{ID=71, Naslov="Links 2-3-4", AlbumID=6, Dolzina=229, Ocena=5},
                new Pesem{ID=72, Naslov="Sonne", AlbumID=6, Dolzina=269, Ocena=5},
                new Pesem{ID=73, Naslov="Ich Will", AlbumID=6, Dolzina=213, Ocena=5},
                new Pesem{ID=74, Naslov="Feuer Frei!", AlbumID=6, Dolzina=191, Ocena=5},
                new Pesem{ID=75, Naslov="Mutter", AlbumID=6, Dolzina=277, Ocena=5},
                new Pesem{ID=76, Naslov="Spieluhr", AlbumID=6, Dolzina=266, Ocena=4},
                new Pesem{ID=77, Naslov="Zwitter", AlbumID=6, Dolzina=253, Ocena=4},
                new Pesem{ID=78, Naslov="Rein Raus", AlbumID=6, Dolzina=193, Ocena=4},
                new Pesem{ID=79, Naslov="Adios", AlbumID=6, Dolzina=230, Ocena=4},
                new Pesem{ID=80, Naslov="Nebel", AlbumID=6, Dolzina=291, Ocena=5},

                new Pesem{ID=81, Naslov="Hells Bells", AlbumID=7, Dolzina=312, Ocena=5},
                new Pesem{ID=82, Naslov="Shoot to Thrill", AlbumID=7, Dolzina=311, Ocena=5},
                new Pesem{ID=83, Naslov="What Do You Do for Money Honey", AlbumID=7, Dolzina=211, Ocena=4},
                new Pesem{ID=84, Naslov="Givin the Dog a Bone", AlbumID=7, Dolzina=210, Ocena=4},
                new Pesem{ID=85, Naslov="Let Me Put My Love into You", AlbumID=7, Dolzina=239, Ocena=4},
                new Pesem{ID=86, Naslov="Back in Black", AlbumID=7, Dolzina=255, Ocena=5},
                new Pesem{ID=87, Naslov="You Shook Me All Night Long", AlbumID=7, Dolzina=210, Ocena=5},
                new Pesem{ID=88, Naslov="Have a Drink on Me", AlbumID=7, Dolzina=233, Ocena=4},
                new Pesem{ID=89, Naslov="Shake a Leg", AlbumID=7, Dolzina=238, Ocena=4},
                new Pesem{ID=90, Naslov="Rock and Roll Ain't Noise Pollution", AlbumID=7, Dolzina=252, Ocena=5},

                new Pesem{ID=91, Naslov="Highway to Hell", AlbumID=8, Dolzina=208, Ocena=5},
                new Pesem{ID=92, Naslov="Girls Got Rhythm", AlbumID=8, Dolzina=197, Ocena=4},
                new Pesem{ID=93, Naslov="Walk All Over You", AlbumID=8, Dolzina=302, Ocena=4},
                new Pesem{ID=94, Naslov="Touch Too Much", AlbumID=8, Dolzina=244, Ocena=5},
                new Pesem{ID=95, Naslov="Beating Around the Bush", AlbumID=8, Dolzina=234, Ocena=4},
                new Pesem{ID=96, Naslov="Shot Down in Flames", AlbumID=8, Dolzina=202, Ocena=4},
                new Pesem{ID=97, Naslov="Get It Hot", AlbumID=8, Dolzina=155, Ocena=3},
                new Pesem{ID=98, Naslov="If You Want Blood (You've Got It)", AlbumID=8, Dolzina=243, Ocena=5},
                new Pesem{ID=99, Naslov="Love Hungry Man", AlbumID=8, Dolzina=256, Ocena=4},
                new Pesem{ID=100, Naslov="Night Prowler", AlbumID=8, Dolzina=346, Ocena=5}
            };


            /*foreach (Pesem p in pesmi)
            {
                context.Pesmi.Add(p);
            }*/
            context.Pesmi.AddRange(pesmi);
            context.SaveChanges();

            var izvajalecPesmi = new IzvajalecPesem[]
            {
            new IzvajalecPesem{IzvajalecID=1,PesemID=0},
            new IzvajalecPesem{IzvajalecID=1,PesemID=1},
            /*new IzvajalecPesem{IzvajalecID=1,PesemID=2},
            new IzvajalecPesem{IzvajalecID=1,PesemID=3},
            new IzvajalecPesem{IzvajalecID=2,PesemID=4},
            new IzvajalecPesem{IzvajalecID=2,PesemID=5},
            new IzvajalecPesem{IzvajalecID=3,PesemID=6},
            new IzvajalecPesem{IzvajalecID=3,PesemID=7},*/
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
            new IzvajalecPesem{IzvajalecID=0,PesemID=22},
            new IzvajalecPesem{IzvajalecID=0,PesemID=23},
            new IzvajalecPesem{IzvajalecID=0,PesemID=24},
            new IzvajalecPesem{IzvajalecID=0,PesemID=25},
            new IzvajalecPesem{IzvajalecID=0,PesemID=26},
            new IzvajalecPesem{IzvajalecID=0,PesemID=27},
            new IzvajalecPesem{IzvajalecID=0,PesemID=28},
            new IzvajalecPesem{IzvajalecID=0,PesemID=29},
            new IzvajalecPesem{IzvajalecID=0,PesemID=30},
            new IzvajalecPesem{IzvajalecID=0,PesemID=31},
            new IzvajalecPesem{IzvajalecID=0,PesemID=32},
            new IzvajalecPesem{IzvajalecID=0,PesemID=33},
            new IzvajalecPesem{IzvajalecID=0,PesemID=34},
            new IzvajalecPesem{IzvajalecID=0,PesemID=35},
            new IzvajalecPesem{IzvajalecID=0,PesemID=36},
            new IzvajalecPesem{IzvajalecID=0,PesemID=37},
            new IzvajalecPesem{IzvajalecID=0,PesemID=38},
            new IzvajalecPesem{IzvajalecID=0,PesemID=39},
            new IzvajalecPesem{IzvajalecID=1,PesemID=40},
            new IzvajalecPesem{IzvajalecID=1,PesemID=41},
            new IzvajalecPesem{IzvajalecID=1,PesemID=42},
            new IzvajalecPesem{IzvajalecID=1,PesemID=43},
            new IzvajalecPesem{IzvajalecID=1,PesemID=44},
            new IzvajalecPesem{IzvajalecID=1,PesemID=45},
            new IzvajalecPesem{IzvajalecID=1,PesemID=46},
            new IzvajalecPesem{IzvajalecID=1,PesemID=47},
            new IzvajalecPesem{IzvajalecID=1,PesemID=48},
            new IzvajalecPesem{IzvajalecID=1,PesemID=49},
            new IzvajalecPesem{IzvajalecID=1,PesemID=50},
            new IzvajalecPesem{IzvajalecID=1,PesemID=51},
            new IzvajalecPesem{IzvajalecID=1,PesemID=52},
            new IzvajalecPesem{IzvajalecID=1,PesemID=53},
            new IzvajalecPesem{IzvajalecID=1,PesemID=54},
            new IzvajalecPesem{IzvajalecID=1,PesemID=55},
            new IzvajalecPesem{IzvajalecID=1,PesemID=56},
            new IzvajalecPesem{IzvajalecID=2,PesemID=57},
            new IzvajalecPesem{IzvajalecID=2,PesemID=58},
            new IzvajalecPesem{IzvajalecID=2,PesemID=59},
            new IzvajalecPesem{IzvajalecID=2,PesemID=60},
            new IzvajalecPesem{IzvajalecID=2,PesemID=61},
            new IzvajalecPesem{IzvajalecID=2,PesemID=62},
            new IzvajalecPesem{IzvajalecID=2,PesemID=63},
            new IzvajalecPesem{IzvajalecID=2,PesemID=64},
            new IzvajalecPesem{IzvajalecID=2,PesemID=65},
            new IzvajalecPesem{IzvajalecID=2,PesemID=66},
            new IzvajalecPesem{IzvajalecID=2,PesemID=67},
            new IzvajalecPesem{IzvajalecID=2,PesemID=68},
            new IzvajalecPesem{IzvajalecID=2,PesemID=69},
            new IzvajalecPesem{IzvajalecID=2,PesemID=70},
            new IzvajalecPesem{IzvajalecID=2,PesemID=71},
            new IzvajalecPesem{IzvajalecID=2,PesemID=72},
            new IzvajalecPesem{IzvajalecID=2,PesemID=73},
            new IzvajalecPesem{IzvajalecID=2,PesemID=74},
            new IzvajalecPesem{IzvajalecID=2,PesemID=75},
            new IzvajalecPesem{IzvajalecID=2,PesemID=76},
            new IzvajalecPesem{IzvajalecID=2,PesemID=77},
            new IzvajalecPesem{IzvajalecID=2,PesemID=78},
            new IzvajalecPesem{IzvajalecID=2,PesemID=79},
            new IzvajalecPesem{IzvajalecID=2,PesemID=80},
            new IzvajalecPesem{IzvajalecID=3,PesemID=81},
            new IzvajalecPesem{IzvajalecID=3,PesemID=82},
            new IzvajalecPesem{IzvajalecID=3,PesemID=83},
            new IzvajalecPesem{IzvajalecID=3,PesemID=84},
            new IzvajalecPesem{IzvajalecID=3,PesemID=85},
            new IzvajalecPesem{IzvajalecID=3,PesemID=86},
            new IzvajalecPesem{IzvajalecID=3,PesemID=87},
            new IzvajalecPesem{IzvajalecID=3,PesemID=88},
            new IzvajalecPesem{IzvajalecID=3,PesemID=89},
            new IzvajalecPesem{IzvajalecID=3,PesemID=90},
            new IzvajalecPesem{IzvajalecID=3,PesemID=91},
            new IzvajalecPesem{IzvajalecID=3,PesemID=92},
            new IzvajalecPesem{IzvajalecID=3,PesemID=93},
            new IzvajalecPesem{IzvajalecID=3,PesemID=94},
            new IzvajalecPesem{IzvajalecID=3,PesemID=95},
            new IzvajalecPesem{IzvajalecID=3,PesemID=96},
            new IzvajalecPesem{IzvajalecID=3,PesemID=97},
            new IzvajalecPesem{IzvajalecID=3,PesemID=98},
            new IzvajalecPesem{IzvajalecID=3,PesemID=99},
            new IzvajalecPesem{IzvajalecID=3,PesemID=100}
            };
           
            context.IzvajalecPesems.AddRange(izvajalecPesmi);
            context.SaveChanges();
        }
    }
}