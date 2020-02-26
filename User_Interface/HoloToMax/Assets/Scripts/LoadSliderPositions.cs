using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{

    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class LoadSliderPositions : MonoBehaviour, IInputClickHandler
    {
        GameObject[] slider;

        private void Start()
        {
            slider = GameObject.FindGameObjectsWithTag("Slider");
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            for (int i = 0; i < slider.Length; i++)
            {
                slider[i].GetComponent<SliderScript>().LoadPosition();
            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
