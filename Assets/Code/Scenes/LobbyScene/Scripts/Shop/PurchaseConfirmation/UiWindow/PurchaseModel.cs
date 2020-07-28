using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow
{
    /// <summary>
    /// Полностью описывает продукт.
    /// </summary>
    public class PurchaseModel
    {
        public readonly int shopModelId;
        public readonly ProductModel productModel;

        public PurchaseModel(ProductModel productModel, int shopModelId)
        {
            this.productModel = productModel;
            this.shopModelId = shopModelId;
        }
    }
}