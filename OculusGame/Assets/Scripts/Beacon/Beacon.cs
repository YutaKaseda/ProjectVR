using UnityEngine;
using System.Collections;

public class Beacon : MonoBehaviour {

    public bool putFlg { get; private set; }
    public bool moveFlg { get; private set; }
	public bool baseBeacon { get; private set; }
    public float time { get; private set; }
    public float interval { get; private set; }
    public float waitTime { get; private set; }

    void Awake()
    {
        putFlg = false;
        time = 0;
        waitTime = 3;
        interval = 10;
        moveFlg = false;
		baseBeacon = false;
    }

    public void BeaconPut()
    {
        if (putFlg == false)
        {
            if (Input.GetButton("BatuP2"))  //ばつが押されている間
            {
                time += Time.deltaTime;
                moveFlg = true;

                if (time >= waitTime)   //時間を超えたとき設置
                {
                    if(baseBeacon == true){
						putFlg = true;
						Instantiate(ResourcesManager.Instance.GetResourceScene("babel"), transform.position, transform.rotation);
					}else{
						Instantiate(ResourcesManager.Instance.GetResourceScene("Beacon"), transform.position, transform.rotation);
						baseBeacon = true;
						time = 0;
					}
					moveFlg = false;
                    time = 0;
                }
            }

            else if (Input.GetButtonUp("BatuP2"))
            {
                time = 0;  //ばつが離れたとき
                moveFlg = false;
            }

        }
        else{

            time += Time.deltaTime;

            if (time >= interval)
            {
                Debug.Log("reload");
                putFlg = false;
                time = 0;
            }
        }
    }
}
