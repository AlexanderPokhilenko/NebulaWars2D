//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentLookupGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public static class WppAccrualComponentsLookup {

    public const int View = 0;
    public const int Alpha = 1;
    public const int Image = 2;
    public const int MovingIcon = 3;
    public const int Position = 4;
    public const int Scale = 5;
    public const int WarshipPowerPoints = 6;

    public const int TotalComponents = 7;

    public static readonly string[] componentNames = {
        "View",
        "Alpha",
        "Image",
        "MovingIcon",
        "Position",
        "Scale",
        "WarshipPowerPoints"
    };

    public static readonly System.Type[] componentTypes = {
        typeof(Code.Scenes.BattleScene.ECS.Components.Game.ViewComponents.ViewComponent),
        typeof(Code.Scenes.LobbyScene.ECS.AlphaComponent),
        typeof(Code.Scenes.LobbyScene.ECS.ImageComponent),
        typeof(Code.Scenes.LobbyScene.ECS.MovingIconComponent),
        typeof(Code.Scenes.LobbyScene.ECS.PositionComponent),
        typeof(Code.Scenes.LobbyScene.ECS.ScaleComponent),
        typeof(Code.Scenes.LootboxScene.PrefabScripts.Wpp.ECS.WarshipPowerPointsComponent)
    };
}
