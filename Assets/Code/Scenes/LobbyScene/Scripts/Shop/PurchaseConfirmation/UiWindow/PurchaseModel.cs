using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow
{
    /// <summary>
    /// Полностью описывает продукт.
    /// </summary>
    public class PurchaseModel
    {
        public readonly int ShopModelId;
        public readonly ProductModel ProductModel;

        public PurchaseModel(ProductModel productModel, int shopModelId)
        {
            ProductModel = productModel;
            ShopModelId = shopModelId;
        }
    }
}