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
            log.Debug(nameof(ValidateProductAsync));
            
            try
            {
                //Отправка запроса на проверку и регистрацию покупки
                HttpClient httpClient = new HttpClient();
                byte[] data;
                using (MultipartFormDataContent formData = new MultipartFormDataContent())
                {
                    formData.Add(new StringContent(skuArg), "sku");
                    formData.Add(new StringContent(token), "token");
                    log.Debug("Перед отправкой");
                    HttpResponseMessage response = await httpClient
                        .PostAsync(NetworkGlobals.ValidatePurchaseUrl, formData);
                    log.Debug("1");
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception($"{nameof(response.IsSuccessStatusCode)} {response.IsSuccessStatusCode}");
                    }
                    data = await response.Content.ReadAsByteArrayAsync();
                    log.Debug("2");
                    log.Debug("Успешное выполнение запроса.");
                }

                if (data == null)
                {
                    throw new NullReferenceException("server answer is null");
                }
                string[] result = ZeroFormatterSerializer.Deserialize<string[]>(data);
                log.Debug("3");
                
                // проверка нормального ответа от сервера
                 if (result == null || result.Length == 0)
                 {
                     UiSoundsManager.Instance().PlayError();
                     log.Fatal("Не удалось получить от сервера список продуктов, которые были им проверены.");
                     
                     return;
                 }
                
                log.Debug("4");
                
                //вызвать Confirm по полученным данным
                // foreach (string sku in result)
                // {
                //     log.Debug($"{nameof(sku)} {sku}");
                //     LogManager.Print();
                //     log.Debug("5");
                //     LogManager.Print();
                //     bool success = purchasingService.TryConfirmPendingPurchase(skuArg);
                //     log.Debug("6");
                //     LogManager.Print();
                //     if (success)
                //     {
                //         //уведомить сервер, что удалось сообщить о сохранении в UnityApi 
                //         await new Dich314().SendConfirmationSuccessMessage(skuArg);
                //     }
                //     else
                //     {
                //         UiSoundsManager.Instance().PlayError();
                //         log.Error($"Не удалось уведомить unity api о том, что продукт был сохранён в БД. " +
                //                   $"{nameof(skuArg)} {skuArg}");
                //     }
                // }
            }
            catch (Exception exception)
            {
                UiSoundsManager.Instance().PlayError();
                log.Error(exception.Message);
                
            }
            
            log.Debug("82");
        }

    }
}