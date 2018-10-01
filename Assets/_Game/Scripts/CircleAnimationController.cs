using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleAnimationController : MonoBehaviour {


    public GameObject greenCircle;
    public GameObject blueCircle;
    public GameObject redCircle;
    public GameObject yellowCircle;


    public AnimationCurve curve;

    public float speed = 1.0f;




    // Use this for initialization
    void Start()
    {
        Animation();
       // LeanTween.scale(greenCircle, greenCircle.transform.localScale * 2.0f, 2.0f).setEaseInBounce();

    }

    void Animation() {
        LeanTween.move(greenCircle, blueCircle.transform.position, speed).setEaseInOutCubic();
        LeanTween.move(blueCircle, redCircle.transform.position, speed).setEaseInOutCubic();
        LeanTween.move(redCircle, yellowCircle.transform.position, speed).setEaseInOutCubic();
        LeanTween.move(yellowCircle, greenCircle.transform.position, speed).setEaseInOutCubic()
                 .setOnComplete(Animation);
        
    }

	// Update is called once per frame
	void Update () {
		
	}
}
