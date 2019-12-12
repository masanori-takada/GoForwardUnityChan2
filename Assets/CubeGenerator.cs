using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab;

    float delta = 0;
    float span = 1.0f;
    //キューブ生成の時間間隔

    float genPosX = 12;

    float offsetY = 0.3f;
    //キューブの生成位置オフセット
    float spaceY = 6.9f;
    //キューブの縦方向の間

    float offsetX = 0.5f;
    float spaceX = 0.4f;

    int maxBlockNum = 4;
    //キューブの生成個数の上限


    void Start()
    {

    }


    void Update()
    {
        this.delta += Time.deltaTime;
        //キューブ生成までの時間蓄積

        if (this.delta > this.span)
        {
            this.delta = 0;
            int n = Random.Range(1, maxBlockNum + 1);
            //生成するキューブ数を決める

            for (int i = 0; i < n; i++)
            //決めたキューブ数だけ、forにより繰り返し生成し続ける
            {
                GameObject go = Instantiate(cubePrefab) as GameObject;
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);

            }

            this.span = this.offsetX + this.spaceX * n;
            //生成するキューブの数が少ない場合は次のキューブ生成までの間隔を短くし、
            //キューブの数が多い場合は次のキューブ生成までの間隔を長くしています。
        }

    }


}


