using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    float speed = -12;
    float deadline = -10;


    void Start()
    {

    }


    void Update()
    {
        //画面外に出たら破棄する
        transform.Translate(this.speed * Time.deltaTime, 0, 0);
        //Translateは、引数に与えた値のぶんだけ現在の位置から移動します
        //（指定した値の座標に移動するわけではないことに注意してください）
        if (transform.position.x < this.deadline)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            GetComponent<AudioSource>().Play();
        }

        if (other.gameObject.tag == "Cube")
        {
            GetComponent<AudioSource>().Play();
        }

    }
}
