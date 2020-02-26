using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class BtnBlink : MonoBehaviour, IInputClickHandler
    {
        public bool toggle;
        private bool off = true;

        public void OnInputClicked(InputClickedEventData eventData)
        {
            ColorResponse();
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
            material.color = new Color(1f, 1f, 1f);
        }
    }
}
