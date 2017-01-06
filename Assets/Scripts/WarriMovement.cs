using UnityEngine;
using System.Collections;

public class WarriMovement : MonoBehaviour {

    public bool runsRight;

    //gibt die geschwindigkeit der krieger an
    public float warriSpeed = 30;
    public Renderer rend;
    public GameObject playerScript;

    void Start()
    {
        if(gameObject.transform.position.x < 0)
        {
            runsRight = true;
        }
        else
        {
            runsRight = false;
        }

    }

    void Update()
    {
       
        WarriMovementChecker();
        //diese ifabfrage ist dafür da, dass wenn man nach kurzer zeit wieder in die mittlere ebene kommt nicht vor dem Teleport von einer einheit erwischt zu werden!
        if(playerScript.GetComponent<player>().imMid == false)
        {
            gameObject.transform.Translate(new Vector2(0, 443.5f));
        }
    }


    //die bewegung links und rechts
    void WarriMovementChecker()
    {
        if (runsRight== true)
        {
            rend.transform.Translate(Vector2.right * Time.deltaTime * warriSpeed);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (runsRight == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            rend.transform.Translate(Vector2.right * Time.deltaTime * warriSpeed);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
    }
}
