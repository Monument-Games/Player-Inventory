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

        public Quaternion getCamRotation()
        {
            return Quaternion.Euler(camRotation);
        }

        public void DisableCollision()
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<BoxCollider>().enabled = false;
        }

        public IEnumerator EnableCollision()
        {
            yield return new WaitForSeconds(1f);
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<BoxCollider>().enabled = true;
        }
    }
}