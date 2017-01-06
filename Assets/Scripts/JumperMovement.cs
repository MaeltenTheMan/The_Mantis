using UnityEngine;
using System.Collections;

public class JumperMovement : MonoBehaviour {

    public bool runsRight;

    //gibt die geschwindigkeit der krieger an
    public float jumperSpeed = 30;
    public Renderer rend;
    public int counter = 0;
    public GameObject playerScript;

    void Start()
    {
        if (gameObject.transform.position.x < 0)
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

        JumperMovementChecker();
        if (playerScript.GetComponent<player>().imMid == false)
        {
            gameObject.transform.Translate(new Vector2(0, 443.5f));
        }

    }


    //die bewegung links und rechts
    //hier könnte man noch ein leites auf- und abbewegen einbauen
    void JumperMovementChecker()
    {
        counter++;
        if (counter < 5 )//hier käme ein hochbewegen
        {
            if (runsRight == true)
            {
                rend.transform.Translate(Vector2.right * Time.deltaTime * jumperSpeed);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            else if (runsRight == false)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                rend.transform.Translate(Vector2.right * Time.deltaTime * jumperSpeed);

            }
        }
        else if (counter >= 5)//hier käme ein runterbewegen
        {
            if (runsRight == true)
            {
                rend.transform.Translate(Vector2.right * Time.deltaTime * jumperSpeed);
                transform.localRotation = Quaternion.Euler(0, 0, 0);

            }
            else if (runsRight == false)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
                rend.transform.Translate(Vector2.right * Time.deltaTime * jumperSpeed);

            }
        }
        else if (counter == 10)
        {
            counter = 0;
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