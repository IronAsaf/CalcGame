using System;
using UnityEngine;

namespace UI
{
    public class MenuHandler : MonoBehaviour
    {
        public void OnEnable()
        {
            
        }

        public void OnClickCloseMenu()
        {
            gameObject.SetActive(false);
        }
    }
}
