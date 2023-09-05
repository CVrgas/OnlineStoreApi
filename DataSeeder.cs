using OnlineStoreApi.Models;

namespace OnlineStoreApi.services
{
    public static class DataSeeder
    {
        public static void SeedData(DataContext context)
        {
            // mria si la base de dato tienes datos
            if (context.Products.Any())
            {
                return; // si tienes dato no la seed denuevo.
            }

            // Seed database
            var products = new[]
            {
                new Product
                {
                    Id = 173,
                    Name = "Microsoft Surface Laptop 4",
                    Brand = "Microsoft Surface",
                    Description = "Style and speed. Stand out on HD video calls backed by Studio Mics. Capture ideas on the vibrant touchscreen.",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/8/thumbnail.jpg",
                    Price = 1499,
                    Stock = 68
                },
                new Product
                {
                    Id = 174,
                    Name = "Samsung Universe 9",
                    Brand = "Samsung",
                    Description = "Samsung's new variant which goes beyond Galaxy to the Universe",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/3/thumbnail.jpg",
                    Price = 1249,
                    Stock = 36
                },
                new Product
                {
                    Id = 175,
                    Name = "iPhone 9",
                    Brand = "Apple",
                    Description = "An apple mobile which is nothing like apple",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/1/thumbnail.jpg",
                    Price = 549,
                    Stock = 94
                },
                new Product
                {
                    Id = 176,
                    Name = "iPhone X",
                    Brand = "Apple",
                    Description = "SIM-Free, Model A19211 6.5-inch Super Retina HD display with OLED technology A12 Bionic chip with ...",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/2/thumbnail.jpg",
                    Price = 899,
                    Stock = 34
                },
                new Product
                {
                    Id = 177,
                    Name = "Infinix INBOOK",
                    Brand = "Infinix",
                    Description = "Infinix Inbook X1 Ci3 10th 8GB 256GB 14 Win10 Grey – 1 Year Warranty",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/9/thumbnail.jpg",
                    Price = 1099,
                    Stock = 96
                },
                new Product
                {
                    Id = 178,
                    Name = "Huawei P30",
                    Brand = "Huawei",
                    Description = "Huawei’s re-badged P30 Pro New Edition was officially unveiled yesterday in Germany and now the device has made its way to the UK.",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/5/thumbnail.jpg",
                    Price = 499,
                    Stock = 32
                },
                new Product
                {
                    Id = 179,
                    Name = "OPPOF19",
                    Brand = "OPPO",
                    Description = "OPPO F19 is officially announced on April 2021.",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/4/thumbnail.jpg",
                    Price = 280,
                    Stock = 123
                },
                new Product
                {
                    Id = 180,
                    Name = "Samsung Galaxy Book",
                    Brand = "Samsung",
                    Description = "Samsung Galaxy Book S (2020) Laptop With Intel Lakefield Chip, 8GB of RAM Launched",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/7/thumbnail.jpg",
                    Price = 1499,
                    Stock = 50
                },
                new Product
                {
                    Id = 181,
                    Name = "MacBook Pro",
                    Brand = "Apple",
                    Description = "MacBook Pro 2021 with mini-LED display may launch between September, November",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/6/thumbnail.png",
                    Price = 1749,
                    Stock = 83
                },
                new Product
                {
                    Id = 182,
                    Name = "HP Pavilion 15-DK1056WM",
                    Brand = "HP Pavilion",
                    Description = "HP Pavilion 15-DK1056WM Gaming Laptop 10th Gen Core i5, 8GB, 256GB SSD, GTX 1650 4GB, Windows 10",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/10/thumbnail.jpeg",
                    Price = 1099,
                    Stock = 89
                },
                new Product
                {
                    Id = 183,
                    Name = "perfume Oil",
                    Brand = "Impression of Acqua Di Gio",
                    Description = "Mega Discount, Impression of Acqua Di Gio by GiorgioArmani concentrated attar perfume Oil",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/11/thumbnail.jpg",
                    Price = 13,
                    Stock = 65
                },
                new Product
                {
                    Id = 184,
                    Name = "Fog Scent Xpressio Perfume",
                    Brand = "Fog Scent Xpressio",
                    Description = "Product details of Best Fog Scent Xpressio Perfume 100ml For Men cool long lasting perfumes for Men",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/13/thumbnail.webp",
                    Price = 13,
                    Stock = 61
                },
                new Product
                {
                    Id = 185,
                    Name = "Brown Perfume",
                    Brand = "Royal_Mirage",
                    Description = "Royal_Mirage Sport Brown Perfume for Men & Women - 120ml",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/12/thumbnail.jpg",
                    Price = 40,
                    Stock = 52
                },
                new Product
                {
                    Id = 186,
                    Name = "Non-Alcoholic Concentrated Perfume Oil",
                    Brand = "Al Munakh",
                    Description = "Original Al Munakh® by Mahal Al Musk | Our Impression of Climate | 6ml Non-Alcoholic Concentrated Perfume Oil",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/14/thumbnail.jpg",
                    Price = 120,
                    Stock = 114
                },
                new Product
                {
                    Id = 187,
                    Name = "Oil Free Moisturizer 100ml",
                    Brand = "Dermive",
                    Description = "Dermive Oil Free Moisturizer with SPF 20 is specifically formulated with ceramides, hyaluronic acid & sunscreen.",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/18/thumbnail.jpg",
                    Price = 40,
                    Stock = 88
                },
                new Product
                {
                    Id = 188,
                    Name = "Tree Oil 30ml",
                    Brand = "Hemani Tea",
                    Description = "Tea tree oil contains a number of compounds, including terpinen-4-ol, that have been shown to kill certain bacteria,",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/17/thumbnail.jpg",
                    Price = 12,
                    Stock = 78
                },
                new Product
                {
                    Id = 189,
                    Name = "Eau De Perfume Spray",
                    Brand = "Lord - Al-Rehab",
                    Description = "Genuine  Al-Rehab spray perfume from UAE/Saudi Arabia/Yemen High Quality",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/15/thumbnail.jpg",
                    Price = 30,
                    Stock = 105
                },
                new Product
                {
                    Id = 190,
                    Name = "Hyaluronic Acid Serum",
                    Brand = "L'Oreal Paris",
                    Description = "L'OrÃ©al Paris introduces Hyaluron Expert Replumping Serum formulated with 1.5% Hyaluronic Acid",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/16/thumbnail.jpg",
                    Price = 19,
                    Stock = 110
                },
                new Product
                {
                    Id = 191,
                    Name = "Skin Beauty Serum.",
                    Brand = "ROREC White Rice",
                    Description = "Product name: rorec collagen hyaluronic acid white face serum riceNet weight: 15 m",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/19/thumbnail.jpg",
                    Price = 46,
                    Stock = 54
                },
                new Product
                {
                    Id = 192,
                    Name = "- Daal Masoor 500 grams",
                    Brand = "Saaf & Khaas",
                    Description = "Fine quality Branded Product Keep in a cool and dry place",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/21/thumbnail.png",
                    Price = 20,
                    Stock = 133
                },
                new Product
                {
                    Id = 193,
                    Name = "cereals muesli fruit nuts",
                    Brand = "fauji",
                    Description = "original fauji cereal muesli 250gm box pack original fauji cereals muesli fruit nuts flakes breakfast cereal break fast faujicereals cerels cerel foji fouji",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/24/thumbnail.jpg",
                    Price = 46,
                    Stock = 113
                },
                new Product
                {
                    Id = 194,
                    Name = "Freckle Treatment Cream- 15gm",
                    Brand = "Fair & Clear",
                    Description = "Fair & Clear is Pakistan's only pure Freckle cream which helpsfade Freckles, Darkspots and pigments. Mercury level is 0%, so there are no side effects.",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/20/thumbnail.jpg",
                    Price = 70,
                    Stock = 140
                },
                new Product
                {
                    Id = 195,
                    Name = "Gulab Powder 50 Gram",
                    Brand = "Dry Rose",
                    Description = "Dry Rose Flower Powder Gulab Powder 50 Gram • Treats Wounds",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/25/thumbnail.jpg",
                    Price = 70,
                    Stock = 47
                },
                new Product
                {
                    Id = 196,
                    Name = "Orange Essence Food Flavou",
                    Brand = "Baking Food Items",
                    Description = "Specifications of Orange Essence Food Flavour For Cakes and Baking Food Item",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/23/thumbnail.jpg",
                    Price = 14,
                    Stock = 26
                },
                new Product
                {
                    Id = 197,
                    Name = "Flying Wooden Bird",
                    Brand = "Flying Wooden",
                    Description = "Package Include 6 Birds with Adhesive Tape Shape: 3D Shaped Wooden Birds Material: Wooden MDF, Laminated 3.5mm",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/27/thumbnail.webp",
                    Price = 51,
                    Stock = 17
                },
                new Product
                {
                    Id = 198,
                    Name = "Elbow Macaroni - 400 gm",
                    Brand = "Bake Parlor Big",
                    Description = "Product details of Bake Parlor Big Elbow Macaroni - 400 gm",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/22/thumbnail.jpg",
                    Price = 14,
                    Stock = 146
                },
                new Product
                {
                    Id = 199,
                    Name = "Plant Hanger For Home",
                    Brand = "Boho Decor",
                    Description = "Boho Decor Plant Hanger For Home Wall Decoration Macrame Wall Hanging Shelf",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/26/thumbnail.jpg",
                    Price = 41,
                    Stock = 131
                },
                new Product
                {
                    Id = 200,
                    Name = "3D Embellishment Art Lamp",
                    Brand = "LED Lights",
                    Description = "3D led lamp sticker Wall sticker 3d wall art light on/off button  cell operated (included)",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/28/thumbnail.jpg",
                    Price = 20,
                    Stock = 54
                },
                new Product
                {
                    Id = 201,
                    Name = "Handcraft Chinese style",
                    Brand = "luxury palace",
                    Description = "Handcraft Chinese style art luxury palace hotel villa mansion home decor ceramic vase with brass fruit plate",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/29/thumbnail.webp",
                    Price = 60,
                    Stock = 7
                },
                new Product
                {
                    Id = 202,
                    Name = "Key Holder",
                    Brand = "Golden",
                    Description = "Attractive DesignMetallic materialFour key hooksReliable & DurablePremium Quality",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://i.dummyjson.com/data/products/30/thumbnail.jpg",
                    Price = 30,
                    Stock = 54
                },
                new Product
                {
                    Id = 222,
                    Name = "nuevo producto",
                    Brand = "ElnuevoTT",
                    Description = "estre es unnuevo rpoducto invetnado",
                    ImagesUrl = new List<string>(),
                    Thumbnail = "https://as1.ftcdn.net/v2/jpg/04/62/93/66/1000_F_462936689_BpEEcxfgMuYPfTaIAOC1tCDurmsno7Sp.jpg",
                    Price = 12.99m,
                    Stock = 100
                }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}