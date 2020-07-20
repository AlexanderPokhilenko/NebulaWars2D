using System;
using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;
using NetworkLibrary.NetworkLibrary.Http;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Scenes.LobbyScene.ECS
{
    [LobbyUi]
    [Unique]
    public class StartButtonClickedComponent : IComponent
    {
    }
    
    [LobbyUi] [Unique]
    public class CancelButtonClickedComponent: IComponent{}
    
    [LobbyUi] [Unique]
    public class BlurValueComponent: IComponent
    {
        public float blurValue;
    }
    
    [LobbyUi] [Unique]
    public class BlurImageEnabledComponent: IComponent{}
    
    [Unique]
    [LobbyUi]
    public class MatchLoadingTableEnabledComponent: IComponent{}

    [LobbyUi] [Unique]
    public class StartButtonPressTimeComponent: IComponent
    {
        public DateTime value;
    }
    
    [LobbyUi] [Unique]
    public class WarningEnabledComponent: IComponent
    {
        public string message;
    }
    
    [LobbyUi] 
    public class ShiftWarshipsLeftCommand: IComponent
    {}
    
    [LobbyUi]
    public class ShiftWarshipsRightCommand: IComponent{}

    [LobbyUi] [Unique]
    public class UsernameComponent: IComponent
    {
        public string username;
    }
    [LobbyUi] [Unique]
    public class SoftCurrencyComponent: IComponent
    {
        public int value;
    }
    
    [LobbyUi] [Unique]
    public class HardCurrencyComponent: IComponent
    {
        public int value;
    }
    
    [LobbyUi] [Unique]
    public class PointsForBigLootboxComponent: IComponent
    {
        public int value;
    }  
    
    [LobbyUi] [Unique] 
    public class PointsForSmallLootboxComponent: IComponent
    {
        public int value;
    }
    
    [LobbyUi] [Unique] 
    public class AccountRatingComponent: IComponent
    {
        public int value;
    }
    
    [LobbyUi] [Unique] 
    public class CurrentWarshipIndexComponent: IComponent
    {
        public int value;
    }
    
    [LobbyUi] [Unique] 
    public class BattleWaitingUiEnabledComponent: IComponent{}
    
    [LobbyUi] 
    public class WarshipComponent: IComponent
    {
        public ushort index;
        public WarshipDto warshipDto;
    }
    
    [LobbyUi] [Unique] 
    public class BlockWarshipsShiftToTheLeft: IComponent{}
    [LobbyUi] [Unique] 
    public class BlockWarshipsShiftToTheRight: IComponent{}

    [LobbyUi] [Unique]
    public class MatchSearchDataForMenuComponent: IComponent
    {
        public int numberOfPlayersInMatch;
        public int numberOfPlayersInQueue;
    }

    [LobbyUi, Game, WppAccrual]
    public sealed class PositionComponent : IComponent
    {
        public Vector3 value;
    }

    [LobbyUi, WppAccrual]
    public class ImageComponent: IComponent
    {
        public Image image;
    }

    [LobbyUi, WppAccrual]
    public class MovingIconComponent: IComponent
    {
        public int increment;
        public IconTrajectory iconTrajectory;
        public AwardTypeEnum awardTypeEnum;
    }
    
    public class IconTrajectory
    {
        public int currentControlPointIndex;
        public List<ControlPoint> controlPoints;
    }

    [LobbyUi, WppAccrual]
    public class ScaleComponent: IComponent
    {
        public Vector3 scale;
    }

    [LobbyUi, WppAccrual]
    public class AlphaComponent: IComponent
    {
        /// <summary>
        /// 0 - прозрачный, 1 - не прозрачный
        /// </summary>
        public float alpha;
    }

    [LobbyUi]
    public class AwardTextComponent: IComponent
    {
        public int quantity;
        public Vector3 startPosition;
        public DateTime creationTime;
        public DateTime fadeTime;
    }

    [LobbyUi]
    public class ViewComponent: IComponent
    {
        public GameObject gameObject;
    }

    [LobbyUi]
    public class TextComponent: IComponent
    {
        public Text Text;
    }

    [LobbyUi]
    public class CommandToCreateAwardImagesComponent: IComponent
    {
        public int quantity;
        public AwardTypeEnum awardTypeEnum;
        public DateTime startSpawnTime;
    }

    public enum AwardTypeEnum:sbyte
    {
        SoftCurrency,
        AccountRating,
        HardCurrency,
        LootboxPoints,
        WarshipPowerPoints
    }

    [LobbyUi, FlagPrefix("message")]
    public class EnableShopUiLayerComponent : IComponent
    {
        
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class DisableShopUiLayerComponent : IComponent
    {
        
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class EnableWarshipListUiLayerComponent : IComponent
    {
        
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class DisableWarshipListUiLayerComponent : IComponent
    {
        
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class EnableWarshipOverviewUiLayerComponent : IComponent
    {
        public WarshipDto WarshipDto;
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class DisableWarshipOverviewUiLayerComponent : IComponent
    {
        
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class EnableWarshipOverviewModalWindowComponent : IComponent
    {
        public WarshipDto WarshipDto;
    }
    [LobbyUi, FlagPrefix("message")]
    public class DisableWarshipOverviewModalWindowComponent : IComponent
    {
        
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class EnableWarshipImprovementModalWindowComponent : IComponent
    {
        public WarshipDto WarshipDto;
    }
    [LobbyUi, FlagPrefix("message")]
    public class DisableWarshipImprovementModalWindowComponent : IComponent
    {
        
    }

    [LobbyUi, FlagPrefix("message")]
    public class BackButtonPressedComponent : IComponent
    {
        
    }
    
    
    [LobbyUi, FlagPrefix("message")]
    public class ImproveWarshipButtonPressedComponent : IComponent
    {
        
    }
    
    [LobbyUi, FlagPrefix("message")]
    public class ShiftSkinLeftComponent : IComponent
    {
        
    }
    [LobbyUi, FlagPrefix("message")]
    public class ShiftSkinRightComponent : IComponent
    {
        
    }

    [LobbyUi, Unique]
    public class CurrentSkinIndex : IComponent
    {
        public int index;
    }

    [LobbyUi, Unique]
    public class WarshipOverviewDto : IComponent
    {
        public WarshipDto WarshipDto;
    }
}