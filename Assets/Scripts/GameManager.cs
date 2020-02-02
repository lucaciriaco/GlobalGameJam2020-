using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    Vector3 p1Start;
    Vector3 p2Start;
    public Sprite[] partsSprites;
    public Text partsCounter;
    public Text winQuote;
    public GameObject player1;
    public GameObject player2;
    public int partsCollected;
    public int partsQuantity;

    GameObject[] parts;

    private void Awake()
    {
        parts = GameObject.FindGameObjectsWithTag("Part");
        partsQuantity = parts.Length;
        partsCollected = 0;
    }

    void Start()
    {
        /*
        for (int i = 0; i < parts.Length - 1; i++)
        {
            parts[i].gameObject.GetComponent<SpriteRenderer>().sprite = partsSprites[(Random.Range(0, partsSprites.Length - 1))];
        }
        */
        Cursor.lockState = CursorLockMode.Locked;
        winQuote.enabled = false;
        p1Start = player1.transform.position;
        p2Start = player2.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        partsCounter.text = "Parts to repair the ship: " + partsCollected + "/" + partsQuantity;
        if(partsCollected == partsQuantity)
        {
            winQuote.enabled = true;
        }
        /*
        if(Input.GetKeyDown("R"))
        {

        }
        */
    }

    public void restart()
    {
        player1.gameObject.transform.position = p1Start;
        player2.gameObject.transform.position = p2Start;
    }
}
