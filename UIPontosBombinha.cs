using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPontosBombinha : MonoBehaviour
{
    private Gerenciador GJ;
    public Text meuTexto3;


    // Start is called before the first frame update
    void Start()
    {
        meuTexto3 = GetComponent<Text>();
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            meuTexto3.text = GJ.RetornaPontos3().ToString() + "/50";
        }
    }
}
