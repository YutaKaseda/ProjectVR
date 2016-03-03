// 2/19 梅村 ボスのデータ
// 3/1 梅村 ui連動
using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class BossData : MonoBehaviour {
	public const int TARGET2D = 1;
	public const int TARGET3D = 2;
	public const int BOSS_PATTERN_STAY = 0;
	public const int BOSS_PATTERN_VULCAN = 99;
	public const int BOSS_PATTERN_RAILGUN = 1;
	public const int BOSS_PATTERN_TACKLE = -2;
	public const int BOSS_PATTERN_ENEMY_CREATE = 2;
	public const int BOSS_PATTERN_NULL = -1;
 
    public int bossHp;
    public int bossHate;//+10で2Dを狙う -10で3Dを狙う
	public int bossAttackTarget{ set; get;}

	AllUI allUi;
	void Awake(){
		bossHp = 2000;
		bossAttackTarget = TARGET2D;
		allUi = GameObject.FindWithTag ("UI").GetComponent<AllUI> ();
	}
	/// <summary>
	/// ダメージ処理
	/// </summary>
	/// <param name="bullet">弾の種類</param>
	/// <param name="player">攻撃しているプレイヤー</param>
    
	public void BossDamage(string bullet,string player){

		switch(bullet){
		case "NormalBullet":
            bossHp -= 1;
			EffectFactory.Instance.Create("hit",transform.position + new Vector3(Random.Range(-30,30),Random.Range(-30,30),Random.Range(-30,30)),
			                              transform.rotation);

			allUi.UiUpdate("ScoreUp",100);
			allUi.UiUpdate("DeathBlowGaugeUp",0);
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

        if (bossHp == 1000)
            StartCoroutine(SmokeEffect());

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

    IEnumerator SmokeEffect()
    {
        while (bossHp > 0)
        {
            EffectFactory.Instance.Create("smoke", transform.position + new Vector3(Random.Range(-30, 30), Random.Range(-30, 30), Random.Range(-30, 30)),
                                              transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void OnDestroy()
    {
        OnlineLevel.Instance.ChangeNextState();
    }
}