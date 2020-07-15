#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("8CozihXWgHsACISwAQrrADlB3mDxij/1Tz2FWIKPTlGIQCUdN8LzIJJDVbdlLPbpNtFWezWl+OVGqSUD1bwVYxCM8VnnpWu0R/oYt4GKcs/6obamQAPHHnXR/JakcQjS8DxHpJ98o5X5LExyV3yfXnYoijAK8OTaOK2jWK+hcGtQHDhkg0shAM5/xydLXbOhtyUji5uVy03XA4Zkv09OS8Fz8NPB/Pf423e5dwb88PDw9PHyYScGWT36Rl0iidDHisC5UBiJM8GGnBw/CAQjFJGOEL4fW5MQs8ODYXPw/vHBc/D783Pw8PFUHWpMwpAL4Wei55mua4hOVew1vMMrDUlqATg11sYU25PnK0pMibIk6hDAO15jJ4ul3nnabKrv7PPy8PHw");
        private static int[] order = new int[] { 2,12,9,11,5,11,7,10,9,13,13,12,12,13,14 };
        private static int key = 241;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
