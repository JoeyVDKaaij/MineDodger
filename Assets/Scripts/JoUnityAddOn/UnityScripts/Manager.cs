using UnityEngine;

namespace JoUnityAddOn.UnityScripts
{
    public class Manager : MonoBehaviour
    {
        #region instance
    
        public static Manager instance { get; private set; }

        private void OnEnable()
        {
            if (instance == null)
            {
                instance = this;
            
                if (transform.parent != null)
                    DontDestroyOnLoad(transform.parent.gameObject);
                else
                    DontDestroyOnLoad(this);
            }
            else Destroy(gameObject);
        }

        private void OnDisable()
        {
            instance = null;
        }

        private void OnDestroy()
        {
            instance = null;
        }
    
        #endregion
    }
}