//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class WppAccrualEntity {

    public Code.Scenes.LobbyScene.ECS.MovingIconComponent movingIcon { get { return (Code.Scenes.LobbyScene.ECS.MovingIconComponent)GetComponent(WppAccrualComponentsLookup.MovingIcon); } }
    public bool hasMovingIcon { get { return HasComponent(WppAccrualComponentsLookup.MovingIcon); } }

    public void AddMovingIcon(int newIncrement, Code.Scenes.LobbyScene.ECS.IconTrajectory newIconTrajectory, Code.Scenes.LobbyScene.ECS.AwardTypeEnum newAwardTypeEnum) {
        var index = WppAccrualComponentsLookup.MovingIcon;
        var component = (Code.Scenes.LobbyScene.ECS.MovingIconComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.MovingIconComponent));
        component.increment = newIncrement;
        component.iconTrajectory = newIconTrajectory;
        component.awardTypeEnum = newAwardTypeEnum;
        AddComponent(index, component);
    }

    public void ReplaceMovingIcon(int newIncrement, Code.Scenes.LobbyScene.ECS.IconTrajectory newIconTrajectory, Code.Scenes.LobbyScene.ECS.AwardTypeEnum newAwardTypeEnum) {
        var index = WppAccrualComponentsLookup.MovingIcon;
        var component = (Code.Scenes.LobbyScene.ECS.MovingIconComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.MovingIconComponent));
        component.increment = newIncrement;
        component.iconTrajectory = newIconTrajectory;
        component.awardTypeEnum = newAwardTypeEnum;
        ReplaceComponent(index, component);
    }

    public void RemoveMovingIcon() {
        RemoveComponent(WppAccrualComponentsLookup.MovingIcon);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiInterfaceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class WppAccrualEntity : IMovingIconEntity { }

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class WppAccrualMatcher {

    static Entitas.IMatcher<WppAccrualEntity> _matcherMovingIcon;

    public static Entitas.IMatcher<WppAccrualEntity> MovingIcon {
        get {
            if (_matcherMovingIcon == null) {
                var matcher = (Entitas.Matcher<WppAccrualEntity>)Entitas.Matcher<WppAccrualEntity>.AllOf(WppAccrualComponentsLookup.MovingIcon);
                matcher.componentNames = WppAccrualComponentsLookup.componentNames;
                _matcherMovingIcon = matcher;
            }

            return _matcherMovingIcon;
        }
    }
}
