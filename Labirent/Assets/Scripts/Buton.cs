using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buton : MonoBehaviour
{
    bool pauseGame = false; // oyunu durdur   
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void YenidenBasla()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Level2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Level3()
    {
        SceneManager.LoadScene("Level3");
    }
    public void Level4()
    {
        SceneManager.LoadScene("Level4");
    }
    public void Level5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void OncekiLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void PauseGame() //oyunu durdurmak için yazdýðýmýz fonksiyon
    {
        pauseGame = !pauseGame;

        if (pauseGame == true)
        {
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
