using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float timer;


    [SerializeField] private float tiempoDeTarea = 30;

    public static Spawner spawner;
    private bool spawneado = false;
    private Vector3 puntoSpaWN;

    private bool puntoVisible;
    Vector3 puntoMapa;
    [SerializeField] private  EnemigoRokuro enemigoR;

    public float Timer { get => timer; set => timer = value; }
    public bool Spawneado { get => spawneado; set => spawneado = value; }

    private void Awake()
    {
        timer = tiempoDeTarea;
        cam = Camera.main;
        if (spawner == null)
        {
            spawner = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

       if (!spawneado)
       {
          timer -= Time.deltaTime;
          if (timer <= 0)
          {

              do
              {
                   puntoMapa = new Vector3(UnityEngine.Random.Range(11.608f, -11.617f), 2f, UnityEngine.Random.Range(9.995f, -13.198f));
                   Vector3 viewportPoint = cam.WorldToViewportPoint(puntoMapa);
                   if (!(viewportPoint.x > 0 && viewportPoint.x < 1 && viewportPoint.y > 0 && viewportPoint.y < 1 && viewportPoint.z > 0))
                   {
                      //spawneado = true;
                      puntoSpaWN = puntoMapa;
                      puntoVisible = false;
                   }
              } 
              while (puntoVisible);


                    Spawnear();

          }

       }
        
      
    }

    private void Spawnear()
    {
        puntoVisible = true;
        enemigoR.transform.position = puntoMapa;
        enemigoR.gameObject.SetActive(true);
        timer = tiempoDeTarea;
    }

    private IEnumerator WaitForTaskAndSpawn()
    {
        while (true)
        {

        }
    }
}
