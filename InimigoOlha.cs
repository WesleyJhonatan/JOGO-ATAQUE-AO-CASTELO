using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class InimigoOlha : MonoBehaviour
{
    private NavMeshAgent Agente;
    private GameObject Heroi;
    private Gerenciador GJ;


    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Agente = GetComponent<NavMeshAgent>();
        Heroi = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {

            float DistanciaHeroi = Vector3.Distance(transform.position, Heroi.transform.position);
            if (DistanciaHeroi < 50 && DistanciaHeroi > 2)
            {
                Agente.speed = 2f;
                MoverInimigo();

            }

            else
            {
                Agente.speed = 0;
            }

        }

    }

    private void MoverInimigo()
    {
        Agente.destination = Heroi.transform.position;
    }

}
