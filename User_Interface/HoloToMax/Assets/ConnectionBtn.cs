using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    public class ConnectionBtn : MonoBehaviour, IInputClickHandler
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            StartCoroutine(Blink(GetComponent<Renderer>().material));
            byte[] data = Encoding.UTF8.GetBytes("hallo");
            GameObject.Find("UDP").GetComponent<UDPCommunication>().SendUDPMessage("192.168.178.35", "6161",data);

            eventData.Use();
        }

        IEnumerator Blink(Material material)
        {
            material.color = new Color(0f, 1f, 0f);
            yield return new WaitForSeconds(0.1f);
            material.color = new Color(1f, 1f, 1f);
        }
    }
}
