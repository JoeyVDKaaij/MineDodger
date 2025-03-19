using UnityEngine;

namespace JoUnityAddOn.Input
{
    public class Mouse
    {
        /// <summary>
        /// Toggle the current Mouse State.
        /// From Locked to None and the other way around.
        /// From Invisible to Visible and the other way around.
        /// </summary>
        public static void ToggleMouseAccess()
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.None;
            else
                Cursor.lockState = CursorLockMode.Locked;
        
            Cursor.visible = !Cursor.visible;
        }

        /// <summary>
        /// Locks the mouse in place and makes it invisible.
        /// </summary>
        public static void LockMouse()
        {
            Cursor.lockState = CursorLockMode.Locked;
        
            Cursor.visible = false;
        }

        /// <summary>
        /// Unlocks the mouse so users can move it around and makes it visible.
        /// </summary>
        public static void UnlockMouse()
        {
            Cursor.lockState = CursorLockMode.None;
        
            Cursor.visible = true;
        }
    }
}