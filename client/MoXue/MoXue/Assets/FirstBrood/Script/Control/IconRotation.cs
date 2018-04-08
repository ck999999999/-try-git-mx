using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class IconRotation : MonoBehaviour {

    //public float rotationSpeed = 300.0f;
    //public bool isClock = false;
    //public bool isRotation = false;
    //float rotationNow = 0.0f;
    public Animator animatorRotation;
    // Use this for initialization
    public void StartRotation () {
        //Debug.Log("~~~~~~~~~~~~~~~~~~~~~~~~~~~StartRotation~~~~~~~~~~~~~~~~~~~~~");
        //isRotation = true;
        //isClock = false;
        animatorRotation.SetTrigger("RunOnce");
    }
	
	// Update is called once per frame
	void Update () {
        //if (isRotation)
        //{
        //    if (rotationNow > 180) isClock = false;
        //    if(isClock)
        //        rotationNow += Time.deltaTime * rotationSpeed;
        //    else
        //        rotationNow -= Time.deltaTime * rotationSpeed;

            
        //    if (rotationNow < 0)
        //    {
        //        rotationNow = 0;
        //        gameObject.transform.rotation = new Quaternion(0, 0, rotationNow, 0);
        //        isRotation = false;
        //        isClock = true;
        //    }
        //    else
        //        gameObject.transform.rotation = new Quaternion(0, 0, rotationNow, 0);
        //}
	}

}
