using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TriggerSetup : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        name = name.Replace("(", "");
        name = name.Replace(")", "");

        String[] numbers = name.Split(new String[] { " " }, StringSplitOptions.None);

        transform.localPosition = new Vector3(transform.localPosition.x - (Int32.Parse(numbers[2]))*0.125f, transform.localPosition.y - (Int32.Parse(numbers[1])) * 0.1f, transform.localPosition.z);

    }
}
