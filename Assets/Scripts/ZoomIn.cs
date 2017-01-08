using UnityEngine;
using System.Collections;

public class ZoomIn : MonoBehaviour {

    public Camera myCam;
	// Use this for initialization
	void Start () {
        StartCoroutine(CountdownToZoomIn());
        StartCoroutine(StartGame());
    }

    private IEnumerator CountdownToZoomIn()
    {
        yield return new WaitForSeconds(1f);
           
            StartCoroutine(ZoomIn1());
        Debug.Log("Zoom in wird gestartet");

    }

    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(4.1f);
        Application.LoadLevel(3);
    }

    private IEnumerator ZoomIn1()
    {
        for (int i = 0; i < 39; i++)
        {
            yield return new WaitForSeconds(0.05f);
            {
                
                myCam.orthographicSize = myCam.orthographicSize - 1;
                myCam.transform.position = new Vector3(myCam.transform.position.x-1.53846153f, myCam.transform.position.y-0.25f, -96.6f);
                Debug.Log("Zoom");
            }
        }
    }
}
