using System;
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

        public void Update()
        {
            Debug.Log(transform.localPosition);
        }
    }
}