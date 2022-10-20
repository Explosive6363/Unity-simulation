using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
	private Camera mainCamera;
	
	// キャラクター初期設定(インスペクタから入力)
	[Header ("初期X位置(-4～4)")]
	public int initPos_X; // 初期X位置
	[Header ("初期Z位置(-4～4)")]
	public int initPos_Z; // 初期Z位置

	void Start()
    {
	    mainCamera = Camera.main;
	    
		// 初期位置に対応する座標へオブジェクトを移動させる
		Vector3 pos = new Vector3 ();
		pos.x = initPos_X; // x座標：1ブロックのサイズが1(1.0f)なのでそのまま代入
		pos.y = 1.5f; // y座標（固定）
		pos.z = initPos_Z; // z座標
		transform.position = pos; // オブジェクトの座標を変更

		Vector2 scale = transform.localScale;
		scale.x *= -1.0f; // X方向の大きさを正負入れ替える
		transform.localScale = scale;
    }
	
    void Update() 
    {
	    // ビルボード処理
	    // (スプライトオブジェクトをメインカメラの方向に向ける)
	    Vector3 cameraPos = mainCamera.transform.position; // 現在のカメラ座標を取得
	    cameraPos.y = transform.position.y; // キャラが地面と垂直に立つようにする
	    transform.LookAt (cameraPos);
    }
}