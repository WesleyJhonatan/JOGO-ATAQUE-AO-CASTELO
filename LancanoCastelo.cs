using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancanoCastelo : MonoBehaviour
{
    public Granada _granada;
    public Transform localDeLancamento;
    public float forcaDeLancamento = 50;
    public float numeroDeGranadas = 10;
    public float tempoPorLancamento = 1;

    float cronometroGranada = 1;
    bool lancouGranada = false;

    private GameObject Castle;
    public Animator Animador;
    public float tempo = 0;

    private Gerenciador GJ;

    private void Start()
    {
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
        Castle = GameObject.FindGameObjectWithTag("MeuCastelo");

    }
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            float DistanciaCastelo = Vector3.Distance(transform.position, Castle.transform.position);
            if (DistanciaCastelo < 200 && DistanciaCastelo > 2)
            {
                Animador.SetBool("Pedrada", true);
            }

            else
            {

                Animador.SetBool("Pedrada", false);
            }
        }
            
    }

    public void TacaPedra()
    {
            if (localDeLancamento && numeroDeGranadas >= 0 && !lancouGranada)
            {
                tempo = 0;
                numeroDeGranadas = 10;
                lancouGranada = true;
                Granada objGranada = Instantiate(_granada, localDeLancamento.position, transform.rotation) as Granada;
                Rigidbody rbGranada = objGranada.GetComponent<Rigidbody>();
                rbGranada.AddForce(localDeLancamento.transform.forward * forcaDeLancamento, ForceMode.Impulse);
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
