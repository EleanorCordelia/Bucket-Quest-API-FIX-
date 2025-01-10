using Bogus;
using BucketQuestAPI.Entities;
using Entities;

namespace BucketQuestAPI.Data;

public class Seed
{
    private static Trip FakeTrip(DataContext context, List<ActivityType> ActivityTypes, string Location)
    {
        Faker<Trip> fakeTrip = new Faker<Trip>( locale: "id_ID" )
            .RuleFor(t => t.Name, f => f.Lorem.Sentence())
            .RuleFor(t => t.Description, f => f.Lorem.Paragraph())
            .RuleFor(t => t.Price, f => f.Random.Number(50_000, 500_000))
            .RuleFor(t => t.Duration, f => f.Lorem.Sentence())
            .RuleFor(t => t.Catatan, f => f.Lorem.Sentence())
            .RuleFor(t => t.Location, f => Location)
            .RuleFor(t => t.Itinerary, f => new List<string> { f.Lorem.Sentence() })
            .RuleFor(t => t.ActivityTypes, f => new List<ActivityType> { ActivityTypes[f.Random.Number(0, ActivityTypes.Count - 1)] })
            .RuleFor(t => t.Photos, f => new List<Photo> { FakePhoto() });
        return fakeTrip.Generate();
    }
    private static List<Trip> FakeTripN(DataContext context, List<ActivityType> ActivityTypes, string Location, int N)
    {
        Faker<Trip> fakeTrip = new Faker<Trip>( locale: "id_ID" )
            .RuleFor(t => t.Name, f => f.Lorem.Sentence())
            .RuleFor(t => t.Description, f => f.Lorem.Paragraph())
            .RuleFor(t => t.Price, f => f.Random.Number(50_000, 500_000))
            .RuleFor(t => t.Duration, f => f.Lorem.Sentence())
            .RuleFor(t => t.Catatan, f => f.Lorem.Sentence())
            .RuleFor(t => t.Location, f => Location)
            .RuleFor(t => t.Itinerary, f => new List<string> { f.Lorem.Sentence() })
            .RuleFor(t => t.ActivityTypes, f => new List<ActivityType> { ActivityTypes[f.Random.Number(0, ActivityTypes.Count - 1)] })
            .RuleFor(t => t.Photos, f => new List<Photo> { FakePhoto() });
        return fakeTrip.Generate(N);
    }
    private static TripPackage FakeTripPackage(DataContext context, List<ActivityType> ActivityTypes, string Location)
    {
        Faker<TripPackage> fakeTripPackage = new Faker<TripPackage>( locale: "id_ID" )
            .RuleFor(tp => tp.Name, f => f.Lorem.Sentence())
            .RuleFor(tp => tp.Location, f => Location)
            .RuleFor(tp => tp.Trips, f => FakeTripN(context, ActivityTypes, Location, 3));
        return fakeTripPackage.Generate();
    }
    private static Photo FakePhoto()
    {
        Faker<Photo> fakePhoto = new Faker<Photo>( locale: "id_ID" )
            .RuleFor(p => p.Url, f => f.Image.PicsumUrl());
        return fakePhoto.Generate();
    }

