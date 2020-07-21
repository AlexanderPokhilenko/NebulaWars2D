#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter
{
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;
    using global::ZeroFormatter.Comparers;

    public static partial class ZeroFormatterInitializer
    {
        static bool registered = false;

        [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void Register()
        {
            if(registered) return;
            registered = true;
            // Enums
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::ViewTypeId>.Register(new ZeroFormatter.DynamicObjectSegments.ViewTypeIdFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::ViewTypeId>.Register(new ZeroFormatter.DynamicObjectSegments.ViewTypeIdEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::DataLayer.Tables.TransactionTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.DataLayer.Tables.TransactionTypeEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::DataLayer.Tables.TransactionTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.DataLayer.Tables.TransactionTypeEnumEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnumEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.IncrementCoefficientFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.IncrementCoefficientEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnumEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.SkinTypeEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.SkinTypeEnumEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LootboxPrizeTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LootboxPrizeTypeEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.MarkType>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.MarkTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.MarkType>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.MarkTypeEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnumEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.ProductSizeEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.ProductSizeEnumEqualityComparer());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum?>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.NullableProductSizeEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum?>.Register(new NullableEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum>());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnumFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnumEqualityComparer());
            
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageType>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.MessageTypeFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Comparers.ZeroFormatterEqualityComparer<global::NetworkLibrary.NetworkLibrary.Udp.MessageType>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.MessageTypeEqualityComparer());
            
            // Objects
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.WarshipParameterFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristicsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.SkinTypeDtoFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipDto>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.WarshipDtoFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.AccountDto>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.AccountDtoFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShownFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LobbyModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LobbyModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LootboxModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxSoftCurrencyModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LootboxSoftCurrencyModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxHardCurrencyModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LootboxHardCurrencyModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxWarshipPowerPointsModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.LootboxWarshipPowerPointsModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.DiscountPriceFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.ForeignServiceProductFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductMark>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.ProductMarkFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProductFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.WarshipModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.ProductModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.SectionModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.SectionModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ShopModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.ShopModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipImprovementModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.WarshipImprovementModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResult>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.PlayerModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.PlayerModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BotModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.BotModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.GameUnits>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.GameUnitsFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleMatchModel>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.BattleRoyaleMatchModelFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.MatchmakerResponse>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.MatchmakerResponseFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Experimental.MatchResultDto>.Register(new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Experimental.MatchResultDtoFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsInfosMessage>.Register(new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsInfosMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.PositionsMessage>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.PositionsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageClass1>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageClass1Formatter<ZeroFormatter.Formatters.DefaultResolver>());
            ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessagesContainer>.Register(new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.MessagesContainerFormatter<ZeroFormatter.Formatters.DefaultResolver>());
            // Structs
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModelFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfoFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransformFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1Formatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessageFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessage>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessage?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessage>(structFormatter));
            }
            {
                var structFormatter = new ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.MessageWrapperFormatter<ZeroFormatter.Formatters.DefaultResolver>();
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageWrapper>.Register(structFormatter);
                ZeroFormatter.Formatters.Formatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageWrapper?>.Register(new global::ZeroFormatter.Formatters.NullableStructFormatter<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageWrapper>(structFormatter));
            }
            // Unions
            // Generics
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum, int>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, int, ushort>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>();
            ZeroFormatter.Formatters.Formatter.RegisterDictionary<ZeroFormatter.Formatters.DefaultResolver, ushort, ushort>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, byte[]>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel[]>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter>();
            ZeroFormatter.Formatters.Formatter.RegisterArray<ZeroFormatter.Formatters.DefaultResolver, string>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.BotModel, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.BotModel>>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel>>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.PlayerModel, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.PlayerModel>>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.SectionModel, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SectionModel>>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>>();
            ZeroFormatter.Formatters.Formatter.RegisterCollection<ZeroFormatter.Formatters.DefaultResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipDto, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.WarshipDto>>();
        }
    }
}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class WarshipParameterFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.Name);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 1, value.BaseValue);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>(ref bytes, startOffset, offset, 2, value.Increment);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>(ref bytes, startOffset, offset, 3, value.UiIncrementTypeEnum);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WarshipParameterObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WarshipParameterObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Name;

        // 0
        public override string Name
        {
            get
            {
                return _Name.Value;
            }
            set
            {
                _Name.Value = value;
            }
        }

        // 1
        public override float BaseValue
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient Increment
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum UiIncrementTypeEnum
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public WarshipParameterObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Name = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _Name);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class WarshipCharacteristicsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (6 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(ref bytes, startOffset, offset, 0, value.DefenceParameters);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(ref bytes, startOffset, offset, 1, value.AttackParameters);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.AttackName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 3, value.AttackDescription);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(ref bytes, startOffset, offset, 4, value.UltimateParameters);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 5, value.UltimateName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 6, value.UltimateDescription);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 6);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WarshipCharacteristicsObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WarshipCharacteristicsObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]> _DefenceParameters;
        CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]> _AttackParameters;
        CacheSegment<TTypeResolver, string> _AttackName;
        CacheSegment<TTypeResolver, string> _AttackDescription;
        CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]> _UltimateParameters;
        CacheSegment<TTypeResolver, string> _UltimateName;
        CacheSegment<TTypeResolver, string> _UltimateDescription;

        // 0
        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[] DefenceParameters
        {
            get
            {
                return _DefenceParameters.Value;
            }
            set
            {
                _DefenceParameters.Value = value;
            }
        }

        // 1
        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[] AttackParameters
        {
            get
            {
                return _AttackParameters.Value;
            }
            set
            {
                _AttackParameters.Value = value;
            }
        }

        // 2
        public override string AttackName
        {
            get
            {
                return _AttackName.Value;
            }
            set
            {
                _AttackName.Value = value;
            }
        }

        // 3
        public override string AttackDescription
        {
            get
            {
                return _AttackDescription.Value;
            }
            set
            {
                _AttackDescription.Value = value;
            }
        }

        // 4
        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[] UltimateParameters
        {
            get
            {
                return _UltimateParameters.Value;
            }
            set
            {
                _UltimateParameters.Value = value;
            }
        }

        // 5
        public override string UltimateName
        {
            get
            {
                return _UltimateName.Value;
            }
            set
            {
                _UltimateName.Value = value;
            }
        }

        // 6
        public override string UltimateDescription
        {
            get
            {
                return _UltimateDescription.Value;
            }
            set
            {
                _UltimateDescription.Value = value;
            }
        }


        public WarshipCharacteristicsObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 6, __elementSizes);

            _DefenceParameters = new CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _AttackParameters = new CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _AttackName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _AttackDescription = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _UltimateParameters = new CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _UltimateName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _UltimateDescription = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (6 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(ref targetBytes, startOffset, offset, 0, ref _DefenceParameters);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(ref targetBytes, startOffset, offset, 1, ref _AttackParameters);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _AttackName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 3, ref _AttackDescription);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipParameter[]>(ref targetBytes, startOffset, offset, 4, ref _UltimateParameters);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 5, ref _UltimateName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 6, ref _UltimateDescription);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 6);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SkinTypeDtoFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>(ref bytes, startOffset, offset, 0, value.Id);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.Name);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SkinTypeDtoObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SkinTypeDtoObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Name;

        // 0
        public override global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum Id
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string Name
        {
            get
            {
                return _Name.Value;
            }
            set
            {
                _Name.Value = value;
            }
        }


        public SkinTypeDtoObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _Name = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _Name);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class WarshipDtoFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipDto>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.WarshipDto value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (9 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Id);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.Rating);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.PowerLevel);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.PowerPoints);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 4, value.Description);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 5, value.CombatRoleName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 6, value.WarshipName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics>(ref bytes, startOffset, offset, 7, value.WarshipCharacteristics);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>>(ref bytes, startOffset, offset, 8, value.Skins);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>(ref bytes, startOffset, offset, 9, value.CurrentSkinType);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 9);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipDto Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WarshipDtoObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WarshipDtoObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.WarshipDto, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 4, 0, 0, 0, 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Description;
        CacheSegment<TTypeResolver, string> _CombatRoleName;
        CacheSegment<TTypeResolver, string> _WarshipName;
        global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics _WarshipCharacteristics;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>> _Skins;
        global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto _CurrentSkinType;

        // 0
        public override int Id
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int Rating
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int PowerLevel
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int PowerPoints
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override string Description
        {
            get
            {
                return _Description.Value;
            }
            set
            {
                _Description.Value = value;
            }
        }

        // 5
        public override string CombatRoleName
        {
            get
            {
                return _CombatRoleName.Value;
            }
            set
            {
                _CombatRoleName.Value = value;
            }
        }

        // 6
        public override string WarshipName
        {
            get
            {
                return _WarshipName.Value;
            }
            set
            {
                _WarshipName.Value = value;
            }
        }

        // 7
        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics WarshipCharacteristics
        {
            get
            {
                return _WarshipCharacteristics;
            }
            set
            {
                __tracker.Dirty();
                _WarshipCharacteristics = value;
            }
        }

        // 8
        public override global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto> Skins
        {
            get
            {
                return _Skins.Value;
            }
            set
            {
                _Skins.Value = value;
            }
        }

        // 9
        public override global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto CurrentSkinType
        {
            get
            {
                return _CurrentSkinType;
            }
            set
            {
                __tracker.Dirty();
                _CurrentSkinType = value;
            }
        }


        public WarshipDtoObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 9, __elementSizes);

            _Description = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
            _CombatRoleName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _WarshipName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
            _WarshipCharacteristics = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics>(originalBytes, 7, __binaryLastIndex, __tracker);
            _Skins = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 8, __binaryLastIndex, __tracker));
            _CurrentSkinType = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>(originalBytes, 9, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (9 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 4, ref _Description);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 5, ref _CombatRoleName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 6, ref _WarshipName);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipCharacteristics>(ref targetBytes, startOffset, offset, 7, _WarshipCharacteristics);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>>(ref targetBytes, startOffset, offset, 8, ref _Skins);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeDto>(ref targetBytes, startOffset, offset, 9, _CurrentSkinType);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 9);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class AccountDtoFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.AccountDto>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.AccountDto value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (7 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.Username);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.AccountRating);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.SoftCurrency);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.HardCurrency);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 4, value.BigLootboxPoints);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 5, value.SmallLootboxPoints);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.WarshipDto>>(ref bytes, startOffset, offset, 6, value.Warships);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 7, value.AccountId);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 7);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.AccountDto Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new AccountDtoObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class AccountDtoObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.AccountDto, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 4, 4, 4, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Username;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.WarshipDto>> _Warships;

        // 0
        public override string Username
        {
            get
            {
                return _Username.Value;
            }
            set
            {
                _Username.Value = value;
            }
        }

        // 1
        public override int AccountRating
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int SoftCurrency
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int HardCurrency
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override int BigLootboxPoints
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override int SmallLootboxPoints
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 6
        public override global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.WarshipDto> Warships
        {
            get
            {
                return _Warships.Value;
            }
            set
            {
                _Warships.Value = value;
            }
        }

        // 7
        public override int AccountId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 7, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public AccountDtoObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 7, __elementSizes);

            _Username = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _Warships = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.WarshipDto>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (7 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _Username);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.WarshipDto>>(ref targetBytes, startOffset, offset, 6, ref _Warships);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 7, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 7);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class RewardsThatHaveNotBeenShownFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.SoftCurrencyDelta);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.HardCurrencyDelta);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.LootboxPointsDelta);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.AccountRatingDelta);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new RewardsThatHaveNotBeenShownObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class RewardsThatHaveNotBeenShownObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int SoftCurrencyDelta
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int HardCurrencyDelta
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int LootboxPointsDelta
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int AccountRatingDelta
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public RewardsThatHaveNotBeenShownObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class WarshipRatingScaleModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int[]>(ref bytes, startOffset, offset, 0, value.RankMaxRatingArray);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WarshipRatingScaleModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WarshipRatingScaleModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, int[]> _RankMaxRatingArray;

        // 0
        public override int[] RankMaxRatingArray
        {
            get
            {
                return _RankMaxRatingArray.Value;
            }
            set
            {
                _RankMaxRatingArray.Value = value;
            }
        }


        public WarshipRatingScaleModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _RankMaxRatingArray = new CacheSegment<TTypeResolver, int[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, int[]>(ref targetBytes, startOffset, offset, 0, ref _RankMaxRatingArray);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LobbyModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LobbyModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.LobbyModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.AccountDto>(ref bytes, startOffset, offset, 0, value.AccountDto);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown>(ref bytes, startOffset, offset, 1, value.RewardsThatHaveNotBeenShown);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel>(ref bytes, startOffset, offset, 2, value.WarshipRatingScaleModel);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.LobbyModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LobbyModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LobbyModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.LobbyModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::NetworkLibrary.NetworkLibrary.Http.AccountDto _AccountDto;
        global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown _RewardsThatHaveNotBeenShown;
        global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel _WarshipRatingScaleModel;

        // 0
        public override global::NetworkLibrary.NetworkLibrary.Http.AccountDto AccountDto
        {
            get
            {
                return _AccountDto;
            }
            set
            {
                __tracker.Dirty();
                _AccountDto = value;
            }
        }

        // 1
        public override global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown RewardsThatHaveNotBeenShown
        {
            get
            {
                return _RewardsThatHaveNotBeenShown;
            }
            set
            {
                __tracker.Dirty();
                _RewardsThatHaveNotBeenShown = value;
            }
        }

        // 2
        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel WarshipRatingScaleModel
        {
            get
            {
                return _WarshipRatingScaleModel;
            }
            set
            {
                __tracker.Dirty();
                _WarshipRatingScaleModel = value;
            }
        }


        public LobbyModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _AccountDto = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.AccountDto>(originalBytes, 0, __binaryLastIndex, __tracker);
            _RewardsThatHaveNotBeenShown = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown>(originalBytes, 1, __binaryLastIndex, __tracker);
            _WarshipRatingScaleModel = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel>(originalBytes, 2, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.AccountDto>(ref targetBytes, startOffset, offset, 0, _AccountDto);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.RewardsThatHaveNotBeenShown>(ref targetBytes, startOffset, offset, 1, _RewardsThatHaveNotBeenShown);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipRatingScaleModel>(ref targetBytes, startOffset, offset, 2, _WarshipRatingScaleModel);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LootboxPrizeModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>(ref bytes, startOffset, offset, 0, value.LootboxPrizeType);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte[]>(ref bytes, startOffset, offset, 1, value.SerializedModel);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LootboxPrizeModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LootboxPrizeModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, byte[]> _SerializedModel;

        // 0
        public override global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType LootboxPrizeType
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override byte[] SerializedModel
        {
            get
            {
                return _SerializedModel.Value;
            }
            set
            {
                _SerializedModel.Value = value;
            }
        }


        public LootboxPrizeModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _SerializedModel = new CacheSegment<TTypeResolver, byte[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, byte[]>(ref targetBytes, startOffset, offset, 1, ref _SerializedModel);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LootboxModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.LootboxModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel>>(ref bytes, startOffset, offset, 0, value.Prizes);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.LootboxModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LootboxModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LootboxModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.LootboxModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel>> _Prizes;

        // 0
        public override global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel> Prizes
        {
            get
            {
                return _Prizes.Value;
            }
            set
            {
                _Prizes.Value = value;
            }
        }


        public LootboxModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Prizes = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeModel>>(ref targetBytes, startOffset, offset, 0, ref _Prizes);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LootboxSoftCurrencyModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxSoftCurrencyModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.LootboxSoftCurrencyModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Amount);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.LootboxSoftCurrencyModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LootboxSoftCurrencyModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LootboxSoftCurrencyModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.LootboxSoftCurrencyModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int Amount
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public LootboxSoftCurrencyModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LootboxHardCurrencyModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxHardCurrencyModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.LootboxHardCurrencyModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Amount);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.LootboxHardCurrencyModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LootboxHardCurrencyModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LootboxHardCurrencyModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.LootboxHardCurrencyModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int Amount
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public LootboxHardCurrencyModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class LootboxWarshipPowerPointsModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxWarshipPowerPointsModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.LootboxWarshipPowerPointsModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (4 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.WarshipSkinName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.StartValue);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.FinishValue);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.MaxValueForLevel);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int?>(ref bytes, startOffset, offset, 4, value.WarshipId);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.LootboxWarshipPowerPointsModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new LootboxWarshipPowerPointsModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class LootboxWarshipPowerPointsModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.LootboxWarshipPowerPointsModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 4, 5 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _WarshipSkinName;

        // 0
        public override string WarshipSkinName
        {
            get
            {
                return _WarshipSkinName.Value;
            }
            set
            {
                _WarshipSkinName.Value = value;
            }
        }

        // 1
        public override int StartValue
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int FinishValue
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int MaxValueForLevel
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override int? WarshipId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int?>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int?>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public LootboxWarshipPowerPointsModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _WarshipSkinName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _WarshipSkinName);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int?>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class DiscountPriceFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, decimal?>(ref bytes, startOffset, offset, 0, value.CostBeforeDiscount);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new DiscountPriceObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class DiscountPriceObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 17 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override decimal? CostBeforeDiscount
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, decimal?>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, decimal?>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public DiscountPriceObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, decimal?>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class ForeignServiceProductFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.ProductGoogleId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 1, value.Consumable);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new ForeignServiceProductObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class ForeignServiceProductObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 1 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _ProductGoogleId;

        // 0
        public override string ProductGoogleId
        {
            get
            {
                return _ProductGoogleId.Value;
            }
            set
            {
                _ProductGoogleId.Value = value;
            }
        }

        // 1
        public override bool Consumable
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public ForeignServiceProductObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _ProductGoogleId = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _ProductGoogleId);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class ProductMarkFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductMark>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.ProductMark value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.MarkType>(ref bytes, startOffset, offset, 0, value.MarkType);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int?>(ref bytes, startOffset, offset, 1, value.NumberOfPercent);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.ProductMark Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new ProductMarkObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class ProductMarkObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.ProductMark, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 5 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override global::NetworkLibrary.NetworkLibrary.Http.MarkType MarkType
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.MarkType>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.MarkType>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int? NumberOfPercent
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int?>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int?>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public ProductMarkObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.MarkType>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int?>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class WarshipPowerPointsProductFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.WarshipId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.CurrentPowerPointsAmount);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.CurrentMaxPowerPointsAmount);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.PowerPointsIncrement);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WarshipPowerPointsProductObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WarshipPowerPointsProductObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int WarshipId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int CurrentPowerPointsAmount
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int CurrentMaxPowerPointsAmount
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override int PowerPointsIncrement
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public WarshipPowerPointsProductObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class WarshipModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.WarshipModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.Description);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.KitName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.PrefabPath);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.WarshipId);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WarshipModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WarshipModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.WarshipModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _Description;
        CacheSegment<TTypeResolver, string> _KitName;
        CacheSegment<TTypeResolver, string> _PrefabPath;

        // 0
        public override string Description
        {
            get
            {
                return _Description.Value;
            }
            set
            {
                _Description.Value = value;
            }
        }

        // 1
        public override string KitName
        {
            get
            {
                return _KitName.Value;
            }
            set
            {
                _KitName.Value = value;
            }
        }

        // 2
        public override string PrefabPath
        {
            get
            {
                return _PrefabPath.Value;
            }
            set
            {
                _PrefabPath.Value = value;
            }
        }

        // 3
        public override int WarshipId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public WarshipModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _Description = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _KitName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _PrefabPath = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _Description);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _KitName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _PrefabPath);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class ProductModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.ProductModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (17 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::DataLayer.Tables.TransactionTypeEnum>(ref bytes, startOffset, offset, 0, value.TransactionType);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.ImagePreviewPath);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.CostString);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>(ref bytes, startOffset, offset, 3, value.CurrencyTypeEnum);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 4, value.Id);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 5, value.Name);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductMark>(ref bytes, startOffset, offset, 6, value.ProductMark);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct>(ref bytes, startOffset, offset, 7, value.ForeignServiceProduct);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice>(ref bytes, startOffset, offset, 8, value.DiscountPrice);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct>(ref bytes, startOffset, offset, 9, value.WarshipPowerPointsProduct);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum?>(ref bytes, startOffset, offset, 10, value.ShopItemSize);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.DateTime?>(ref bytes, startOffset, offset, 11, value.UtcDeadline);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int?>(ref bytes, startOffset, offset, 12, value.MagnificationRatio);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipModel>(ref bytes, startOffset, offset, 13, value.WarshipModel);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 14, value.Cost);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 15, value.Disabled);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 16, value.SkinPrefabPath);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 17, value.Amount);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 17);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.ProductModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new ProductModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class ProductModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.ProductModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0, 0, 4, 4, 0, 0, 0, 0, 0, 5, 13, 5, 0, 4, 1, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _ImagePreviewPath;
        CacheSegment<TTypeResolver, string> _CostString;
        CacheSegment<TTypeResolver, string> _Name;
        global::NetworkLibrary.NetworkLibrary.Http.ProductMark _ProductMark;
        global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct _ForeignServiceProduct;
        global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice _DiscountPrice;
        global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct _WarshipPowerPointsProduct;
        global::NetworkLibrary.NetworkLibrary.Http.WarshipModel _WarshipModel;
        CacheSegment<TTypeResolver, string> _SkinPrefabPath;

        // 0
        public override global::DataLayer.Tables.TransactionTypeEnum TransactionType
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::DataLayer.Tables.TransactionTypeEnum>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::DataLayer.Tables.TransactionTypeEnum>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string ImagePreviewPath
        {
            get
            {
                return _ImagePreviewPath.Value;
            }
            set
            {
                _ImagePreviewPath.Value = value;
            }
        }

        // 2
        public override string CostString
        {
            get
            {
                return _CostString.Value;
            }
            set
            {
                _CostString.Value = value;
            }
        }

        // 3
        public override global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum CurrencyTypeEnum
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override int Id
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override string Name
        {
            get
            {
                return _Name.Value;
            }
            set
            {
                _Name.Value = value;
            }
        }

        // 6
        public override global::NetworkLibrary.NetworkLibrary.Http.ProductMark ProductMark
        {
            get
            {
                return _ProductMark;
            }
            set
            {
                __tracker.Dirty();
                _ProductMark = value;
            }
        }

        // 7
        public override global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct ForeignServiceProduct
        {
            get
            {
                return _ForeignServiceProduct;
            }
            set
            {
                __tracker.Dirty();
                _ForeignServiceProduct = value;
            }
        }

        // 8
        public override global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice DiscountPrice
        {
            get
            {
                return _DiscountPrice;
            }
            set
            {
                __tracker.Dirty();
                _DiscountPrice = value;
            }
        }

        // 9
        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct WarshipPowerPointsProduct
        {
            get
            {
                return _WarshipPowerPointsProduct;
            }
            set
            {
                __tracker.Dirty();
                _WarshipPowerPointsProduct = value;
            }
        }

        // 10
        public override global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum? ShopItemSize
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum?>(__originalBytes, 10, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum?>(__originalBytes, 10, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 11
        public override global::System.DateTime? UtcDeadline
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::System.DateTime?>(__originalBytes, 11, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::System.DateTime?>(__originalBytes, 11, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 12
        public override int? MagnificationRatio
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int?>(__originalBytes, 12, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int?>(__originalBytes, 12, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 13
        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipModel WarshipModel
        {
            get
            {
                return _WarshipModel;
            }
            set
            {
                __tracker.Dirty();
                _WarshipModel = value;
            }
        }

        // 14
        public override int Cost
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 14, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 14, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 15
        public override bool Disabled
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 15, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 15, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 16
        public override string SkinPrefabPath
        {
            get
            {
                return _SkinPrefabPath.Value;
            }
            set
            {
                _SkinPrefabPath.Value = value;
            }
        }

        // 17
        public override int Amount
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 17, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 17, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public ProductModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 17, __elementSizes);

            _ImagePreviewPath = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _CostString = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
            _Name = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _ProductMark = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductMark>(originalBytes, 6, __binaryLastIndex, __tracker);
            _ForeignServiceProduct = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct>(originalBytes, 7, __binaryLastIndex, __tracker);
            _DiscountPrice = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice>(originalBytes, 8, __binaryLastIndex, __tracker);
            _WarshipPowerPointsProduct = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct>(originalBytes, 9, __binaryLastIndex, __tracker);
            _WarshipModel = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipModel>(originalBytes, 13, __binaryLastIndex, __tracker);
            _SkinPrefabPath = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 16, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (17 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::DataLayer.Tables.TransactionTypeEnum>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _ImagePreviewPath);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _CostString);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 5, ref _Name);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductMark>(ref targetBytes, startOffset, offset, 6, _ProductMark);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ForeignServiceProduct>(ref targetBytes, startOffset, offset, 7, _ForeignServiceProduct);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.DiscountPrice>(ref targetBytes, startOffset, offset, 8, _DiscountPrice);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipPowerPointsProduct>(ref targetBytes, startOffset, offset, 9, _WarshipPowerPointsProduct);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum?>(ref targetBytes, startOffset, offset, 10, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::System.DateTime?>(ref targetBytes, startOffset, offset, 11, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int?>(ref targetBytes, startOffset, offset, 12, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipModel>(ref targetBytes, startOffset, offset, 13, _WarshipModel);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 14, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 15, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 16, ref _SkinPrefabPath);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 17, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 17);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class SectionModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SectionModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.SectionModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel[][]>(ref bytes, startOffset, offset, 0, value.UiItems);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 1, value.NeedFooterPointer);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.HeaderName);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.SectionModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new SectionModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class SectionModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.SectionModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 1, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel[][]> _UiItems;
        CacheSegment<TTypeResolver, string> _HeaderName;

        // 0
        public override global::NetworkLibrary.NetworkLibrary.Http.ProductModel[][] UiItems
        {
            get
            {
                return _UiItems.Value;
            }
            set
            {
                _UiItems.Value = value;
            }
        }

        // 1
        public override bool NeedFooterPointer
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override string HeaderName
        {
            get
            {
                return _HeaderName.Value;
            }
            set
            {
                _HeaderName.Value = value;
            }
        }


        public SectionModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _UiItems = new CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel[][]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _HeaderName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductModel[][]>(ref targetBytes, startOffset, offset, 0, ref _UiItems);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _HeaderName);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class ShopModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ShopModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.ShopModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.Id);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SectionModel>>(ref bytes, startOffset, offset, 1, value.UiSections);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.ShopModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new ShopModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class ShopModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.ShopModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SectionModel>> _UiSections;

        // 0
        public override int Id
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SectionModel> UiSections
        {
            get
            {
                return _UiSections.Value;
            }
            set
            {
                _UiSections.Value = value;
            }
        }


        public ShopModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _UiSections = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SectionModel>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.SectionModel>>(ref targetBytes, startOffset, offset, 1, ref _UiSections);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class WarshipImprovementModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.WarshipImprovementModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.WarshipImprovementModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.PowerPointsCost);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.SoftCurrencyCost);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.WarshipImprovementModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new WarshipImprovementModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class WarshipImprovementModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.WarshipImprovementModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int PowerPointsCost
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override int SoftCurrencyCost
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public WarshipImprovementModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class GameRoomValidationResultFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResult>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResult value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>(ref bytes, startOffset, offset, 0, value.ResultEnum);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string[]>(ref bytes, startOffset, offset, 1, value.ProblemPlayersIds);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResult Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new GameRoomValidationResultObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class GameRoomValidationResultObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResult, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string[]> _ProblemPlayersIds;

        // 0
        public override global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum ResultEnum
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string[] ProblemPlayersIds
        {
            get
            {
                return _ProblemPlayersIds.Value;
            }
            set
            {
                _ProblemPlayersIds.Value = value;
            }
        }


        public GameRoomValidationResultObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _ProblemPlayersIds = new CacheSegment<TTypeResolver, string[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string[]>(ref targetBytes, startOffset, offset, 1, ref _ProblemPlayersIds);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class BattleRoyaleClientMatchModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (4 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.GameServerIp);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.GameServerPort);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.MatchId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 3, value.PlayerTemporaryId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel[]>(ref bytes, startOffset, offset, 4, value.PlayerModels);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 4);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BattleRoyaleClientMatchModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BattleRoyaleClientMatchModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 2, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _GameServerIp;
        CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel[]> _PlayerModels;

        // 0
        public override string GameServerIp
        {
            get
            {
                return _GameServerIp.Value;
            }
            set
            {
                _GameServerIp.Value = value;
            }
        }

        // 1
        public override int GameServerPort
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int MatchId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override ushort PlayerTemporaryId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 4
        public override global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel[] PlayerModels
        {
            get
            {
                return _PlayerModels.Value;
            }
            set
            {
                _PlayerModels.Value = value;
            }
        }


        public BattleRoyaleClientMatchModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 4, __elementSizes);

            _GameServerIp = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _PlayerModels = new CacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 4, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (4 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _GameServerIp);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel[]>(ref targetBytes, startOffset, offset, 4, ref _PlayerModels);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 4);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class PlayerModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.PlayerModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.PlayerModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (6 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 0, value.TemporaryId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.WarshipName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.WarshipPowerLevel);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 3, value.ServiceId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 4, value.AccountId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 5, value.Nickname);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 6, value.SkinName);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 6);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.PlayerModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new PlayerModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class PlayerModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.PlayerModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 2, 0, 4, 0, 4, 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _WarshipName;
        CacheSegment<TTypeResolver, string> _ServiceId;
        CacheSegment<TTypeResolver, string> _Nickname;
        CacheSegment<TTypeResolver, string> _SkinName;

        // 0
        public override ushort TemporaryId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string WarshipName
        {
            get
            {
                return _WarshipName.Value;
            }
            set
            {
                _WarshipName.Value = value;
            }
        }

        // 2
        public override int WarshipPowerLevel
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override string ServiceId
        {
            get
            {
                return _ServiceId.Value;
            }
            set
            {
                _ServiceId.Value = value;
            }
        }

        // 4
        public override int AccountId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override string Nickname
        {
            get
            {
                return _Nickname.Value;
            }
            set
            {
                _Nickname.Value = value;
            }
        }

        // 6
        public override string SkinName
        {
            get
            {
                return _SkinName.Value;
            }
            set
            {
                _SkinName.Value = value;
            }
        }


        public PlayerModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 6, __elementSizes);

            _WarshipName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _ServiceId = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
            _Nickname = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 5, __binaryLastIndex, __tracker));
            _SkinName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 6, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (6 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _WarshipName);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 3, ref _ServiceId);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 5, ref _Nickname);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 6, ref _SkinName);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 6);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class BotModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BotModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.BotModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 0, value.TemporaryId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 1, value.BotName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 2, value.WarshipName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 3, value.WarshipPowerLevel);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.BotModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BotModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BotModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.BotModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 2, 0, 0, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _BotName;
        CacheSegment<TTypeResolver, string> _WarshipName;

        // 0
        public override ushort TemporaryId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override string BotName
        {
            get
            {
                return _BotName.Value;
            }
            set
            {
                _BotName.Value = value;
            }
        }

        // 2
        public override string WarshipName
        {
            get
            {
                return _WarshipName.Value;
            }
            set
            {
                _WarshipName.Value = value;
            }
        }

        // 3
        public override int WarshipPowerLevel
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 3, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public BotModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _BotName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
            _WarshipName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 1, ref _BotName);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 2, ref _WarshipName);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 3, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class GameUnitsFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameUnits>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.GameUnits value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.PlayerModel>>(ref bytes, startOffset, offset, 0, value.Players);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.BotModel>>(ref bytes, startOffset, offset, 1, value.Bots);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.GameUnits Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new GameUnitsObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class GameUnitsObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.GameUnits, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.PlayerModel>> _Players;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.BotModel>> _Bots;

        // 0
        public override global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.PlayerModel> Players
        {
            get
            {
                return _Players.Value;
            }
            set
            {
                _Players.Value = value;
            }
        }

        // 1
        public override global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.BotModel> Bots
        {
            get
            {
                return _Bots.Value;
            }
            set
            {
                _Bots.Value = value;
            }
        }


        public GameUnitsObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _Players = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.PlayerModel>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _Bots = new CacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.BotModel>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.PlayerModel>>(ref targetBytes, startOffset, offset, 0, ref _Players);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.List<global::NetworkLibrary.NetworkLibrary.Http.BotModel>>(ref targetBytes, startOffset, offset, 1, ref _Bots);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class BattleRoyaleMatchModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleMatchModel>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleMatchModel value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.GameServerIp);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.GameServerPort);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.MatchId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameUnits>(ref bytes, startOffset, offset, 3, value.GameUnits);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleMatchModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new BattleRoyaleMatchModelObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class BattleRoyaleMatchModelObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleMatchModel, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _GameServerIp;
        global::NetworkLibrary.NetworkLibrary.Http.GameUnits _GameUnits;

        // 0
        public override string GameServerIp
        {
            get
            {
                return _GameServerIp.Value;
            }
            set
            {
                _GameServerIp.Value = value;
            }
        }

        // 1
        public override int GameServerPort
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int MatchId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::NetworkLibrary.NetworkLibrary.Http.GameUnits GameUnits
        {
            get
            {
                return _GameUnits;
            }
            set
            {
                __tracker.Dirty();
                _GameUnits = value;
            }
        }


        public BattleRoyaleMatchModelObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _GameServerIp = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _GameUnits = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameUnits>(originalBytes, 3, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _GameServerIp);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameUnits>(ref targetBytes, startOffset, offset, 3, _GameUnits);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class MatchmakerResponseFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.MatchmakerResponse>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.MatchmakerResponse value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (5 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 0, value.PlayerHasJustBeenRegistered);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 1, value.PlayerInQueue);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, bool>(ref bytes, startOffset, offset, 2, value.PlayerInBattle);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel>(ref bytes, startOffset, offset, 3, value.MatchModel);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 4, value.NumberOfPlayersInQueue);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 5, value.NumberOfPlayersInBattles);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 5);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.MatchmakerResponse Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MatchmakerResponseObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MatchmakerResponseObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Http.MatchmakerResponse, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 1, 1, 1, 0, 4, 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel _MatchModel;

        // 0
        public override bool PlayerHasJustBeenRegistered
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override bool PlayerInQueue
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override bool PlayerInBattle
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, bool>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, bool>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel MatchModel
        {
            get
            {
                return _MatchModel;
            }
            set
            {
                __tracker.Dirty();
                _MatchModel = value;
            }
        }

        // 4
        public override int NumberOfPlayersInQueue
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 4, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 5
        public override int NumberOfPlayersInBattles
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 5, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public MatchmakerResponseObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 5, __elementSizes);

            _MatchModel = ObjectSegmentHelper.DeserializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel>(originalBytes, 3, __binaryLastIndex, __tracker);
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (5 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, bool>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeSegment<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyaleClientMatchModel>(ref targetBytes, startOffset, offset, 3, _MatchModel);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 4, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 5, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 5);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Experimental
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MatchResultDtoFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Experimental.MatchResultDto>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Experimental.MatchResultDto value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (3 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, string>(ref bytes, startOffset, offset, 0, value.SkinName);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 1, value.CurrentWarshipRating);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 2, value.MatchRatingDelta);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.Dictionary<global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum, int>>(ref bytes, startOffset, offset, 3, value.LootboxPoints);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 3);
            }
        }

        public override global::Libraries.NetworkLibrary.Experimental.MatchResultDto Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MatchResultDtoObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MatchResultDtoObjectSegment<TTypeResolver> : global::Libraries.NetworkLibrary.Experimental.MatchResultDto, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 4, 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, string> _SkinName;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum, int>> _LootboxPoints;

        // 0
        public override string SkinName
        {
            get
            {
                return _SkinName.Value;
            }
            set
            {
                _SkinName.Value = value;
            }
        }

        // 1
        public override int CurrentWarshipRating
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override int MatchRatingDelta
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 2, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 3
        public override global::System.Collections.Generic.Dictionary<global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum, int> LootboxPoints
        {
            get
            {
                return _LootboxPoints.Value;
            }
            set
            {
                _LootboxPoints.Value = value;
            }
        }


        public MatchResultDtoObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 3, __elementSizes);

            _SkinName = new CacheSegment<TTypeResolver, string>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _LootboxPoints = new CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum, int>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 3, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (3 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, string>(ref targetBytes, startOffset, offset, 0, ref _SkinName);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 2, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum, int>>(ref targetBytes, startOffset, offset, 3, ref _LootboxPoints);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 3);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class CooldownsInfosMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsInfosMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsInfosMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (1 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, float>(ref bytes, startOffset, offset, 0, value.AbilityMaxCooldown);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo[]>(ref bytes, startOffset, offset, 1, value.WeaponsInfos);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 1);
            }
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsInfosMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new CooldownsInfosMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class CooldownsInfosMessageObjectSegment<TTypeResolver> : global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsInfosMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo[]> _WeaponsInfos;

        // 0
        public override float AbilityMaxCooldown
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, float>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 1
        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo[] WeaponsInfos
        {
            get
            {
                return _WeaponsInfos.Value;
            }
            set
            {
                _WeaponsInfos.Value = value;
            }
        }


        public CooldownsInfosMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 1, __elementSizes);

            _WeaponsInfos = new CacheSegment<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo[]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 1, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (1 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, float>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo[]>(ref targetBytes, startOffset, offset, 1, ref _WeaponsInfos);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 1);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class PositionsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.PositionsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.PositionsMessage value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (2 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>>(ref bytes, startOffset, offset, 0, value.EntitiesInfo);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, ushort>(ref bytes, startOffset, offset, 1, value.PlayerEntityId);
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>>(ref bytes, startOffset, offset, 2, value.RadiusInfo);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 2);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.PositionsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new PositionsMessageObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class PositionsMessageObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.PositionsMessage, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0, 2, 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>> _EntitiesInfo;
        CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>> _RadiusInfo;

        // 0
        public override global::System.Collections.Generic.Dictionary<ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform> EntitiesInfo
        {
            get
            {
                return _EntitiesInfo.Value;
            }
            set
            {
                _EntitiesInfo.Value = value;
            }
        }

        // 1
        public override ushort PlayerEntityId
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, ushort>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, ushort>(__originalBytes, 1, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }

        // 2
        public override global::System.Collections.Generic.Dictionary<ushort, ushort> RadiusInfo
        {
            get
            {
                return _RadiusInfo.Value;
            }
            set
            {
                _RadiusInfo.Value = value;
            }
        }


        public PositionsMessageObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 2, __elementSizes);

            _EntitiesInfo = new CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
            _RadiusInfo = new CacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 2, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (2 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>>(ref targetBytes, startOffset, offset, 0, ref _EntitiesInfo);
                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, ushort>(ref targetBytes, startOffset, offset, 1, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);
                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>>(ref targetBytes, startOffset, offset, 2, ref _RadiusInfo);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 2);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }

    public class TestMessageClass1Formatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageClass1>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageClass1 value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, int>(ref bytes, startOffset, offset, 0, value.SomeNumber);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageClass1 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new TestMessageClass1ObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class TestMessageClass1ObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageClass1, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 4 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;


        // 0
        public override int SomeNumber
        {
            get
            {
                return ObjectSegmentHelper.GetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, __tracker);
            }
            set
            {
                ObjectSegmentHelper.SetFixedProperty<TTypeResolver, int>(__originalBytes, 0, __binaryLastIndex, __extraFixedBytes, value, __tracker);
            }
        }


        public TestMessageClass1ObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeFixedLength<TTypeResolver, int>(ref targetBytes, startOffset, offset, 0, __binaryLastIndex, __originalBytes, __extraFixedBytes, __tracker);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MessagesContainerFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessagesContainer>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.MessagesContainer value)
        {
            var segment = value as IZeroFormatterSegment;
            if (segment != null)
            {
                return segment.Serialize(ref bytes, offset);
            }
            else if (value == null)
            {
                BinaryUtil.WriteInt32(ref bytes, offset, -1);
                return 4;
            }
            else
            {
                var startOffset = offset;

                offset += (8 + 4 * (0 + 1));
                offset += ObjectSegmentHelper.SerializeFromFormatter<TTypeResolver, byte[][]>(ref bytes, startOffset, offset, 0, value.Messages);

                return ObjectSegmentHelper.WriteSize(ref bytes, startOffset, offset, 0);
            }
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.MessagesContainer Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = BinaryUtil.ReadInt32(ref bytes, offset);
            if (byteSize == -1)
            {
                byteSize = 4;
                return null;
            }
            return new MessagesContainerObjectSegment<TTypeResolver>(tracker, new ArraySegment<byte>(bytes, offset, byteSize));
        }
    }

    public class MessagesContainerObjectSegment<TTypeResolver> : global::NetworkLibrary.NetworkLibrary.Udp.MessagesContainer, IZeroFormatterSegment
        where TTypeResolver : ITypeResolver, new()
    {
        static readonly int[] __elementSizes = new int[]{ 0 };

        readonly ArraySegment<byte> __originalBytes;
        readonly global::ZeroFormatter.DirtyTracker __tracker;
        readonly int __binaryLastIndex;
        readonly byte[] __extraFixedBytes;

        CacheSegment<TTypeResolver, byte[][]> _Messages;

        // 0
        public override byte[][] Messages
        {
            get
            {
                return _Messages.Value;
            }
            set
            {
                _Messages.Value = value;
            }
        }


        public MessagesContainerObjectSegment(global::ZeroFormatter.DirtyTracker dirtyTracker, ArraySegment<byte> originalBytes)
        {
            var __array = originalBytes.Array;

            this.__originalBytes = originalBytes;
            this.__tracker = dirtyTracker = dirtyTracker.CreateChild();
            this.__binaryLastIndex = BinaryUtil.ReadInt32(ref __array, originalBytes.Offset + 4);

            this.__extraFixedBytes = ObjectSegmentHelper.CreateExtraFixedBytes(this.__binaryLastIndex, 0, __elementSizes);

            _Messages = new CacheSegment<TTypeResolver, byte[][]>(__tracker, ObjectSegmentHelper.GetSegment(originalBytes, 0, __binaryLastIndex, __tracker));
        }

        public bool CanDirectCopy()
        {
            return !__tracker.IsDirty;
        }

        public ArraySegment<byte> GetBufferReference()
        {
            return __originalBytes;
        }

        public int Serialize(ref byte[] targetBytes, int offset)
        {
            if (__extraFixedBytes != null || __tracker.IsDirty)
            {
                var startOffset = offset;
                offset += (8 + 4 * (0 + 1));

                offset += ObjectSegmentHelper.SerializeCacheSegment<TTypeResolver, byte[][]>(ref targetBytes, startOffset, offset, 0, ref _Messages);

                return ObjectSegmentHelper.WriteSize(ref targetBytes, startOffset, offset, 0);
            }
            else
            {
                return ObjectSegmentHelper.DirectCopyAll(__originalBytes, ref targetBytes, offset);
            }
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class BattleRoyalePlayerModelFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        readonly Formatter<TTypeResolver, string> formatter1;
        readonly Formatter<TTypeResolver, string> formatter2;
        readonly Formatter<TTypeResolver, int> formatter3;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                ;
            }
        }

        public BattleRoyalePlayerModelFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            formatter1 = Formatter<TTypeResolver, string>.Default;
            formatter2 = Formatter<TTypeResolver, string>.Default;
            formatter3 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.AccountId);
            offset += formatter1.Serialize(ref bytes, offset, value.Nickname);
            offset += formatter2.Serialize(ref bytes, offset, value.WarshipName);
            offset += formatter3.Serialize(ref bytes, offset, value.WarshipPowerLevel);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Http.BattleRoyalePlayerModel(item0, item1, item2, item3);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class WeaponInfoFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::ViewTypeId> formatter0;
        readonly Formatter<TTypeResolver, float> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public WeaponInfoFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::ViewTypeId>.Default;
            formatter1 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 5);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.ViewType);
            offset += formatter1.Serialize(ref bytes, offset, value.Cooldown);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.WeaponInfo(item0, item1);
        }
    }

    public class KillMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        readonly Formatter<TTypeResolver, global::ViewTypeId> formatter1;
        readonly Formatter<TTypeResolver, int> formatter2;
        readonly Formatter<TTypeResolver, global::ViewTypeId> formatter3;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                ;
            }
        }

        public KillMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            formatter1 = Formatter<TTypeResolver, global::ViewTypeId>.Default;
            formatter2 = Formatter<TTypeResolver, int>.Default;
            formatter3 = Formatter<TTypeResolver, global::ViewTypeId>.Default;
            
        }

        public override int? GetLength()
        {
            return 10;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 10);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.KillerId);
            offset += formatter1.Serialize(ref bytes, offset, value.KillerType);
            offset += formatter2.Serialize(ref bytes, offset, value.VictimId);
            offset += formatter3.Serialize(ref bytes, offset, value.VictimType);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.KillMessage(item0, item1, item2, item3);
        }
    }

    public class PlayerInfoMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<int, ushort>> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public PlayerInfoMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<int, ushort>>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.EntityIds);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerInfoMessage(item0);
        }
    }

    public class PlayerTrackingMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public PlayerTrackingMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.PlayerId);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PlayerTrackingMessage(item0);
        }
    }

    public class PointTrackingMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public PointTrackingMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Point);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.PointTrackingMessage(item0);
        }
    }

    public class ShowPlayerAchievementsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public ShowPlayerAchievementsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.MatchId);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.ShowPlayerAchievementsMessage(item0);
        }
    }

    public class CooldownsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        readonly Formatter<TTypeResolver, float[]> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public CooldownsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            formatter1 = Formatter<TTypeResolver, float[]>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.AbilityCooldown);
            offset += formatter1.Serialize(ref bytes, offset, value.WeaponsCooldowns);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.BattleStatus.CooldownsMessage(item0, item1);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class ViewTransformFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, ushort> formatter0;
        readonly Formatter<TTypeResolver, ushort> formatter1;
        readonly Formatter<TTypeResolver, ushort> formatter2;
        readonly Formatter<TTypeResolver, global::ViewTypeId> formatter3;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                ;
            }
        }

        public ViewTransformFormatter()
        {
            formatter0 = Formatter<TTypeResolver, ushort>.Default;
            formatter1 = Formatter<TTypeResolver, ushort>.Default;
            formatter2 = Formatter<TTypeResolver, ushort>.Default;
            formatter3 = Formatter<TTypeResolver, global::ViewTypeId>.Default;
            
        }

        public override int? GetLength()
        {
            return 7;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 7);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.__x);
            offset += formatter1.Serialize(ref bytes, offset, value.__y);
            offset += formatter2.Serialize(ref bytes, offset, value.__angle);
            offset += formatter3.Serialize(ref bytes, offset, value.typeId);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform(item0, item1, item2, item3);
        }
    }

    public class Vector2Formatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, ushort> formatter0;
        readonly Formatter<TTypeResolver, ushort> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public Vector2Formatter()
        {
            formatter0 = Formatter<TTypeResolver, ushort>.Default;
            formatter1 = Formatter<TTypeResolver, ushort>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.__x);
            offset += formatter1.Serialize(ref bytes, offset, value.__y);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.Vector2(item0, item1);
        }
    }

    public class TestPositionsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>> formatter0;
        readonly Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public TestPositionsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ViewTransform>>.Default;
            formatter1 = Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.EntitiesInfo);
            offset += formatter1.Serialize(ref bytes, offset, value.__RadiusInfo);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestPositionsMessage(item0, item1);
        }
    }

    public class RadiusesMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public RadiusesMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.RadiusInfo);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.RadiusesMessage(item0);
        }
    }

    public class DetachesMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, ushort[]> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public DetachesMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, ushort[]>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.DetachedIds);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DetachesMessage(item0);
        }
    }

    public class DestroysMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, ushort[]> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public DestroysMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, ushort[]>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.DestroyedIds);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.DestroysMessage(item0);
        }
    }

    public class HidesMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, ushort[]> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public HidesMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, ushort[]>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.HiddenIds);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.HidesMessage(item0);
        }
    }

    public class ParentsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public ParentsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::System.Collections.Generic.Dictionary<ushort, ushort>>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessage value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.ParentInfo);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.ParentsMessage(item0);
        }
    }

    public class TestMessageStruct1Formatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public TestMessageStruct1Formatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1 value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.SomeNumber);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1 Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.ServerToPlayer.PositionMessages.TestMessageStruct1(item0);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.Common
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class DeliveryConfirmationMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, uint> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public DeliveryConfirmationMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, uint>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.MessageNumberThatConfirms);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.Common.DeliveryConfirmationMessage(item0);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.PlayerToServer
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class BattleExitMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, int> formatter0;
        readonly Formatter<TTypeResolver, ushort> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public BattleExitMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, int>.Default;
            formatter1 = Formatter<TTypeResolver, ushort>.Default;
            
        }

        public override int? GetLength()
        {
            return 6;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 6);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.MatchId);
            offset += formatter1.Serialize(ref bytes, offset, value.TemporaryId);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.PlayerToServer.BattleExitMessage(item0, item1);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class PlayerInputMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, ushort> formatter0;
        readonly Formatter<TTypeResolver, int> formatter1;
        readonly Formatter<TTypeResolver, float> formatter2;
        readonly Formatter<TTypeResolver, float> formatter3;
        readonly Formatter<TTypeResolver, float> formatter4;
        readonly Formatter<TTypeResolver, bool> formatter5;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                    && formatter4.NoUseDirtyTracker
                    && formatter5.NoUseDirtyTracker
                ;
            }
        }

        public PlayerInputMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, ushort>.Default;
            formatter1 = Formatter<TTypeResolver, int>.Default;
            formatter2 = Formatter<TTypeResolver, float>.Default;
            formatter3 = Formatter<TTypeResolver, float>.Default;
            formatter4 = Formatter<TTypeResolver, float>.Default;
            formatter5 = Formatter<TTypeResolver, bool>.Default;
            
        }

        public override int? GetLength()
        {
            return 19;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 19);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.TemporaryId);
            offset += formatter1.Serialize(ref bytes, offset, value.MatchId);
            offset += formatter2.Serialize(ref bytes, offset, value.X);
            offset += formatter3.Serialize(ref bytes, offset, value.Y);
            offset += formatter4.Serialize(ref bytes, offset, value.Angle);
            offset += formatter5.Serialize(ref bytes, offset, value.UseAbility);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item4 = formatter4.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item5 = formatter5.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.UserInputMessage.PlayerInputMessage(item0, item1, item2, item3, item4, item5);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class PlayerPingMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, ushort> formatter0;
        readonly Formatter<TTypeResolver, int> formatter1;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                ;
            }
        }

        public PlayerPingMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, ushort>.Default;
            formatter1 = Formatter<TTypeResolver, int>.Default;
            
        }

        public override int? GetLength()
        {
            return 6;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 6);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.TemporaryId);
            offset += formatter1.Serialize(ref bytes, offset, value.MatchId);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.PlayerToServer.Ping.PlayerPingMessage(item0, item1);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Udp.ServerToPlayer
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class HealthPointsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public HealthPointsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Value);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.HealthPointsMessage(item0);
        }
    }

    public class MaxHealthPointsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public MaxHealthPointsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Value);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxHealthPointsMessage(item0);
        }
    }

    public class MaxShieldPointsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public MaxShieldPointsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Value);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.MaxShieldPointsMessage(item0);
        }
    }

    public class ShieldPointsMessageFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessage>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, float> formatter0;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                ;
            }
        }

        public ShieldPointsMessageFormatter()
        {
            formatter0 = Formatter<TTypeResolver, float>.Default;
            
        }

        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessage value)
        {
            BinaryUtil.EnsureCapacity(ref bytes, offset, 4);
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.Value);
            return offset - startOffset;
        }

        public override global::Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessage Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::Libraries.NetworkLibrary.Udp.ServerToPlayer.ShieldPointsMessage(item0);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp
{
    using global::System;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;

    public class MessageWrapperFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageWrapper>
        where TTypeResolver : ITypeResolver, new()
    {
        readonly Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageType> formatter0;
        readonly Formatter<TTypeResolver, byte[]> formatter1;
        readonly Formatter<TTypeResolver, uint> formatter2;
        readonly Formatter<TTypeResolver, bool> formatter3;
        
        public override bool NoUseDirtyTracker
        {
            get
            {
                return formatter0.NoUseDirtyTracker
                    && formatter1.NoUseDirtyTracker
                    && formatter2.NoUseDirtyTracker
                    && formatter3.NoUseDirtyTracker
                ;
            }
        }

        public MessageWrapperFormatter()
        {
            formatter0 = Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageType>.Default;
            formatter1 = Formatter<TTypeResolver, byte[]>.Default;
            formatter2 = Formatter<TTypeResolver, uint>.Default;
            formatter3 = Formatter<TTypeResolver, bool>.Default;
            
        }

        public override int? GetLength()
        {
            return null;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.MessageWrapper value)
        {
            var startOffset = offset;
            offset += formatter0.Serialize(ref bytes, offset, value.MessageType);
            offset += formatter1.Serialize(ref bytes, offset, value.SerializedMessage);
            offset += formatter2.Serialize(ref bytes, offset, value.MessageId);
            offset += formatter3.Serialize(ref bytes, offset, value.NeedResponse);
            return offset - startOffset;
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.MessageWrapper Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 0;
            int size;
            var item0 = formatter0.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item1 = formatter1.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item2 = formatter2.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            var item3 = formatter3.Deserialize(ref bytes, offset, tracker, out size);
            offset += size;
            byteSize += size;
            
            return new global::NetworkLibrary.NetworkLibrary.Udp.MessageWrapper(item0, item1, item2, item3);
        }
    }


}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class ViewTypeIdFormatter<TTypeResolver> : Formatter<TTypeResolver, global::ViewTypeId>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::ViewTypeId value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::ViewTypeId Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::ViewTypeId)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }



    public class ViewTypeIdEqualityComparer : IEqualityComparer<global::ViewTypeId>
    {
        public bool Equals(global::ViewTypeId x, global::ViewTypeId y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::ViewTypeId x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.DataLayer.Tables
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class TransactionTypeEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::DataLayer.Tables.TransactionTypeEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::DataLayer.Tables.TransactionTypeEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::DataLayer.Tables.TransactionTypeEnum Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::DataLayer.Tables.TransactionTypeEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class TransactionTypeEnumEqualityComparer : IEqualityComparer<global::DataLayer.Tables.TransactionTypeEnum>
    {
        public bool Equals(global::DataLayer.Tables.TransactionTypeEnum x, global::DataLayer.Tables.TransactionTypeEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::DataLayer.Tables.TransactionTypeEnum x)
        {
            return (int)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.Libraries.NetworkLibrary.Experimental
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class MatchRewardTypeEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class MatchRewardTypeEnumEqualityComparer : IEqualityComparer<global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum>
    {
        public bool Equals(global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum x, global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::Libraries.NetworkLibrary.Experimental.MatchRewardTypeEnum x)
        {
            return (int)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Http
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class IncrementCoefficientFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class IncrementCoefficientEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient x, global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.IncrementCoefficient x)
        {
            return (int)x;
        }
    }



    public class UiIncrementTypeEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class UiIncrementTypeEnumEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum x, global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.UiIncrementTypeEnum x)
        {
            return (int)x;
        }
    }



    public class SkinTypeEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class SkinTypeEnumEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum x, global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.SkinTypeEnum x)
        {
            return (int)x;
        }
    }



    public class LootboxPrizeTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class LootboxPrizeTypeEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType x, global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.LootboxPrizeType x)
        {
            return (int)x;
        }
    }



    public class MarkTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.MarkType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.MarkType value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.MarkType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.MarkType)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class MarkTypeEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.MarkType>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.MarkType x, global::NetworkLibrary.NetworkLibrary.Http.MarkType y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.MarkType x)
        {
            return (int)x;
        }
    }



    public class CurrencyTypeEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class CurrencyTypeEnumEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum x, global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.CurrencyTypeEnum x)
        {
            return (int)x;
        }
    }



    public class ProductSizeEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }


    public class NullableProductSizeEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum?>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 5;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum? value)
        {
            BinaryUtil.WriteBoolean(ref bytes, offset, value.HasValue);
            if (value.HasValue)
            {
                BinaryUtil.WriteInt32(ref bytes, offset + 1, (Int32)value.Value);
            }
            else
            {
                BinaryUtil.EnsureCapacity(ref bytes, offset, offset + 5);
            }

            return 5;
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum? Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 5;
            var hasValue = BinaryUtil.ReadBoolean(ref bytes, offset);
            if (!hasValue) return null;

            return (global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum)BinaryUtil.ReadInt32(ref bytes, offset + 1);
        }
    }



    public class ProductSizeEnumEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum x, global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.ProductSizeEnum x)
        {
            return (int)x;
        }
    }



    public class GameRoomValidationResultEnumFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 4;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum value)
        {
            return BinaryUtil.WriteInt32(ref bytes, offset, (Int32)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 4;
            return (global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum)BinaryUtil.ReadInt32(ref bytes, offset);
        }
    }



    public class GameRoomValidationResultEnumEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum x, global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum y)
        {
            return (Int32)x == (Int32)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Http.GameRoomValidationResultEnum x)
        {
            return (int)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168
namespace ZeroFormatter.DynamicObjectSegments.NetworkLibrary.NetworkLibrary.Udp
{
    using global::System;
    using global::System.Collections.Generic;
    using global::ZeroFormatter.Formatters;
    using global::ZeroFormatter.Internal;
    using global::ZeroFormatter.Segments;


    public class MessageTypeFormatter<TTypeResolver> : Formatter<TTypeResolver, global::NetworkLibrary.NetworkLibrary.Udp.MessageType>
        where TTypeResolver : ITypeResolver, new()
    {
        public override int? GetLength()
        {
            return 1;
        }

        public override int Serialize(ref byte[] bytes, int offset, global::NetworkLibrary.NetworkLibrary.Udp.MessageType value)
        {
            return BinaryUtil.WriteByte(ref bytes, offset, (Byte)value);
        }

        public override global::NetworkLibrary.NetworkLibrary.Udp.MessageType Deserialize(ref byte[] bytes, int offset, global::ZeroFormatter.DirtyTracker tracker, out int byteSize)
        {
            byteSize = 1;
            return (global::NetworkLibrary.NetworkLibrary.Udp.MessageType)BinaryUtil.ReadByte(ref bytes, offset);
        }
    }



    public class MessageTypeEqualityComparer : IEqualityComparer<global::NetworkLibrary.NetworkLibrary.Udp.MessageType>
    {
        public bool Equals(global::NetworkLibrary.NetworkLibrary.Udp.MessageType x, global::NetworkLibrary.NetworkLibrary.Udp.MessageType y)
        {
            return (Byte)x == (Byte)y;
        }

        public int GetHashCode(global::NetworkLibrary.NetworkLibrary.Udp.MessageType x)
        {
            return (int)(Byte)x;
        }
    }



}
#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612
