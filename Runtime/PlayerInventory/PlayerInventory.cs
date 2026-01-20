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
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

                if (Physics.Raycast(ray, out RaycastHit info, Config.cfg.interactionRange))
                {
                    switch (info.transform.tag)
                    {
                        case "Item":
                            TryPickupItem(info.transform.gameObject.GetComponent<Item>());
                            break;
                        case "Placeable Area":
                            TryPlaceItem();
                            break;
                    }
                }
            }
        }

        void TryPickupItem(Item item)
        {
            if (handheld != null)
            {
                DropItem();
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
            handheld.transform.localRotation = handheld.getCamRotation();
        }

        void DropItem()
        {
            Vector3 forward = transform.TransformDirection(Vector3.forward);
            handheld.GetComponent<Rigidbody>().AddForce(forward * Config.cfg.itemForce);
            handheld.transform.SetParent(null);
            StartCoroutine(handheld.EnableCollision());
            handheld = null;
        }

        void TryPlaceItem()
        {

        }
    }
}