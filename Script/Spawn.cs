using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {

    public GameObject prefab;
    public GameObject zombie;
    public float raio = 10;


    public LayerMask mask = -1;
    float radius = 2.5f;
    Vector3 altura;

    void Start () {
	}
	
	void Update () {

	}

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Player") {
            for(int i = 0; i < 2; i++) {
                float x = Random.RandomRange(1, raio);
                float z = Random.RandomRange(1, raio);
                Vector3 randomPos = new Vector3(x,transform.position.y + 2, z);
                RaycastHit hit;
                Ray ray = new Ray(randomPos + Vector3.up * 100, Vector3.down);

                if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask)){
                    if (hit.collider != null){
                        altura = new Vector3(x, hit.point.y - radius, z);
                    }
                }


                zombie = Instantiate(prefab, transform.parent);
                zombie.transform.parent = transform;
                zombie.transform.localPosition = altura;
            }
        }
    }
    void OnDrawGizmos(){
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raio);
    }
}
