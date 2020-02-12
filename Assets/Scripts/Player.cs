using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject partHolder;
    public GameManager gameManager;

    private bool _hasPart;
    private GameObject _lastPart;
    // Start is called before the first frame update
    void Start()
    {
        _hasPart = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if ((collision.gameObject.tag == "Part") && (_hasPart == false))
        {
            _hasPart = true;
            _lastPart = collision.gameObject;
            collision.gameObject.SetActive(false);
        }
        if (collision.gameObject.tag == "Ship")
        {
            if (_hasPart == true)
            {
                gameManager.partsCollected++;
                Destroy(_lastPart);
                _hasPart = false;
                Debug.Log("Lo deja en la nave");
            }
        }
        if (collision.gameObject.tag == "Traps" || collision.gameObject.tag == "Proyectile")
        {
            if(_lastPart != null)
            {
                _lastPart.gameObject.SetActive(true);
            }
            _hasPart = false;
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
