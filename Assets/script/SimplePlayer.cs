using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayer : MonoBehaviour
{

    void Start()
    {
        
    }

    /* FixedUpdateの説明
     * Updateは１秒間に何回呼ばれるかわからない（端末性能に左右される）
     * Time.deltaTimeは変動する（同フレーム内で同値になる）
     * 
     * FiexdUpdeteは１秒間に呼ばれる回数が決まっている
     * Time.fixedDeltaTimeも値が固定
     * 上記２つを使うことにより正確な値（ゲームバランスの構築ができる）
    */
    void FixedUpdate()
    {
        var hori = Input.GetAxis("Horizontal");// * Time.fixedDeltaTime
        var vert = Input.GetAxis("Vertical");// * Time.fixedDeltaTime
        var force = new Vector3(hori,vert,0f);
        // transform.position += new Vector3(hori,vert,0f);
        // Rigidbodyの中でTime.fixedDeltaTimeが使用されているらしい
        GetComponent<Rigidbody>().AddForce(force * 100f);
    }
}
