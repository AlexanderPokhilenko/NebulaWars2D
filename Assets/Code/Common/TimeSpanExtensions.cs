using System;

namespace Code.Scenes.LobbyScene.ECS.Systems.Execute
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan Multiply(this TimeSpan timeSpan, int number)
        {
            return TimeSpan.FromMilliseconds(timeSpan.TotalMilliseconds * number);
        } 
        
        public static TimeSpan Multiply(this TimeSpan timeSpan, double number)
        {
            return TimeSpan.FromMilliseconds(timeSpan.TotalMilliseconds * number);
        } 
    }
}