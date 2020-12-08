using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class DeathManager : MonoBehaviour
{
    //Move a cena para o game over quando as vidas acabam

    GameObject Beetle1;
    bool gameOver = false;


    void Start()
    {
        Beetle1 = GameObject.FindGameObjectWithTag("Beetle");
    }

    void Update()
    {
        if (Beetle1 == null && !gameOver)
            GameOver();

    }

    // Placar com score atual e o high score
    void GameOver()
    {
        gameOver = true;
        if (PlayerPrefs.GetInt("Score") > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", PlayerPrefs.GetInt("Score"));
              


        StartCoroutine(LoadGameOver());
    }

    IEnumerator LoadGameOver()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(2);

    }

}
