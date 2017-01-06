using UnityEngine;
using System.Collections;

public class Suicide : MonoBehaviour {
    public Renderer rend;
    private float speed = 0.35f;
    public Camera myCam;

    public GameObject Explosion;

    public GameObject playerScript;

    public bool meRunsRight= false;
    
	// Use this for initialization
	void Start () {
        if (playerScript.GetComponent<player>().runsRight)
        {
            meRunsRight = true;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (playerScript.GetComponent<player>().imTop == false)
        {
            gameObject.transform.Translate(new Vector2(0, -443.5f));
        }
        else
        {
            if (meRunsRight)
            {
                rend.transform.Translate(Vector2.right * Time.deltaTime * speed);
            }
            else if (meRunsRight == false)
            {
                rend.transform.Translate(Vector2.left * Time.deltaTime * speed);
            }
        }
    }

void OnCollisionEnter2D(Collision2D col)
    {
        Instantiate(Explosion, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.3f), Quaternion.identity);//level1 (start)

        if (col.gameObject.name == "Player")
        {
            playerScript.GetComponent<player>().mantisDeath();
            
        }

         Destroy(gameObject);
      //   myCam.GetComponent<CamFollow>().ShakeCamera(0.05f, 0.08f);
    }

}

