using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{

    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class LoadSpherePositions : MonoBehaviour, IInputClickHandler
    {
        GameObject[] spheres;
        public int slot;
        public bool full { get; set; }

        private void Start()
        {
            spheres = GameObject.FindGameObjectsWithTag("DroneSphere");
            full = false;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (!GameObject.Find("DroneButton 3").GetComponent<OpenDroneSlots>().on)
            {
                for (int i = 0; i < spheres.Length; i++)
                {
                    spheres[i].GetComponent<SphereScript>().LoadPosition(false, slot);
                }
            }
            else
            {
                for (int i = 0; i < spheres.Length; i++)
                {
                    spheres[i].GetComponent<SphereScript>().SavePosition(slot);
                }
                full = true;
                GetComponent<BtnToggle>().On = true;
                GameObject.Find("DroneButton 3").GetComponent<OpenDroneSlots>().OpenSlots();
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
