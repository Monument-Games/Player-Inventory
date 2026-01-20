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
            newItem.layer = LayerMask.NameToLayer("Ignore Player");

            Undo.RegisterCreatedObjectUndo(newItem, "Create " + newItem.name);
        }

        [MenuItem("GameObject/Nim 7/Dropoff", false, 0)]
        public static void CreateDropoff(MenuCommand command)
        {
            GameObject newDropoff = new GameObject();

            newDropoff.AddComponent<DropoffArea>();
            newDropoff.tag = "Dropoff";
            newDropoff.name = "Dropoff Area";
            newDropoff.GetComponent<BoxCollider>().isTrigger = true;

            Undo.RegisterCreatedObjectUndo(newDropoff, "Create " + newDropoff.name);
        }
    }
}