using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoGolem : MonoBehaviour
{
    private Gerenciador GJ;
    public Text meuTexto4;


    // Start is called before the first frame update
    void Start()
    {
        meuTexto4 = GetComponent<Text>();
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            meuTexto4.text = GJ.RetornaPontos4().ToString() + "/10";
        }
    }
}