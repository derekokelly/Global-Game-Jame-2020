using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AudioLog : MonoBehaviour
{

    public Flowchart flowchart;
    public string block;

    private Coroutine lastRoutine;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            lastRoutine = StartCoroutine(Interact());
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            StopCoroutine(lastRoutine);
        }
    }

    IEnumerator Interact() { 
        while (true)
        {
            if (Input.GetKeyDown("z"))
            {
                StartLog();
                break;
            }
            yield return null;
        }
    }

    void StartLog()
    {
        flowchart.ExecuteBlock(block);
    }
}

