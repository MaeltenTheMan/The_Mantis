using UnityEngine;
using System.Collections;

public class LogoFadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(Countdown());
	}
	
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(6);
        Application.LoadLevel(1);
    }
}
