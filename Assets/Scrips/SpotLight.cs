using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLight : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float duration;

    private Vector3 velocity;
    private bool apagada=true;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()   
    {
        transform.DORotate(cam.transform.eulerAngles, duration);
        ApagarLuz();
    }
    private void ApagarLuz()
    {
        if (Input.GetKeyDown(KeyCode.F)&&apagada)
        {
            gameObject.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.F) && !apagada)
        {
            gameObject.SetActive(true);

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
    
}
