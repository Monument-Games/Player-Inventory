using UnityEngine;

namespace MonumentGames.Config
{
    public class Config : MonoBehaviour
    {
        public static Config cfg;

        [Header("Controls")] 
        public KeyCode pickUpKey = KeyCode.E;
        public KeyCode sprintKey = KeyCode.LeftShift;

        [Header("Player Interaction")] 
        public float interactionRange = 2f;

        public float itemForce = 10f;

        public void Awake()
        {
            if (Config.cfg != this && Config.cfg != null)
                Destroy(this);
            else
                Config.cfg = this;
        }
    }
} 
