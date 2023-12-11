using ecom.minhhai.bookstore.Infrastructure;
using ecom.minhhai.bookstore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace ecom.minhhai.bookstore.Context
{
    public static class SeedData
    {
        public static void RoleData(this ModelBuilder modelBuilder)
        {
            /* modelBuilder.Entity<RoleModel>().HasData(
                     new RoleModel() { RoleId = Guid.Parse("5B71C14D-AEDB-41E1-A1D9-943FD5D3983C"), RoleName = "Admin" },
                     new RoleModel() { RoleId = Guid.Parse("E9BB47A8-D3FC-409C-8651-0542816F7483"), RoleName = "Nhân Viên" }
                 );*/
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "5B71C14D-AEDB-41E1-A1D9-943FD5D3983C", Name = AppicationRole.Admin, NormalizedName = AppicationRole.Admin.ToUpper() },
            new IdentityRole { Id = "E9BB47A8-D3FC-409C-8651-0542816F7483", Name = AppicationRole.Customer, NormalizedName = AppicationRole.Customer.ToUpper() }
                );
        }
        public static void UserData(this ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<AccountModel>();

            modelBuilder.Entity<AccountModel>().HasData(
                new AccountModel
                {
                    Id = "9C0AA3D8-C892-4407-9521-3BBFA5B05D0A",
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    Active = true
                    
                }
            );
        }
        public static void UserRoleData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = "9C0AA3D8-C892-4407-9521-3BBFA5B05D0A", RoleId = "5B71C14D-AEDB-41E1-A1D9-943FD5D3983C" }
            );
        }

        public static void CategoryData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryModel>().HasData(
                    new CategoryModel()
                    {
                        CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                        CategoryName = "Horror"
                    },
                    new CategoryModel()
                    {
                        CategoryId = Guid.Parse("79992A22-2A2B-49BC-81A7-66B41ED033B0"),
                        CategoryName = "Fiction"
                    },
                    new CategoryModel()
                    {
                        CategoryId = Guid.Parse("E357ABBD-CC3E-4769-9863-9F8B640073F8"),
                        CategoryName = "Romance",
                    },
                    new CategoryModel()
                    {
                        CategoryId = Guid.Parse("83918000-7C93-435D-AAB5-E3177F8E6C81"),
                        CategoryName = "Comics",
                    },
                    new CategoryModel()
                    {
                        CategoryId = Guid.Parse("5C5F3888-D5C2-442C-B05F-B05648370FE9"),
                        CategoryName = "Fantasy",
                    }
                );
        }

        public static void BookData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookModel>().HasData(
                    new BookModel()
                    {
                        BookId = Guid.NewGuid(),
                        BookName = "The Shining",
                        BookDescription = "Jack Torrance's new job at the Overlook Hotel is the perfect chance for a fresh start. As the off-season caretaker at the atmospheric old hotel, he'll have plenty of time to spend reconnecting with his family and working on his writing. But as the harsh winter weather sets in, the idyllic location feels ever more remote...and more sinister. And the only one to notice the strange and terrible forces gathering around the Overlook is Danny Torrance, a uniquely gifted five-year-old.",
                        Author = "Stephen King",
                        CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                        Price = 10,
                        Thumbnail = "theshining.png",
                        CreateDate = DateTime.Now,
                        BestSellers = true,
                        HomeFlag = true,
                        Active = true,
                        Tags = "The Shining",
                        Title = "The Shining",
                        Alias = "the-shining",
                        MetaDesc = "The Shining",
                        MetaKey = "The Shining",
                        UnitsInStock = 10,
                        OriginalPrice = 14,
                        Discount = 20
                    },

                    new BookModel()
                    {
                        BookId = Guid.NewGuid(),
                        BookName = "A Guest in the House",
                        BookDescription = "In Emily Carroll's haunting adult graphic novel horror story A Guest in the House , a young woman marries a kind dentist only to realize that there’s a dark mystery surrounding his former wife’s death.",
                        Author = "Emily Carroll",
                        CategoryId = Guid.Parse("83918000-7C93-435D-AAB5-E3177F8E6C81"),
                        Price = 15,
                        Thumbnail = "aguestinthehouse.png",
                        CreateDate = DateTime.Now,
                        BestSellers = true,
                        HomeFlag = false,
                        Active = true,
                        Tags = "A Guest in the House",
                        Title = "A Guest in the House",
                        Alias = "a-guest-in-the-house",
                        MetaDesc = "A Guest in the House",
                        MetaKey = "A Guest in the House",
                        UnitsInStock = 10,
                        OriginalPrice = 20,
                        Discount = 20
                    },

                    new BookModel()
                    {
                        BookId = Guid.NewGuid(),
                        BookName = "Lights",
                        BookDescription = "Following Brenna Thummler’s bestselling and critically acclaimed graphic novels Sheets and Delicates, Marjorie, Eliza, and Wendell the ghost are back to uncover the secrets of Wendell’s human life in the third and final heartwarming installment of the Sheets trilogy.",
                        Author = "Brenna Thummler",
                        CategoryId = Guid.Parse("83918000-7C93-435D-AAB5-E3177F8E6C81"),
                        Price = 20,
                        Thumbnail = "lights.png",
                        CreateDate = DateTime.Now,
                        BestSellers = true,
                        HomeFlag = false,
                        Active = true,
                        Tags = "Lights",
                        Title = "Lights",
                        Alias = "lights",
                        MetaDesc = "Lights",
                        MetaKey = "Lights",
                        UnitsInStock = 10,
                        OriginalPrice = 20,
                        Discount = 20
                    },

                    new BookModel()
                    {
                        BookId = Guid.NewGuid(),
                        BookName = "The Handyman Method",
                        BookDescription = "When a young family moves into an unfinished development community, cracks begin to emerge in both their new residence and their lives, as a mysterious online DIY instructor delivers dark subliminal suggestions about how to handle any problem around the house. The trials of home improvement, destructive insecurities, and haunted house horror all collide in this thrilling story perfect for fans of Nick Cutter’s bestsellers The Troop and The Deep",
                        Author = "Nick Cutter",
                        CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                        Price = 20,
                        Thumbnail = "thehandymanmethod.png",
                        CreateDate = DateTime.Now,
                        BestSellers = false,
                        HomeFlag = true,
                        Active = true,
                        Tags = "The Handyman Method",
                        Title = "The Handyman Method",
                        Alias = "the-handyman-method",
                        MetaDesc = "The Handyman Method",
                        MetaKey = "The Handyman Method",
                        UnitsInStock = 10,
                        OriginalPrice = 25,
                        Discount = 20
                    },

                    new BookModel()
                    {
                        BookId = Guid.NewGuid(),
                        BookName = "The Last Girls Standing",
                        BookDescription = "In this queer YA psychological thriller from the author of Some Girls Do, perfect for fans of One of Us Is Lying and A Good Girl’s Guide to Murder, the sole surviving counselors of a summer camp massacre search to uncover the truth of what happened that fateful night, but what they find out might just get them killed.",
                        Author = "Jennifer Dugan",
                        CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                        Price = 14,
                        Thumbnail = "the-last-girls-standing.png",
                        CreateDate = DateTime.Now,
                        BestSellers = true,
                        HomeFlag = false,
                        Active = true,
                        Tags = "The Last Girls Standing",
                        Title = "The Last Girls Standing",
                        Alias = "the-last-girls-standing",
                        MetaDesc = "The Last Girls Standing",
                        MetaKey = "The Last Girls Standing",
                        UnitsInStock = 10,
                        OriginalPrice = 19,
                        Discount = 20
                    },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "A Multitude of Dreams",
                         BookDescription = "Princess Imogen of Goslind has lived a sheltered life for three years at the boarded-up castle—she and the rest of its inhabitants safe from the bloody mori roja plague that’s ravaged the kingdom. But Princess Imogen has a secret, and as King Stuart descends further into madness, it’s at great risk of being revealed. Rations dwindle each day, and unhappy murmurings threaten to crack the facade of the years-long charade being played within the castle walls.",
                         Author = "Mara Rutherford",
                         CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                         Price = 10,
                         Thumbnail = "multitude-of-dreams.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = true,
                         Active = true,
                         Tags = "A Multitude of Dreams",
                         Title = "A Multitude of Dreams",
                         Alias = "multitude-of-dreams",
                         MetaDesc = "A Multitude of Dreams",
                         MetaKey = "A Multitude of Dreams",
                         UnitsInStock = 10,
                         OriginalPrice = 15,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "The Exorcist Legacy: 50 Years of Fear",
                         BookDescription = "Since 1973, The Exorcist and its progeny have scared and inspired half a century of filmgoers. Now, on the 50th anniversary of the original movie release, this is the definitive, fascinating story of the scariest movie ever madeand its lasting impact as one of the most shocking, influential, and successful adventures in the history of film. Written by Nat Segaloff, an original publicist for the movie and the acclaimed biographer of its director, with a foreword from John Russo, author and cowriter of the seminal horror film Night of the Living Dead.",
                         Author = "Nat Segaloff",
                         CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                         Price = 14,
                         Thumbnail = "the-exorcist-legacy.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = false,
                         Active = true,
                         Tags = "The Exorcist Legacy: 50 Years of Fear",
                         Title = "The Exorcist Legacy: 50 Years of Fear",
                         Alias = "the-exorcist-legacy-50-years-of-fear",
                         MetaDesc = "The Exorcist Legacy: 50 Years of Fear",
                         MetaKey = "The Exorcist Legacy: 50 Years of Fear",
                         UnitsInStock = 10,
                         OriginalPrice = 19,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "The Frangitelli Mirror",
                         BookDescription = "Rose Carbonelli sees ghosts. She doesn’t sleep. She watches every corner, studies every shadow, listens to the screams that no one else hears. Rose Carbonelli is terrified.",
                         Author = "G.R. Thomas",
                         CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                         Price = 14,
                         Thumbnail = "the-frangitelli-mirror.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = false,
                         Active = true,
                         Tags = "The Frangitelli Mirror",
                         Title = "The Frangitelli Mirror",
                         Alias = "the-frangitelli-mirror",
                         MetaDesc = "The Frangitelli Mirror",
                         MetaKey = "The Frangitelli Mirror",
                         UnitsInStock = 10,
                         OriginalPrice = 19,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Two Minutes with the Devil",
                         BookDescription = "It’s the summer of 86, and school is out in the little Gulf Coast town of Harbor Bluff. Maximum Overdrive is at the cinema, Rampage is all the rage at the arcade, and the only rule from parents is to be home in time for supper. Things couldn’t be simpler or better . . . until kids begin disappearing while playing a children’s game called Two Minutes with the Devil.",
                         Author = "Matt Micheli",
                         CategoryId = Guid.Parse("FA50393E-B832-45ED-987A-C61E494EFFA7"),
                         Price = 8,
                         Thumbnail = "two-minutes-with-the-devil.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = false,
                         Active = true,
                         Tags = "Two Minutes with the Devil",
                         Title = "Two Minutes with the Devil",
                         Alias = "two-minutes-with-the-devil",
                         MetaDesc = "Two Minutes with the Devil",
                         MetaKey = "Two Minutes with the Devil",
                         UnitsInStock = 10,
                         OriginalPrice = 13,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Things in the Basement",
                         BookDescription = "From New York Times bestselling author Ben Hatke comes Things in the Basement , a young readers graphic novel about Milo, a young boy who discovers a portal to a secret world in his basement.",
                         Author = "Ben Hatke",
                         CategoryId = Guid.Parse("83918000-7C93-435D-AAB5-E3177F8E6C81"),
                         Price = 10,
                         Thumbnail = "things-in-the-basement.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = false,
                         Active = true,
                         Tags = "Things in the Basement",
                         Title = "Things in the Basement",
                         Alias = "things-in-the-basement",
                         MetaDesc = "Things in the Basement",
                         MetaKey = "Things in the Basement",
                         UnitsInStock = 10,
                         OriginalPrice = 15,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Billie Blaster and the Robot Army from Outer Space",
                         BookDescription = "An out-of-this-world new middle-grade graphic novel about a genius scientist and her evil nemesis—from New York Times bestselling author Laini Taylor and cartoonist Jim Di Bartolo",
                         Author = "Laini Taylor",
                         CategoryId = Guid.Parse("83918000-7C93-435D-AAB5-E3177F8E6C81"),
                         Price = 10,
                         Thumbnail = "billie-blaster.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "Billie Blaster and the Robot Army from Outer Space",
                         Title = "Billie Blaster and the Robot Army from Outer Space",
                         Alias = "billie-blaster-and-the-robot-armu-from-outer-space",
                         MetaDesc = "Billie Blaster and the Robot Army from Outer Space",
                         MetaKey = "Billie Blaster and the Robot Army from Outer Space",
                         UnitsInStock = 10,
                         OriginalPrice = 15,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Milk & Mocha: Our Little Happiness",
                         BookDescription = "An out-of-this-world new middle-grade graphic novel about a genius scientist and her evil nemesis—from New York Times bestselling author Laini Taylor and cartoonist Jim Di Bartolo",
                         Author = "Melani Sie",
                         CategoryId = Guid.Parse("83918000-7C93-435D-AAB5-E3177F8E6C81"),
                         Price = 10,
                         Thumbnail = "milk-and-mocha.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "Milk & Mocha: Our Little Happiness",
                         Title = "Milk & Mocha: Our Little Happiness",
                         Alias = "milk-and-mocha-our-little-happiness",
                         MetaDesc = "Milk & Mocha: Our Little Happiness",
                         MetaKey = "Milk & Mocha: Our Little Happiness",
                         UnitsInStock = 10,
                         OriginalPrice = 15,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Kiss the Girl",
                         BookDescription = "Ariel del Mar is one of the most famous singers in the world. She and her sisters—together, known as the band Siren Seven—have been a pop culture phenomenon since they were kids. On stage, wearing her iconic red wig and sequined costumes, staring out at a sea of fans, is where she shines. Anyone would think she’s the girl who has everything. ",
                         Author = "Zoraida Córdova",
                         CategoryId = Guid.Parse("79992A22-2A2B-49BC-81A7-66B41ED033B0"),
                         Price = 10,
                         Thumbnail = "kiss-the-girl.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "Kiss the Girl",
                         Title = "Kiss the Girl",
                         Alias = "kiss-the-girl",
                         MetaDesc = "Kiss the Girl",
                         MetaKey = "Kiss the Girl",
                         UnitsInStock = 10,
                         OriginalPrice = 15,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "The Peach Seed",
                         BookDescription = "Fletcher Dukes and Altovise Benson reunite after decades apart― and a mountain of secrets―in this debut exploring the repercussions of a single choice and how an enduring talisman challenges and holds a family together.",
                         Author = "Anita Gail Jones",
                         CategoryId = Guid.Parse("79992A22-2A2B-49BC-81A7-66B41ED033B0"),
                         Price = 15,
                         Thumbnail = "the-peach-seed.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "The Peach Seed",
                         Title = "The Peach Seed",
                         Alias = "the-peach-seed",
                         MetaDesc = "The Peach Seed",
                         MetaKey = "The Peach Seed",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Witness: Stories",
                         BookDescription = "From a National Book Award finalist, Witness is an elegant, insistent narrative of actions taken and not taken.",
                         Author = "Jamel Brinkley",
                         CategoryId = Guid.Parse("79992A22-2A2B-49BC-81A7-66B41ED033B0"),
                         Price = 16,
                         Thumbnail = "stories.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "Witness: Stories",
                         Title = "Witness: Stories",
                         Alias = "witness-stories",
                         MetaDesc = "Witness: Stories",
                         MetaKey = "Witness: Stories",
                         UnitsInStock = 10,
                         OriginalPrice = 22,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Who We Are Now",
                         BookDescription = "Four friends. Fifteen years. Who We Are Now is a story of Sliding Doors moments, those seemingly small choices of early adulthood that determine the course of our lives.",
                         Author = "Lauryn Chamberlain",
                         CategoryId = Guid.Parse("79992A22-2A2B-49BC-81A7-66B41ED033B0"),
                         Price = 12,
                         Thumbnail = "who-we-are-now.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = true,
                         Active = true,
                         Tags = "Who We Are Now",
                         Title = "Who We Are Now",
                         Alias = "who-we-are-now",
                         MetaDesc = "Who We Are Now",
                         MetaKey = "Who We Are Now",
                         UnitsInStock = 10,
                         OriginalPrice = 15,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "The Art of Scandal",
                         BookDescription = "On the night of her husband Matt’s fortieth birthday, Rachel Abbott receives a sexy, explicit text from her husband that she quickly realizes was meant for another woman. Divorce is inevitable, and Rachel is determined not to leave her thirteen-year marriage empty handed. Meanwhile, Matt, a rising star mayor with his eye on the White House, can’t afford a messy split in the middle of his reelection campaign. They strike a deal: Rachel gets one million dollars and their lavish house in the wealthy DC suburb of Oasis Springs, as long as she keeps playing the ideal Black trophy wife until the election.",
                         Author = "Regina Black",
                         CategoryId = Guid.Parse("E357ABBD-CC3E-4769-9863-9F8B640073F8"),
                         Price = 14,
                         Thumbnail = "the-art-of-scandal.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "The Art of Scandal",
                         Title = "The Art of Scandal",
                         Alias = "the-art-of-scandal",
                         MetaDesc = "The Art of Scandal",
                         MetaKey = "The Art of Scandal",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "A Little Like Waking",
                         BookDescription = "You’ve Reached Sam meets The Good Place in this deeply-felt, surreal and fully illustrated love story about a girl, a boy, a dreamer, and a dream from best-selling and award-winning author Adam Rex.",
                         Author = "Adam Rex",
                         CategoryId = Guid.Parse("E357ABBD-CC3E-4769-9863-9F8B640073F8"),
                         Price = 14,
                         Thumbnail = "a-little-like-waking.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "A Little Like Waking",
                         Title = "A Little Like Waking",
                         Alias = "a-little-like-walking",
                         MetaDesc = "A Little Like Waking",
                         MetaKey = "A Little Like Waking",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Together We Rot",
                         BookDescription = "A teen girl looking for the truth about her missing mother forms a reluctant alliance with her former best friend...in exchange for hiding him from his cult-leading family.",
                         Author = "Skyla Arndt",
                         CategoryId = Guid.Parse("E357ABBD-CC3E-4769-9863-9F8B640073F8"),
                         Price = 14,
                         Thumbnail = "together-we-rot.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = false,
                         Active = true,
                         Tags = "Together We Rot",
                         Title = "Together We Rot",
                         Alias = "together-we-rot",
                         MetaDesc = "Together We Rot",
                         MetaKey = "Together We Rot",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "The Roommate Pact",
                         BookDescription = "The proposition is simple: if ER nurse Claire Harper and her roommate, firefighter Graham Scott, are still single by the time they’re forty, they’ll take the proverbial plunge together…as friends with benefits. Maybe it’s the wine, but in the moment, Claire figures the pact is a safe-enough deal, considering she hasn’t had much luck in love and he’s in no rush to settle down. Like, at all. Besides, there’s no way she could ever really fall for Graham and his thrill-seeking ways. Not after what happened to her father…",
                         Author = "Allison Ashley",
                         CategoryId = Guid.Parse("E357ABBD-CC3E-4769-9863-9F8B640073F8"),
                         Price = 14,
                         Thumbnail = "the-roommate-pact.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "The Roommate Pact",
                         Title = "The Roommate Pact",
                         Alias = "the-roommate-pact",
                         MetaDesc = "The Roommate Pact",
                         MetaKey = "The Roommate Pact",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "He Who Drowned the World",
                         BookDescription = "Zhu Yuanzhang, the Radiant King, is riding high after her victory that tore southern China from its Mongol masters. Now she burns with a new desire: to seize the throne and crown herself emperor.",
                         Author = "Shelley Parker-Chan",
                         CategoryId = Guid.Parse("5C5F3888-D5C2-442C-B05F-B05648370FE9"),
                         Price = 14,
                         Thumbnail = "he-who-drowned-the-world.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = false,
                         Active = true,
                         Tags = "He Who Drowned the World",
                         Title = "He Who Drowned the World",
                         Alias = "he who drowned the world",
                         MetaDesc = "He Who Drowned the World",
                         MetaKey = "He Who Drowned the World",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "In Charm's Way",
                         BookDescription = "A witch struggling to regain what she has lost casts a forbidden spell—only to discover much more than she expected, in this enchanting new rom-com by New York Times bestselling author Lana Harper.",
                         Author = "Lana Harper",
                         CategoryId = Guid.Parse("5C5F3888-D5C2-442C-B05F-B05648370FE9"),
                         Price = 14,
                         Thumbnail = "in-charm-way.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = true,
                         Active = true,
                         Tags = "In Charm's Way",
                         Title = "In Charm's Way",
                         Alias = "in-charm-way",
                         MetaDesc = "In Charm's Way",
                         MetaKey = "In Charm's Way",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "The Apology",
                         BookDescription = "In South Korea, a 105-year-old woman receives a letter. Ten days later, she has been thrust into the afterlife, fighting to head off a curse that will otherwise devastate generations to come.",
                         Author = "Jimin Han",
                         CategoryId = Guid.Parse("5C5F3888-D5C2-442C-B05F-B05648370FE9"),
                         Price = 14,
                         Thumbnail = "the-apology.png",
                         CreateDate = DateTime.Now,
                         BestSellers = true,
                         HomeFlag = false,
                         Active = true,
                         Tags = "The Apology",
                         Title = "The Apology",
                         Alias = "the-apology",
                         MetaDesc = "The Apology",
                         MetaKey = "The Apology",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     },

                     new BookModel()
                     {
                         BookId = Guid.NewGuid(),
                         BookName = "Omen of Ice",
                         BookDescription = "Keltania Tunne has spent her whole life training to become a bodyguard for a Winter Fae. It’s the highest of honors for a druid…only when Tania arrives at the Winter Court for the first time, nothing is what she expected.",
                         Author = "Jus Accardo",
                         CategoryId = Guid.Parse("5C5F3888-D5C2-442C-B05F-B05648370FE9"),
                         Price = 14,
                         Thumbnail = "omen-of-ice.png",
                         CreateDate = DateTime.Now,
                         BestSellers = false,
                         HomeFlag = false,
                         Active = true,
                         Tags = "Omen of Ice",
                         Title = "Omen of Ice",
                         Alias = "omen-of-ice",
                         MetaDesc = "Omen of Ice",
                         MetaKey = "Omen of Ice",
                         UnitsInStock = 10,
                         OriginalPrice = 20,
                         Discount = 20
                     }
                );
        }
        public static void PostData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PostModel>().HasData(
                    new PostModel()
                    {
                        PostId = Guid.NewGuid(),
                        Title = "Tattered Cover Book Store Files for Bankruptcy",
                        Contents = "Tattered Cover Book Store, one of the country’s largest and best-known independent bookstores, filed for reorganization under Chapter 11 Subchapter V in the U.S. Bankruptcy Court for the District of Colorado yesterday. According to the Denver Post, documents filed in the bankruptcy court show Tattered Cover was more than $660,000 in the red between January and September. The business owes more than $1 million to publishers, as well as more than $375,000 to Colorado's Office of the State Auditor for abandoned gift cards.\r\n\r\nThe Subchapter V portion of Chapter 11 was enacted by Congress in 2020 to provide a streamlined process for small companies to reorganize. If the financing is approved, Tattered Cover will have access of up to $1 million in debtor-in-possession financing, provided by a new company formed by current company board members and investors that include Leslie Rainbolt and Margie Gart. The new funding, the announcement said, “will be used to obtain much-needed additional inventory in time for the critical 2023 holiday consumer buying season, fulfill customer orders, upgrade technology, and to maintain operations and staff compensation during the restructuring process.”\r\n\r\nVarious companies that supply books to Tattered Cover said that they will need to time to get a better understanding of the store's new financing before deciding on how to continue to work with the store in the future. The store has been on credit hold with a number of publishers.\r\n\r\nThe current owners, Bended Page LLC, acquired Tattered Cover in 2020 and, after an initial period of expansion, found business slowing, due in part to the pandemic. The bookstore also endured some management changes when Kwame Spearman, one of the lead investors who was named CEO, stepped down from that position in April after deciding to run for mayor of Denver. He subsequently withdrew from that race, and is now running for the Denver school board.\r\n\r\nIn July, Brad Dempsey, a lawyer specializing in finance and business restructuring, was named interim CEO. “Our objective is to put Tattered Cover on a smaller, more modern and financially sustainable platform that will ensure our ability to serve Colorado readers for many more decades,” Dempsey said in a statement. “Restructuring for long-term viability requires managers to make very difficult business decisions that affect people and business partners, and we intend to do what we can to minimize these impacts.”\r\n\r\nDempsey was referring to a host of changes that are in the process of being implemented. Among them are closing three of its seven stores: the locations in Denver’s McGregor Square, Westminster, and Colorado Springs. Those stores are expected to be closed by early November, at which time inventory and technology from the three will be transferred to the store’s four other locations.\r\n\r\nThe store closures will result in cutting “at least” 27 staff positions out of Tattered Cover’s current 103 positions, though the company said that some employees may fill temporary seasonal positions at the remaining stores during the holiday season. Tattered Cover’s Denver International Airport locations will continue operating, as part of a licensing agreement with Hudson Bookstores.\r\n\r\nIn addition to Dempsey, the company’s restructuring will be led by its senior management team: CFO Margie Keenan, newly named COO Jeremy Patlen (formerly v-p of buying), and Alexis Miles, v-p of human resources.\r\n\r\nThe company said that all customer gift cards will be honored, and orders will continue to be fulfilled, while all loyalty programs will also continue as usual. Events currently scheduled for this October and November at closing locations will be rescheduled, if possible, to take place at the store’s remaining locations, with all event changes to be posted on the bookseller's website.\r\n\r\nThe original Tattered Cover was opened in 1971 by Stephen Cogil and purchased by Joyce Meskis in 1974. Meskis sold it to Len Vlahos and Kristen Gilligan in 2015, who sold it to the current owners. The store is considered among the leading independent bookstores in the country, and has a long history of being at the forefront in the fight for free speech and First Amendment rights.",
                        Thumbnail = "tattered-cover-bookstore-files-for-bankruptcy.jpg",
                        Published = true,
                        Alias = "tattered-cover-bookstore-files-for-bankruptcy",
                        CreateDate = DateTime.Now,
                        Author = "Jim Milliot",
                        Tags = "Tattered Cover Book Store Files for Bankruptcy",
                        IsHot = true,
                        IsNewFeed = true,
                        MetaDesc = "Tattered Cover Book Store Files for Bankruptcy",
                        MetaKey = "Tattered Cover Book Store Files for Bankruptcy",
                    },
                    new PostModel()
                    {
                        PostId = Guid.NewGuid(),
                        Title = "Fans Recharge the Comics Industry at New York Comic Con 2023",
                        Contents = "New York Comic Con held an exhausting but exhilarating annual celebration of comics and pop culture October 12–15 at the Javits Center in New York City. While final attendance count is still pending, estimates are that crowds surpassed last year’s 200,000.\r\n\r\nThe show floor presented a psychedelic mash-up of pop culture, with manga and anime dominating. Massive character balloons of Goku from Dragon Ball and Luffy from One Piece loomed over the throngs, while immersive 3D manga displays from Shueisha and impressive activations from Crunchyroll, Manga Plus, and Bandai drew long lines. The prevalence of manga and anime-inspired costumes amongst cosplayers made clear just how much younger fans are riding the manga wave.\r\n\r\nFor publishers, it was a transitional year. Marvel was the only major comics publisher to invest in a prominent show floor presence, as DC, Dark Horse, and Image mostly sat it out, while IDW set up in Artist Alley on the lower level. But the gap left an opening for upstart exhibitors like Vault and Mad Cave to shine. And other new imprints, partnerships, and brands dotted the show floor.\r\n\r\nThe splashiest announcement was for Ghost Machine, added as an imprint at Image Comics led by veteran writer/producer and former DC Comics executive Geoff Johns. The brand promises a creator-owned line of comics with a shared universe and media development; creators involved include artists Gary Frank and Bryan Hitch and novelist Brad Meltzer. Also from Image, creator Rick Remender (Deadly Class) promoted his new Giant Generator imprint, sporting an international cast of creators including Daniel Acuña, Paul Azaceta, JG Jones, and Bengal. Another new player, Massive Publishing, serves as a publishing partner for various entities, such as collectibles auction app WhatNot and existing music-to-comics label Behemoth.\r\n\r\nThis buzz rose above reports of slower industry sales, discussed across the dedicated professional programming held Thursday. Direct market distributor Lunar kicked things off with a retailer breakfast, where Ghost Machine debuted. Retailer organization ComicsPRO followed with a slate of presentations, including updates on a metadata project that brings together an unprecedented mix of publishers, distributors, and retailers aiming to standardize industry metadata—with an eventual goal of sellthrough sales charts, now unavailable for the direct market.\r\n\r\nICv2’s presentation by Milton Griepp showed graphic novel sales strong and overall sales higher than 2019, but periodical comics sales slipping—even as the book market in general continues to soften following its pandemic highs. Concerns over inflation cutting into discretionary spending were also noted.\r\n\r\nYet the mood at the show was optimistic. Despite the high costs that prevented other publishers from exhibiting, Vault CEO and publisher Damian Wassel noted that Vault’s many readers in the NYC market made it worth their investment. “Attendance was incredible, and our sales were up dramatically over last year,” he said. “It's our best con ever.”\r\n\r\nMad Cave debuted recent licenses with Winx and Gatchaman, setting up their largest booth to date to showcase their expansion. “We got to show off Papercutz for the first time at NYCC [and] all the new things that we're doing, including more creator owned or licensed projects,” said CMO Allison Pond.\r\n\r\nAbrams ComicArts editor-in-chief Charles Kochman was pleased to see major book trade houses—including PRH, MacMillan, HarperCollins—and comics publishers united in one area on main the show floor. “By putting us together, you give people a sense of comparing and contrasting, but also there's a community among publishers,” he said.\r\n\r\nPRH highlighted their many genre imprints, along with new arrivals Ten Speed Graphic and a look-ahead to Inklore, a new imprint publishing manga, manhwa, and webtoons. According to PRH director of brand events Lindsey Elias, “people are super excited about Inklore and want to buy the [not yet released] books now,” adding: “We're able to do sales, marketing, and publicity all in one go.”",
                        Thumbnail = "fans-recharge-the-conmics-industry-at-new-york-comic-con-2023.jpg",
                        Published = true,
                        Alias = "fans-recharge-the-conmics-industry-at-new-york-comic-con-2023",
                        CreateDate = DateTime.Now,
                        Author = "Heidi MacDonald",
                        Tags = "Fans Recharge the Comics Industry at New York Comic Con 2023",
                        IsHot = true,
                        IsNewFeed = true,
                        MetaDesc = "Fans Recharge the Comics Industry at New York Comic Con 2023",
                        MetaKey = "Fans Recharge the Comics Industry at New York Comic Con 2023",
                    },
                    new PostModel()
                    {
                        PostId = Guid.NewGuid(),
                        Title = "New Thrillers About True Crime",
                        Contents = "Amazon Publishing associate publisher Gracie Doyle understands the appeal of amateur sleuthing. “I can’t be the only kid who wanted to be a detective,” she says. “And with all of us home for a couple of years, there’s a Rear Window element. We all love a good mystery.”\r\n\r\nAmong the books on her list is Elle Marr’s The Alone Time (Thomas & Mercer, Mar. 2024), which sees long-buried truths coming to light. Twenty-five years after Fiona and Violet Seng survived the private plane crash that killed their parents and left the girls, then ages 13 and seven, stranded in the Pacific Northwest wilderness for three weeks, a persistent documentarian calls into question their version of the events.\r\n\r\nIn Janice Hallet’s The Mysterious Case of the Alperton Angels (Atria, Jan. 2024), two true crime authors tussle over the career-making untold story of a cultlike group who believed that the child of one of its members was the Antichrist. “There’s a fine line between what’s public safety and what’s invading people’s privacy,” says Atria senior editor Kaitlin Olson. “Amateur detectives can go too far. We’ve seen this play out in real investigations—while intentions are really good, people on social media can get in the way.”\r\n\r\nThe intentions aren’t even necessarily good in Dervla McTiernan’s What Happened to Nina?, in which a character posts videos with conflicting theories of what happened to a missing girl in order to sow confusion. (See PW’s q&a with Dervla McTiernan, “Trial by Internet.”) In Kellye Garrett’s next thriller, the entire internet is on the lookout for a woman who fits the ideal victim profile: a Missing White Woman (Mulholland, Apr. 2024; Garrett discusses the phenomenon in “Social Distortion.”)\r\n\r\nHusband and wife team Nicci Gerrard and Sean French, who’ve written numerous thrillers as Nicci French, probe the ramifications of reopening old wounds in their latest, Has Anyone Seen Charlotte Salter? (Morrow, Mar. 2024). The wife and devoted mother of the title disappears just before her husband’s 50th birthday party; when a neighbor’s body is found soon after, the police conclude that the two were having an affair and died in a murder-suicide. Thirty years later, the neighbor’s son produces a popular podcast about the tragedy, throwing both families into turmoil.\r\n\r\n“We need stories, they explain life to us,” Gerrard says; she and French are former journalists. “But sometimes there isn’t a shape to the mess of life. We read stories of serial killers, and when there’s no evident psychological motivation, it’s like trying to find a fingerhold in smooth rock.”\r\n\r\nAnything for the story\r\n\r\nJournalists are held to a standard the average TikTok creator isn’t, but they, too, can lose sight of the impact their work has on their subjects. Christina Estes draws on more than 20 years of reporting experience for her debut novel, Off the Air (Minotaur, Mar. 2024), in which journalist Jolene Garcia hopes that her investigation of a death at a local radio station will make her career. “She comes up against a line she isn’t sure she should cross,” says Minotaur associate editor Madeline Houpt. “She thinks, ‘Am I going too far?’ But she wants to solve the case.”\r\n\r\nJenny Hollander, director of content strategy at Marie Claire, turns the tables on a fellow journalist in her debut, Everyone Who Can Forgive Me Is Dead (Minotaur, Feb. 2024). Charlie Colbert, a successful magazine editor, witnessed a horrific event at her journalism school nine years earlier. When she learns that one of her former classmates is making a movie about the event, known as the Scarlet Christmas, Charlie worries that the truth will come out. “She doesn’t totally remember what happened,” says St. Martin’s editor Sallie Lotz, who edited the book. “But she knows she lied about it.”\r\n\r\nAlmost Surely Dead by Amina Akhtar (Mindy’s Book Studio, Feb. 2024) tells the story of Dunia, a woman who is attacked on the subway, unravels, and then goes missing. Two obsessed journalists launch a true crime podcast seeking fame from Dunia’s misfortune: they want a Netflix deal, they’re selling merch. “I wanted to dive into trauma as content,” Akhtar says. “There should be a code of ethics for true crime. Something horrible happened to somebody; if the family is willing to talk to you, you’re probably walking the right line. If someone doesn’t want their story told, whose decision is it to tell it? Who owns the story?”\r\n\r\nJason Pinter explores the tension between truth-telling and entertainment-selling in Past Crimes (Severn House, Feb. 2024), set in a near-future where true crime fans can immerse themselves in hyper-realistic simulations of gruesome historical killings; people can pay to search for clues inside Jeffrey Dahmer’s Wisconsin cabin, for instance, or attend Lincoln’s assassination. “In these virtual experiences, the evilness has been taken out,” Pinter says. “All we’re left with is the entertainment.”\r\n\r\nIn Jeffrey B. Burton’s The Dead Years (Severn House, Mar. 2024), a long-dormant serial killer sees a Netflix docudrama based on his crimes, and isn’t happy about his portrayal. “Morbid curiosity is a universal trait,” Burton says. “Every day in some paper somewhere around the world, there’s a story that proves truth is stranger than fiction—‘Holy shit, what did the guy do?’ ”",
                        Thumbnail = "new-thrillers-about-true-crime.jpg",
                        Published = true,
                        Alias = "new-thrillers-about-true-crime",
                        CreateDate = DateTime.Now,
                        Author = "Liz Scheier",
                        Tags = "New Thrillers About True Crime",
                        IsHot = true,
                        IsNewFeed = true,
                        MetaDesc = "New Thrillers About True Crime",
                        MetaKey = "New Thrillers About True Crime",
                    },
                    new PostModel()
                    {
                        PostId = Guid.NewGuid(),
                        Title = "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel",
                        Contents = "Lefteri’s new novel, The Book of Fire, due out in January from Ballantine, addresses climate change as it follows a contemporary Greek family—music teacher Irini; her painter husband, Tasso; and their daughter, Chara—who live in a village in an ancient forest and whose lives are upended when a fire erupts, decimating both forest and village. The villagers blame a developer who started the fire while clearing land to build a hotel, but he isn’t the sole culprit, as prolonged high temperatures created dry conditions that turned the forest into a tinderbox.\r\n\r\n“How do we deal with situations where there’s someone to blame, but there’s also something bigger happening?” Lefteri says. “And how do we deal with that during times of trauma?”\r\n\r\nThe first time Lefteri saw an out-of-control forest fire in Greece was in 2017, when she was working as a volunteer at an Athens refugee center for women and children who’d been displaced during the Syrian Civil War. “I woke up one morning and the sky was filled with smoke,” she recalls. “There was a fire in a nearby town. It haunted me.”\r\n\r\nLefteri decided to write The Book of Fire in 2021, after another, bigger fire on the Greek island of Evia destroyed an ancient forest, killed more than 100 people, and left others homeless and physically scarred. She went to Greece for six weeks, while three months pregnant, to do research for the novel.\r\n\r\nThis included visiting the town of Mati, the site of yet another fatal fire, in 2018, and talking with still-traumatized locals, many of whom rejected the idea that climate change was responsible.\r\n\r\n“Being there was overwhelming,” Lefteri says. “I wanted to leave, which I felt horrible about. Every time I write a book I feel guilt, about being able to go home, a home that hasn’t been destroyed, that isn’t a camp. There’s this thing that happens to me where I become frightened about life. I can be quite robust, but when I’m alone I feel the fragility of life. It gets to me. I find it hard to regain my grounding, but then I remember what other people are dealing with.”\r\n\r\nLefteri is disarmingly open about her personal life and displays a genuine interest in others, which makes her effective as a field researcher who’s willing to be the sympathetic ear. “Christy is one of the most caring and compassionate people I’ve ever met,” says Lefteri’s agent, Marianne Gunn O’Connor. “She has a beautiful personality and a sweet nature. She worries about the world and writes with her heart.”\r\n\r\nBorn in 1980 in London, Lefteri was a sensitive child who enjoyed oil painting and stories. Her father, who’d been an officer in the war in Cyprus in 1974, came to the U.K. with Lefteri’s mother. Lefteri remembers her childhood home as a warm place, but her father, who she says had undiagnosed PTSD, was prone to outbursts. “That was the impact of someone not speaking about their trauma,” Lefteri explains. “I remember thinking as a child, what am I doing wrong? I still carry that. I’m constantly thinking I’m doing something wrong. That’s how unspoken trauma gets passed from one generation to the next.”\r\n\r\nAs she grew older, Lefteri became interested in writing as a way to express trauma. She worked for a time as a psychoanalyst, and in 2010 she earned her PhD in creative writing from Brunel University and wrote her first novel, A Watermelon, a Fish and a Bible, about the war in Cyprus, as part of her thesis project.\r\n\r\n“Writing really gets to my heart,” says Lefteri, whose characters often use art to cope with their troubles. “I think sometimes we have to go into our pain to overcome it.”\r\n\r\nAnne Speyer, Lefteri’s editor, appreciates the author’s ability to make big topics feel accessible. “Christy is wonderful at taking things that you read about in the news and making them personal,” she says. “She also makes you feel deeply about her characters. That’s the key to a great story, and she’s done it with every book.”\r\n\r\nLefteri’s next novel will be about European women’s football and will be set during World War I and in the present as it explores women’s lives across generations. “The book is linked to what I experienced with my daughter’s dad after she was born,” Lefteri says. “I left like I had lost my independence, that everything was put on me. This book will be about women’s dreams, about how far we’ve come, and if we’ve come as far as we think.”\r\n\r\nAs evening sets in, Lefteri hears a voice downstairs and checks the clock. The nanny is about to leave and it’s time to get her daughter. The pair may go for a walk with their dog, Alfie. (An emphatic animal lover, Lefteri is “completely obsessed” with him.)\r\n\r\nShe hopes The Book of Fire will inspire people to pay attention to how humanity treats the planet and every living thing on it. “There’s a grief we feel at the loss of our environment, and we don’t often realize that it causes such sadness,” she says. “If we lose our world, we’re nothing. Perhaps this book can make people pause and feel. When we really feel, it can impact a decision.”\r\n\r\nElaine Szewczyk’s writing has appeared in McSweeney’s and other publications. She’s the author of the novel I’m with Stupid.",
                        Thumbnail = "the-forest-fires-of-greece-wreathe-christy-lefteri's-latest-novel.jpg",
                        Published = true,
                        Alias = "the-forest-fires-of-greece-wreathe-christy-lefteri's-latest-novel",
                        CreateDate = DateTime.Now,
                        Author = "Elaine Szewczyk",
                        Tags = "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel",
                        IsHot = true,
                        IsNewFeed = true,
                        MetaDesc = "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel",
                        MetaKey = "The Forest Fires of Greece Wreathe Christy Lefteri's Latest Novel",
                    },
                    new PostModel()
                    {
                        PostId = Guid.NewGuid(),
                        Title = "Salar Abdoh's Tehran Is a City of Contradictions",
                        Contents = "“I also wanted to have a reckoning with the revolution,” he says. “This move was arguably the foundational step of my life. I could have stayed away like so many exiles and lived a strictly America life. Very deliberately I chose not to.”\r\n\r\nMany of the geopolitical issues of the past 40-plus years, Abdoh contends, stem from the Iranian Revolution, which toppled the monarchy, led to the establishment of the Islamic Republic, and changed the balance of power in the Middle East. “As someone who wanted to be an adventurer even more so than I wanted to be a writer,” he says, “I thought, where else but Iran!”\r\n\r\nTehran, the sprawling city of 15 million where much of A Nearby Country Called Love is set, is portrayed as a place of infinite contradictions. Pollution, traffic jams, overflowing garbage, and precarious construction sites are parts of everyday life. Modesty squads patrol the streets, fining or arresting women for “improprieties” such as not wearing hijabs. There is a steady stream of news about women who choose to burn themselves to death rather than continue to be beaten by husbands, fathers, or brothers for perceived acts of defiance.\r\n\r\nAt the same time, Abdoh’s Tehran is a cosmopolitan city brimming with cafés, culture, and well-educated locals who frequent concerts, galleries, and literary readings. There is also a vibrant underground network of gay bars and drag clubs.\r\n\r\nBut no matter the neighborhood or occasion, there are some constants in Tehran. Among them, and reflected in the psyches of Abdoh’s characters, is dread. “While it’s not quite the quotidian oppression outsiders imagine, there is the sense of always being on edge,” he says. “That dread has become innate, part of our very character.” And yet, he adds, “at some point folk figured out that rather than fighting the authorities to keep them out of their lives, they can simply disregard and ignore them, which creates a schizophrenia that you learn to live with, though at a cost to your mental and physical well-being.”\r\n\r\nA Nearby Country Called Love, which PW’s review called “a moving and nuanced study of gender and sexuality in contemporary Iran,” follows Issa as he reluctantly returns to Tehran from New York City and attempts to come to terms with his brother’s death. As the novel opens, Issa and his friend Nasser are on a mission to avenge the suicide-by-burning of a wife whose husband, the pair believe, drove her to that fate. While Nasser, a fireman who moonlights as an appliance salesman, revels in the testosterone-fueled vigilante mission—their second—Issa, a former soldier, knows there is nothing noble about what they have set out to do. He is also reminded of the persecution his late brother Hashem faced in their neighborhood due to his sexual orientation.\r\n\r\nViolence threads throughout the novel, as do Issa’s questions about the nature of masculinity and what is expected of a man living in contemporary Iran.\r\n\r\n“My father was a boxer and a soldier,” Abdoh says. “Machismo was part of the fabric, part of the molecule of everything that I grew up with. But my brother Reza was into theater and the arts. At an early age, he knew he was gay, and my father viewed him with shame. I was always in the middle, being pulled in both directions. I modeled Issa’s brother on my family experience, and on what Reza endured and accomplished before he died of AIDS in 1995.”\r\n\r\nIssa lives above the dojo his father ran until his death. His brother Hashem was a revered queer artist in Tehran’s underground—and their father did everything he could to scare Hashem straight. After enduring bullying and beatings by schoolmates and his father, Hashem learned to be defiant no matter the price. His death devastated Issa and prompted him to learn more about the community of friends, lovers, and artists who embraced his brother.\r\n\r\nIssa starts by reading authors Hashem cherished: Beckett, Auden, Proust, and Rilke. Soon, he’s attending parties and performances with people in his brother’s circle. Boundaries melt away. Eventually, Issa becomes romantically involved with a man. For Issa, though, this is a process of self-discovery—and even a way of honoring his brother.\r\n\r\nReferences to various Western literary works are sprinkled throughout the narrative, as are mentions of Perso-Arabic classics. The latter, Abdoh says, “cast a huge shadow of influence for me because many of those writers and mystics were always after the ultimate questions. Ontology—the branch of metaphysics dealing with the nature of being—was their bread and butter.” The same can be said for Abdoh, whose work probes the nature of belonging, masculinity, and the self.\r\n\r\nAnd while Abdoh set the novel in Iran and many of its plot points are unique to that country, he also wanted to address the global question of “how to be a man in this day and age,” he says, “when the paradigm of who we are supposed to be has shifted and none of us really knows how to behave, to respond.”",
                        Thumbnail = "Salar-abdohs-tehran-is a-city-of-contradictions.jpg",
                        Published = true,
                        Alias = "salar-abdohs-tehran-is a-city-of-contradictions",
                        CreateDate = DateTime.Now,
                        Author = "Leigh Haber",
                        Tags = "Salar Abdoh's Tehran Is a City of Contradictions",
                        IsHot = true,
                        IsNewFeed = true,
                        MetaDesc = "Salar Abdoh's Tehran Is a City of Contradictions",
                        MetaKey = "Salar Abdoh's Tehran Is a City of Contradictions",
                    },
                    new PostModel()
                    {
                        PostId = Guid.NewGuid(),
                        Title = "Jennifer Belle Gets Brave and Regrets Everything",
                        Contents = "Things couldn’t have gone much better for a 28-year-old debut author in 1996. There were blurbs from Jay McInerney (“a funny, sad, nasty little gem of novel”) and Tama Janowitz (“hilariously enthralling”). Madonna optioned the film rights—and wanted to direct. “Best new novelist,” declared Entertainment Weekly. “I think I was in 14 magazines at the same time, on a newsstand on my corner,” Jennifer Belle says via Zoom from her art-cluttered apartment overlooking New York City’s Washington Square Park.\r\n\r\nAnd then there was the dead fish. A bucket of them, to be precise, brought to Belle’s first Greenwich Village apartment by a photographer on assignment. “We spent a whole day shooting,” she recalls, “and somehow in the end, the picture—a full page in New York magazine—is me with a real dead fish on my head. There was a really nice one, where I’m kind of leaned over. Like, I have a headache and I’m holding the fish like a hot compress.” She recreates the pose with her iPhone. “But that’s not the one they used.”\r\n\r\nIf ever there was a debut novelist who didn’t need a prop, it was Belle. Her downtown “it girl” resumé would have been enough to make Chloë Sevigny jealous: the daughter of poet Jill Hoffman, Belle dropped out of high school at 15, lied her way into a job at a Bleecker Street bar, played a young Penny Arcade in the performance artist’s shows at La MaMa theater, and started her novel, Going Down, to have something to read at her mother’s writing workshops. By the time the book came out, she was selling luxury apartments for the Corcoran Group. The one job she’d never had, Belle informed New York’s profile writer, was the occupation Going Down’s 19-year-old protagonist takes up to pay for college: call girl. That is indeed what happens in the summer of 1982 to Swanna Swain. Her parents, like Belle’s, are recently separated. Her mother, like Belle’s, is a Guggenheim-winning poet. Her interests, like Belle’s, would run screaming from the snake-infested woods of Vermont, where her mom’s new boyfriend has a room at an artists’ retreat, and toward the landmarks of 1980s Manhattan: Canal Jeans, O’Neals’ Baloon, Woody Allen.\r\n\r\nThen the novel, which Akashic describes as “a kind of inverse Lolita,” reaches its midway point, and Swanna does something Belle never did. “I never got into an older man’s car and went to his house for two days or three days while his wife was away in England,” she says. “It’s more of a composite of older men I dated, which was not unusual back in 1982 or ’3 or ’4 or ’5, or probably today. I mean, I don’t know anybody who didn’t make out with the bartender at their friend’s bar mitzvah or the limo driver at the prom.”\r\n\r\nIs it wise for a novelist with a history of being confused for her characters to write about a teenage seductress? Maybe not. But Belle, who’s girded herself for her first interview in 12 years with red lipstick and a pair of miniature Barbie doll earrings, is the type of raconteur who can’t resist a good punchline, even when she knows it’ll get in her trouble. “Your editor thought you’d be a good match for a book about pedophilia?” she quips, two minutes into our conversation.\r\n\r\nIn a more reflective moment, Belle says that Swanna “never feels like a victim. I think she probably is a victim because she’s 14 and she’s having an affair with a 37-year-old married man. But she doesn’t feel that way for one minute. She thinks she’s in control and she really thinks she’s in love.”\r\n\r\nThough the parallels to Lolita are clear, a different novel served as the inspiration for Swanna’s story: Charles Portis’s True Grit. Belle, who was given a copy by someone in her writing workshop—she runs four of them out of her apartment and has helped shepherd into print novels by Nicola Harrison and Marilyn Simon Rothstein—says it “looked like nothing I would be interested in whatsoever. It has a gun on the cover. But something about reading this book about a 14-year-old girl who sets out to avenge her father’s murder—and she’s unapologetic and she’s cool and she’s tough—something just went off in my head. That I could tell my story the way I wanted to tell it. But I had to make the book more than just being picked up and going to this artist colony that didn’t allow kids. So, I added stuff.”\r\n\r\nOf course, it’s the stuff Belle added that may land her in hot water. Why take the risk? Partly, she says, because she’s “so unhappy with the state of publishing—the censorship going on all over the place.” Asked for an example, she points to a former member of her workshop, Jeanine Cummins, whose 2020 bestseller American Dirt met with fierce backlash from Latinx writers who accused Cummins and her publisher, Flatiron Books, of exploiting their stories.\r\n\r\n“Basically, every single publishing house wanted this book,” Belle says. “And by the end of her journey, she was canceled. All the publishers should have stood up and said, ‘We wanted this book. We decide who gets to tell what story. Not one person on the internet.’ ”\r\n\r\nBelle notes that when her agent, Sterling Lord Literistic’s Doug Stewart (who also reps Cummins), sent Swanna in Love “around to all the big people, they said, ‘Great writing. We love her. But we don’t have a vision for it.’ That was the word I got. I thought I’d be on Zooms with people, and they’d say, ‘Let’s make her older,’ or, ‘Let’s make him younger.’ But what I found were no Zooms, just this language about ‘vision.’ ”\r\n\r\nBelle counts herself lucky to have landed at Akashic, which she’s admired “from the very beginning” (her friend Arthur Nersesian’s The Fuck-Up was the indie press’s first release, in 1997). And while the crusader in her is ready to defend the idea that “people have the right to write whatever they want,” the novelist in her is mainly just thrilled to have unlocked a story she’s been trying to tell for a long time.\r\n\r\nOriginally planned as a flashback in another novel, Swanna in Love came “pouring out” of Belle during Covid lockdowns, when she spent 14 weeks with her husband and two sons in their Hudson Valley country house. “I had never spent 14 days in that house,” she says. “And what I discovered is, I really don’t like it there. I just hated it so much. Something about connecting with that feeling of powerlessness, of having no control over your environment, like when you’re 14 or 15 or 16, brought this character out of me.”\r\n\r\n“I have spent a decade helping other people get published,” Belle says at another point in the conversation. “And writing also, but not writing what I wanted to write. And then something changed. I got brave. Maybe I’ll change my mind. I’ve regretted everything I’ve ever done in my life, so it wouldn’t surprise me.”",
                        Thumbnail = "jennifer-belle-gets-brave-and-regrets-everything.jpg",
                        Published = true,
                        Alias = "jennifer-belle-gets-brave-and-regrets-everything",
                        CreateDate = DateTime.Now,
                        Author = "David Adams",
                        Tags = "Jennifer Belle Gets Brave and Regrets Everything",
                        IsHot = true,
                        IsNewFeed = true,
                        MetaDesc = "Jennifer Belle Gets Brave and Regrets Everything",
                        MetaKey = "Jennifer Belle Gets Brave and Regrets Everything",
                    }

                    );
        }
        public static void PaymentData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentModel>().HasData(
                    new PaymentModel() { PaymentId = 1, PaymentMethod = "Paypal" },
                    new PaymentModel() { PaymentId = 2, PaymentMethod = "Cash on deliveryy" }
                );
        }
        public static void LocationData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LocationModel>().HasData(
            #region Thành Phố Hà Nội
                new LocationModel()
                {
                    LocationId = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                    Name = "Hà Nội",
                    Type = "Tỉnh/Thành",
                    NameWithType = "TP. Hà Nội",
                    Levels = 1
                },
                    //oke
            #region Quận Ba Đình 
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Name = "Ba Đình",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận Hà Nội",
                        Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                        Levels = 2
                    },
            #region Phường xã thuộc Quận Ba Đình
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cống Vị",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cống Vị",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Điện Biên",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Điện Biên",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Đội Cấn",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Đội Cấn",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Giảng Võ",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Giảng Võ",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Kim Mã",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Kim Mã",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Liễu Giai",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Liễu Giai",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Ngọc Hà",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Ngọc Hà",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Ngọc Khánh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Ngọc Khánh",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Nguyễn Trung Trực",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Nguyễn Trung Trực",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phúc Xá",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phúc Xá",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Quán Thánh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Quán Thánh",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thành Công",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thành Công",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Trúc Bạch",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Trúc Bạch",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Phúc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Vĩnh Phúc",
                        Parent = Guid.Parse("51438FD1-5FCF-47B3-A3EA-6183887CB20E"),
                        Levels = 3
                    },

            #endregion

            #endregion // oke 
            #region Quận Bắc Từ Liêm
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Name = "Bắc Từ Liêm",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận Bắc Từ Liêm",
                        Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                        Levels = 2
                    },
            #region Phường xã thuộc bắc từ liêm
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cổ Huế 1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cổ Huế 1",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cổ Huế 2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cổ Huế 2",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Đức Thắng",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Đức Thắng",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Đông Ngạc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Đông Ngạc",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thụy Phương",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thụy Phương",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Liên Mạc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Liên Mạc",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thượng Cát",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thượng Cát",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tây Tựu",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tây Tựu",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Minh Khai",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Minh Khai",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phú Diễn",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phú Diễn",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phúc Diễn",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phúc Diễn",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Xuân Đỉnh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Xuân Đỉnh",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Xuân Tảo",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Xuân Tảo",
                        Parent = Guid.Parse("644D658B-DCAC-42C6-90AF-22E527F9E2B6"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #region Quận Cầu Giấy
                new LocationModel()
                {
                    LocationId = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Name = "Bắc Cầu Giấy",
                    Type = "Quận/Huyện",
                    NameWithType = "Quận Cầu Giấy",
                    Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                    Levels = 2
                },
            #region Phường xã cầu giấy
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Dịch Vọng",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Dịch Vọng",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Dịch Vọng Hậu",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Dịch Vọng Hậu",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Mai Dịch",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Mai Dịch",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Nghĩa Đô",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Nghĩa Đô",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Nghĩa Tân",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Nghĩa Tân",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Quan Hoa",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Quan Hoa",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Trung Hòa",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Trung Hòa",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Yên Hòa",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Yên Hòa",
                    Parent = Guid.Parse("D6DE1CD7-94E3-4F61-B464-167ED8CE2B5F"),
                    Levels = 3
                },
            #endregion
            #endregion
            #region Quận Đống Đa
                new LocationModel()
                {
                    LocationId = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Name = "Đống Đa",
                    Type = "Quận/Huyện",
                    NameWithType = "Quận Đống Đa",
                    Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                    Levels = 2
                },
            #region Phường xã đống đa
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Cát Linh",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Cát Linh",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Hàng Bột",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Hàng Bột",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Khâm Thiên",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Khâm Thiên",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Khương Thượng",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Khương Thượng",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Kim Liên",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Kim Liêng",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Láng Hạ",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Láng Hạ",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Láng Thượng",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Láng Thượng",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Nam Đồng",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Nam Đồng",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Ngã Tư Sở",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Ngã Tư Sở",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Ô Chợ Dừa",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Ô Chợ Dừa",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phương Liên",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phương Liên",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phương Mai",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phương Mai",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Quang Trung",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Quang Trung",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Quốc Tử Giám",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Quốc Tử Giám",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Thịnh Quang",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Thịnh Quang",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Thổ Quan",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Thổ Quan",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Trung Liệt",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Trung Liệt",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Trung Phụng",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Trung Phụng",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Trung Tự",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Trung Tự",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Văn Chương",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Văn Chương",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Văn Miếu",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Văn Miếu",
                    Parent = Guid.Parse("A43DB02E-6AB4-4CA9-93B1-F8F4FD1199DD"),
                    Levels = 3
                },
            #endregion
            #endregion
            #region Quận Hà Đông
                new LocationModel()
                {
                    LocationId = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Name = "Hà Đông",
                    Type = "Quận/Huyện",
                    NameWithType = "Quận Hà Đông",
                    Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                    Levels = 2
                },
            #region phường xã hà đông
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Biên Giang",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Biên Giang",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Đồng Mai",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Đồng Mai",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Yên Nghĩa",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Yên Nghĩa",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Dương Nội",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Dương Nội",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Hà Cầu",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Hà Cầu",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "La Khê",
                    Type = "Phường/Xã",
                    NameWithType = "Phường La Khê",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Mộ Lao",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Mộ Lao",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Nguyễn Trãi",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Nguyễn Trãi",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phú La",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phú La",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phú Lãm",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phú Lãm",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phú Lương",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phú Lương",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Kiếm Hưng",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Kiếm Hưng",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phúc La",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phúc La",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Quang Trung",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Quang Trung",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Vạn Phúc",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Vạn Phúc",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Văn Quán",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Văn Quán",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Yết Kiêu",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Yết Kiêu",
                    Parent = Guid.Parse("B192232C-1639-49DB-825A-963F7CB61B95"),
                    Levels = 3
                },
            #endregion
            #endregion
            #region Quận hai bà trưng
                new LocationModel()
                {
                    LocationId = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Name = "Hai Bà Trưng",
                    Type = "Quận/Huyện",
                    NameWithType = "Quận Hai Bà Trưng",
                    Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                    Levels = 2
                },
            #region PHường xã 2 bà trưng
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Bách Khoa",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Bách Khoa",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Bạch Đằng",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Bạch Đằng",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Bạch Mai",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Bạch Mai",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Cầu Dền",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Cầu Dền",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Đống Mác",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Đống Mác",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Đồng Nhân",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Đồng Nhân",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Đồng Tâm",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Đồng Tâm",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Lê Đại Hành",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Lê Đại Hành",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Minh Khai",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Minh Khai",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Nguyễn Du",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Nguyễn Du",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phạm Đình Hổ",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phạm Đình Hổ",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Phố Huế",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Phố Huế",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Quỳnh Lôi",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Quỳnh Lôi",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Quỳnh Mai",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Quỳnh Mai",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Thanh Lương",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Thanh Lương",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Thanh Nhàn",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Thanh Nhàn",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Trương Định",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Trương Định",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
                new LocationModel()
                {
                    LocationId = Guid.NewGuid(),
                    Name = "Vĩnh Tuy",
                    Type = "Phường/Xã",
                    NameWithType = "Phường Vĩnh Tuy",
                    Parent = Guid.Parse("7BE70774-4B61-466C-A8A2-BDAE4DC15448"),
                    Levels = 3
                },
            #endregion
            #endregion


            #region Quận Hoàn Kiếm
                 new LocationModel()
                 {
                     LocationId = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Name = "Hoàn Kiếm",
                     Type = "Quận/Huyện",
                     NameWithType = "Quận Hoàn Kiếm",
                     Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                     Levels = 2
                 },
            #region Phường hoàn kiếm
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Cửa Đông",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Cửa Đông",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Chương Dương",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Chương Dương",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Đồng Xuân",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Đồng Xuân",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Cửa Nam",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Cửa Nam",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Bài",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Bài",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Bạc",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Bạc",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Bông",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Bông",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Bồ",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Bồ",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Đào",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Đào",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Buồm",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Buồm",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Mã",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Mã",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Gai",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Gai",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Phan Chu Trinh",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Phan Chu Trinh",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Hàng Trống",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Hàng Trống",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Lý Thái Tổ",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Lý Thái Tổ",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Phúc Tân",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Phúc Tân",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Tràng Tiền",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Tràng Tiền",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
                 new LocationModel()
                 {
                     LocationId = Guid.NewGuid(),
                     Name = "Trần Hưng Đạo",
                     Type = "Phường/Xã",
                     NameWithType = "Phường Trần Hưng Đạo",
                     Parent = Guid.Parse("8FE57AF2-B1F5-4F21-91F5-4CBEE0E0926B"),
                     Levels = 3
                 },
            #endregion
            #endregion

            #region Quận Hoàng Mai
                            new LocationModel()
                            {
                                LocationId = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Name = "Hoàn Kiếm",
                                Type = "Quận/Huyện",
                                NameWithType = "Quận Hoàn Kiếm",
                                Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                Levels = 2
                            },
            #region phường xã hoàng mai
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Đại Kim",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Đại Kim",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Định Công",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Định Công",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Giáp Bát",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Giáp Bát",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Hoàng Liệt",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Hoàng Liệt",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Hoàng Văn Thụ",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Hoàng Văn Thụ",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Lĩnh Nam",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Lĩnh Nam",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Mai Động",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Mai Động",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Tân Mai",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Tân Mai",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Thanh Trì",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Thanh Trì",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Thịnh Liệt",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Thịnh Liệt",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Trần Phú",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Trần Phú",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Tương Mai",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Tương Mai",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Vĩnh Hưng",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Vĩnh Hưng",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
                            new LocationModel()
                            {
                                LocationId = Guid.NewGuid(),
                                Name = "Yên Sở",
                                Type = "Phường/Xã",
                                NameWithType = "Phường Yên Sở",
                                Parent = Guid.Parse("BBBAE337-294B-4535-AC03-57C9465FB77C"),
                                Levels = 3
                            },
            #endregion
            #endregion

            #region quận long biên
                          new LocationModel()
                          {
                              LocationId = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Name = "Long Biên",
                              Type = "Quận/Huyện",
                              NameWithType = "Quận Long Biên",
                              Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                              Levels = 2
                          },
            #region phường xã long biên
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Bồ Đề",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Bồ Đề",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Cự Khối",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Cự Khối",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Đức Giang",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Đức Giang",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Gia Thụy",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Gia Thụy",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Giang Biên",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Giang Biên",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Long Biên",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Long Biên",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Ngọc Lâm",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Ngọc Lâm",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Ngọc Thụy",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Ngọc Thụy",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Phúc Đồng",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Phúc Đồng",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Phúc Lợi",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Phúc Lợi",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Sài Đồng",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Sài Đồng",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Thạch Bàn",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Thạch Bàn",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Thượng Thanh",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Thượng Thanh",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },
                          new LocationModel()
                          {
                              LocationId = Guid.NewGuid(),
                              Name = "Việt Hưng",
                              Type = "Phường/Xã",
                              NameWithType = "Phường Việt Hưng",
                              Parent = Guid.Parse("EB73F3A7-D6E8-4C56-8149-E6E45052CD3F"),
                              Levels = 3
                          },

            #endregion
            #endregion

            #region Quận Nam Từ Liêm
                              new LocationModel()
                              {
                                  LocationId = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Name = "Nam Từ Liêm",
                                  Type = "Quận/Huyện",
                                  NameWithType = "Quận Nam Từ Liêm",
                                  Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                  Levels = 2
                              },
            #region phường xã nam từ liêm
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Cầu Diễn",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Cầu Diễn",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Mỹ Đình 1",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Mỹ Đình 1",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Mỹ Đình 2",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Mỹ Đình 2",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Phú Đô",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Phú Đô",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Mễ Tri",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Mễ Tri",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Trung Văn",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Trung Văn",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Đại Mỗ",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Đại Mỗ",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Tây Mỗ",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Tây Mỗ",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Phương Canh",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Phương Canh",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
                              new LocationModel()
                              {
                                  LocationId = Guid.NewGuid(),
                                  Name = "Xuân Phương",
                                  Type = "Phường/Xã",
                                  NameWithType = "Phường Xuân Phương",
                                  Parent = Guid.Parse("C89114D4-5C9E-45C4-B66D-22268860D81A"),
                                  Levels = 3
                              },
            #endregion
            #endregion

            #region Quận Tây Hồ
                               new LocationModel()
                               {
                                   LocationId = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Name = "Nam Tây Hồ",
                                   Type = "Quận/Huyện",
                                   NameWithType = "Quận Tây Hồ",
                                   Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                   Levels = 2
                               },
            #region phường xã tây hồ
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Bưởi",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Bưởi",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Nhật Tân",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Nhật Tân",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Thượng",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Phú Thượng",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Quảng An",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Quảng An",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thụy Khuê",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Thụy Khuê",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tứ Liên",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Tứ Liên",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Xuân La",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Xuân La",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Yên Phụ",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Yên Phụ",
                                   Parent = Guid.Parse("7748E80C-F132-40AE-A85A-BBD130E22993"),
                                   Levels = 3
                               },
            #endregion
            #endregion
            #region quận Thanh Xuân
                               new LocationModel()
                               {
                                   LocationId = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Name = "Thanh Xuân",
                                   Type = "Quận/Huyện",
                                   NameWithType = "Quận Thanh Xuân",
                                   Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                   Levels = 2
                               },
            #region phường xã thanh xuân
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Hạ Đình",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Hạ Đình",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Khương Đình",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Khương Đình",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Khương Mai",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Khương Mai",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Khương Trung",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Khương Trung",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Kim Giang",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Kim Giang",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Nhân Chính",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Nhân Chính",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phương Liệt",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Phương Liệt",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thanh Xuân Bắc",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Thanh Xuân Bắc",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thanh Xuân Nam",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Thanh Xuân Nam",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thanh Xuân Trung",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Thanh Xuân Trung",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thượng Đình",
                                   Type = "Phường/Xã",
                                   NameWithType = "Phường Thượng Đình",
                                   Parent = Guid.Parse("299C54BF-C324-43C7-997A-6CCE1E1BB4E6"),
                                   Levels = 3
                               },
            #endregion
            #endregion
            #region Huyện Ba Vì
                               new LocationModel()
                               {
                                   LocationId = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Name = "Ba Vì",
                                   Type = "Quận/Huyện",
                                   NameWithType = "Huyện Ba Vì",
                                   Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                   Levels = 2
                               },
            #region phường xã ba vì
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tây Đằng",
                                   Type = "Phường/Xã",
                                   NameWithType = "Thị Trấn Tây Đằng",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Ba Trại",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Ba Trại",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Ba Vì",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Ba Vì",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Cẩm Lĩnh",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Cẩm Lĩnh",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Cam Thượng",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Cam Thượng",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Châu Sơn",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Châu Sơn",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Chu Minh",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Chu Minh",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Cổ Đô",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Cổ Đô",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Đông Quang",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Đông Quang",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Đồng Thái",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Đồng Thái",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Khánh Thượng",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Khánh Thượng",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Minh Châu",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Minh Châu",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Minh Quang",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Minh Quang",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phong Vân",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phong Vân",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Châu",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phú Châu",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Cường",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phú Cường",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Đông",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phú Đông",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Phương",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phú Phương",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Sơn",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phú Sơn",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Sơn Đà",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Sơn Đà",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tản Hồng",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Tản Hồng",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tản Lĩnh",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Tản Lĩnh",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thái Hòa",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Thái Hòa",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thuần Mỹ",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Thuần Mỹ",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thụy An",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Thụy An",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tiên Phong",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Tiên Phong",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tòng Bạc",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Tòng Bạc",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Vân Hóa",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Vân Hóa",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Vạn Thắng",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Vạn Thắng",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Vật Lại",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Vật Lại",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Yên Bài",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Yên Bài",
                                   Parent = Guid.Parse("453FE1E3-207A-462F-B7B5-E9D7F876C68E"),
                                   Levels = 3
                               },
            #endregion
            #endregion
            #region Huyện Chương Mỹ
                               new LocationModel()
                               {
                                   LocationId = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Name = "Chương Mỹ",
                                   Type = "Quận/Huyện",
                                   NameWithType = "Huyện Chương Mỹ",
                                   Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                   Levels = 2
                               },
            #region phường xã chương mỹ
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Chúc Sơn",
                                   Type = "Phường/Xã",
                                   NameWithType = "Thị Trấn Chúc Sơn",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Xuân Mai",
                                   Type = "Phường/Xã",
                                   NameWithType = "Thị Trấn Xuân Mai",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Đại Yên",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Đại Yên",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Đông Phương Yên",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Đông Phương Yên",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Đông Sơn",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Đông Sơn",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Đồng Lạc",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Đồng Lạc",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Đồng Phú",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Đồng Phú",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Hòa Chính",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Hòa Chính",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Hoàng Diệu",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Hoàng Diệu",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Hoàng Văn Thụ",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Hoàng Văn Thụ",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Hồng Phong",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Hồng Phong",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Hợp Đồng",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Hợp Đồng",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Hữu Văn",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Hữu Văn",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Lam Điền",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Lam Điền",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Mỹ Lương",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Mỹ Lương",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Nam Phương Tiến",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Nam Phương Tiến",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Ngọc Hòa",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Ngọc Hòa",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Nam An",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phú Nam An",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phú Nghĩa",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phú Nghĩa",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Phụng Châu",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Phụng Châu",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Quảng Bị",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Quảng Bị",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tân Tiến",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Tân Tiến",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tiên Phương",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Tiên Phương",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Tốt Động",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Tốt Động",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thanh Bình",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Thanh Bình",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thủy Sơn Tiên",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Thủy Sơn Tiên",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thụy Hương",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Thụy Hương",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Thượng Vực",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Thượng Vực",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Trần Phú",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Trần Phú",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Trung Hòa",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Trung Hòa",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
                               new LocationModel()
                               {
                                   LocationId = Guid.NewGuid(),
                                   Name = "Trường Yên",
                                   Type = "Phường/Xã",
                                   NameWithType = "Xã Trường Yên",
                                   Parent = Guid.Parse("87829A37-089F-4079-A68C-2CEEBABE9A8A"),
                                   Levels = 3
                               },
            #endregion
            #endregion
            #region huyện Đan Phượng
                                 new LocationModel()
                                 {
                                     LocationId = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Name = "Đan Phương",
                                     Type = "Quận/Huyện",
                                     NameWithType = "Huyện Đan Phương",
                                     Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                     Levels = 2
                                 },
            #region xã đan phượng
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Đan Phượng",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Đan Phượng",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Đồng Tháp",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Đồng Tháp",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Hạ Mỗ",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Hạ Mỗ",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Hồng Hà",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Hồng Hà",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Liên Hà",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Liên Hà",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Liên Hồng",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Liên Hồng",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Liên Trung",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Liên Trung",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
                                 new LocationModel()
                                 {
                                     LocationId = Guid.NewGuid(),
                                     Name = "Thọ Trung",
                                     Type = "Phường/Xã",
                                     NameWithType = "Xã Thọ Trung",
                                     Parent = Guid.Parse("214B982C-8805-4897-8E86-9E7D6C644EB5"),
                                     Levels = 3
                                 },
            #endregion
            #endregion
            #region huyện đông anh
                                     new LocationModel()
                                     {
                                         LocationId = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Name = "Đông Anh",
                                         Type = "Quận/Huyện",
                                         NameWithType = "Huyện Đông Anh",
                                         Parent = Guid.Parse("AB0A3D49-4943-447D-A755-C13B00F8181D"),
                                         Levels = 2
                                     },
            #region xã đông anh
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Bắc Hồng",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Bắc Hồng",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Cổ Loa",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Cổ Loa",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Dục Tú",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Dục Tú",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Kim Chung",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Kim Chung",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Văn Nội",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Văn Nội",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Việt Hùng",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Việt Hùng",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Võng La",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Võng La",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
                                     new LocationModel()
                                     {
                                         LocationId = Guid.NewGuid(),
                                         Name = "Xuân Canh",
                                         Type = "Phường/Xã",
                                         NameWithType = "Xã Xuân Canh",
                                         Parent = Guid.Parse("2B7CF31E-456D-4674-827E-0868120DA973"),
                                         Levels = 3
                                     },
            #endregion
            #endregion
                    // check tu day
            #endregion
            #region Tỉnh Khánh Hòa
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("09D71DA2-6869-48E1-B7FB-418A162BC6AB"),
                        Name = "Khánh Hòa",
                        Type = "Tỉnh/Thành",
                        NameWithType = "Tỉnh Khánh Hòa",
                        Levels = 1
                    },
            #region Nha Trang
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Name = "Nha Trang",
                        Type = "Quận/Huyện",
                        NameWithType = "TP.Nha Trang",
                        Parent = Guid.Parse("09D71DA2-6869-48E1-B7FB-418A162BC6AB"),
                        Levels = 2
                    },
            #region phường xã nha trang
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Lộc Thọ",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Lộc Thọ",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Ngọc Hiệp",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Ngọc Hiệp",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Hải",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Hải",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Hòa",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Hòa",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Long",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Long",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Tiến",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Tiến",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Tân",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Tân",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phương Sài",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phương Sài",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Hải",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Vĩnh Hải",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Hòa",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Vĩnh Hòa",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Phước",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Vĩnh Phước",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Nguyên",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Vĩnh Nguyên",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Trường",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Vĩnh Trường",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Đồng",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Phước Đồng",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Lương",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Vĩnh Lương",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Thái",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Vĩnh Thái",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Trung",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Vĩnh Trung",
                        Parent = Guid.Parse("1AD0946C-B04C-4F57-9F3F-68F93A6AB624"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region Cam Ranh
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Name = "Cam Ranh",
                        Type = "Quận/Huyện",
                        NameWithType = "TP.Cam Ranh",
                        Parent = Guid.Parse("09D71DA2-6869-48E1-B7FB-418A162BC6AB"),
                        Levels = 2
                    },
            #region xã cam ranh
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Ba Ngòi",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Ba Ngòi",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cam Lộc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cam Lộc",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cam Lợi",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cam Lợi",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cam Linh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cam Linh",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cam Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cam Thuận",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cam Phú",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cam Phú",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cam Phú Bắc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cam Phú Bắc",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Cam Phú Nam",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Cam Phú Nam",
                        Parent = Guid.Parse("A82D16B2-87AD-4EFD-B9BE-F44C8A2489F9"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region Khánh Vĩnh
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Name = "Khánh Vĩnh",
                        Type = "Quận/Huyện",
                        NameWithType = "Huyện Khánh Vĩnh",
                        Parent = Guid.Parse("09D71DA2-6869-48E1-B7FB-418A162BC6AB"),
                        Levels = 2
                    },
            #region phường khánh vĩnh
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khánh Hiệp",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Khánh Hiệp",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khánh Bình",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Khánh Bình",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khánh Trung",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Khánh Trung",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khánh Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Khánh Đông",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khánh Thượng",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Khánh Thượng",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Sông Cầu",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Sông Cầu",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Liên Sang",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Liên Sang",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khánh Phú",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Khánh Phú",
                        Parent = Guid.Parse("6DA0E1E2-7DA9-4D13-97CB-ABF993072DF3"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region diên khánh
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Name = "Diên Khánh",
                        Type = "Quận/Huyện",
                        NameWithType = "Huyện Diên Khánh",
                        Parent = Guid.Parse("09D71DA2-6869-48E1-B7FB-418A162BC6AB"),
                        Levels = 2
                    },
            #region xã Diên Khánh
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Phước",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Phước",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Lạc",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Lạc",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Tân",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Tân",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Hòa",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Hòa",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Thạnh",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Thạnh",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Toàn",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Toàn",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên An",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên An",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Bình",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Bình",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Diên Lộc",
                        Type = "Phường/Xã",
                        NameWithType = "Xã Diên Lộc",
                        Parent = Guid.Parse("60EAB0C3-BED9-4BD6-807A-EA1115DCF3ED"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #endregion
            #region Tp.HCM
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Name = "Hồ Chí Minh",
                        Type = "Tỉnh/Thành",
                        NameWithType = "TP.Hồ Chí Minh",
                        Levels = 1
                    },
            #region Quận 1
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                        Name = "1",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 1",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường quận 1
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Bến Nghé",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Bến Nghé",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Bến Thành",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Bến Thành",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Cô Giang",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Cô Giang",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Cầu Kho",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Cầu Kho",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Cầu Ông Lãnh",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Cầu Ông Lãnh",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Nguyễn Cư Trinh",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Nguyễn Cư Trinh",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Nguyễn Thái Bình",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Nguyễn Thái Bình",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Phạm Ngũ Lão",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Phạm Ngũ Lão",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Phạm Tân Định",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Tân Định",
                         Parent = Guid.Parse("D18996F9-2298-4218-B671-4ED4D8B798A5"),
                         Levels = 3
                     },
            #endregion
            #endregion
            #region quận 3
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Name = "3",
                         Type = "Quận/Huyện",
                         NameWithType = "Quận 3",
                         Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                         Levels = 2
                     },
            #region phường q3
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "1",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 1",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "2",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 2",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "3",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 3",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "4",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 4",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "5",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 5",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "6",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 6",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "7",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 7",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "8",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 8",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "9",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 9",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "10",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 10",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "11",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 11",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "12",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 12",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "13",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 13",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "14",
                         Type = "Phường/Xã",
                         NameWithType = "Phường 14",
                         Parent = Guid.Parse("49A31A33-2137-4E55-9345-1197103B429A"),
                         Levels = 3
                     },
            #endregion
            #endregion
            #region quận 2
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Name = "2",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 2",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q2
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "An Khánh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường An Khánh",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "An Lợi Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường An Lợi Đông",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "An Phú",
                        Type = "Phường/Xã",
                        NameWithType = "Phường An Phú",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bình An",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bình An",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bình Khánh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bình Khánh",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bình Trưng Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bình Trưng Đông",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bình Trưng Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bình Trưng Tây",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bình Cát Lái",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bình Cát Lái",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thạnh Mỹ Lợi",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thạnh Mỹ Lợi",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thảo Điền",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thảo Điền",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thủ Thiêm",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thủ Thiêm",
                        Parent = Guid.Parse("9DDE39C2-B8B9-4D35-B115-74315FE0BA17"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận 4
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Name = "4",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 4",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q4
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "14",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 14",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "15",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 15",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "16",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 16",
                        Parent = Guid.Parse("AAC2FE9D-CC17-44FD-A065-6C99D9C4CAD5"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận 5
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Name = "5",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 5",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q5
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 4",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "14",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 14",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "15",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 15",
                        Parent = Guid.Parse("C62BB4BC-ED58-4D24-969D-1F8217604943"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận 6
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Name = "6",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 6",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q6
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 4",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "14",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 14",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "15",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 15",
                        Parent = Guid.Parse("9D3285D1-FF8A-44E0-A3C4-BE8AB5B449F9"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận 7
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Name = "7",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 7",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q7
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Thuận Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Thuận Đông",
                        Parent = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Thuận Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Thuận Tây",
                        Parent = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Kiểng",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Kiểng",
                        Parent = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Hưng",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Hưng",
                        Parent = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bình Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bình Thuận",
                        Parent = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Quy",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Quy",
                        Parent = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phú Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phú Thuận",
                        Parent = Guid.Parse("9946273B-38FD-41CA-B82B-3B08352F974D"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận 8
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Name = "8",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 8",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q8
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 4",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 14",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 14",
                        Parent = Guid.Parse("B0D2839E-183C-43F2-9209-D697DF7860D4"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận 10
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Name = "10",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 10",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q10
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 4",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 14",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 14",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 15",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 15",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 16",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 16",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 17",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 17",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 18",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 18",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 19",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 19",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 20",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 20",
                        Parent = Guid.Parse("50245F51-EF5B-4639-851F-7E92BF7D0F11"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #region quận 11
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Name = "11",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 11",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q11
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 4",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phường 13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("158D1541-BD3F-4D74-B860-F7A7815E7DB7"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #region quận 12
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Name = "12",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận 12",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường q12
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thạnh Lộc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thạnh Lộc",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hiệp Thành",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hiệp Thành",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thới An",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thới An",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Chánh Hiệp",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Chánh Hiệp",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "An Phú Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường An Phú Đông",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Thới Hiệp",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Thới Hiệp",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Trung Mỹ Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Trung Mỹ Tây",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Hưng Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Hưng Thuận",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Đông Hưng Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Đông Hưng Thuận",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Thới Nhất",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Thới Nhất",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Xuân",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Xuân",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tam Bình",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tam Bình",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hiệp Bình Phước",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hiệp Bình Phước",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hiệp Bình Chánh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hiệp Bình Chánh",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Trung",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Trung",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Tây",
                        Parent = Guid.Parse("E7ACFBDA-7650-4013-AB3C-D274A1F7C7C3"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #region quận tb
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Name = "Tân Bình",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận Tân Bình",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường qtb
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 4",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "14",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 14",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "15",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 15",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "16",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 16",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "17",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 17",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "18",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 18",
                        Parent = Guid.Parse("303EAF9E-12A9-412C-B786-0C57C2458D0A"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #region quận gv
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Name = "Gò Vấp",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận Gò Vấp",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường gv
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "4",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 4",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "8",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 8",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "9",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 9",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "10",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 10",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("257F44B6-5CE3-4052-9D67-F6F7BCD16210"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #region quận td
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Name = "Thủ Đức",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận Thủ Đức",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường td
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hiệp Bình Chánh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hiệp Bình Chánh",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hiệp Bình Phước",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hiệp Bình Phước",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Chiểu",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Chiểu",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Đông",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Tây",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Trung",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Trung",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Linh Xuân",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Linh Xuân",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tam Bình",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tam Bình",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tam Phú",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tam Phú",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Trường Thọ",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Trường Thọ",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Chánh Hiệp",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Chánh Hiệp",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Hưng Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Hưng Thuận",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tân Thới Hiệp",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tân Thới Hiệp",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tăng Nhơn Phú A",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tăng Nhơn Phú A",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tăng Nhơn Phú B",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tăng Nhơn Phú B",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Trường Thạnh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Trường Thạnh",
                        Parent = Guid.Parse("1D924D2C-A3D1-4E9A-B7C6-599A84A0FCDC"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #region quận bình thạnh
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Name = "Bình Thạnh",
                        Type = "Quận/Huyện",
                        NameWithType = "Quận Bình Thạnh",
                        Parent = Guid.Parse("E460197D-0956-4EB3-8363-5BD892D1EA36"),
                        Levels = 2
                    },
            #region phường bình thạnh
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "1",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 1",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "2",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 2",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "3",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 3",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "5",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 5",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "6",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 6",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "7",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 7",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "11",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 11",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "12",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 12",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "13",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 13",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "14",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 14",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "15",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 15",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "17",
                        Type = "Phường/Xã",
                        NameWithType = "Phường 17",
                        Parent = Guid.Parse("01558079-0710-4141-A885-E8C25BA6ADCF"),
                        Levels = 3
                    },

            #endregion
            #endregion
            #endregion
            #region Tp.Đà Nẵng
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("0140F9E9-5FA0-4BDB-BFFB-B2C4FE4C3EC9"),
                         Name = "Đà Nẵng",
                         Type = "Tỉnh/Thành",
                         NameWithType = "TP.Đà Nẵng",
                         Levels = 1
                     },

            #region quận linh chiếu
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                         Name = "Linh Chiếu",
                         Type = "Quận/Huyện",
                         NameWithType = "Quận Linh Chiếu",
                         Parent = Guid.Parse("0140F9E9-5FA0-4BDB-BFFB-B2C4FE4C3EC9"),
                         Levels = 2
                     },
            #region phường quận linh chiếu
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Hòa Hiệp Bắc",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Hòa Hiệp Bắc",
                         Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                         Levels = 3
                     },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Hiệp Nam",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Hiệp Nam",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Khương",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Khương",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Minh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Minh",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Quý",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Quý",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Thọ Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Thọ Đông",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Thọ Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Thọ Tây",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Xuân",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Xuân",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khuê Trung",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Khuê Trung",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Phát",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Phát",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Khánh Bắc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Khánh Bắc",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Khánh Nam",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Khánh Nam",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Minh Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Minh Tây",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Phú",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Phú",
                        Parent = Guid.Parse("F883C0EA-A18A-4334-BE88-83EDE3003098"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận Thanh Khê
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                         Name = "Thanh Khê",
                         Type = "Quận/Huyện",
                         NameWithType = "Quận Thanh Khê",
                         Parent = Guid.Parse("0140F9E9-5FA0-4BDB-BFFB-B2C4FE4C3EC9"),
                         Levels = 2
                     },
            #region phường quận Thanh Khê
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "An Khê",
                         Type = "Phường/Xã",
                         NameWithType = "Phường An Khê",
                         Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                         Levels = 3
                     },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Chính Gián",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Chính Gián",
                        Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Khê",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Khê",
                        Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tam Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tam Thuận",
                        Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thanh Khê Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thanh Khê Đông",
                        Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thanh Khê Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thanh Khê Tây",
                        Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Vĩnh Trung",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Vĩnh Trung",
                        Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Xuân Hà",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Xuân Hà",
                        Parent = Guid.Parse("815A6281-8F81-45F4-BC6D-4B052342857E"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận Hải Châu
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                         Name = "Hải Châu",
                         Type = "Quận/Huyện",
                         NameWithType = "Phường Hải Châu",
                         Parent = Guid.Parse("0140F9E9-5FA0-4BDB-BFFB-B2C4FE4C3EC9"),
                         Levels = 2
                     },
            #region phường quận Hải Châu
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Bình Hiên",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Bình Hiên",
                         Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                         Levels = 3
                     },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bình Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bình Thuận",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hải Châu  I",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hải Châu I",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hải Châu II",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hải Châu II",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Cường Bắc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Cường Bắc",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Cường Nam",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Cường Nam",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Cường Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Cường Đông",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Nam Dương",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Nam Dương",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Ninh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Ninh",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thạch Thang",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thạch Thang",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thanh Bình",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thanh Bình",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thuận Phước",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thuận Phước",
                        Parent = Guid.Parse("BDD49C9A-01EE-4D69-9E26-10AF8E1F61F7"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận Sơn Trà
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                         Name = "Sơn Trà",
                         Type = "Quận/Huyện",
                         NameWithType = "Quận Sơn Trà",
                         Parent = Guid.Parse("0140F9E9-5FA0-4BDB-BFFB-B2C4FE4C3EC9"),
                         Levels = 2
                     },
            #region phường quận Sơn Trà
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "An Hải Bắc",
                         Type = "Phường/Xã",
                         NameWithType = "Phường An Hải Bắc",
                         Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                         Levels = 3
                     },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "An Hải Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường An Hải Đông",
                        Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "An Hải Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường An Hải Tây",
                        Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Mân Thái",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Mân Thái",
                        Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Nại Hiên Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Nại Hiên Đông",
                        Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Mỹ",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Mỹ",
                        Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thọ Quang",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thọ Quang",
                        Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phước Ninh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phước Ninh",
                        Parent = Guid.Parse("D227A999-6712-4E27-B93C-E4A0DE49B16C"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận Ngũ hành sơn
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("88FCC7A5-0C04-448F-9239-6C19D377884E"),
                         Name = "Ngũ Hành Sơn",
                         Type = "Quận/Huyện",
                         NameWithType = "Quận Ngũ Hành Sơn",
                         Parent = Guid.Parse("0140F9E9-5FA0-4BDB-BFFB-B2C4FE4C3EC9"),
                         Levels = 2
                     },
            #region phường quận Ngũ hành sơn
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Hòa Hải",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Hòa Hải",
                         Parent = Guid.Parse("88FCC7A5-0C04-448F-9239-6C19D377884E"),
                         Levels = 3
                     },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Khuê Mỹ",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Khuê Mỹ",
                        Parent = Guid.Parse("88FCC7A5-0C04-448F-9239-6C19D377884E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Mỹ An",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Mỹ An",
                        Parent = Guid.Parse("88FCC7A5-0C04-448F-9239-6C19D377884E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Mỹ Đa",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Mỹ Đa",
                        Parent = Guid.Parse("88FCC7A5-0C04-448F-9239-6C19D377884E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Mỹ An",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Mỹ An",
                        Parent = Guid.Parse("88FCC7A5-0C04-448F-9239-6C19D377884E"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thanh Khê Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thanh Khê Đông",
                        Parent = Guid.Parse("88FCC7A5-0C04-448F-9239-6C19D377884E"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region quận Cẩm lệ
                     new LocationModel()
                     {
                         LocationId = Guid.Parse("6EDB696A-8413-4F93-8E72-BBBE00D0439A"),
                         Name = "Cẩm Lệ",
                         Type = "Quận/Huyện",
                         NameWithType = "Quận Cẩm Lệ",
                         Parent = Guid.Parse("0140F9E9-5FA0-4BDB-BFFB-B2C4FE4C3EC9"),
                         Levels = 2
                     },
            #region phường quận Cẩm lệ
                     new LocationModel()
                     {
                         LocationId = Guid.NewGuid(),
                         Name = "Hòa Thọ Đông",
                         Type = "Phường/Xã",
                         NameWithType = "Phường Hòa Thọ Đông",
                         Parent = Guid.Parse("6EDB696A-8413-4F93-8E72-BBBE00D0439A"),
                         Levels = 3
                     },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Thọ Tây",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Thọ Tây",
                        Parent = Guid.Parse("6EDB696A-8413-4F93-8E72-BBBE00D0439A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Phát",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Phát",
                        Parent = Guid.Parse("6EDB696A-8413-4F93-8E72-BBBE00D0439A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa An",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa An",
                        Parent = Guid.Parse("6EDB696A-8413-4F93-8E72-BBBE00D0439A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hòa Thọ Đông",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hòa Thọ Đông",
                        Parent = Guid.Parse("6EDB696A-8413-4F93-8E72-BBBE00D0439A"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #endregion
            #region Tỉnh Hà Tĩnh
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("F58B06B8-BB4C-4D13-BC63-AA5E092D7949"),
                        Name = "Hà Tĩnh",
                        Type = "Tỉnh/Thành",
                        NameWithType = "Tỉnh Hà Tĩnh",
                        Levels = 1
                    },
            #region tp.hà tĩnh
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Name = "Hà Tĩnh",
                        Type = "Quận/Huyện",
                        NameWithType = "TP.Hà Tĩnh",
                        Parent = Guid.Parse("F58B06B8-BB4C-4D13-BC63-AA5E092D7949"),
                        Levels = 2
                    },
            #region phường hà tĩnh
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Trần Phú",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Trần Phú",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Nam Hà",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Nam Hà",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bắc Hà",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bắc Hà",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Nguyễn Du",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Nguyễn Du",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Đại Nài",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Đại Nài",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Thạch Linh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Thạch Linh",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Văn Yên",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Văn Yên",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "North Carolina",
                        Type = "Phường/Xã",
                        NameWithType = "Phường North Carolina",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Ohio",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Ohio",
                        Parent = Guid.Parse("57C28592-B979-42A9-9A8B-F71C7E21C01A"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region tx hồng lĩnh
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("24B62611-1759-45BC-A0A7-AB678C9BA256"),
                        Name = "Hồng Lĩnh",
                        Type = "Thị xã",
                        NameWithType = "Thị xã Hồng Lĩnh",
                        Parent = Guid.Parse("F58B06B8-BB4C-4D13-BC63-AA5E092D7949"),
                        Levels = 2
                    },
            #region phường hồng lĩnh
                       new LocationModel()
                       {
                           LocationId = Guid.NewGuid(),
                           Name = "Bắc Hồng",
                           Type = "Phường/Xã",
                           NameWithType = "Phường Bắc Hồng",
                           Parent = Guid.Parse("24B62611-1759-45BC-A0A7-AB678C9BA256"),
                           Levels = 3
                       },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Đức Thuận",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Đức Thuận",
                        Parent = Guid.Parse("24B62611-1759-45BC-A0A7-AB678C9BA256"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hưng Long",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hưng Long",
                        Parent = Guid.Parse("24B62611-1759-45BC-A0A7-AB678C9BA256"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hưng Lộc",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hưng Lộc",
                        Parent = Guid.Parse("24B62611-1759-45BC-A0A7-AB678C9BA256"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Hưng Thịnh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Hưng Thịnh",
                        Parent = Guid.Parse("24B62611-1759-45BC-A0A7-AB678C9BA256"),
                        Levels = 3
                    },
            #endregion
            #endregion
            #region tx hương sơn
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("F4ED60BA-E570-4E85-9AC9-38CDADE14886"),
                        Name = "Hương Sơn",
                        Type = "Quận/Huyện",
                        NameWithType = "Huyện Hương Sơn",
                        Parent = Guid.Parse("F58B06B8-BB4C-4D13-BC63-AA5E092D7949"),
                        Levels = 2
                    },
            #region phường hương sơn
                       new LocationModel()
                       {
                           LocationId = Guid.NewGuid(),
                           Name = "Hương Vinh",
                           Type = "Phường/Xã",
                           NameWithType = "Phường Hương Vinh",
                           Parent = Guid.Parse("F4ED60BA-E570-4E85-9AC9-38CDADE14886"),
                           Levels = 3
                       },
                        new LocationModel()
                        {
                            LocationId = Guid.NewGuid(),
                            Name = "Hương Xuân",
                            Type = "Phường/Xã",
                            NameWithType = "Phường Hương Xuân",
                            Parent = Guid.Parse("F4ED60BA-E570-4E85-9AC9-38CDADE14886"),
                            Levels = 3
                        },
                        new LocationModel()
                        {
                            LocationId = Guid.NewGuid(),
                            Name = "Hương Trà",
                            Type = "Phường/Xã",
                            NameWithType = "Phường Hương Trà",
                            Parent = Guid.Parse("F4ED60BA-E570-4E85-9AC9-38CDADE14886"),
                            Levels = 3
                        },
            #endregion
            #endregion
            #endregion
            #region Thái Bình
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("D285807C-184C-4505-B39B-F15108486656"),
                        Name = "Thái Bình",
                        Type = "Tỉnh",
                        NameWithType = "Tỉnh Thái Bình",
                        Levels = 1
                    },
            #region thành phố thái bình
                    new LocationModel()
                    {
                        LocationId = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Name = "Thái Bình",
                        Type = "Thành Phố",
                        NameWithType = "Thành Phố Thái Bình",
                        Parent = Guid.Parse("D285807C-184C-4505-B39B-F15108486656"),
                        Levels = 2
                    },
            #region phường thái bình
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Bồ Xuyên",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Bồ Xuyên",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Phú Khánh",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Phú Khánh",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Kỳ Bá",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Kỳ Bá",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Tiền Phong",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Tiền Phong",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Quang Trung",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Quang Trung",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Trần Lãm",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Trần Lãm",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Lê Hồng Phong",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Lê Hồng Phong",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    },
                    new LocationModel()
                    {
                        LocationId = Guid.NewGuid(),
                        Name = "Trần Hưng Đạo",
                        Type = "Phường/Xã",
                        NameWithType = "Phường Trần Hưng Đạo",
                        Parent = Guid.Parse("A1DC85EA-FDBE-4603-AC5C-E9871DA7BA73"),
                        Levels = 3
                    }
                    #endregion
                    #endregion
                    #endregion
                );
        }
        public static void TranSactStatusData(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactStatusModel>().HasData(
                    new TransactStatusModel() { TransactStatusId = 1, Status = "Chưa Giao Hàng" },
                    new TransactStatusModel() { TransactStatusId = 2, Status = "Đang Giao Hàng" },
                    new TransactStatusModel() { TransactStatusId = 3, Status = "Đã Giao Hàng" }
                );
        }
    }
}
