using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue2 : MonoBehaviour
{
    public Animator Animador;
    private Gerenciador GJ;
    public GameObject Camera2;
    public GameObject Camera3;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animador = GetComponent<Animator>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {
                Animador.SetBool("Gira", true);
            
        }
    }

   
    public void ParaAnima()
    {
        Animador.SetBool("Gira", false);
        Camera3.SetActive(true);
        Camera2.SetActive(false);
    }
}
