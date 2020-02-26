using System;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ToggleEcho : MonoBehaviour, IInputClickHandler
    {
        public OSC osc;
        bool echo = false;
        public void OnInputClicked(InputClickedEventData eventData)
        {
            echo = !echo;

            OscMessage message = new OscMessage();
            message.address = "sphere";
            message.values.Add(6);
            osc.Send(message);
        }

        private void OnApplicationQuit()
        {
            if(echo)
            {
                OscMessage message = new OscMessage();
                message.address = "sphere";
                message.values.Add(6);
                osc.Send(message);
            }
        }
    }
}
