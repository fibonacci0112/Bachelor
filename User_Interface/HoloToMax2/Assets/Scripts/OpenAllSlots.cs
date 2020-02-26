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
    public class OpenAllSlots : MonoBehaviour, IInputClickHandler
    {
        GameObject[] slider;
        public bool on { get; set; }
        GameObject nav5;
        GameObject nav6;
        GameObject nav7;

        private void Start()
        {
            on = false;
            slider = GameObject.FindGameObjectsWithTag("Slider");

            nav5 = GameObject.Find("NavButton 5");
            nav6 = GameObject.Find("NavButton 6");
            nav7 = GameObject.Find("NavButton 7");


            nav5.GetComponent<MeshRenderer>().enabled = false; nav5.GetComponent<BoxCollider>().enabled = false;
            nav6.GetComponent<MeshRenderer>().enabled = false; nav6.GetComponent<BoxCollider>().enabled = false;
            nav7.GetComponent<MeshRenderer>().enabled = false; nav7.GetComponent<BoxCollider>().enabled = false;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            OpenSlots();

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        public void OpenSlots()
        {
            if (on)
            {
                if (nav5.GetComponent<MeshRenderer>().enabled == true || nav6.GetComponent<MeshRenderer>().enabled == true || nav7.GetComponent<MeshRenderer>().enabled == true)
                {
                    if (!nav5.GetComponent<LoadSliderPositions>().full) { nav5.GetComponent<MeshRenderer>().enabled = false; nav5.GetComponent<BoxCollider>().enabled = false; }
                    if (!nav6.GetComponent<LoadSliderPositions>().full) { nav6.GetComponent<MeshRenderer>().enabled = false; nav6.GetComponent<BoxCollider>().enabled = false; }
                    if (!nav7.GetComponent<LoadSliderPositions>().full) { nav7.GetComponent<MeshRenderer>().enabled = false; nav7.GetComponent<BoxCollider>().enabled = false; }
                }

            }
            else
            {
                if (nav5.GetComponent<MeshRenderer>().enabled == false || nav6.GetComponent<MeshRenderer>().enabled == false || nav7.GetComponent<MeshRenderer>().enabled == false)

                {
                    nav5.GetComponent<MeshRenderer>().enabled = true; nav5.GetComponent<BoxCollider>().enabled = true;
                    nav6.GetComponent<MeshRenderer>().enabled = true; nav6.GetComponent<BoxCollider>().enabled = true;
                    nav7.GetComponent<MeshRenderer>().enabled = true; nav7.GetComponent<BoxCollider>().enabled = true;
                }
            }

            on = !on;

            GetComponent<BtnToggle>().On = on;
        }
    }
}
