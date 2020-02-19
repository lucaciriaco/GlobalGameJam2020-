using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject thingToActivate;

    private LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        thingToActivate.SetActive(false);
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thingToActivate.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            thingToActivate.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        
    }
}
