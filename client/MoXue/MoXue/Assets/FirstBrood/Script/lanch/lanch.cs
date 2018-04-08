using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lanch : MonoBehaviour {
	// Use this for initialization
	void Start () {
        StartCoroutine(AutoGo());

		#if UNITY_EDITOR 
		#elif (UNITY_IPHONE || UNITY_IOS) 
		IronSource.Agent.init ("6f8940fd");	
		#elif UNITY_ANDROID
		IronSource.Agent.init ("6f32bb75");
		#endif
		IronSource.Agent.validateIntegration();
    }

    // Update is called once per frame
    IEnumerator AutoGo ()
    {
        yield return new WaitForSeconds(2.5f);
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
	}
}
