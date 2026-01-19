using UnityEngine;
using UnityEditor;

namespace MonumentGames.PlayerInventory.Editor
{
    public class ItemCreator : MonoBehaviour
    {
        [MenuItem("GameObject/Nim 7/Item", false, 0)]
        public static void CreateItem(MenuCommand command)
        {
            GameObject newItem = GameObject.CreatePrimitive(PrimitiveType.Cube);

            newItem.AddComponent<Item>();
            newItem.tag = "Item";
            newItem.name = "Item";

            Undo.RegisterCreatedObjectUndo(newItem, "Create " + newItem.name);
        }

    }
}