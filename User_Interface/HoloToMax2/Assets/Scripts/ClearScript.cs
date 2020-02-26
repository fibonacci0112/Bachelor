// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{

    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class ClearScript : MonoBehaviour, IInputClickHandler
    {
        GameObject[] triggers;

        public void Start()
        {
            triggers = GameObject.FindGameObjectsWithTag("Trigger");
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            for (int i = 0; i < triggers.Length; i++)
            {
                triggers[i].GetComponent<TriggerScript>().activated = false;
                triggers[i].GetComponent<TriggerScript>().UpdateTrigger();
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
