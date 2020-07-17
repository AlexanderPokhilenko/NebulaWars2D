using System;
using UnityEngine;

namespace Code.Scenes.LobbyScene.Scripts
{
    public class GooglePurchaseData 
    {
        // INAPP_PURCHASE_DATA
        public string inAppPurchaseData;
        // INAPP_DATA_SIGNATURE
        public string inAppDataSignature;
 
        public GooglePurchaseJson json;
 
        [Serializable]
        private struct GooglePurchaseReceipt 
        {
            public string Payload;
        }
 
        [Serializable]
        private struct GooglePurchasePayload 
        {
            public string json;
            public string signature;
        }
 
        [Serializable]
        public struct GooglePurchaseJson 
        {
            public string autoRenewing;
            public string orderId;
            public string packageName;
            public string productId;
            public string purchaseTime;
            public string purchaseState;
            public string developerPayload;
            public string purchaseToken;
        }
 
        public GooglePurchaseData(string receipt) 
        {
            try 
            {
                GooglePurchaseReceipt purchaseReceipt = JsonUtility.FromJson<GooglePurchaseReceipt>(receipt);
                GooglePurchasePayload purchasePayload = JsonUtility.FromJson<GooglePurchasePayload>(purchaseReceipt.Payload);
                GooglePurchaseJson inAppJsonData = JsonUtility.FromJson<GooglePurchaseJson>(purchasePayload.json);
 
                inAppPurchaseData = purchasePayload.json;
                inAppDataSignature = purchasePayload.signature;
                json = inAppJsonData;
            }
            catch 
            {
                Debug.Log("Could not parse receipt: " + receipt);
                inAppPurchaseData = "";
                inAppDataSignature = "";
            }
        }
    }
}