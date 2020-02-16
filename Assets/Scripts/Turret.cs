using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject proyectile;
    public float timeBetweenInstances;

    void Start()
    {
        InvokeRepeating("launchProyectile",1f, timeBetweenInstances);
    }

    void launchProyectile()
    {
        Instantiate(proyectile,spawnPoint);
    }
}
