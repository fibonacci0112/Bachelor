// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{ 
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class StartSamplerScript : MonoBehaviour, IInputClickHandler
    {

        public void OnInputClicked(InputClickedEventData eventData)
        {

            if (GameObject.Find("Mover").GetComponent<MoveScript>().Activated == true)
            {
                return;
            }
            GameObject.Find("Mover").GetComponent<MoveScript>().Activated = true;


            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}