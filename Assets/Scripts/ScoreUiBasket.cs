using UnityEngine;
using TMPro;

public class ScoreUiBasket : MonoBehaviour
{
    public GameObject Basket;
    public GameObject ScoreText;
    public TMP_Text text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Basket.transform.position;
    }

    public void ShowUI()
    {

        ScoreText.SetActive(!ScoreText.activeSelf);
    }
}
