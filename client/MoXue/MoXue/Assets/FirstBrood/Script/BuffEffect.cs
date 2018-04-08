using UnityEngine;
using System.Collections;

public class BuffEffect : MonoBehaviour {
	
	public GameObject taget;
	public GameObject colorTaget;
	public Color myColor = new Color();
	
	public int rSpeed = 50;
	
	// Use this for initialization
	void Start () {
		colorTaget.GetComponent<Renderer>().material.SetColor ("_TintColor", myColor);
		taget.GetComponent<Animation>().Play("BuffEffect");
			
	}
	
	// Update is called once per frame
	void Update () {
		if(!taget.GetComponent<Animation>().isPlaying){			
		    taget.transform.Rotate(0, 1*rSpeed*Time.deltaTime, 0);
		}

	}
}
