using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue : MonoBehaviour
{
    public Animator Animador;
    private Gerenciador GJ;
    public GameObject Camera1;
    public GameObject Camera2;

    public GameObject Jogo;
    public GameObject Inicial;

    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animador = GetComponent<Animator>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
           Animador.SetBool("CameraAnda", true);
        }
    }

    public void ComecaGira()
    {
        Animador.SetBool("CameraAnda", false);
        Camera2.SetActive(true);
        Camera1.SetActive(false);
    }

}
