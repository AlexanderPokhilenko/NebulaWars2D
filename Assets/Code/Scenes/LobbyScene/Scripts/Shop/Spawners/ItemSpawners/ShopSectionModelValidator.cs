using Code.Common.Logger;
using NetworkLibrary.NetworkLibrary.Http;

namespace Code.Scenes.LobbyScene.Scripts.Shop.Spawners.ItemSpawners
{
    /// <summary>
    /// Проверяет, что в разделе все элементы одинакового размера.
    /// Проверяет, что у каждого товара есть идентификатор
    /// </summary>
    public class ShopSectionModelValidator
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(ShopSectionModelValidator));
        
        public bool Validate(SectionModel sectionModel)
        {
            ProductSizeEnum? sectionItemsSize = null;   
            foreach (ProductModel[] line in sectionModel.UiItems)
            {
                foreach (ProductModel itemModel in line)
                {
                    if (sectionItemsSize == null)
                    {
                        sectionItemsSize = itemModel.ShopItemSize;
                    }
                    else if (itemModel.ShopItemSize!=sectionItemsSize)
                    {
                        //В одном разделе есть объекты разного размера
                        //я к такому пока не готов
                        return false;
                    }

                    //У товара нет идентификатора
                    if (itemModel.Id == 0)
                    {
                        log.Error($"{nameof(Validate)} {nameof(itemModel.Id)} is null." +
                                  $" {nameof(itemModel.Name)} {itemModel.Name}");
                    }
                }   
            }
            return true;
        }
    }
}