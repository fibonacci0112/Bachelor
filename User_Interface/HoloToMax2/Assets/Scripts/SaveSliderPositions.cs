using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;


namespace HoloToolkit.Unity.InputModule.Tests
{

    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class SaveSliderPositions : MonoBehaviour, IInputClickHandler
    {
        GameObject[] slider;
        GameObject[] slots;
        bool on = false;

        private void Start()
        {
            slider = GameObject.FindGameObjectsWithTag("Slider");
            slots = GameObject.FindGameObjectsWithTag("Slot");

            foreach (GameObject g in slots)
            {
                g.SetActive(false);
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            OpenSlots();          
            //GameObject.Find("UDPSender").GetComponent<UDPSend>().sendString("grillo");
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        public void OpenSlots()
        {
            if (on)
            {
                foreach (GameObject g in slots) { if (g.activeInHierarchy && !g.GetComponent<LoadSliderPositions>().full) /* && slot ist leer*/   { g.SetActive(false); } }
            }
            else
            {
                foreach (GameObject g in slots) { if (!g.activeInHierarchy) { g.SetActive(true); } }
            }

            on = !on;

            GetComponent<BtnToggle>().On = on;
        }
    }
}
