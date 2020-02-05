using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Sprite[] partsSprites;
    public Text partsCounterUI;
    public Text winQuoteUI;
    public Text triesCounterUI;
    public Text timerUI;
    public GameObject player1;
    public GameObject player2;
    public int partsCollected;
    public int partsQuantity;
    public float triesCounter;
    public float timer;


    GameObject[] parts;
    Vector3 p1Start;
    Vector3 p2Start;

    private void Awake()
    {
        parts = GameObject.FindGameObjectsWithTag("Part");
        partsQuantity = parts.Length;
        partsCollected = 0;
    }

    void Start()
    {
        
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].gameObject.GetComponent<SpriteRenderer>().sprite = partsSprites[(Random.Range(0, partsSprites.Length))];
        }
        Cursor.lockState = CursorLockMode.Locked;
        winQuoteUI.enabled = false;
        p1Start = player1.transform.position;
        p2Start = player2.transform.position;
        triesCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        partsCounterUI.text = "Parts to repair the ship: " + partsCollected + "/" + partsQuantity;
        triesCounterUI.text = "Tries: " + triesCounter;
        if(partsCollected == partsQuantity)
        {
            winQuoteUI.enabled = true;
        }

        if(Input.GetKeyDown("r"))
        {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void restart()
    {
        triesCounter = triesCounter + 0.5f;
        player1.gameObject.transform.position = p1Start;
        player2.gameObject.transform.position = p2Start;
    }
}
