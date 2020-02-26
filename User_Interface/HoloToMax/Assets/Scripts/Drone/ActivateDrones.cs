using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ActivateDrones : MonoBehaviour, IInputClickHandler
    {
        GameObject[] spheres;
        private void Start()
        {
           spheres = GameObject.FindGameObjectsWithTag("DroneSphere");
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
                for (int i = 0; i < spheres.Length; i++)
                {
                    spheres[i].GetComponent<SphereScript>().Activator(!spheres[i].GetComponent<SphereScript>().activated);
                }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
