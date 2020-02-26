using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{

    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class ResetSpheres : MonoBehaviour, IInputClickHandler
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
                spheres[i].GetComponent<SphereScript>().LoadPosition(true,0);
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
