using UnityEngine;
using System.Collections;

public class GroundCheck : MonoBehaviour {

    private player playerScript;


	void Start () {
        playerScript = gameObject.GetComponentInParent<player>();
        Debug.Log("hier spielt die musik");
	}
	
	void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Ground")
        {
            playerScript.grounded = true;
            Debug.Log("trigger");
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.name == "Ground")
        {
            playerScript.grounded = true;
          
        }
       
    }

    void OnTriggerExit2D(Collider2D col)
    {
        playerScript.grounded = false;
    }
}
