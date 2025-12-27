using UnityEngine;
using UnityEngine.UI;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance;

    public GameObject winPanel;
    public Text winText;

    void Awake()
    {
        Instance = this;
    }

    public void WinGame()
    {
        int finalScore = ScoreManager.Instance.score;
        winText.text = "Vous avez gagné !\nScore : " + finalScore;

        winPanel.SetActive(true);

        Time.timeScale = 0f;
    }
}
