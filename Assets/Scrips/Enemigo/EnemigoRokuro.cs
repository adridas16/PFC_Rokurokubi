using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoRokuro : MonoBehaviour
{
    private NavMeshAgent agent;
    private PlayerControler player;
    [SerializeField] private float timerAtaque = 15;
    private EnemigoRokuro enemigoR;
    [SerializeField] private Spawner spawner;
    [SerializeField] private GameObject PanelM;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        spawner.Spawneado = true;
    }

    void Start()
    {
        player = GameObject.FindObjectOfType<PlayerControler>();
        
    }

    void Update()
    {
        timerAtaque -= Time.deltaTime;
        if (timerAtaque > 0)
        {
            Perseguir();
        }
        else if (timerAtaque < 0)
        {
            spawner.Spawneado = false;
            timerAtaque = 15;
            gameObject.SetActive(false);
        }

    }


    //funciona con evento de animacion
    private void Perseguir()
    {
        //Tengo que definir como destino la posicion del player
        agent.SetDestination(player.transform.position);

        //Si no hay calculos Pendientes para saber donde esta mi objetivo
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            //me paro
            agent.isStopped = true;
            Cursor.lockState = CursorLockMode.None;
            //activar la animacion de ataque
            EnfocarPlayer();
            PanelM.SetActive(true);
            
        }
        else
        {
            agent.isStopped=false;
            EnfocarPlayer();
        }
    }

    private void EnfocarPlayer()
    {
        //calculo al vector que enfoque al jugador
        Vector3 direccionAPlayer = (player.transform.position - transform.position).normalized;
        //me aseguro que no vuelque el enemigo al player
        direccionAPlayer.y = 0;
        //calcula la rotacion a la que me tengo que girar para orientarme en esa direccion
        transform.rotation = Quaternion.LookRotation(direccionAPlayer);
    }




}
