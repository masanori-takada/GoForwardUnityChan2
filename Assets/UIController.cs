using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //シーン遷移するときは必須

public class UIController : MonoBehaviour
{
    GameObject gameOverText;
    GameObject runLengthText;

    float len = 0;
    float speed = 0.03f;

    bool isGameOver = false;

    void Start()
    {
        this.gameOverText = GameObject.Find("GameOver");
        this.runLengthText = GameObject.Find("RunLength");
    }


    void Update()
    {
        if (this.isGameOver == false)
        {
            this.len += this.speed;
            this.runLengthText.GetComponent<Text>().text = "Distance" + len.ToString("F2") + "m";
        }

        if (this.isGameOver == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                SceneManager.LoadScene("GameScene");
                //シーン遷移して、引数にある”GameScene”を読み込む
            }
        }
    }

    public void GameOver()
    //unitychanコントローラから、アクセスできるようpublic修飾子
    {
        this.gameOverText.GetComponent<Text>().text = "GameOver";
        this.isGameOver = true;
    }
}
