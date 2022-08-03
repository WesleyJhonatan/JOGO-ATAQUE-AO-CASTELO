using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AtacaMeucastelo : MonoBehaviour
{
    private NavMeshAgent Agente;
    private GameObject Castelo;
    public Animator Animador;
    private Gerenciador GJ;


    void Start()
    {

        Animador = GetComponent<Animator>();
        Agente = GetComponent<NavMeshAgent>();
        Castelo = GameObject.FindGameObjectWithTag("MeuCastelo");
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            float DistanciaCastelo = Vector3.Distance(transform.position, Castelo.transform.position);
            if (DistanciaCastelo < 400 && DistanciaCastelo > 2)
            {
                Agente.speed = 5;
                MoverInimigo();
                Animador.SetBool("Andar", true);

            }

            if (DistanciaCastelo < 200 && DistanciaCastelo > 2)
            {
                Agente.speed = 0;
                Animador.SetBool("Andar", false);
            }
        }
         
    }

    private void MoverInimigo()
    {
        Agente.destination = Castelo.transform.position;
    }

}
