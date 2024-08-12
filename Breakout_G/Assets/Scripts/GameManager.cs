using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public TextMeshProUGUI pointText;
    private int pointAmount = 0;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(ball);
    }

    // Update is called once per frame
    void Update()
    {
        pointText.text = pointAmount.ToString();
    }

    public void GainPoint()
    {
        pointAmount += 1;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameScene");
    }
}
