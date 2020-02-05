using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject[] thingToActivate;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = true;
        for(int i = 0;i<thingToActivate.Length-1;i++)
        {
            thingToActivate[i].SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            for (int i = 0; i < thingToActivate.Length - 1; i++)
            {
                thingToActivate[i].SetActive(true);
            }
            sprite.enabled = false;
        }
    }

    private void OnDrawGizmos()
    {
        for(int i = 0;i<thingToActivate.Length-1; i++)
        {
            Gizmos.DrawLine(this.gameObject.transform.position, thingToActivate[i].transform.position);
        }
    }
}
