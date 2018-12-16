using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAimAndFire : MonoBehaviour
{
    private GameObject _player;
    public GameObject _bullet;
    public Transform _bulletStartPoint;
    public float _bulletFireRate;
    public float _bulletDistance;
    [SerializeField]
    private float _findDistance;
    private Vector3 _lastTargetPos = Vector3.zero;
    private Quaternion _lookAtRot;
    [SerializeField]
    private int _rotationSpeed;
    private float _timer;
    GameManeger gm;

    void Start()
    {
        gm = FindObjectOfType<GameManeger>();
        gm.EnemySend += Gm_enemySend;

    }

    private void Gm_enemySend(GameObject enemy)
    {
        _player = enemy;
    }


    void Update()
    {
        if (_player != null)
        FindTarget();
    }

    void FindTarget()
    {
        
        float distance = Vector3.Distance(_player.transform.position, transform.position);
        if (distance < _findDistance)
        {
            if (_lastTargetPos != _player.transform.position)
            {
                _lastTargetPos = _player.transform.position;
                _lookAtRot = Quaternion.LookRotation(_lastTargetPos - transform.position);
            }

            if (transform.rotation != _lookAtRot)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, _lookAtRot, Time.deltaTime * _rotationSpeed);
            }
            FireAtTarget();
        }
    }

    void FireAtTarget()
    {
        _timer += Time.deltaTime;
        if (_timer > _bulletFireRate)
        {

            GameObject bullet = (GameObject)Instantiate(_bullet, _bulletStartPoint.position, _bulletStartPoint.rotation);

            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * _bulletDistance;
            Destroy(bullet, 5);
            GetComponent<AudioSource>().Play();

            _timer = 0;
        }
    }
}
