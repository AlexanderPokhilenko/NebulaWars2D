using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.UiStorages;
using ZeroFormatter;

namespace Code.Scenes.LobbyScene.Scripts
{
    /// <summary>
    /// Отправляет сообщение на сервер для создания транзакции при покупке за реальную валюту.
    /// </summary>
    public class ProductValidator
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(ProductValidator));
        public async Task ValidateProductAsync(string skuArg, string token, PurchasingService purchasingService)
        {
          
        }
    }
}