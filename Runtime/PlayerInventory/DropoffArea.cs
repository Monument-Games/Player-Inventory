using UnityEngine;

namespace MonumentGames.PlayerInventory
{
    [RequireComponent(BoxCollider)]
    public class DropoffArea : MonoBehaviour
    {
        public Vector3 itemOffset;
        public Vector3 itemRotation;
        private Item currentItem;

        public void AddItem(Item item)
        {
            // Put Item to Area and enable Physics and Collision
            currentItem = item;
            currentItem.EnableCollision();

            // Reset Rotation and Position of Item
            currentItem.transform.localPosition = new Vector3(0, 0, 0);
            currentItem.transform.localRotation = Quaternion.Euler(0, 0, 0);
            
            // Apply Item specific offset
            currentItem.transform.localPosition = itemOffset;
            currentItem.transform.localRotation = currentItem.GetRotation(itemRotation);

            layer = LayerMask.NameToLayer("Ignore Raycast");
        }
    }
}