using UnityEngine;

namespace Code.Scenes.BattleScene.ScriptableObjects
{
    [CreateAssetMenu(fileName = "NewViewObjectsBase", menuName = "ViewObjectsBase", order = 52)]
    public class ViewObjectsBase : ScriptableSingleton<ViewObjectsBase>
    {
        public ViewObject[] viewObjects;

        public ViewObject GetViewObject(ViewTypeId typeId)
        {
            int id = (int) typeId;
            if (id >= 0 && id < viewObjects.Length)
            {
                return viewObjects[id];
            }
            else
            {
                int index = (int) ViewTypeId.Invisible;
                return viewObjects[index];
            }
        }
    }
}
