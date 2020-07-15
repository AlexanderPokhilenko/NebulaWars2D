// using NetworkLibrary.NetworkLibrary.Http;
//
// namespace Code.Scenes.LobbyScene.Scripts
// {
//     public class DailyDealsSectionFactory
//     {
//         public SectionModel Create()
//         {
//             SectionModel sectionModel = new SectionModel
//             {
//                 HeaderName = "DAILY DEALS",
//                 NeedFooterPointer = true
//             };
//             
//             sectionModel.UiItems = new ProductModel[2][];
//             //первая строка
//             sectionModel.UiItems[0] = new[]
//             {
//                 new ProductModel
//                 {
//                     ProductType = ProductType.DailyPresent,
//                     CurrencyType = CurrencyType.Free,
//                     ImagePreviewPath = "coins5",
//                     CostString = 20.ToString(),
//                     Cost = 20,
//                     ShopItemSize = ProductSizeEnum.Small,
//                     Name = "15",
//                     KitId = "1_1"
//                 }, 
//                 new ProductModel
//                 {
//                     ProductType = ProductType.WarshipPowerPoints,
//                     CurrencyType = CurrencyType.SoftCurrency,
//                     ImagePreviewPath = "bird",
//                     CostString = 50.ToString(),
//                     Cost = 50,
//                     WarshipPowerPointsProduct = new WarshipPowerPointsProduct
//                     {
//                         WarshipId = 2,
//                         CurrentMaxPowerPointsAmount = 12,
//                         PowerPointsIncrement = 12,
//                         CurrentPowerPointsAmount = 8
//                     },
//                     ShopItemSize = ProductSizeEnum.Small,
//                     KitId = "1_2"
//                 }, 
//                 new ProductModel
//                 {
//                     ProductType = ProductType.WarshipPowerPoints,
//                     CurrencyType = CurrencyType.SoftCurrency,
//                     ImagePreviewPath = "bird",
//                     CostString = 50.ToString(),
//                     Cost = 50,
//                     WarshipPowerPointsProduct = new WarshipPowerPointsProduct()
//                     {
//                         WarshipId = 2,
//                         CurrentMaxPowerPointsAmount = 150,
//                         PowerPointsIncrement = 16,
//                         CurrentPowerPointsAmount = 48
//                     },
//                     ShopItemSize = ProductSizeEnum.Small,
//                     KitId = "1_3"
//                 }
//             }; 
//             
//             //вторая строка
//             sectionModel.UiItems[1] = new[]
//             {
//                 new ProductModel
//                 {
//                     ProductType = ProductType.WarshipPowerPoints,
//                     CurrencyType = CurrencyType.SoftCurrency,
//                     ImagePreviewPath = "bird",
//                     CostString = 140.ToString(),
//                     Cost = 140,
//                     WarshipPowerPointsProduct = new WarshipPowerPointsProduct()
//                     {
//                         WarshipId = 2,
//                         CurrentMaxPowerPointsAmount = 300,
//                         PowerPointsIncrement = 42,
//                         CurrentPowerPointsAmount = 95
//                     },
//                     ShopItemSize = ProductSizeEnum.Small,
//                     KitId = "1_4"
//                 },
//                 new ProductModel
//                 {
//                     ProductType = ProductType.WarshipPowerPoints,
//                     CurrencyType = CurrencyType.SoftCurrency,
//                     ImagePreviewPath = "bird",
//                     CostString = 280.ToString(),
//                     Cost = 280,
//                     WarshipPowerPointsProduct = new WarshipPowerPointsProduct()
//                     {
//                         WarshipId = 2,
//                         CurrentMaxPowerPointsAmount = 180,
//                         PowerPointsIncrement = 50,
//                         CurrentPowerPointsAmount = 142
//                     },
//                     ShopItemSize = ProductSizeEnum.Small,
//                     KitId = "1_5"
//                 }, 
//                 new ProductModel
//                 {
//                     ProductType = ProductType.WarshipPowerPoints,
//                     CurrencyType = CurrencyType.SoftCurrency,
//                     ImagePreviewPath = "bird",
//                     CostString = 50.ToString(),
//                     Cost = 50,
//                     WarshipPowerPointsProduct = new WarshipPowerPointsProduct()
//                     {
//                         WarshipId = 2,
//                         CurrentMaxPowerPointsAmount = 240,
//                         PowerPointsIncrement = 84,
//                         CurrentPowerPointsAmount = 234
//                     },
//                     ShopItemSize = ProductSizeEnum.Small,
//                     KitId = "1_6"
//                 }
//             };
//             
//             return sectionModel;
//         }
//     }
// }