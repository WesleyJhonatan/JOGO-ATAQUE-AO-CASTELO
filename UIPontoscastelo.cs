using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPontoscastelo : MonoBehaviour
{
    private Gerenciador GJ;
    public Text meuTexto2;


    // Start is called before the first frame update
    void Start()
    {
        meuTexto2 = GetComponent<Text>();
        GJ = GameObject.FindGameObjectWithTag("GameController").GetComponent<Gerenciador>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GJ.EstadoDoJogo() == true)
        {
            meuTexto2.text = GJ.RetornaPontos2().ToString() + "/1";
        }
    }
}
