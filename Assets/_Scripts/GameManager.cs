using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI textHighScore;
    public TextMeshProUGUI textScore;
    public static int score;
    public static int highScore;
    public TextMeshProUGUI moveOff;
    public TextMeshProUGUI moveOn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Snake.moveThroughWalls == false)
        {
            moveOff.gameObject.SetActive(true);
            moveOn.gameObject.SetActive(false);
        }
        else
        {
            moveOff.gameObject.SetActive(false);
            moveOn.gameObject.SetActive(true);
        }

        textScore.text = "Score: " + score;

        if (score > highScore)
        {
            highScore = score;
        }
        textHighScore.text = "High Score: " + highScore;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        TitleScreen();
        ChooseMode();
    }
    void TitleScreen()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Game");
        }
    }
    void ChooseMode()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Snake.moveThroughWalls = !Snake.moveThroughWalls;
            moveOff.gameObject.SetActive(!Snake.moveThroughWalls);
            moveOn.gameObject.SetActive(Snake.moveThroughWalls);
        }
    }
}
