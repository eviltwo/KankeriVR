using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class LookEnemy : MonoBehaviour
{

    public GameObject Camera;//カメラ
    public GameObject Player;//プレイヤー
    public List<GameObject> RespawnPoint = new List<GameObject>();//リスポーン地点
    public List<GameObject> Enemy = new List<GameObject>();//プレイヤー
    public Vector3 Forward;//カメラの向いている方向
    public Vector3 CheckPos; //チェックするための位置
    public RaycastHit hit;//レイキャストがヒットしたとき
    public List<int> Enemyflg = new List<int>();//発見フラグ
    public List<int> EnemyCheckflg = new List<int>();//チェックフラグ
    public List<int> EnemyWaitTime = new List<int>();//待ち時間
    public List<int> LookEnemyflg = new List<int>();//プレイヤー発見フラグ
    public GameObject EffectPrefab;

    void Start()
    {
        //AddEnemy(GameObject.FindWithTag("Player"));
        RespawnPoint.Add(GameObject.FindWithTag("respawn"));
    }

    //ループ
    void Update()
    {
        //カメラの向きを取得
        Forward = Player.transform.TransformDirection(Vector3.forward);

        for (int i = 0; i < Enemy.Count; i++)
        {
            //チェック位置の初期化
            CheckPos = Camera.transform.position;

            for (int j = 1; j < 100; j++)
            {
                //チェックポジションの位置をずらす
                CheckPos = Camera.transform.position + Forward * j;

                //プレイヤーがチェック範囲内にいるかチェックする
                if (Vector3.Distance(Enemy[i].transform.position, CheckPos) <= 5)
                {
                    EnemyCheckflg[i] = 1;
                    Enemyflg[i] = 1;
                    break;
                }
                else
                {
                    EnemyCheckflg[i] = 0;
                }
            }
        }

        for (int i = 0; i < Enemy.Count; i++)
        {
            if (Enemyflg[i] == 1)
            {
                if (Physics.Raycast(transform.position, (Enemy[i].transform.position - transform.position).normalized, out hit))
                {
                    if (hit.transform.tag != "Player")
                    {
                        Enemyflg[i] = 0;
                    }
                }
            }

            if (Enemyflg[i] == 1)
            {
                EnemyWaitTime[i]++;
                Enemyflg[i] = 0;
            }
            else
            {
                EnemyWaitTime[i] = 0;
            }
            if (EnemyWaitTime[i] >= 180)
            {
                LookEnemyflg[i] = 1;
            }
            else
            {
                LookEnemyflg[i] = 0;
            }
        }

        for (int i = 0; i < Enemy.Count; i++)
        {
            if (LookEnemyflg[i] == 1)
            {
                VanishEnemy(i , Random.Range(0 , 1));
            }
        }
    }

    public void AddEnemy(GameObject enemy)
    {
        Enemy.Add(enemy);
        EnemyCheckflg.Add(0);
        Enemyflg.Add(0);
        EnemyWaitTime.Add(0);
        LookEnemyflg.Add(0);
    }

    public void VanishEnemy(int a , int b)
    {
        Instantiate(EffectPrefab, Enemy[a].transform.position, Quaternion.identity);
		Enemy [a].transform.position = new Vector3 (
			Random.Range (-10, 10),
			1,
			Random.Range (-10, 10));
		
		NetworkManager.Destroy (Enemy [a]);
		//RespawnPoint[b].transform.position;
    }
}