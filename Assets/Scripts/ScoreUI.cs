using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TMP_Text ScoreBoxText;
    public GameObject ScoreText;
    public GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoxText.text = "Score: " + gameManager.Score.ToString();
    }

    public void Hide()
    {
        ScoreText.SetActive(false);
    }

    public void Show()
    {
        ScoreText.SetActive(true);
    }
}
