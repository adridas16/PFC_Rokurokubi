using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ApagarLuces : MonoBehaviour
{
    [SerializeField] List<GameObject> listaLuces;
    //[SerializeField] private GameObject[] luces;
    [SerializeField]float timerLuz=0;
    [SerializeField] Animator anim;
    int luces;
    Camera cam;
    [SerializeField] private float distancialuz;
    private bool seApaga=false;
    // Start is called before the first frame update
    void Start()
    {
       cam=Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        timerLuz += Time.deltaTime;
        ApagarLuz();
        EncenderLuz();
    }
    void ApagarLuz()
    {
        if (timerLuz >= 30&&luces==0)
        {
            
            for (int i = 0; i < listaLuces.Count; i++)
            {
              listaLuces[i].gameObject.SetActive(false);
              anim.SetBool("Apagon", true);
              seApaga = true;
            }
            
            
        }
        else if (luces >= 1)
        {
            for (int i = 0; i < listaLuces.Count; i++)
            {
                listaLuces[i].gameObject.SetActive(true);
                anim.SetBool("Apagon", false);
            }
        }
       
    }
   

    void EncenderLuz()
    {
        if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitinfo, distancialuz)&& seApaga)
        {
            if (hitinfo.transform.CompareTag("ApagarLuz"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    hitinfo.transform.GetComponent<Outline>().enabled=true;
                    Debug.Log(hitinfo);
                    Debug.Log(luces);
                    luces++;
                }
            }
            else
            {
                hitinfo.transform.GetComponent<Outline>().enabled = false;
            }
        }
    }
}
