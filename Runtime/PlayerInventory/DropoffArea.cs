using UnityEngine;

namespace MonumentGames.PlayerInventory
{
    [RequireComponent(typeof(BoxCollider))]
    public class DropoffArea : MonoBehaviour
    {
        public Vector3 itemOffset;
        public Vector3 itemRotation;
        private Item currentItem;

        public void AddItem(Item item)
        {
            // Put Item to Area and enable Physics and Collision
            currentItem = item;
            currentItem.transform.SetParent(transform);
            currentItem.EnableCollision();

            currentItem.SetOnDropoff(true);
            currentItem.SetDropoffArea(this);

            // Reset Rotation and Position of Item
            currentItem.transform.localPosition = new Vector3(0, 0, 0);
            currentItem.transform.localRotation = Quaternion.Euler(0, 0, 0);
            
            // Apply Item specific offset
            currentItem.transform.localPosition = itemOffset;
            currentItem.transform.localRotation = currentItem.GetRotation(itemRotation);

            gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
        }

        public void RemoveItem() {
            currentItem.SetOnDropoff(false);
            currentItem.SetDropoffArea(null);
            currentItem = null;

            gameObject.layer = LayerMask.NameToLayer("Default");
        }

        public Item GetCurrentItem() {
            return currentItem;
        }

        public bool HasItem() {
            return currentItem != null;
        }
    }
}
