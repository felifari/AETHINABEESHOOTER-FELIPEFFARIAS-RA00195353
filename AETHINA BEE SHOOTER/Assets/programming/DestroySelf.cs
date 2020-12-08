using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{

    //Destroi objetos coletaveis que ficam tempo demais na tela
    public float time;
    void Start()
    {
        Destroy(gameObject, time);
    }

}
