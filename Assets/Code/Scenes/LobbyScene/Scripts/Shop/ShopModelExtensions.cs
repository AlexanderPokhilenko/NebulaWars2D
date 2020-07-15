using System.Collections.Generic;
using System.Linq;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LobbyScene.Scripts.Shop
{
    public static class ShopModelExtensions
    {
        public static List<ProductModel> GetAllProducts(this ShopModel shopModel)
        {
            List<ProductModel> productModels = shopModel.UiSections
                .SelectMany(container => container.UiItems)
                .SelectMany(test1=>test1)
                .ToList();
            return productModels;
        }
        
        public static List<ForeignServiceProduct> GetRealCurrencyProducts(this ShopModel shopModel)
        {
            
            List<ForeignServiceProduct> realCurrencyProducts =  shopModel.UiSections
                .SelectMany(container => container.UiItems)
                .SelectMany(test1=>test1)
                .Where(productModel => productModel.CurrencyTypeEnum == CurrencyTypeEnum.RealCurrency)
                .Select(productModel => productModel.ForeignServiceProduct)
                .ToList();
            return realCurrencyProducts;
        }
    }
}