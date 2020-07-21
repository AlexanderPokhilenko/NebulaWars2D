﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿﻿using System.Collections.Generic;
using ZeroFormatter;

namespace NetworkLibrary.NetworkLibrary.Http
{
    [ZeroFormattable]
    public class LootboxModel
    {
        [Index(0)] public virtual List<LootboxPrizeModel> Prizes { get; set; }
    }

    [ZeroFormattable]
    public class LootboxPrizeModel
    {
        [Index(0)] public virtual LootboxPrizeType LootboxPrizeType { get; set; }
        [Index(1)] public virtual byte[] SerializedModel { get; set; }
    }

    [ZeroFormattable]
    public class LootboxSoftCurrencyModel
    {
        [Index(0)] public virtual int Amount { get; set; }
    }
    [ZeroFormattable]
    public class LootboxHardCurrencyModel
    {
        [Index(0)] public virtual int Amount { get; set; }
    }
    [ZeroFormattable]
    public class LootboxWarshipPowerPointsModel
    {
        [Index(0)] public virtual string WarshipPrefabName { get; set; }
        [Index(1)] public virtual int StartValue { get; set; }
        [Index(2)] public virtual int FinishValue { get; set; }
        [Index(3)] public virtual int MaxValueForLevel { get; set; }
    }

    public enum LootboxPrizeType
    {
        SoftCurrency,
        LootboxPoints,
        WarshipPowerPoints,
        HardCurrency
    }
}