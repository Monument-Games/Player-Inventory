using System;
using System.Collections;
using UnityEngine;

namespace MonumentGames.PlayerInventory
{
    [RequireComponent(typeof(BoxCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Item : MonoBehaviour
    {
        public Vector3 camOffset;
        public Vector3 camRotation;
        private bool onDropoff;
        private DropoffArea area = null;

        public Quaternion GetRotation()
        {
            return Quaternion.Euler(camRotation);
        }
        
        public Quaternion GetRotation(Vector3 rotation)
        {
            return Quaternion.Euler(rotation);
        }

        public void DisableCollision()
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<BoxCollider>().enabled = false;
        }

        public void EnableCollision()
        {
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
        }

        public void SetDropoffArea(DropoffArea area) {
            this.area = area;
        }

        public DropoffArea GetDropoffArea() {
            return area;
        }

        public void SetOnDropoff(bool val) {
            onDropoff = val;
        }

        public bool GetOnDropoff() {
            return onDropoff;
        }
    }
}
