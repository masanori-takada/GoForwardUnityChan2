using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    Animator animator;
    //アニメーションのための型
    Rigidbody2D rigid2D;
    //ジャンプ等の移動のための型

    float groundLevel = -3.0f;
    //地面の位置
    float jumpVelocity = 20;
    //ジャンプ速度
    float dump = 0.8f;
    //ジャンプ速度の減衰係数

    float deadLine = -9;
    //ゲームオーバーになる位置

    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.rigid2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        this.animator.SetFloat("Horizontal", 1);
        //アニメータ遷移条件の0.1以上を満たす値にする

        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        //三項演算子とは、　　値を代入する変数 = (条件式) ? 変数1 : 変数2;
        //条件式を満たした場合には左辺の変数に「変数1」が代入され、
        //条件式を満たさなかった場合には左辺の変数に「変数2」が代入されます。
        this.animator.SetBool("isGround", isGround);
        //変数isGround　は、空中ならfalse、着地ならtrue　が代入される

        GetComponent<AudioSource>().volume = (isGround) ? 1 : 0;
        //isGround がtrueのときは左辺のvolumeに１を代入、それ以外falseのときは、volumeに0を代入する

        //着地状態でクリックされた場合
        if (Input.GetMouseButtonDown(0) && isGround)
        //GetMouseButtonDownは押した瞬間　かつ　変数isGroundがtrueのとき
        {
            this.rigid2D.velocity = new Vector2(0, this.jumpVelocity);
        }

        if (Input.GetMouseButton(0) == false)
        //GetMouseButtonは押し続けている期間
        {
            if (this.rigid2D.velocity.y > 0)
            {
                this.rigid2D.velocity *= this.dump;
                //係数は変数にかけること
                //（this.rigid2D.velocity.y *= this.dump; にしちゃうと変数でないのでエラー）
            }
        }

        //ゲームオーバーを判定し、UIコントローラの関数を呼ぶ
        if (transform.position.x < this.deadLine)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().GameOver();
            //Findでオブジェクトを探して、GetComponentでそのオブジェクトのスクリプトを取得し、ドットで関数を使う
            Destroy(gameObject);
        }
    }
}
