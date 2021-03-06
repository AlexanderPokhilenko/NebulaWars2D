//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiContext {

    public LobbyUiEntity blurValueEntity { get { return GetGroup(LobbyUiMatcher.BlurValue).GetSingleEntity(); } }
    public Code.Scenes.LobbyScene.ECS.BlurValueComponent blurValue { get { return blurValueEntity.blurValue; } }
    public bool hasBlurValue { get { return blurValueEntity != null; } }

    public LobbyUiEntity SetBlurValue(float newBlurValue) {
        if (hasBlurValue) {
            throw new Entitas.EntitasException("Could not set BlurValue!\n" + this + " already has an entity with Code.Scenes.LobbyScene.ECS.BlurValueComponent!",
                "You should check if the context already has a blurValueEntity before setting it or use context.ReplaceBlurValue().");
        }
        var entity = CreateEntity();
        entity.AddBlurValue(newBlurValue);
        return entity;
    }

    public void ReplaceBlurValue(float newBlurValue) {
        var entity = blurValueEntity;
        if (entity == null) {
            entity = SetBlurValue(newBlurValue);
        } else {
            entity.ReplaceBlurValue(newBlurValue);
        }
    }

    public void RemoveBlurValue() {
        blurValueEntity.Destroy();
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    public Code.Scenes.LobbyScene.ECS.BlurValueComponent blurValue { get { return (Code.Scenes.LobbyScene.ECS.BlurValueComponent)GetComponent(LobbyUiComponentsLookup.BlurValue); } }
    public bool hasBlurValue { get { return HasComponent(LobbyUiComponentsLookup.BlurValue); } }

    public void AddBlurValue(float newBlurValue) {
        var index = LobbyUiComponentsLookup.BlurValue;
        var component = (Code.Scenes.LobbyScene.ECS.BlurValueComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.BlurValueComponent));
        component.blurValue = newBlurValue;
        AddComponent(index, component);
    }

    public void ReplaceBlurValue(float newBlurValue) {
        var index = LobbyUiComponentsLookup.BlurValue;
        var component = (Code.Scenes.LobbyScene.ECS.BlurValueComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.BlurValueComponent));
        component.blurValue = newBlurValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBlurValue() {
        RemoveComponent(LobbyUiComponentsLookup.BlurValue);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class LobbyUiMatcher {

    static Entitas.IMatcher<LobbyUiEntity> _matcherBlurValue;

    public static Entitas.IMatcher<LobbyUiEntity> BlurValue {
        get {
            if (_matcherBlurValue == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.BlurValue);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherBlurValue = matcher;
            }

            return _matcherBlurValue;
        }
    }
}
