using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public int score;
    public int highScore;

    public void Setup()
    {
        Invoke("Display", 6);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene("Fuck this is the scene merge it");
    }
    
    public void MenuButton()
    {
        SceneManager.LoadScene("Main Menu");
    }

    private void Display()
    {
        gameObject.SetActive(true);
        scoreText.text = score.ToString() + " POINTS";
        highScoreText.text = highScoreText.text = "HIGHSCORE: " + highScore.ToString();
    }
}
