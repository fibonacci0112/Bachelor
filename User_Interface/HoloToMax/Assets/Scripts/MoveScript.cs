using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MoveScript : MonoBehaviour
{

    
    private bool activated = true;
    float a = 0.9375f;
    public int bpm;
    public OSC osc;
    int count;

    public bool Activated
    {
        get
        {
            return activated;
        }

        set
        {
            activated = value;
            if (activated)
            {
                StartCoroutine(MoveBlock(osc));
            }
        }
    }

    void Start()
    {
        StartCoroutine(MoveBlock(osc));
        count = 0;
        osc = GameObject.Find("OSC").GetComponent<OSC>();
    }

    IEnumerator MoveBlock(OSC osc)
    {
        OscMessage message;
        while (Activated)
        {
            message = new OscMessage();
            message.address = "sampler";
            yield return new WaitForSeconds(60f/bpm/4f);
            a -= 0.125f;
            if (a < -0.9375f)
            {
                a = 0.9375f;
            }
            transform.localPosition = new Vector3(a, transform.localPosition.y, transform.localPosition.z);
            message.values = new ArrayList(Enumerable.Range(0, GetComponentInParent<GridScript>().grid.GetLength(0)).Select(x => GetComponentInParent<GridScript>().grid[x, count]).ToList());
            osc.Send(message);
            //Debug.Log(message);
            count = count == 15 ? 0 : count + 1;
        }

    }

}
