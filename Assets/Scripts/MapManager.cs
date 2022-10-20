using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class MapManager : MonoBehaviour
{
    // オブジェクト・プレハブ(インスペクタから指定)
    public Transform blockParent; // マップブロックの親オブジェクトのTransform
    public GameObject blockPrefabGrass; // 草ブロック
    public GameObject blockPrefabWater; // 水場ブロック
    public GameObject blockPrefabSea;

    // 定数定義
    public const int MAP_WIDTH = 9; // マップの横幅
    public const int MAP_HEIGHT = 9; // マップの縦(奥行)の幅
    private const int GENERATE_RATIO_GRASS = 90; // 草ブロックが生成される確率

    public const int SEA_WIDTH = 35;
    public const int SEA_HEIGHT = 25;

    void Start()
    {
        WolrdField();
        WorldSea();
    }
    
    private void WolrdField()
    {
        // ブロック生成位置の基点となる座標を設定
        Vector3 defaultPos = new Vector3 (0.0f, 0.0f, 0.0f); // x:0.0f y:0.0f z:0.0f のVector3変数defaultPosを宣言
        defaultPos.x = -(MAP_WIDTH / 2); // x座標の基点
        defaultPos.z = -(MAP_HEIGHT / 2); // z座標の基点

        // ブロック生成処理
        for (int i = 0; i < MAP_WIDTH; i++)
        {// マップの横幅分繰り返し処理
            for (int j = 0; j < MAP_HEIGHT; j++)
            {// マップの縦幅分繰り返し処理
                // ブロックの場所を決定
                Vector3 pos = defaultPos; // 基点の座標を元に変数posを宣言
                pos.x += i; // 1個目のfor分の繰り返し回数分x座標をずらす
                pos.z += j; // 2個目のfor分の繰り返し回数分z座標をずらす

                // ブロックの種類を決定
                int rand = Random.Range (0, 100); // 0~99の中から1つランダムな数字を取得
                bool isGrass = false; // 草ブロック生成フラグ(初期状態はfalse)
                // 乱数値が草ブロック確率値より低ければ草ブロックを生成する
                if (rand < GENERATE_RATIO_GRASS)
                    isGrass = true;

                // オブジェクトを生成
                GameObject obj; // 生成するオブジェクトの参照
                if (isGrass)
                {// 草ブロック生成フラグ：ON
                    obj = Instantiate (blockPrefabGrass, blockParent); // blockParentの子に草ブロックを生成
                }
                else
                {// 草ブロック生成フラグ：OFF
                    obj = Instantiate (blockPrefabWater, blockParent); // blockParentの子に水場ブロックを生成
                }
                // オブジェクトの座標を適用
                obj.transform.position = pos;
            }
        }
    }
    
    private void WorldSea(){
        // ブロック生成位置の基点となる座標を設定
        Vector3 defaultPos = new Vector3 (0.0f, -1.0f, 0.0f); // x:0.0f y:0.0f z:0.0f のVector3変数defaultPosを宣言
        defaultPos.x = -(SEA_WIDTH / 2); // x座標の基点
        defaultPos.z = -(SEA_HEIGHT / 2); // z座標の基点

        for (int i = 0; i < SEA_WIDTH; i++){
            for (int j = 0; j < SEA_HEIGHT; j++)
            {
                Vector3 pos = defaultPos; // 基点の座標を元に変数posを宣言
                pos.x += i; // 1個目のfor分の繰り返し回数分x座標をずらす
                pos.z += j; // 2個目のfor分の繰り返し回数分z座標をずらす

                GameObject obj;
                obj = Instantiate(blockPrefabSea, blockParent);
                obj.transform.position = pos;

            }
        }
    }
    
    void Update()
    {
        
    }
}