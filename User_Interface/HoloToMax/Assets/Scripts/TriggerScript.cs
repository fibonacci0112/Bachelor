using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class TriggerScript : MonoBehaviour, IInputClickHandler
    {
        public bool activated = false;
        Color color;
        string[] numbers;

        public void Start()
        {
            numbers = name.Split(new string[] { " " }, StringSplitOptions.None);
        }


        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.

            activated = !activated;
            UpdateTrigger();        
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        public void UpdateTrigger()
        {
            if (activated)
            {
                color = new Color(1, 0, 0);
            }
            else
            {
                color = new Color(0.3f, 0, 0);
            }
            GetComponent<MeshRenderer>().material.color = color;
            GetComponentInParent<GridScript>().grid[Int32.Parse(numbers[1]), Int32.Parse(numbers[2])] = activated ? 1 : 0;
        }

    }
}
