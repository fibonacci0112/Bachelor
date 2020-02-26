using System;
using System.Collections;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class SoundControl : MonoBehaviour, IInputClickHandler
    {
        private OscMessage message;
        public OSC osc;
        int choice = 1;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            choice = (choice >= 3) ? 0 : choice + 1;
            GetComponent<MaterialSwitcher>().SwitchMaterial(choice);

            String[] values = name.Split(new String[] { " " }, StringSplitOptions.None);
            message = new OscMessage();

            message.address = "soundcontrol";
            message.values.Add(choice);

            osc.Send(message);
            Debug.Log(message);

            

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
