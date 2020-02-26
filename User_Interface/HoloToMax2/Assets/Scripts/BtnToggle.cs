using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class BtnToggle : MonoBehaviour, IInputClickHandler
    {

        bool on;
        public bool autoToggle;

        public bool On
        {
            get { return on; }
            set
            {
                on = value;
                if (on) { GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f); }
                else { GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f); }
            }
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (autoToggle) { On = !On; }
        }
    }
}