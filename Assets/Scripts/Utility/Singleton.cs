using UnityEngine;

namespace Utility
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Reference to our singular instance.
        private static T _instance;
        public static T Instance => _instance;
        /// <summary>
        /// Unity method called just after object creation - like constructor.
        /// </summary>
        protected virtual void Awake()
        {
            // If we don't have reference to instance than this object will take control
            if (_instance == null)
            {
                _instance = this as T;
            }
            else if (_instance != this) // Else this is other instance and we should destroy it!
            {
                Destroy(this);
            }
        }
        /// <summary>
        /// Unity method called before object destruction.
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (_instance != this) // Skip if instance is other than this object.
            {
                return;
            }
            _instance = null;
        }
    }
}
