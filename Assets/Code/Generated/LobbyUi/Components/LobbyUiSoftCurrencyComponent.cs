//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Scenes.LobbyScene.ECS;

public partial class LobbyUiContext {

    public LobbyUiEntity softCurrencyEntity { get { return GetGroup(LobbyUiMatcher.SoftCurrency).GetSingleEntity(); } }
    public SoftCurrencyComponent softCurrency { get { return softCurrencyEntity.softCurrency; } }
    public bool hasSoftCurrency { get { return softCurrencyEntity != null; } }

    public LobbyUiEntity SetSoftCurrency(int newValue) {
        if (hasSoftCurrency) {
            throw new Entitas.EntitasException("Could not set SoftCurrency!\n" + this + " already has an entity with Code.Scenes.LobbyScene.ECS.Components.SoftCurrencyComponent!",
                "You should check if the context already has a softCurrencyEntity before setting it or use context.ReplaceSoftCurrency().");
        }
        var entity = CreateEntity();
        entity.AddSoftCurrency(newValue);
        return entity;
    }

    public void ReplaceSoftCurrency(int newValue) {
        var entity = softCurrencyEntity;
        if (entity == null) {
            entity = SetSoftCurrency(newValue);
        } else {
            entity.ReplaceSoftCurrency(newValue);
        }
    }

    public void RemoveSoftCurrency() {
        softCurrencyEntity.Destroy();
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

    public SoftCurrencyComponent softCurrency { get { return (SoftCurrencyComponent)GetComponent(LobbyUiComponentsLookup.SoftCurrency); } }
    public bool hasSoftCurrency { get { return HasComponent(LobbyUiComponentsLookup.SoftCurrency); } }

    public void AddSoftCurrency(int newValue) {
        var index = LobbyUiComponentsLookup.SoftCurrency;
        var component = (SoftCurrencyComponent)CreateComponent(index, typeof(SoftCurrencyComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceSoftCurrency(int newValue) {
        var index = LobbyUiComponentsLookup.SoftCurrency;
        var component = (SoftCurrencyComponent)CreateComponent(index, typeof(SoftCurrencyComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveSoftCurrency() {
        RemoveComponent(LobbyUiComponentsLookup.SoftCurrency);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherSoftCurrency;

    public static Entitas.IMatcher<LobbyUiEntity> SoftCurrency {
        get {
            if (_matcherSoftCurrency == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.SoftCurrency);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherSoftCurrency = matcher;
            }

            return _matcherSoftCurrency;
        }
    }
}
