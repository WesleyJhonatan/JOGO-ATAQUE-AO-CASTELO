using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LançaEspecial : MonoBehaviour
{

    public Especial _especial;
    public Transform localDeLancamento;
    public float forcaDeLancamento = 50;
    public float numeroDeGranadas = 10;
    public float tempoPorLancamento = 1;

    float cronometroGranada = 1;
    bool lancouGranada = false;

  
    public float tempo = 0;
    public bool podeW = false;
    private float tempoW = 0;
    private Gerenciador GJ;

    private float CinzaW = 115;
    private void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();

    }
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            if (podeW == true)
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    podeW = false;
                    if (localDeLancamento && numeroDeGranadas >= 0 && !lancouGranada)
                    {
                        numeroDeGranadas = 10;
                        lancouGranada = true;
                        Especial objGranada = Instantiate(_especial, localDeLancamento.position, transform.rotation) as Especial;
                        Rigidbody rbGranada = objGranada.GetComponent<Rigidbody>();
                        rbGranada.AddForce(localDeLancamento.transform.forward * forcaDeLancamento, ForceMode.Impulse);
                    }


                }
            }

           

            if (lancouGranada)
            {
                cronometroGranada += Time.deltaTime;
            }
            if (cronometroGranada >= tempoPorLancamento)
            {
                lancouGranada = false;
                cronometroGranada = 1;
            }
        }
            
    }
}

    
      

  
