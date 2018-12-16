using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorLerp : MonoBehaviour {

    private Image image;
    float t = 0.0f;

    // Use this for initialization
    void Start () {
       image = GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {

        image.color = new Color(image.color.r, image.color.g, image.color.b, Mathf.Lerp(0,1,t));
        t += 0.5f * Time.deltaTime;
    }
}
