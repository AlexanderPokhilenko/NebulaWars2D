#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("Fo3aqEGqsryHy7vTChKB8SbK7W5C00PzHXbKPqytCDQ9Ie+lcxXM7MfIpMqBSu9yksJTGlBuDbrRxAXuiD6NWM+87E5ikEA9h9uOhd/dBfw9eoWU2asygkqAynvEbt3siwoT3i+dHj0vEhkWNZlXmegSHh4eGh8cHpTxK/IPw+efeQRFUMkZOL1/oigTl6t3V1dmGVYWPdzUcYb/nZ/8KIXS0EYSphoCotELWFWTzfK0UB2EnR4QHy+dHhUdnR4eH4/R+vXGS67dUpgtMO7onYGaSNwlsv+EW9ABoZXPLKUIeG0ce7b64bXmZi6fVTXb0Zbzhc0QmSLyB5/N3EXfH59X4iICIm7Zgd2gDjlMdFgk+3zI6/HN9mjv6Tm1HJcRxB0cHh8e");
        private static int[] order = new int[] { 5,4,9,10,12,5,11,11,11,12,11,13,13,13,14 };
        private static int key = 31;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
