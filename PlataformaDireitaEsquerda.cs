using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlataformaDireitaEsquerda : MonoBehaviour
{

    public float posInicial;
    public float posFinal;
    public float x = 0;
    public float y = 0;
    public float v = 0;
    private bool para = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(para == false)
        {
            if (posInicial <= posFinal)
            {
                x += v;
                transform.localPosition = new Vector3(x, y);
                if (x >= posFinal)
                {
                    para = true;
                }
            }
        }
       
        if(para == true)
        {
           transform.localPosition = new Vector3(posInicial, y);
            x = posInicial;
           para = false;
        }
       

    }

   
}
