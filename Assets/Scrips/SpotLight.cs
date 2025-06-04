using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float duration;
    Light luz;
    private bool apagada=false;
    private void Awake()
    {
        luz = GetComponent<Light>();
    }
    void Start()
    {
        cam = Camera.main;
       
    }

    void Update()   
    {
        transform.DORotate(cam.transform.eulerAngles, duration);    
        ApagarLuz();
    }
    private void ApagarLuz()
    {
        if (Input.GetKeyDown(KeyCode.F)&&!apagada)
        {
            luz.intensity = 0;
            apagada = true;
        }
        else if(Input.GetKeyDown(KeyCode.F) && apagada)
        {
            luz.intensity = 20;
            apagada = false;

        }
    }
    
        //private IEnumerator RotarAObjetivo()
        //{

        //    float timer = 0f;
        //    Quaternion rotacionA = transform.rotation;
        //    Quaternion rotacionB = cam.transform.rotation;
        //    while(timer < smoothTime)
        //    {
        //        timer += Time.deltaTime;
        //        transform.rotation = Quaternion.Slerp(rotacionA, rotacionB, timer / smoothTime);
        //        yield return null;
        //    }
        //    transform.rotation = rotacionB;

        //}
}
