using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplode : MonoBehaviour {
    private GameObject _palyer;

    private void Start()
    {
        GameManeger gm = FindObjectOfType<GameManeger>();
        gm.EnemySend += Gm_enemySend;
    }

    private void Gm_enemySend(GameObject enemy)
    {
        _palyer = enemy;
    }

    void OnCollisionEnter(Collision col)
    {

        Debug.Log(col.gameObject.name);
        GetComponent<ParticleSystem>().Play();
        GetComponent<MeshRenderer>().enabled = false;
        Destroy(gameObject,1f);

        if (col.gameObject.Equals(_palyer))
            Debug.Log("Trapija liķenei");

    }

}
