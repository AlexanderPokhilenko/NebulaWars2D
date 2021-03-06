//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiContext {

    public LobbyUiEntity accountRatingEntity { get { return GetGroup(LobbyUiMatcher.AccountRating).GetSingleEntity(); } }
    public Code.Scenes.LobbyScene.ECS.AccountRatingComponent accountRating { get { return accountRatingEntity.accountRating; } }
    public bool hasAccountRating { get { return accountRatingEntity != null; } }

    public LobbyUiEntity SetAccountRating(int newValue) {
        if (hasAccountRating) {
            throw new Entitas.EntitasException("Could not set AccountRating!\n" + this + " already has an entity with Code.Scenes.LobbyScene.ECS.AccountRatingComponent!",
                "You should check if the context already has a accountRatingEntity before setting it or use context.ReplaceAccountRating().");
        }
        var entity = CreateEntity();
        entity.AddAccountRating(newValue);
        return entity;
    }

    public void ReplaceAccountRating(int newValue) {
        var entity = accountRatingEntity;
        if (entity == null) {
            entity = SetAccountRating(newValue);
        } else {
            entity.ReplaceAccountRating(newValue);
        }
    }

    public void RemoveAccountRating() {
        accountRatingEntity.Destroy();
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

    public Code.Scenes.LobbyScene.ECS.AccountRatingComponent accountRating { get { return (Code.Scenes.LobbyScene.ECS.AccountRatingComponent)GetComponent(LobbyUiComponentsLookup.AccountRating); } }
    public bool hasAccountRating { get { return HasComponent(LobbyUiComponentsLookup.AccountRating); } }

    public void AddAccountRating(int newValue) {
        var index = LobbyUiComponentsLookup.AccountRating;
        var component = (Code.Scenes.LobbyScene.ECS.AccountRatingComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.AccountRatingComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceAccountRating(int newValue) {
        var index = LobbyUiComponentsLookup.AccountRating;
        var component = (Code.Scenes.LobbyScene.ECS.AccountRatingComponent)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.AccountRatingComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveAccountRating() {
        RemoveComponent(LobbyUiComponentsLookup.AccountRating);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherAccountRating;

    public static Entitas.IMatcher<LobbyUiEntity> AccountRating {
        get {
            if (_matcherAccountRating == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.AccountRating);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherAccountRating = matcher;
            }

            return _matcherAccountRating;
        }
    }
}
