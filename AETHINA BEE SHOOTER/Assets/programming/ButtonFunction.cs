using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{

    //Botoes dos menus, Quit fecha a aplicacao e Play te leva para o jogo 
    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene(1);
    }

    public void Loadscene(int a)
    {
        SceneManager.LoadScene(a);
    }
}
