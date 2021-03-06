//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class LobbyUiEntity {

    public Code.Scenes.LobbyScene.ECS.EnablePurchaseConfirmationWindow enablePurchaseConfirmationWindow { get { return (Code.Scenes.LobbyScene.ECS.EnablePurchaseConfirmationWindow)GetComponent(LobbyUiComponentsLookup.EnablePurchaseConfirmationWindow); } }
    public bool hasEnablePurchaseConfirmationWindow { get { return HasComponent(LobbyUiComponentsLookup.EnablePurchaseConfirmationWindow); } }

    public void AddEnablePurchaseConfirmationWindow(Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow.PurchaseModel newPurchase) {
        var index = LobbyUiComponentsLookup.EnablePurchaseConfirmationWindow;
        var component = (Code.Scenes.LobbyScene.ECS.EnablePurchaseConfirmationWindow)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.EnablePurchaseConfirmationWindow));
        component.purchase = newPurchase;
        AddComponent(index, component);
    }

    public void ReplaceEnablePurchaseConfirmationWindow(Code.Scenes.LobbyScene.Scripts.Shop.PurchaseConfirmation.UiWindow.PurchaseModel newPurchase) {
        var index = LobbyUiComponentsLookup.EnablePurchaseConfirmationWindow;
        var component = (Code.Scenes.LobbyScene.ECS.EnablePurchaseConfirmationWindow)CreateComponent(index, typeof(Code.Scenes.LobbyScene.ECS.EnablePurchaseConfirmationWindow));
        component.purchase = newPurchase;
        ReplaceComponent(index, component);
    }

    public void RemoveEnablePurchaseConfirmationWindow() {
        RemoveComponent(LobbyUiComponentsLookup.EnablePurchaseConfirmationWindow);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherEnablePurchaseConfirmationWindow;

    public static Entitas.IMatcher<LobbyUiEntity> EnablePurchaseConfirmationWindow {
        get {
            if (_matcherEnablePurchaseConfirmationWindow == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.EnablePurchaseConfirmationWindow);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherEnablePurchaseConfirmationWindow = matcher;
            }

            return _matcherEnablePurchaseConfirmationWindow;
        }
    }
}
