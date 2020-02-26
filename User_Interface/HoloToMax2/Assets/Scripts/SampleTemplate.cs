// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{

    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class SampleTemplate : MonoBehaviour, IInputClickHandler
    {
        bool[] valueMatrix = new bool[128];
        GameObject[] triggers;
        public bool full { get; set; }

        public void Start()
        {
            full = false;
            triggers = GameObject.FindGameObjectsWithTag("Trigger");
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (GameObject.Find("SampleButton 4").GetComponent<OpenSampleSlots>().on)
            {
                for (int i = 0; i < triggers.Length; i++)
                {
                    valueMatrix[i] = triggers[i].GetComponent<TriggerScript>().activated;
                }
                full = true;
                GetComponent<BtnToggle>().On = true;
                GameObject.Find("SampleButton 4").GetComponent<OpenSampleSlots>().OpenSlots();
            }
            else
            {
                for (int i = 0; i < triggers.Length; i++)
                {
                    triggers[i].GetComponent<TriggerScript>().activated = valueMatrix[i];
                    triggers[i].GetComponent<TriggerScript>().UpdateTrigger();
                }
            }


            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
