using eCourse.Database.Context;
using eCourse.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace eCourse.WebAPI.Helpers
{
    public class SetupService
    {
        public static void MigrateDatabase(CourseContext context)
        {
            context.Database.Migrate();
        }
        public static void SeedDatabase(CourseContext context)
        {
            //Seeding roles
            if (context.Role.Count() == 0)
            {
                var list = new List<Role>
                {
                    new Role { Naziv = "AdministrativnoOsoblje"},
                    new Role { Naziv = "Predavač"},
                    new Role { Naziv = "Klijent"}
                };
                foreach (var item in list)
                {
                    context.Role.Add(item);
                }
                context.SaveChanges();
            }
            //Seeding opcina
            if (context.Opcina.Count() == 0)
            {
                var nazivList = new List<string>
                {
                    "Banovići","Banja Luka","Berkovići","Bihać","Bijeljina","Bileća", "Bosanska Krupa","Bosanski Petrovac","Bosansko Grahovo","Bratunac","Brčko","Breza","Brod","Bugojno","Busovača","Bužim","Cazin","Centar","Čajniče","Čapljina","Čelić","Čelinac","Čitluk","Derventa","Doboj","Doboj-Istok","Doboj-Jug","Dobretići","Domaljevac-Šamac","Donji Vakuf","Donji Žabar","Drvar","Foča (FBiH)","Foča (RS)","Fojnica","Gacko","Glamoč","Goražde","Gornji Vakuf-Uskoplje","Gračanica","Gradačac","Gradiška","Grude","Hadžići","Han-Pijesak","Ilidža","Ilijaš","Istočna Ilidža","Istočni Drvar","Istočni Mostar","Istočni Stari Grad","Istočno Novo Sarajevo","Istočno Sarajevo","Jablanica","Jajce","Jezero","Kakanj","Kalesija","Kalinovik","Kiseljak","Kladanj","Ključ","Kneževo","Konjic","Kostajnica","Kotor-Varoš","Kozarska Dubica","Kreševo","Krupa na Uni","Kupres (FBiH)","Kupres (RS)","Laktaši","Livno","Lopare","Lukavac","Ljubinje","Ljubuški","Maglaj","Milići","Modriča","Mostar","Mrkonjić Grad","Neum","Nevesinje","Novi Grad","Novi Grad (Sarajevo)","Novi Travnik","Novo Goražde","Novo Sarajevo","Odžak","Olovo","Orašje","Osmaci","Oštra Luka","Pale (FBiH)","Pale (RS)","Pelagićevo","Petrovac","Petrovo","Posušje","Prijedor","Prnjavor","Prozor-Rama","Ravno","Ribnik","Rogatica","Rudo","Sanski Most","Sapna","Sarajevo","Sokolac","Srbac","Srebrenica","Srebrenik","Stanari","Stari Grad","Stolac","Šamac","Šekovići","Šipovo","Široki Brijeg","Teočak","Teslić","Tešanj","Tomislavgrad","Travnik","Trebinje","Trnovo (FBiH)","Trnovo (RS)","Tuzla","Ugljevik","Usora","Vareš","Velika Kladuša","Visoko","Višegrad","Vitez","Vlasenica","Vogošća","Vukosavlje","Zavidovići","Zenica","Zvornik","Žepče","Živinice"
                };
                foreach (var naziv in nazivList)
                {
                    context.Opcina.Add(new Opcina
                    {
                        Naziv = naziv
                    });
                }
                context.SaveChanges();
            }
            //Seeding tipUplate
            if (context.TipUplate.Count() == 0)
            {
                var tipList = new List<TipUplate>
                {
                    new TipUplate
                    {
                        Naziv = "Članarina",
                        Cijena = 200 //mjesečna cijena
                    },
                    new TipUplate
                    {
                        Naziv = "Jednokratna uplata za kurs"
                    }
                };
                foreach (var tip in tipList)
                {
                    context.TipUplate.Add(tip);
                }
                context.SaveChanges();
            }
            //Seeding osoba and app users
            if (context.ApplicationUser.Count() == 0)
            {
                var listUser = new List<ApplicationUser>
                {
                    new ApplicationUser
                    {
                        Email = "osoblje@user.com",
                        Username = "administrativnoOsoblje",
                        PasswordSalt = "4MDzEbW7FZxGG0kEoSy8dg==",
                        PasswordHash = "4gGIxxpc5KbSa78rD0Mf9/0GusmDxEThMXG/XqmT6Zc=",
                        DatumRodjenja = new System.DateTime(1995,1,1),
                        Ime = "Charlie",
                        OpcinaId = 1,
                        JMBG = "1111111111111",
                        Prezime = "Rogers",
                        Spol = "M",
                        DatumRegistracije = DateTime.Now,
                        Active = true
                    },
                    new ApplicationUser
                    {
                        Email = "user1@user.com",
                        Username = "predavac",
                        PasswordSalt = "/rDyKmixi4V+mLEHYl6ZnQ==",
                        PasswordHash = "4vyRimmwsTtpKwDT/p4X52wzBG7mQXHJf1k79d847GA=",
                        DatumRodjenja = new System.DateTime(1995,1,1),
                        Ime = "Emma",
                        OpcinaId = 1,
                        JMBG = "1111111111111",
                        Prezime = "Coleman",
                        Spol = "Z",
                        DatumRegistracije = DateTime.Now,
                        Active = true
                    },
                    new ApplicationUser
                    {
                        Email = "user2@user.com",
                        Username = "predavac2",
                        PasswordSalt = "/rDyKmixi4V+mLEHYl6ZnQ==",
                        PasswordHash = "4vyRimmwsTtpKwDT/p4X52wzBG7mQXHJf1k79d847GA=",
                        DatumRodjenja = new System.DateTime(1995,1,1),
                        Ime = "Jason",
                        OpcinaId = 1,
                        JMBG = "1111111111111",
                        Prezime = "Grant",
                        Spol = "M",
                        DatumRegistracije = DateTime.Now,
                        Active = true
                    },
                    new ApplicationUser
                    {
                        Email = "mobile@user.com",
                        Username = "mobile",
                        PasswordSalt = "m3drxJcDcSrIlAHloDVKWg==",
                        PasswordHash = "tXuFA6coobuIii4KtqAJOzY5+7xeRloTU0JI8FZsH7E=",
                        DatumRodjenja = new System.DateTime(1995,1,1),
                        Ime = "Michael",
                        OpcinaId = 1,
                        JMBG = "1111111111111",
                        Prezime = "Denis",
                        Spol = "Other",
                        DatumRegistracije = DateTime.Now,
                        Active = true
                    },
                    new ApplicationUser
                    {
                        Email = "mobile2@user.com",
                        Username = "mobile2",
                        PasswordSalt = "m3drxJcDcSrIlAHloDVKWg==",
                        PasswordHash = "tXuFA6coobuIii4KtqAJOzY5+7xeRloTU0JI8FZsH7E=",
                        DatumRodjenja = new System.DateTime(1995,1,1),
                        Ime = "Ricky",
                        OpcinaId = 1,
                        JMBG = "1111111111111",
                        Prezime = "Rufus",
                        Spol = "Z",
                        DatumRegistracije = DateTime.Now,
                        Active = true
                    },
                    new ApplicationUser
                    {
                        Email = "mobile3@user.com",
                        Username = "mobile3",
                        PasswordSalt = "m3drxJcDcSrIlAHloDVKWg==",
                        PasswordHash = "tXuFA6coobuIii4KtqAJOzY5+7xeRloTU0JI8FZsH7E=",
                        DatumRodjenja = new System.DateTime(1995,1,1),
                        Ime = "Edie",
                        OpcinaId = 1,
                        JMBG = "1111111111111",
                        Prezime = "Smith",
                        Spol = "M",
                        DatumRegistracije = DateTime.Now,
                        Active = true
                    }
                };
                var roles = new List<ApplicationUserRole>{
                    new ApplicationUserRole
                    {
                        ApplicationUser = listUser[0],
                        RoleId = 1
                    },
                    new ApplicationUserRole
                    {
                        ApplicationUser = listUser[1],
                        RoleId = 2
                    },
                    new ApplicationUserRole
                    {
                        ApplicationUser = listUser[2],
                        RoleId = 2
                    },
                    new ApplicationUserRole
                    {
                        ApplicationUser = listUser[3],
                        RoleId = 3
                    },
                    new ApplicationUserRole
                    {
                        ApplicationUser = listUser[4],
                        RoleId = 3
                    },
                    new ApplicationUserRole
                    {
                        ApplicationUser = listUser[5],
                        RoleId = 3
                    }
                };
                foreach(var user in listUser)
                {
                    context.ApplicationUser.Add(user);
                }
                foreach(var r in roles)
                {
                    context.ApplicationUserRole.Add(r);
                }
                var uposlenici = new List<Uposlenik>
                {
                    new Uposlenik
                    {
                        DatumZaposlenja = DateTime.Now,
                        ApplicationUser = listUser[0]
                    },
                    new Uposlenik
                    {
                        DatumZaposlenja = DateTime.Now,
                        ApplicationUser = listUser[1]
                    },
                    new Uposlenik
                    {
                        DatumZaposlenja = DateTime.Now,
                        ApplicationUser = listUser[2]
                    }
                };
                var klijenti = new List<Klijent>
                {
                    new Klijent
                    {
                        ApplicationUser = listUser[3]
                    },
                    new Klijent
                    {
                        ApplicationUser = listUser[4]
                    },
                    new Klijent
                    {
                        ApplicationUser = listUser[5]
                    }
                };
                uposlenici.ForEach(u => context.Uposlenik.Add(u));
                klijenti.ForEach(k => context.Klijent.Add(k));

                //seeding uplate
                if (context.Uplata.Count() == 0)
                {
                    var listUplate = new List<Uplata>
                        {
                            new Uplata
                            {
                                DatumUplate = DateTime.Now,
                                Iznos = 100,
                                Klijent = klijenti[0],
                                TipUplateId = 2
                            },
                            new Uplata
                            {
                                DatumUplate = DateTime.Now,
                                Iznos = 100,
                                Klijent = klijenti[1],
                                TipUplateId = 2
                            },
                            new Uplata
                            {
                                DatumUplate = DateTime.Now,
                                Iznos = 100,
                                Klijent = klijenti[2],
                                TipUplateId = 2
                            }
                        };
                    var listClanarine = new List<Clanarina>
                    {
                        new Clanarina
                        {
                            DatumIsteka = DateTime.Now,
                            Uplata = listUplate[0],
                            Klijent = listUplate[0].Klijent
                        },
                        new Clanarina
                        {
                            DatumIsteka = DateTime.Now,
                            Uplata = listUplate[1],
                            Klijent = listUplate[1].Klijent
                        },
                        new Clanarina
                        {
                            DatumIsteka = DateTime.Now,
                            Uplata = listUplate[2],
                            Klijent = listUplate[2].Klijent
                        }
                    };
                    foreach (var item in listUplate)
                    {
                        context.Uplata.Add(item);
                    }
                    foreach(var item in listClanarine)
                    {
                        context.Clanarina.Add(item);
                    }
                    context.SaveChanges();
                }

                context.SaveChanges();
            }
            //Seeding tag
            if (context.Tag.Count() == 0)
            {
                var tagList = new List<Tag>
                {
                    new Tag
                    {
                        Naziv = "Engineering"
                    },
                    new Tag
                    {
                        Naziv = "Chemistry",
                    },
                    new Tag
                    {
                        Naziv = "Math",
                    },
                    new Tag
                    {
                        Naziv = "Language",
                    },
                    new Tag
                    {
                        Naziv = "History",
                    },
                    new Tag
                    {
                        Naziv = "IT",
                    }
                };
                foreach (var tag in tagList)
                {
                    context.Tag.Add(tag);
                }
                context.SaveChanges();
            }
            //seeding course
            if (context.Kurs.Count() == 0)
            {
                var list = new List<Kurs>
                {
                    new Kurs
                    {
                        Naziv = "Algebra 1",
                        SkraceniNaziv = "ALG-1",
                        Opis = "Algebra is one of the broad parts of mathematics, together with number theory, geometry and analysis. In its most general form, algebra is the study of mathematical symbols and the rules for manipulating these symbols. This course is focused on basics of algebra."
                    },
                    new Kurs
                    {
                        Naziv = "Algebra 2",
                        SkraceniNaziv = "ALG-2",
                        Opis = "Algebra is one of the broad parts of mathematics, together with number theory, geometry and analysis. This course focuses on more advanced algebra."
                    },
                    new Kurs
                    {
                        Naziv = "Algorithms and structures in programming",
                        SkraceniNaziv = "ASP",
                        Opis = "In this course we learn about basic algorithms and structures that are often used in programming."
                    },
                    new Kurs
                    {
                        Naziv = "Statistics",
                        SkraceniNaziv = "STAT",
                        Opis = "Statistics is the discipline that concerns the collection, organization, analysis, interpretation and presentation of data. In applying statistics to a scientific, industrial, or social problem, it is conventional to begin with a statistical population or a statistical model to be studied."
                    },
                    new Kurs
                    {
                        Naziv = "Computer networks",
                        SkraceniNaziv = "CN",
                        Opis = "A computer network is a group of computers that use a set of common communication protocols over digital interconnections for the purpose of sharing resources located on or provided by the network nodes. The interconnections between nodes are formed from a broad spectrum of telecommunication network technologies, based on physically wired, optical, and wireless radio-frequency methods that may be arranged in a variety of network topologies."
                    }
                };
                foreach (var item in list)
                {
                    context.Kurs.Add(item);
                }
                context.SaveChanges();
            }
            //seeding kurstag
            if (context.KursTag.Count() == 0)
            {
                var list = new List<KursTag>
                {
                    new KursTag
                    {
                        KursId = 1,
                        TagId = 1
                    },
                    new KursTag
                    {
                        KursId = 1,
                        TagId = 2
                    },
                    new KursTag
                    {
                        KursId = 2,
                        TagId = 3
                    },
                    new KursTag
                    {
                        KursId = 3,
                        TagId = 3
                    },
                };
                foreach (var item in list)
                {
                    context.KursTag.Add(item);
                }
                context.SaveChanges();
            }
            //seeding instance kursa
            if (context.KursInstanca.Count() == 0)
            {
                var list = new List<KursInstanca>
                {
                    new KursInstanca
                    {
                        BrojCasova = 10,
                        Kapacitet = 20,
                        PocetakDatum = DateTime.Now.AddMonths(4),
                        KursId = 1,
                        PrijaveDoDatum = DateTime.Now.AddMonths(4),
                        UposlenikId = 2
                    },
                    new KursInstanca
                    {
                        BrojCasova = 5,
                        PocetakDatum = DateTime.Now.AddMonths(2),
                        KursId = 1,
                        PrijaveDoDatum = DateTime.Now.AddMonths(2),
                        UposlenikId = 3,
                        Cijena = 200
                    },
                    new KursInstanca
                    {
                        BrojCasova = 15,
                        Kapacitet = 2,
                        PocetakDatum = DateTime.Now.AddMonths(4),
                        KursId = 2,
                        PrijaveDoDatum = DateTime.Now.AddMonths(4),
                        UposlenikId = 2
                    },
                    new KursInstanca
                    {
                        BrojCasova = 10,
                        Kapacitet = 20,
                        PocetakDatum = DateTime.Now.AddMonths(1),
                        KursId = 3,
                        PrijaveDoDatum = DateTime.Now.AddMonths(1),
                        UposlenikId = 2
                    },
                    new KursInstanca
                    {
                        BrojCasova = 10,
                        PocetakDatum = DateTime.Now.AddMonths(1),
                        KursId = 4,
                        PrijaveDoDatum = DateTime.Now.AddMonths(1),
                        UposlenikId = 3
                    }
                };
                foreach (var item in list)
                {
                    context.KursInstanca.Add(item);
                }
                context.SaveChanges();
            }
            //seeding klijente na kurs instance
            if (context.KlijentKursInstanca.Count() == 0)
            {
                var kursInstanca = new KursInstanca
                {
                    BrojCasova = 10,
                    PocetakDatum = DateTime.Now.AddMonths(1),
                    KursId = 5,
                    PrijaveDoDatum = DateTime.Now.AddMonths(1),
                    UposlenikId = 3,
                    Cijena = 300,
                    Kapacitet = 3
                };
                var kursInstanca2 = new KursInstanca
                {
                    BrojCasova = 10,
                    PocetakDatum = DateTime.Now.AddMonths(1),
                    KursId = 3,
                    PrijaveDoDatum = DateTime.Now.AddMonths(1),
                    UposlenikId = 2,
                    Cijena = 300,
                    Kapacitet = 3
                };

                var klijentKursInstnaca = new KlijentKursInstanca
                {
                    Active = true,
                    KlijentId = 1,
                    KursInstanca = kursInstanca2,
                    UplataIzvrsena = true
                };
                var klijentKursInstnaca2 = new KlijentKursInstanca
                {
                    Active = true,
                    KlijentId = 2,
                    KursInstanca = kursInstanca2,
                    UplataIzvrsena = true
                };
                var klijentKursInstnaca3 = new KlijentKursInstanca
                {
                    Active = true,
                    KlijentId = 3,
                    KursInstanca = kursInstanca2,
                    UplataIzvrsena = true
                };


                context.Add(kursInstanca);
                context.Add(klijentKursInstnaca);

                context.Add(kursInstanca2);
                context.Add(klijentKursInstnaca2);
                context.Add(klijentKursInstnaca3);

                context.SaveChanges();
            }
        }
    }
}
