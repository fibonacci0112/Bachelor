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
        public int slot;
        public bool full { get; set; }

        private void Start()
        {
            slider = GameObject.FindGameObjectsWithTag("Slider");
            full = false;
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (!GameObject.Find("NavButton 4").GetComponent<OpenAllSlots>().on)
            {
                for (int i = 0; i < slider.Length; i++)
                {
                    slider[i].GetComponent<SliderScript>().LoadPosition(slot);
                }
            }
            else
            {
                for (int i = 0; i < slider.Length; i++)
                {
                    slider[i].GetComponent<SliderScript>().SavePosition(slot);
                }
                full = true;
                GetComponent<BtnToggle>().On = true;
                GameObject.Find("NavButton 4").GetComponent<OpenAllSlots>().OpenSlots();

            }
            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
