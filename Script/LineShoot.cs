using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LineShoot : MonoBehaviour {
    TrailRenderer newTrail;
    Rigidbody rb;
    Transform posPlayer;
    
    
    public void CreateTrailLine(GameObject newObject) {
        newObject = new GameObject();
        rb = newObject.AddComponent<Rigidbody>();
        newTrail = newObject.AddComponent<TrailRenderer>();
    
        print("Instanciadooo");
        //-------------------------
        newTrail.startWidth = 0.05f;
        newTrail.time = 0.05f;
        newTrail.material = Resources.Load("LineMaterial", typeof(Material)) as Material;
    
        //-------------------------
        posPlayer = PlayerManager.instance.cam;
        newObject.transform.position = posPlayer.position;
        rb.useGravity = false;
        rb.AddForce(posPlayer.forward * 60, ForceMode.Impulse);
    }
    

}
