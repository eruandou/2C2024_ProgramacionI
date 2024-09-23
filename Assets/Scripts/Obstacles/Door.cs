using System;
using UnityEngine;

namespace DefaultNamespace.Obstacles
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Animator doorAnimator;

        [ContextMenu("Open Door")]
        public void OpenDoor()
        {
            doorAnimator.SetBool("IsOpen", true);
        }

        [ContextMenu("Close Door")]
        public void CloseDoor()
        {
            doorAnimator.SetBool("IsOpen", false);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.N))
            {
                OpenDoor();
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                CloseDoor();
            }
        }
    }
}