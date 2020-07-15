﻿using ZeroFormatter;

namespace NetworkLibrary.NetworkLibrary.Udp
{
    [ZeroFormattable]
    public class MessagesContainer
    {
        [Index(0)] public virtual byte[][] Messages { get; set; }
        [IgnoreFormat] public const int IndexLength = 16;
    }
}