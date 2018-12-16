using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class AirplainController : MonoBehaviour
{
    [SerializeField]
    float speed = 0.2f;
    [SerializeField]
    float rotSpeedX = 5;
    [SerializeField]
    float rotSpeedY = 5;
    [SerializeField]
    float rotSpeedZ = 5;
    private bool _isDown = false;
    public AudioClip _propeler;
    public AudioClip _explode;
    AudioSource _audio;
    public GameObject _UI;
    public PlayableDirector _timeline;
    public GameObject _turets;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _audio.clip = _propeler;
        _audio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!_isDown)
            AirplainMovment();

    }

    private void AirplainMovment()
    {
        transform.Translate(speed, 0, 0);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.right * rotSpeedX * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(Vector3.left * rotSpeedX * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.forward * rotSpeedZ * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.back * rotSpeedZ * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotSpeedY * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.down * rotSpeedY * Time.deltaTime);
        }

    }

    void OnCollisionEnter(Collision col)
    {

        {


            GetComponent<ParticleSystem>().Play();
            Rigidbody rig = GetComponent<Rigidbody>();
            rig.useGravity = true;
            GetComponentInChildren<Animator>().enabled = false;
            rig.velocity = Vector3.forward;
            _isDown = true;

            _audio.clip = _explode;
            if (!_audio.isPlaying)
            {
                _audio.loop = false;
                _audio.Play();

            }
            StartCoroutine(LoseWon());
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        _timeline.Play();
        other.GetComponent<ParticleSystem>().Play();
        Destroy(_UI);
        _turets.SetActive(false);


    }


    IEnumerator LoseWon()
    {

        yield return new WaitForSeconds(1);
        if (_UI != null)
            _UI.SetActive(_UI);

    }

}
