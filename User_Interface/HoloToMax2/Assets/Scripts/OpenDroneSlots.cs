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
    public class OpenDroneSlots : MonoBehaviour, IInputClickHandler
    {
        GameObject[] slider;
        public bool on { get; set; }
        GameObject btn1;
        GameObject btn2;
        GameObject btn3;

        private void Start()
        {
            on = false;
            slider = GameObject.FindGameObjectsWithTag("Slider");

            btn1 = GameObject.Find("DroneButton 4");
            btn2 = GameObject.Find("DroneButton 5");
            btn3 = GameObject.Find("DroneButton 6");


            btn1.GetComponent<MeshRenderer>().enabled = false; btn1.GetComponent<BoxCollider>().enabled = false;
            btn2.GetComponent<MeshRenderer>().enabled = false; btn2.GetComponent<BoxCollider>().enabled = false;
            btn3.GetComponent<MeshRenderer>().enabled = false; btn3.GetComponent<BoxCollider>().enabled = false;
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
                if (btn1.GetComponent<MeshRenderer>().enabled == true || btn2.GetComponent<MeshRenderer>().enabled == true || btn3.GetComponent<MeshRenderer>().enabled == true)
                {
                    if (!btn1.GetComponent<LoadSpherePositions>().full) { btn1.GetComponent<MeshRenderer>().enabled = false; btn1.GetComponent<BoxCollider>().enabled = false; }
                    if (!btn2.GetComponent<LoadSpherePositions>().full) { btn2.GetComponent<MeshRenderer>().enabled = false; btn2.GetComponent<BoxCollider>().enabled = false; }
                    if (!btn3.GetComponent<LoadSpherePositions>().full) { btn3.GetComponent<MeshRenderer>().enabled = false; btn3.GetComponent<BoxCollider>().enabled = false; }
                }

            }
            else
            {
                if (btn1.GetComponent<MeshRenderer>().enabled == false || btn2.GetComponent<MeshRenderer>().enabled == false || btn3.GetComponent<MeshRenderer>().enabled == false)

                {
                    btn1.GetComponent<MeshRenderer>().enabled = true; btn1.GetComponent<BoxCollider>().enabled = true;
                    btn2.GetComponent<MeshRenderer>().enabled = true; btn2.GetComponent<BoxCollider>().enabled = true;
                    btn3.GetComponent<MeshRenderer>().enabled = true; btn3.GetComponent<BoxCollider>().enabled = true;
                }
            }

            on = !on;

            GetComponent<BtnToggle>().On = on;
        }
    }
}
