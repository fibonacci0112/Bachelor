using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{

    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// </summary>
    public class ToggleSpacialMapping : MonoBehaviour, IInputClickHandler
    {
        GameObject spatialMap;
        private void Awake()
        {
            spatialMap = GameObject.Find("SpatialMapping");
            spatialMap.SetActive(false);
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            if (spatialMap.activeInHierarchy) { spatialMap.SetActive(false); Debug.Log("aktiviert"); }
            else { spatialMap.SetActive(true); Debug.Log("deaktiviert"); }

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }
    }
}
