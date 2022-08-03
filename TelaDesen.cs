using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelaDesen : MonoBehaviour
{
    public float tempo = 0;
    public GameObject Cobra;
    public GameObject Botao;
    void Start()
    {
        
    }

    void Update()
    {
        tempo += 0.1f;
        if(tempo >= 10)
        {
            Cobra.SetActive(false);
            Botao.SetActive(true);
            tempo = 0;
        }
    }
}