    public static async Task SeedTrip(DataContext context)
    {
        context.Database.BeginTransaction();
        var ActivityTypes = new List<ActivityType>
        {
            new ActivityType { Name = "Petualagan" },
            new ActivityType { Name = "Wisata" },
            new ActivityType { Name = "Kuliner" },
            new ActivityType { Name = "Edukasi" },
            new ActivityType { Name = "Kesehatan" },
            new ActivityType { Name = "Olahraga" },
            new ActivityType { Name = "Seni" },
            new ActivityType { Name = "Budaya" },
            new ActivityType { Name = "Belanja" },
            new ActivityType { Name = "Lainnya" }
        };
        await context.ActivityTypes.AddRangeAsync(ActivityTypes);
        await context.SaveChangesAsync();
        var trips = new List<Trip>
        {
            new Trip
            {
                Name= "Pendakian Matahri Terbit Gunung Batur",
                Description= "Nikmati keindahan matahari terbit dari puncak Gunung Batur. Pendakian dimulai dini hari dan dipandu oleh guide berpengalaman.",
                Price= 250_000,
                Duration= "Sekitar 4-5 jam",
                Catatan= "Pastikan kondisi fisik dalam keadaan baik untuk pendakian dengan tingkat kesulitan sedang.",
                Location= "Ubud, Bali",
                Itinerary= new List<string>
                {
                    "Penjemputan di hotel",
                    "Pendakian dimulai",
                    "Tiba di puncak",
                    "Sarapan",
                    "Turun dari puncak",
                    "Kembali ke hotel"
                },
                ActivityTypes= new List<ActivityType>
                {
                    ActivityTypes[0],
                    ActivityTypes[1]
                },
                Photos = new List<Photo>
                {
                    new Photo { Url = "http://cialfla.freedomains.dev/image/api/c21e054b-07b6-46b7-8627-23b3ade5d5af.png"},
                },
            },
            new Trip 
            {
                Name= "Arum Jeream di Sungai Ayung",
                Description= "Rasakan sensasi arung jeram di Sungai Ayung dengan pemandangan alam yang menakjubkan. Aktivitas ini cocok untuk pemula dan dipandu oleh instruktur profesional.",
                Price= 300_000,
                Duration= "Sekitar 2-3 jam",
                Catatan= "Aktivitas ini memerlukan stamina yang baik dan cocok untuk tingkat kesulitan sedang.",
                Location= "Ubud, Bali",
                Itinerary= new List<string>
                {
                    "Penjemputan di hotel",
                    "Persiapan arung jeram",
                    "Arung jeram dimulai",
                    "Selesai arung jeram",
                    "Kembali ke hotel"
                },
                ActivityTypes= new List<ActivityType>
                {
                    ActivityTypes[0],
                    ActivityTypes[1]
                },
                Photos = new List<Photo>
                {
                    new Photo { Url = "http://cialfla.freedomains.dev/image/api/fac305b4-969c-455b-bafe-513ce67de41f.png"}
                }
            },
            new Trip
            {
                Name= "Ubud Jungle Swing",
                Description= "Nikmati ayunan di atas hutan Ubud dengan pemandangan spektakuler, ideal untuk foto-foto Instagram.",
                Price= 99_110,
                Duration= "Sekitar 1-2 jam",
                Catatan= "Aktivitas ini lebih santai dan cocok sebagai pelengkap setelah aktivitas yang lebih menantang.",
                Location= "Ubud, Bali",
                Itinerary= new List<string>
                {
                    "Penjemputan di hotel",
                    "Ayunan dimulai",
                    "Selesai ayunan",
                    "Kembali ke hotel",
                },
                ActivityTypes= new List<ActivityType>
                {
                    ActivityTypes[0],
                    ActivityTypes[1]
                },
                Photos = new List<Photo>
                {
                    new Photo { Url = "http://cialfla.freedomains.dev/image/api/9d706afd-3cc6-4de4-a466-3cf6ecea558e.png"}
                }
            },
            new Trip
            {
                Name= "Kulineran di Pasar Malam Gianyar",
                Description= "Jelajahi pasar malam Gianyar dan nikmati berbagai kuliner khas Bali. Aktivitas ini cocok untuk pecinta kuliner.",
                Price= 50_000,
                Duration= "Sekitar 2-3 jam",
                Catatan= "Pastikan membawa uang tunai dalam jumlah yang cukup untuk pembelian makanan.",
                Location= "Gianyar, Bali",
                Itinerary= new List<string>
                {
                    "Penjemputan di hotel",
                    "Jelajah pasar malam",
                    "Makan malam",
                    "Kembali ke hotel"
                },
                ActivityTypes= new List<ActivityType>
                {
                    ActivityTypes[2]
                },
                Photos = new List<Photo>
                {
                    FakePhoto(),
                },
            },
            new Trip
            {
                Name= "Kelas Memasak Balinese Cuisine",
                Description= "Ikuti kelas memasak masakan khas Bali dan pelajari cara memasaknya dari chef profesional.",
                Price= 150_000,
                Duration= "Sekitar 3-4 jam",
                Catatan= "Pastikan membawa bahan makanan tambahan jika ingin memasak di rumah.",
                Location= "Gianyar, Bali",
                Itinerary= new List<string>
                {
                    "Penjemputan di hotel",
                    "Kelas dimulai",
                    "Makan siang",
                    "Selesai kelas",
                    "Kembali ke hotel"
                },
                ActivityTypes= new List<ActivityType>
                {
                    ActivityTypes[2],
                    ActivityTypes[3]
                },
                Photos = new List<Photo>
                {
                    FakePhoto(),
                },
            },
            new Trip
            {
                Name= "Kelas Yoga Gianyar",
                Description= "Ikuti kelas yoga di Gianyar dan rasakan manfaatnya untuk kesehatan tubuh dan pikiran.",
                Price= 100_000,
                Duration= "Sekitar 1-2 jam",
                Catatan= "Pastikan membawa matras yoga sendiri jika tidak ingin meminjam dari tempat kelas.",
                Location= "Gianyar, Bali",
                Itinerary= new List<string>
                {
                    "Penjemputan di hotel",
                    "Kelas dimulai",
                    "Selesai kelas",
                    "Kembali ke hotel"
                },
                ActivityTypes= new List<ActivityType>
                {
                    ActivityTypes[4],
                    ActivityTypes[5]
                },
                Photos = new List<Photo>
                {
                    FakePhoto(),
                },
            },
            new Trip
            {
                Name= "Petualangan ATV di Ubud",
                Description= "Nikmati sensasi mengendarai ATV melalui trek menantang di Ubud, melintasi persawahan, sungai, hutan, dan gua. Aktivitas ini menawarkan pengalaman seru bagi pasangan yang mencari petualangan.",
                Price= 300_000,
                Duration= "Sekitar 1.5-2 jam",
                Catatan = "Aktivitas ini cocok untuk tingkat kesulitan sedang dan memberikan pengalaman unik menjelajahi alam Ubud.",
                Location = "Ubud, Bali",
                Itinerary = new List<string>
                {
                    "Penjemputan di hotel",
                    "Persiapan ATV",
                    "ATV dimulai",
                    "Selesai ATV",
                    "Kembali ke hotel"
                },
                ActivityTypes = new List<ActivityType>
                {
                    ActivityTypes[0],
                    ActivityTypes[1]
                },
                Photos = new List<Photo>
                {
                    new Photo { Url= "http://cialfla.freedomains.dev/image/api/035455b1-bf43-47d3-80b9-d60a4179ea78.png"}
                },
            },
            new Trip
            {
                Name= "Ayunan di Bali Swing",
                Description= "Rasakan sensasi berayun di atas lembah dengan pemandangan hutan dan sawah yang menakjubkan. Aktivitas ini juga menawarkan spot foto yang Instagramable.",
                Price= 250_000,
                Duration= "Sekitar 1-2 jam",
                Catatan = "Aktivitas ini memberikan pengalaman seru dan romantis bagi pasangan.",
                Location = "Ubud, Bali",
                Itinerary = new List<string>
                {
                    "Penjemputan di hotel",
                    "Ayunan dimulai",
                    "Selesai ayunan",
                    "Kembali ke hotel"
                },
                ActivityTypes = new List<ActivityType>
                {
                    ActivityTypes[0],
                    ActivityTypes[1]
                },
                Photos = new List<Photo>
                {
                    new Photo { Url= "http://cialfla.freedomains.dev/image/api/fd93e8c0-2c1a-48ac-890a-2b45965184b0.png"}
                },
                
            }
        };
        await context.Trips.AddRangeAsync(trips);
        await context.SaveChangesAsync();

        var TripPackages = new List<TripPackage>
        {
            new TripPackage
            {
                Name = "Sunrise Adventure & Nature Thrilling",
                Location = "Ubud, Bali",
                Trips = new List<Trip>
                {
                    trips[0],
                    trips[1],
                    trips[2]
                }
            },
            new TripPackage
            {
                Name = "Culinary & Cultural Exploration",
                Location = "Gianyar, Bali",
                Trips = new List<Trip>
                {
                    trips[3],
                    trips[4],
                    trips[5]
                }
            },
            new TripPackage
            {
                Name = "Ubud Jungle Swing",
                Location = "Ubud, Bali",
                Trips = new List<Trip>
                {
                    trips[6],
                    trips[7]
                }
            }
        };
        await context.TripPackages.AddRangeAsync(TripPackages);
        await context.SaveChangesAsync();
        var locations = new List<string>
        {
            "Ubud, Bali",
            "Gianyar, Bali",
            "Kuta, Bali",
            "Denpasar, Bali",
            "Lombok, NTB",
            "Yogyakarta, DIY",
            "Bandung, Jawa Barat",
            "Jakarta, DKI Jakarta",
            "Bogor, Jawa Barat",
            "Bekasi, Jawa Barat",
            "Tangerang, Banten",
            "Depok, Jawa Barat",
            "Raja Ampat, Papua Barat",
        };
        List<TripPackage> fakePackage = new List<TripPackage> {};
        var random = new Random();
        foreach (var location in locations)
        {
            int n = random.Next(1, 4);
            for (int i = 0; i < n ; i++) fakePackage.Add(FakeTripPackage(context, ActivityTypes, location));
        }

        await context.TripPackages.AddRangeAsync(fakePackage);
        await context.SaveChangesAsync();
        context.Database.CommitTransaction();   
    }
}