using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        
    }
	
    void Update()
    {
        // タップ検出処理
        if (Input.GetMouseButtonDown (0))
        {// タップが行われた
            // タップ先にあるブロックを取得して選択処理を開始する
            GetMapBlockByTapPos ();
        }
    }

    /// <summary>
    /// タップした場所にあるオブジェクトを見つけ、選択処理などを開始する
    /// </summary>
    private void GetMapBlockByTapPos ()
    {
        GameObject targetObject = null; // タップ対象のオブジェクト

        // タップした方向にカメラからRayを飛ばす
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        RaycastHit hit = new RaycastHit ();
        if (Physics.Raycast (ray, out hit))
        {// Rayに当たる位置に存在するオブジェクトを取得(対象にColliderが付いている必要がある)
            targetObject = hit.collider.gameObject;
            Debug.Log(targetObject);
        }
        
        // 対象オブジェクト(マップブロック)が存在する場合の処理
        if (targetObject != null)
        {
            // ブロック選択時処理
            SelectBlock(targetObject.GetComponent<MapBlock> ());
        }
    }

    /// <summary>
    /// 指定したブロックを選択状態にする処理
    /// </summary>
    /// <param name="targetMapBlock">対象のブロックデータ</param>
    private void SelectBlock(MapBlock targetBlock)
    {
        Debug.Log ("\n" + targetBlock.transform.position);
    }
}
