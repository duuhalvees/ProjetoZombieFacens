using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public Material[] material;
    public GameObject mira;
    ArrayList list = new ArrayList();
    GameObject bullet;
    GameObject prefab;
    public AudioSource shotSound;
    public AudioClip shot;

    public Camera myCam;
    RaycastHit hit;
    int num;

    void Start () {
    }
	
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Alpha1)) {
            num = 0;
            changeWeppon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)){
            num = 1;
            changeWeppon();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)){
            num = 2;
            changeWeppon();
        }
        if (Input.GetMouseButtonDown(0)) {
            fire(num+1);
            shotSound.PlayOneShot(shot, 0.7f);
            AudioManager.instance.playDelayedSound("bs04");
        }
        Debug.DrawRay(myCam.transform.position, myCam.transform.forward * 200, Color.blue);
        
    }
    void changeWeppon() {
        Transform weppon = gameObject.transform.GetChild(0).GetChild(0);
        weppon.GetComponent<Renderer>().material = material[num];
    }
    private void fire(int num){

        GameObject obj = new GameObject();
        obj.AddComponent<LineShoot>();
        obj.GetComponent<LineShoot>().CreateTrailLine(obj);


        if (Physics.Raycast(myCam.transform.position, myCam.transform.forward, out hit)) {
            ZombieIA take = hit.transform.GetComponent<ZombieIA>();
            if (take!= null){
                take.TakeDamage(num);
            }
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Vector3 olo = myCam.transform.position;
        //Gizmos.DrawLine(olo, myCam.transform.forward);
    }
}
