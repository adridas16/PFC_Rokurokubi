using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemigoRokuro : MonoBehaviour
{
    private NavMeshAgent agent;
    private PlayerControler player;
    [SerializeField]private float timerAtaque = 15;


    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindObjectOfType<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        perseguir();
       
       
        

    }
 

    //funciona con evento de animacion
    private void perseguir()
    {
        //Tengo que definir como destino la posicion del player
        agent.SetDestination(player.transform.position);

        //Si no hay calculos Pendientes para saber donde esta mi objetivo
        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            //me paro
            agent.isStopped = true;
            //activar la animacion de ataque
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
