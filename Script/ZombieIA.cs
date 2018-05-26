using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieIA : MonoBehaviour {

    public int lifeEnemy = 6;
    private GameObject target;

    public float lookRaio = 10f;

    public float massa = 1;
    public float speed = 2; 
    
    private Vector3 posicao;
    private Vector3 targetPositon;
    private Vector3 velocityDesejada;
    private Vector3 direcao;
    private Vector3 velocidade;

    void Start(){
        target = PlayerManager.instance.Player;
        
    }
    void Update () {
        look();
        seek();
    }
    void seek() {
        posicao = transform.position;
        targetPositon = target.transform.position;

        velocityDesejada = (targetPositon - posicao).normalized * speed;

        direcao = velocityDesejada - velocidade;
        direcao = direcao / massa;

        velocidade += direcao;

        transform.position += velocidade * Time.deltaTime;
    }
    void look() {
        transform.LookAt(target.transform);
    }

    public void TakeDamage(int damage){
        if (lifeEnemy <= 0) {
            Destroy(gameObject);
        }
        lifeEnemy -= damage;
        Debug.Log("lifeEnemy: " + lifeEnemy);
    }
}
