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
        public void Start()
        {
            triggers = GameObject.FindGameObjectsWithTag("Trigger");
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (GameObject.Find("SampleButton 2").GetComponent<SaveSample>().active)
            {
                for (int i = 0; i < triggers.Length; i++)
                {
                    valueMatrix[i] = triggers[i].GetComponent<TriggerScript>().activated;
                }
                Debug.Log("sa");

                //ersetzen durch deaktivierungsmethode in saveSample
                GameObject.Find("SampleButton 2").GetComponent<SaveSample>().active = false;
            }

            if (GameObject.Find("SampleButton 3").GetComponent<LoadSample>().active)
            {
                for (int i = 0; i < triggers.Length; i++)
                {
                    triggers[i].GetComponent<TriggerScript>().activated = valueMatrix[i];
                    triggers[i].GetComponent<TriggerScript>().UpdateTrigger();
                }
                Debug.Log("lo");

                //ersetzen durch deaktivierungsmethode in loadSample
                GameObject.Find("SampleButton 3").GetComponent<LoadSample>().active = false;

            }


            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
