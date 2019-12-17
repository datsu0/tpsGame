using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTps : MonoBehaviour
{
private GameObject player;   //プレイヤー情報格納用
    private Vector3 offset;      //相対距離取得用
    private Vector3 addPos = new Vector3(-1,3,-1);
    private Vector3 maxArg = new Vector3(0,100,0);
    private Vector3 minArg = new Vector3(0,10,0);
 
	// Use this for initialization
	void Start () {
        
        //unitychanの情報を取得
        this.player = GameObject.Find("unitychan");
 
        // MainCamera(自分自身)とplayerとの相対距離を求める
        offset = transform.position - player.transform.position + addPos;
 
	}
	
	// Update is called once per frame
	void Update () {
 
        //新しいトランスフォームの値を代入する
        transform.position = player.transform.position + offset;
 
        //ユニティちゃんの向きと同じようにカメラの向きを変更する
        if(minArg.y<player.transform.rotation.eulerAngles.y||player.transform.rotation.eulerAngles.y<maxArg.y){
            transform.rotation = player.transform.rotation;
        }
	}
}
