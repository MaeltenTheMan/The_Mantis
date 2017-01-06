using UnityEngine;
using System.Collections;

public class Ant : MonoBehaviour {

    public GameObject playerScript;
    public GameObject me;
    public Camera myCam;
    public GameObject particleEffekt;
	// Use this for initialization
	
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hallos");
     
        Instantiate(particleEffekt, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.3f), Quaternion.identity);//level1 (start)
        Destroy(gameObject);
        //myCam.GetComponent<CamFollow>().ShakeCamera(0.05f, 0.1f);

    }
	
	
}
