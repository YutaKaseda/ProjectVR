using UnityEngine;
using System.Collections;

public class Player3dMove: MonoBehaviour {

    PlayerData3D playerData;
    RaycastHit hit;
    GameObject playerCamera;
    Marker marker;

	void Awake(){
        playerData = GetComponent<PlayerData3D>();
        playerData.speed = 3f;
        //ResourcesManager.Instance.ResourcesLoadScene("Play");
        //playerData.oculusCamera = GetComponent<Camera>();
        playerCamera = GameObject.Find("PlayerCamera") as GameObject;
        marker = GameObject.Find("PlayerCamera").GetComponent<Marker>();
	}

    /*void Update()
    {
        Player3DMove();
    }*/
	
	public void Player3DMove(){
        playerData.vectorX = Input.GetAxisRaw("HorizontalP1");
        playerData.vectorY = Input.GetAxisRaw("VerticalP1");
        playerData.movePlayer = new Vector3(playerData.vectorX * playerData.speed, playerData.vectorY * playerData.speed, 0);
        GetComponent<Rigidbody>().velocity = playerData.movePlayer;

        BulletShot();
        Ray();
	}

    void BulletShot()
    {

        if (Input.GetButton("MaruP1"))
        {
            playerData.bulletPosition = new Vector3(transform.position.x+0.15f, transform.position.y-0.5f, transform.position.z+0.6f);
            Instantiate(ResourcesManager.Instance.GetResourceScene("Bullet"), playerData.bulletPosition, playerData.oculusCamera.transform.rotation);
        }
    }
    
    void Ray()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            switch (hit.collider.tag)
            {
                case "CockpitGlass":
                    //canvas.transform.position = hit.point;
                    marker.TargetMarker(hit.point);
                    break;
                default:
                    break;
            }
        }
    }
}
