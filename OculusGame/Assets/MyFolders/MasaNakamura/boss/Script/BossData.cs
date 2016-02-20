// 2/19 梅村 ボスのデータ
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class BossData : MonoBehaviour {
	public const int TARGET2D = 1;
	public const int TARGET3D = 2;
	public const int BOSS_PATTERN_STAY = 0;
	public const int BOSS_PATTERN_VULCAN = 99;
	public const int BOSS_PATTERN_RAILGUN = 1;
	public const int BOSS_PATTERN_TACKLE = 2;
	public const int BOSS_PATTERN_ENEMY_CREATE = 3;
	public const int BOSS_PATTERN_NULL = -1;
 
    public int bossHp;
    public int bossHate;//+10で2Dを狙う -10で3Dを狙う
	public int bossAttackTarget{ set; get;}

	void Awake(){
		bossHp = 400;
		bossAttackTarget = TARGET2D;
	}
	/// <summary>
	/// ダメージ処理
	/// </summary>
	/// <param name="bullet">弾の種類</param>
	/// <param name="player">攻撃しているプレイヤー</param>
    
	public void BossDamage(string bullet,string player){

		switch(bullet){
		case "NormalBullet":
                bossHp -= 2;
			break;
		default:
			Debug.LogError("bullet指定ミス");
			break;
		}

		switch(player){
		case "2D":
			bossHate++;
			break;
		case "3D":
			bossHate--;
			break;
		default:
			Debug.LogError("player指定ミス");
			break;
		}

		if(bossHate >= 10){
			bossAttackTarget = TARGET2D;
			bossHate = 0;
		}
		if(bossHate <= -10){
			bossAttackTarget = TARGET3D;
			bossHate = 0;
		}

        if (bossHp <= 0)
        {
            SoundPlayer.Instance.PlaySoundEffect("Bomb",1.0f);
			EffectFactory.Instance.Create("bom",transform.position,transform.rotation);
            Destroy(gameObject);
        }

	}

    void OnDestroy()
    {
        OnlineLevel.Instance.ChangeNextState();
    }
}