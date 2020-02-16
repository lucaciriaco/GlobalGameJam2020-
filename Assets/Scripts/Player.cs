using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject partHolder;
    public GameManager gameManager;

    private bool hasPart;
    private GameObject lastPart;


    void Start()
    {
        hasPart = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if ((collision.gameObject.tag == "Part") && (hasPart == false))
        {
            hasPart = true;
            lastPart = collision.gameObject;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Ship")
        {
            if (hasPart == true)
            {
                gameManager.partsCollected++;
                Destroy(lastPart);
                hasPart = false;
            }
        }
        if (collision.gameObject.tag == "Traps" || collision.gameObject.tag == "Proyectile")
        {
            if(lastPart != null)
            {
                lastPart.gameObject.SetActive(true);
            }
            hasPart = false;
            gameManager.Restart();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Moving Platform")
        {
            this.transform.parent = collision.transform;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Moving Platform")
        {
            this.transform.parent = null;
        }
    }
}
