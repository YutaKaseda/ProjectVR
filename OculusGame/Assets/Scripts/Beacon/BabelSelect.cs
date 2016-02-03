using UnityEngine;
using System.Collections;

[SerializeField]
public class BabelSelect : MonoBehaviour
{

    /////////パーティクル説明//////////////////////
    //アイドルビーコン.IdolBeacon   (青 色)      //
    //セレクトビーコン.SelectBeacon (オレンジ)   //
    //ユーズビーコン  .UseBeacon    (紫 色)     //
    /////////////////////////////////////////////
    [SerializeField]
    RaycastHit hit;
    [SerializeField]
    GameObject idolBeacon;
    [SerializeField]
    GameObject newIdolBeaconPrefab;
    [SerializeField]
    GameObject newSelectBeaconPrefab;
    [SerializeField]
    GameObject newUseBeaconPrefab;
    [SerializeField]
    GameObject player3D;
    [SerializeField]
    Vector3 selectBeaconPosition;
    [SerializeField]
    string selectBeaconName;
    [SerializeField]
    bool selectViewflg;
    [SerializeField]
    bool warpflg;
    [SerializeField]
    bool rayOutflg;
    [SerializeField]
    float waitTimer;        // Warpまでの時間
    float timer;            // 押している時間
    Transform beasBeaconPosition;


    // プレハブ用
    [SerializeField]
    GameObject idolBeaconPrefab; //青色のビーコンプレハブ
    [SerializeField]
    GameObject selectBeaconPrefab; //オレンジのビーコンプレハブ
    [SerializeField]
    GameObject useBeaconPrefab; //紫のビーコンプレハブ

    [SerializeField]
    Animation anim;

    [SerializeField]
    GameObject camera; //時機のカメラを入れる

    Vector3 tempHitBeaconPosition;
    string tempHitBeaconName;
    void Update()
    {
        Raycast();
        BaseBeaconWarp();
        
    }

    void Awake()
    {
        timer = 0;
        selectViewflg = true;
        warpflg = false;
        rayOutflg = false;
        //player3D = GameObject.Find("Player3D");
        //camera = GameObject.Find("PlayerCamera");
        anim = GameObject.Find("Fadeio").GetComponent<Animation>();
        beasBeaconPosition = GameObject.FindGameObjectWithTag("BeasBeacon").GetComponent<Transform>();
    }


    public void Raycast()
    {

        rayOutflg = false;

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit))
        {

            Debug.Log("RAYCAST");

            if (hit.collider.tag == "Beacon")
            {
                Debug.Log("OnSpace : ");
                rayOutflg = true;
                //セレクトビーコン発生処理
                SelectView();

                if (Input.GetButtonDown("BatuP1"))
                {

                    tempHitBeaconPosition = hit.collider.transform.position;
                    tempHitBeaconName = hit.collider.name;
                    
                    SoundPlayer.Instance.PlaySoundEffect("warp", 1.0f);
                    anim.Play("fade");
                }
            }
        }

        //レイが外れたときにセレクトビーコンを見せる
        if (!rayOutflg)
        {

            if (selectBeaconPrefab != null)
            {

                Destroy(GameObject.Find("SelectBeacon"));
                if (idolBeacon) idolBeacon.SetActive(true);
            }
        }

    }

    //セレクトビーコン発生処理
    public void SelectView()
    {

        idolBeacon = hit.transform.FindChild("IdolBeacon").gameObject;

        if (newSelectBeaconPrefab == null) selectViewflg = true;

        if (newSelectBeaconPrefab) selectViewflg = false;

        if (selectViewflg == true)
        {

            newSelectBeaconPrefab = (GameObject)Instantiate(selectBeaconPrefab, hit.transform.position, hit.transform.rotation);
            newSelectBeaconPrefab.name = selectBeaconPrefab.name;

            idolBeacon.SetActive(false);

            selectViewflg = false;
        }

    }

    //ワープ処理
    public void Warp()
    {

        //前回のユーズビーコンが存在していたら消す
        OldUseBeaconDestroy();
        Debug.Log("Warp関数 : " + tempHitBeaconPosition);
        //Debug.Log("ヒットコリダー : " + hit.collider.transform.position);
        //ワープ処理
        //player3D.transform.position = hit.collider.transform.position;
        player3D.transform.position = tempHitBeaconPosition;

        //ワープした先のビーコンにユーズビーコンを発生させる
        UseBeaconView();

        //selectBeaconName = hit.collider.name;
        selectBeaconName = tempHitBeaconName;
        //selectBeaconPosition = hit.collider.gameObject.transform.position;
        selectBeaconPosition = tempHitBeaconPosition;
        GameObject.Find(selectBeaconName).layer = LayerMask.NameToLayer("Ignore Raycast");


    }


    //前回のユーズビーコンが存在していたら消す
    public void OldUseBeaconDestroy()
    {

        if (useBeaconPrefab)
        {
            Destroy(GameObject.Find("UseBeacon"));
            //GameObject.Find(selectBeaconName).layer = LayerMask.NameToLayer("Default");
        }

        if (warpflg == true)
        {
            GameObject.Find(selectBeaconName).layer = LayerMask.NameToLayer("Default");

            newIdolBeaconPrefab = (GameObject)Instantiate(idolBeaconPrefab, selectBeaconPosition, transform.rotation);

            newIdolBeaconPrefab.name = idolBeaconPrefab.name;

            newIdolBeaconPrefab.transform.parent = GameObject.Find(selectBeaconName).transform;

            warpflg = false;
        }
    }

    //ワープした先のビーコンにユーズビーコンを発生させる
    public void UseBeaconView()
    {

        newUseBeaconPrefab = (GameObject)Instantiate(useBeaconPrefab, tempHitBeaconPosition, transform.rotation);

        newUseBeaconPrefab.name = useBeaconPrefab.name;

        Destroy(idolBeacon);

        warpflg = true;
    }

    void BaseBeaconWarp(){
        if (Input.GetButton("BatuP1")){
            timer += Time.deltaTime;
            if (waitTimer < timer){
                OldUseBeaconDestroy();
                this.transform.position = beasBeaconPosition.position;
                timer = 0;
            }
        }
        else if(Input.GetButtonUp("BatuP1")){
            timer =0;
        }


    }


}