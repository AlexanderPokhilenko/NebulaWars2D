//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Code.Scenes.LobbyScene.ECS;

public partial class LobbyUiEntity {

    public ImageComponent image { get { return (ImageComponent)GetComponent(LobbyUiComponentsLookup.Image); } }
    public bool hasImage { get { return HasComponent(LobbyUiComponentsLookup.Image); } }

    public void AddImage(UnityEngine.UI.Image newImage) {
        var index = LobbyUiComponentsLookup.Image;
        var component = (ImageComponent)CreateComponent(index, typeof(ImageComponent));
        component.image = newImage;
        AddComponent(index, component);
    }

    public void ReplaceImage(UnityEngine.UI.Image newImage) {
        var index = LobbyUiComponentsLookup.Image;
        var component = (ImageComponent)CreateComponent(index, typeof(ImageComponent));
        component.image = newImage;
        ReplaceComponent(index, component);
    }

    public void RemoveImage() {
        RemoveComponent(LobbyUiComponentsLookup.Image);
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

    static Entitas.IMatcher<LobbyUiEntity> _matcherImage;

    public static Entitas.IMatcher<LobbyUiEntity> Image {
        get {
            if (_matcherImage == null) {
                var matcher = (Entitas.Matcher<LobbyUiEntity>)Entitas.Matcher<LobbyUiEntity>.AllOf(LobbyUiComponentsLookup.Image);
                matcher.componentNames = LobbyUiComponentsLookup.componentNames;
                _matcherImage = matcher;
            }

            return _matcherImage;
        }
    }
}
