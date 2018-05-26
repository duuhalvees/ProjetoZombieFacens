using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public GameObject[] weapons;
    public GameObject[] prefab;
    Vector3 prefabAux;
    Transform prefabTransform;

    private void Start(){
        prefabAux = new Vector3(-86f, 0f, -3f);
        prefabTransform.eulerAngles = prefabAux;
        prefabAux = new Vector3(0.44f, 0.42f, 0.42f);
        prefabTransform.localScale = prefabAux;
    }

    private void Update(){
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            changeWeppon(0);
            Destroy(weapons[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            changeWeppon(1);
            Destroy(weapons[0]);
        }
    }
    void changeWeppon(int num) {
        weapons[num] = Instantiate(prefab[num], transform.parent);
        weapons[num].transform.parent = this.transform;
        weapons[num].transform.localPosition = new Vector3(0.32f, 0.15f, 1.189f);
        weapons[num].transform.eulerAngles = prefabTransform.eulerAngles;
        weapons[num].transform.localScale = prefabTransform.localScale;
    }
}
