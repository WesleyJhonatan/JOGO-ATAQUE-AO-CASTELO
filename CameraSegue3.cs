using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSegue3 : MonoBehaviour
{
    public GameObject Heroi;
    public float posX;
    public float posY;
    public float posZ;


    public Animator Animador;
    private Gerenciador GJ;
    private bool podeAnima = true;
    private bool podeSeguir = false;

    public GameObject Jogo;
    public GameObject Inicial;

    public AudioSource JogoV;

    public Movimento Podeir;



    void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Animador = GetComponent<Animator>();
    }


    void Update()
    {
        if (GJ.EstadoDoJogo() == true)

        {

            if (podeAnima == true)
            {
                Animador.SetBool("Sobe", true);
            }


            if (podeSeguir == true)
            {
                JogoV.volume = 0.608f;

                Vector3 Destino = new Vector3(Heroi.transform.position.x + posX, Heroi.transform.position.y + posY, Heroi.transform.position.z + posZ);
                transform.position = Vector3.MoveTowards(transform.position, Destino, 70f);

                GetComponent<Animator>().enabled = false;


                transform.eulerAngles = new Vector3(80, 0, 0);
                Cursor.visible = true;

                Podeir.podeir = true;
            }

        }
    }


    public void ParaAnima()
    {
        podeAnima = false;
        Animador.SetBool("Sobe", false);
        podeSeguir = true;
    }
}
