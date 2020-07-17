using System;
using System.Net.Http;
using System.Threading.Tasks;
using Code.Common;
using Code.Common.Logger;
using Code.Scenes.LobbyScene.Scripts.UiStorages;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class Dich314
    {
        private readonly ILog log = LogManager.CreateLogger(typeof(Dich314));
        public async Task SendConfirmationSuccessMessage(string sku)
        {
            log.Debug(nameof(SendConfirmationSuccessMessage));
            log.Debug($"{nameof(sku)} {sku}");
           
            
            if (!PlayerIdStorage.TryGetServiceId(out string playerServiceId))
            {
                UiSoundsManager.Instance().PlayError();
                log.Error($"Не удалось получить {nameof(playerServiceId)} при отправке " +
                          $"сообщения об успешном подтверждении покупки {nameof(sku)} {sku}");
            }
            
            try
            {
                HttpClient httpClient = new HttpClient();
                using (MultipartFormDataContent formData = new MultipartFormDataContent())
                {
                    formData.Add(new StringContent(playerServiceId), "serviceId");
                    formData.Add(new StringContent(sku), "sku");
                    HttpResponseMessage response = await httpClient
                        .PostAsync(NetworkGlobals.MarkOrderAsCompletedUrl, formData);
                }
                log.Debug("Успешное выполнение запроса.");
            }
            catch (Exception e)
            {
                UiSoundsManager.Instance().PlayError();
                log.Error("Не удалось сообщить об отправке " +
                          $"сообщения об успешном подтверждении покупки {nameof(sku)} {sku} {e.Message} {e.StackTrace}");
            }
        }
    }
}