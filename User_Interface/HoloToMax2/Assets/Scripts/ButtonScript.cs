using System;
using System.Collections;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ButtonScript : MonoBehaviour, IInputClickHandler
    {
        private OscMessage message;
        public OSC osc; 

        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.

            String[] values = name.Split(new String[] { " " }, StringSplitOptions.None);
            message = new OscMessage();

            message.address = values[0].ToLower();
            message.values.Add(values[1]);

            osc.Send(message);
            Debug.Log(message);

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
