﻿using System;
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
    public class OpenSampleSlots : MonoBehaviour, IInputClickHandler
    {
        public bool on { get; set; }
        GameObject btn1;
        GameObject btn2;
        GameObject btn3;

        private void Start()
        {
            on = false;

            btn1 = GameObject.Find("SampleButton 5");
            btn2 = GameObject.Find("SampleButton 6");
            btn3 = GameObject.Find("SampleButton 7");


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
                    if (!btn1.GetComponent<SampleTemplate>().full) { btn1.GetComponent<MeshRenderer>().enabled = false; btn1.GetComponent<BoxCollider>().enabled = false; }
                    if (!btn2.GetComponent<SampleTemplate>().full) { btn2.GetComponent<MeshRenderer>().enabled = false; btn2.GetComponent<BoxCollider>().enabled = false; }
                    if (!btn3.GetComponent<SampleTemplate>().full) { btn3.GetComponent<MeshRenderer>().enabled = false; btn3.GetComponent<BoxCollider>().enabled = false; }
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