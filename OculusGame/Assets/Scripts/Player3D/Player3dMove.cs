using UnityEngine;
using System.Collections;

public class Player3dMove: MonoBehaviour {

    PlayerData3D playerData;
    GameObject playerCamera;
    GameObject markerCanvas;
    GameObject lockonCanvas;
    GameObject[] lockedEnemy;
    GameObject lockonCanvasNumber;
    RaycastHit hit;

	void Awake(){
        
        playerData = GetComponent<PlayerData3D>();
        playerData.speed = 3f;
        playerData.lockonNumber = 1;
        playerCamera = GameObject.Find("PlayerCamera") as GameObject;
        lockonCanvas = GameObject.Find("LockonCanvas") as GameObject;
        markerCanvas = GameObject.Find("MarkerCanvas") as GameObject;
        //markerCanvas.SetActive(false);
        GameObject.Find("UpdateManager").GetComponent<UpdateManager>().player3dMove = this.GetComponent<Player3dMove>();
	}
	
	public void Player3DMove(){
        playerData.vectorX = Input.GetAxisRaw("HorizontalP1");
        playerData.vectorY = Input.GetAxisRaw("VerticalP1");
        playerData.movePlayer = new Vector3(playerData.vectorX * playerData.speed, playerData.vectorY * playerData.speed, 0);
        GetComponent<Rigidbody>().velocity = playerData.movePlayer;

        Ray();
        BulletShot();
        LaserShot();
	}

    void BulletShot()
    {

        if (Input.GetButton("MaruP1"))
        {
            playerData.bulletPosition = new Vector3(transform.position.x+0.15f, transform.position.y-0.5f, transform.position.z+0.6f);
            Instantiate(ResourcesManager.Instance.GetResourceScene("Bullet3D"), playerData.bulletPosition, playerData.oculusCamera.transform.rotation);
        }
    }

    void LaserShot()
    {
        if (Input.GetButton("SankakuP1"))
        {
            markerCanvas.SetActive(true);
            playerData.lockonActive = true;
        }

        if(Input.GetButtonUp("SankakuP1")){
            lockedEnemy = GameObject.FindGameObjectsWithTag("Locked");
            foreach(GameObject enemy in lockedEnemy){
                if(enemy.gameObject != null){
                    Destroy(enemy.gameObject);
                }
            }
            markerCanvas.SetActive(false);
            playerData.lockonActive = false;
        }
    }

    void Ray()
    {
        if (Physics.SphereCast(playerCamera.transform.position, 5f, playerCamera.transform.forward, out hit))
        {
            switch (hit.collider.tag)
            {
                case "Enemy3D":
                    if (playerData.lockonActive)
                    {
                        hit.collider.tag = "Locked";
                        Lockon();
                    }
                break;
            }
        }
    }

    void Lockon()
    {
        lockonCanvasNumber = (GameObject)Instantiate(ResourcesManager.Instance.GetResourceScene("LockonCanvas"), hit.point, transform.rotation);
        lockonCanvasNumber.name = "LockonCanvas" + playerData.lockonNumber;
        lockonCanvas = GameObject.Find("LockonCanvas" + playerData.lockonNumber) as GameObject;
        lockonCanvas.transform.parent = hit.transform;
        lockonCanvas.transform.position = hit.point;
        playerData.lockonNumber++;
    }
}