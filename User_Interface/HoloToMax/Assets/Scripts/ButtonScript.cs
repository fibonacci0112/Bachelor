using System;
using System.Collections;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ButtonScript : MonoBehaviour, IInputClickHandler
    {
        public bool toggle;
        public bool key;
        private bool off = true;
        private OscMessage message;
        public OSC osc; 

        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            if (!key)
            {
                ColorResponse();
            }

            String[] values = name.Split(new String[] { " " }, StringSplitOptions.None);
            message = new OscMessage();

            message.address = values[0].ToLower();
            message.values.Add(values[1]);

            osc.Send(message);
            Debug.Log(message);

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        void ColorResponse()
        {
            if (toggle)
            {
                if (off)
                {
                    GetComponent<Renderer>().material.color = new Color(0f, 1f, 0f);
                }
                else
                {
                    GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f);

                }
                off = !off;
            }
            else
            {
                StartCoroutine(Blink(GetComponent<Renderer>().material));
            }
        }

        IEnumerator Blink(Material material)
        {
            material.color = new Color(0f, 1f, 0f);
            yield return new WaitForSeconds(0.1f);
            material.color = new Color(1f,1f,1f);
        }

    }
}
