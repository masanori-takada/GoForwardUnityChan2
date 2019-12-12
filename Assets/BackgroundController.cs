using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    float scrollSpeed = -0.03f;
    float deadLine = -16;
    float startLine = 15.8f;

    void Start()
    {

    }


    void Update()
    {
        transform.Translate(this.scrollSpeed, 0, 0);
        if (transform.position.x < this.deadLine)
        {
            transform.position = new Vector2(this.startLine, 0);
        }
    }
}
