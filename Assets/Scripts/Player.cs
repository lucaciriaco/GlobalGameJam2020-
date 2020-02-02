﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject partHolder;
    public GameManager gameManager;
    bool hasPart;
    GameObject lastPart;
    // Start is called before the first frame update
    void Start()
    {
        hasPart = false;
    }

    // Update is called once per frame
    void Update()
    {

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
                Debug.Log("Lo deja en la nave");
            }
        }
        if (collision.gameObject.tag == "Traps" || collision.gameObject.tag == "Proyectile")
        {
            if(lastPart != null)
            {
                lastPart.gameObject.SetActive(true);
            }
            hasPart = false;
            gameManager.restart();
            Debug.Log("asdf");
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