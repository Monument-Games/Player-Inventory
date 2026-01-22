using UnityEngine;

namespace MonumentGames.PlayerInventory
{
    using Config;
    
    public class PlayerInventory : MonoBehaviour
    {
        [SerializeField] Camera cam;
        [SerializeField] Item handheld;

        void Awake()
        {
            cam = transform.GetChild(0).GetComponent<Camera>();
        }

        void Update()
        {
            if (Input.GetKeyDown(Config.cfg.pickUpKey))
            {
                if (CheckForItem())
                {
                    return;
                }
                if (CheckForDropoff())
                {
                    return;
                }
                DropItem();
            }
        }

        bool CheckForItem()
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out RaycastHit info, Config.cfg.interactionRange))
            {
                if (info.transform.tag.Equals("Item"))
                {
                    TryPickupItem(info.transform.gameObject.GetComponent<Item>());
                    return true;
                }
            }

            return false;
        }

        bool CheckForDropoff()
        {
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

            if (Physics.Raycast(ray, out RaycastHit info, Config.cfg.interactionRange))
            {
                if (info.transform.tag.Equals("Dropoff"))
                {
                    TryPlaceItem(info.transform.gameObject.GetComponent<DropoffArea>());
                    return true;
                }
            }

            return false;
        }

        void TryPickupItem(Item item)
        {
            if (handheld != null)
            {
                DropItem();
            }

            if (handheld.GetDropoffArea() != null) {
                handheld.GetDropoffArea().RemoveItem();
            }

            // Put Item to camera and disable Physics and Collision
            handheld = item;
            handheld.transform.SetParent(transform.GetChild(0));
            handheld.DisableCollision();

            // Reset Rotation and Position of Item
            handheld.transform.localPosition = new Vector3(0, 0, 0);
            handheld.transform.localRotation = Quaternion.Euler(0, 0, 0);

            // Apply Item specific offset
            handheld.transform.localPosition = handheld.camOffset;
            handheld.transform.localRotation = handheld.GetRotation();
        }

        void DropItem()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            handheld.GetComponent<Rigidbody>().AddForce(forward * Config.cfg.itemForce);
            handheld.transform.SetParent(null);
            handheld.EnableCollision();
            handheld = null;
        }

        void TryPlaceItem(DropoffArea area)
        {
            area.AddItem(handheld);
            handheld = null;
        }
    }
}
