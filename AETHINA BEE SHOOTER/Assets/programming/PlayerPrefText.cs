using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefText : MonoBehaviour
{

    //Escreve a quantidade de vida ou score do jogador na fonte do jogo
    public string names;
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(names) + "";

    }
}
