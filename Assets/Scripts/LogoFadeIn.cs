using UnityEngine;
using System.Collections;

public class LogoFadeIn : MonoBehaviour {
    public GameObject pixelEffekt;

	// Use this for initialization
	void Start () {
        StartCoroutine(Countdown());
        StartCoroutine(PixelEffekt());
	}
	
    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(5.5f);
        Application.LoadLevel(1);
        
    }

    private IEnumerator PixelEffekt()
    {
        yield return new WaitForSeconds(4.5f);
        Instantiate(pixelEffekt, new Vector3(-0.5f, -1.5f, -1.26f), Quaternion.identity);

    }
}
