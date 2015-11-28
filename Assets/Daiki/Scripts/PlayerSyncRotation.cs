using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class PlayerSyncRotation : NetworkBehaviour {
	//SyncVar: ホストサーバーからクライアントへ送られる
	//プレイヤーの角度
	[SyncVar] private Quaternion syncPlayerRotation;

	[SerializeField] private Transform playerTransform;
	[SerializeField] private float lerpRate = 15;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void FixedUpdate () {
		//クライアント側のPlayerの角度を取得
		TransmitRotations();
		//現在角度と取得した角度を補間する
		LerpRotations();
	}

	//角度を補間するメソッド
	void LerpRotations ()
	{
		//自プレイヤー以外のPlayerの時
		if (!isLocalPlayer){
			//プレイヤーの角度とカメラの角度を補間
			playerTransform.rotation = Quaternion.Lerp (playerTransform.rotation,
				syncPlayerRotation, Time.deltaTime * lerpRate);
		}
	}

	//クライアントからホストへ送られる
	[Command]
	void CmdProvideRotationsToServer (Quaternion playerRot)
	{
		syncPlayerRotation = playerRot;
	}

	//クライアント側だけが実行できるメソッド
	[Client]
	void TransmitRotations ()
	{
		if (isLocalPlayer) {
			CmdProvideRotationsToServer(playerTransform.rotation);
		}
	}
}
