using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {
    int attackPattern;//攻撃パターン
    Transform targetPlayer2D,targetPlayer3D;
	// Use this for initialization
	int moveTime;
	int shotTime;
	[SerializeField]
	GameObject bulletPrefab;
    [SerializeField]
    GameObject bulletHomingPrefab;

	bool patternLoop;

    Vector3 targetPlayerVec2D, targetPlayerVec3D;
	GameObject targetPlayerObject;
    Animator anim;

    GameObject railgunEffect;
    int railgunRand;
	void Awake () {
        targetPlayer2D = GameObject.FindWithTag ("Player2D").transform;
		targetPlayer3D = GameObject.FindWithTag ("Player3D").transform;
        attackPattern = 1;
        moveTime = 0;
		shotTime = 0;
		patternLoop = true;
        anim = GetComponent<Animator>();
        railgunEffect = GameObject.Find("Railgun");
        railgunEffect.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
		if(patternLoop == true){
            switch (attackPattern)
            {
                case 1:
                    StartCoroutine("EnemyCreate");
                    break;
                case 2:
                    StartCoroutine("Shot");
                    break;
                case 3:
                    StartCoroutine("Railgun");
                    break;
                default:
                    Debug.LogError("Error");
                    break;
            }
            
		}

		
	}

	IEnumerator Shot(){
        Debug.Log("Shot");
		patternLoop = false;
        //EffectFactory.Instance.Create("Concentration", transform.position, transform.rotation);
		while (moveTime < 300) {
			moveTime++;
			if (moveTime < 150){
				transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (targetPlayer2D.position - transform.position), 0.05f);
			}
			yield return null;
		}
		moveTime = 0;
        while (shotTime < 300)
        {
            shotTime++;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            if ((shotTime % 60) == 0)
            {
                targetPlayerVec2D = targetPlayer2D.transform.position;
                targetPlayerObject = Instantiate(bulletHomingPrefab, transform.position, transform.rotation) as GameObject;
                targetPlayerObject.GetComponent<BossBullet>().TargetBullet(targetPlayerVec2D);
            }
            else
            {
                targetPlayerObject = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
                targetPlayerObject.GetComponent<BossBullet>().RandomBullet();
            }
            yield return null;
        }
        shotTime = 0;
        attackPattern = 3;
        patternLoop = true;
	}

    IEnumerator EnemyCreate()
    {
        Debug.Log("EnemyCreate");
        patternLoop = false;
        //EffectFactory.Instance.Create("Concentration", transform.position, transform.rotation);
        while (moveTime < 300)
        {
            moveTime++;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0,0,0) - transform.position), 0.05f);
            yield return null;
        }
        moveTime = 0;
        while (shotTime < 300)
        {
            shotTime++;
            Instantiate(bulletPrefab, transform.position, transform.rotation);
            if ((shotTime % 60) == 0)
            {
                targetPlayerVec3D = targetPlayer2D.transform.position;
                targetPlayerObject = Instantiate(bulletHomingPrefab, transform.position, transform.rotation) as GameObject;
                targetPlayerObject.GetComponent<BossBullet>().TargetBullet(targetPlayerVec3D);
            }
            else
            {
                targetPlayerObject = Instantiate(bulletPrefab, transform.position, transform.rotation) as GameObject;
                targetPlayerObject.GetComponent<BossBullet>().RandomBullet();
            }
            yield return null;
        }
        shotTime = 0;
        attackPattern = 2;
        patternLoop = true;
    }

    IEnumerator Railgun()
    {
        Debug.Log("RAILGUN");
        railgunRand = Random.Range(1,3);
        patternLoop = false;
        //EffectFactory.Instance.Create("Concentration", transform.position, transform.rotation);
        while (moveTime < 500)
        {
            moveTime++;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0) - transform.position), 0.05f);
            yield return null;
        }
        moveTime = 0;

        anim.SetInteger("Railgun", railgunRand);
        shotTime = 0;
        attackPattern = 1;
    }

    public void RailgunShot()
    {
        railgunEffect.SetActive(true);
        Debug.Log("RAILGUN SHOT!!");
        SoundPlayer.Instance.PlaySoundEffect("Railgun", 1f);
    }
    public void RailgunDelete()
    {
        railgunEffect.SetActive(false);
        Debug.Log("RAILGUN SHOT END!!");
    }
    public void AnimationEnd()
    {
        Debug.Log("END!!");
        patternLoop = true;
        anim.SetInteger("Railgun", 0);
    }
}
