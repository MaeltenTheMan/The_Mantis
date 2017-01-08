using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class player : MonoBehaviour {

    public Renderer rend;
    public GameObject Player;
    public GameObject lvlManager;
    public Transform targetto;

    public Camera myCam;

    public int killCounter;

    public bool teleport = false;
    public bool runsRight = true;
    public bool grounded = false;
    public float jumpForce = 2000;
    public float speed = 0.35f;
    public bool triggerActive = false;
    public bool triggerActive2 = false;
    public bool triggerActive3 = false;
    public bool triggerActive4 = false;
    public bool mantisIsDead = false;
    public int fullHealth;
    public int currentHealth;

    public bool imTop =false;
    public bool imMid= true;

    //Hud Variablen
    public Slider sliderHealth;
    public Text gameOverScreen;

    public GameObject ground;

    public int lives = 2;


    void Awake()
    {
      imMid = true;
       
    }

    void Start()
    {
        //Hud Initialisierung
        sliderHealth.maxValue = fullHealth;
        sliderHealth.value = fullHealth;
    }

    // Update is called once per frame
    void Update()
    {   if (mantisIsDead == false)
        {
            runnerMovement();
            runnerMovementChecker();
        }
        else if (mantisIsDead == true)
        {   
            gameObject.transform.Translate(new Vector2(0, -1f));
        }
         
    }
		
    //die bewegung links und rechts
    void runnerMovementChecker()
    {
        if (runsRight&&teleport == false)
            {
                rend.transform.Translate(Vector2.right * Time.deltaTime * speed);
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
       else if (runsRight==false && teleport==false)
            {
               
                rend.transform.Translate(Vector2.right * Time.deltaTime * speed);
                transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

            else if (teleport == true)
        {
            rend.transform.Translate(Vector2.right * Time.deltaTime * 0);
            
        }
       
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.name == "RightWall")
        {
            runsRight = false;

        }
        else if (coll.gameObject.name == "LeftWall")
        {
            runsRight = true;

        }
        else if (coll.gameObject.name == "Plant")
        {
            
            lives = 0;
            mantisDeath();
        }

        else if(coll.gameObject.name == "Antwarrior(Clone)")
        {
           
            mantisDeath();
        }
        else if (coll.gameObject.name == "Ant(Clone)")
        {
            killCounter++;
        }

        else if(coll.gameObject.name == "Antjumper(Clone)")
        {
            
            mantisDeath();
        }
        else if(coll.gameObject.name == "LifeAnt(Clone)")
        {
            if(lives ==3)
            {
                killCounter = killCounter + 50;
            }
            else if (lives < 3)
            {
                lives++;
                sliderHealth.value = lives;
                killCounter = killCounter + 10;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Uparrow")
        {
            triggerActive = true;
          
        }

       else if(col.name == "Downarrow")
        {
            triggerActive2 = true;
        }

        else if ( col.name == "TriggerLadder")
        {
            ground.GetComponent<Collider2D>().enabled = false;
            
        }

        else if (col.name == "UpArrowBot")
        {
            triggerActive4 = true;
        }
        else if (col.name == "DownArrowBot")
        {
            triggerActive3 = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.name == "Uparrow")
        {
         triggerActive = false;
        }
        else if (col.name == "Downarrow")
        {
            triggerActive2 = false;
        }

        else if(col.name == "DownArrowBot")
        {
            triggerActive3 = false;
        }
        else if (col.name == "UpArrowBot")
        {
            triggerActive4 = false;
        }
        else if(col.name == "TriggerDeath")
        {
            lives = 0;
            mantisDeath();
        }

    }


    void runnerMovement()
    {   //jump
        if (Input.GetButtonDown("Jump") && grounded == true)
        {
            Player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
        }

        //teleport in Obere Ebene
        else if (triggerActive && (Input.GetKey("w")))
        {
            StartCoroutine(changeSmoothing());
            gameObject.transform.Translate(new Vector2(0, 43.5f));
            triggerActive = false;
            imMid = false;
            imTop = true;

                   }
        //teleport in Mittlere Ebene
        else if (triggerActive2 && (Input.GetKey("s")))
        {
            StartCoroutine(changeSmoothing());
            gameObject.transform.Translate(new Vector2(0, -42.5f));
            triggerActive2 = false;
            imMid = true;
            imTop = false;
            lvlManager.GetComponent<LevelManager>().createWarriTeleortDown();
            
            


        }
        //teleport in untere ebene
        else if (triggerActive3 && (Input.GetKey("s")))
        {
            StartCoroutine(changeSmoothing());
            gameObject.transform.Translate(new Vector2(0, -42.5f));
            triggerActive3 = false;
            imMid = false;
            imTop = false;
            lvlManager.GetComponent<LevelManager>().coroutineMid = false;
            runsRight = false;

        } //teleport wieder in mittlere Ebene
        else if (triggerActive4 && (Input.GetKey("w")))
        {
            StartCoroutine(changeSmoothing());
            gameObject.transform.Translate(new Vector2(0, 43.5f));
            triggerActive4 = false;
            imMid = true;
            imTop = false;
            runsRight = true;
            lvlManager.GetComponent<LevelManager>().createWarriTeleortUp();
        }
        
        else if (Input.GetKey("a"))
        {
            runsRight = false;
        }
        else if (Input.GetKey("d"))
        {
            runsRight = true;
        }

    }

    //Lässt das spiel einen moment warten, wenn Mantis gestorben ist
    IEnumerator TimerAfterDeath()
    {
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(1);
    }
    public void doSlider()
    {
        sliderHealth.value = lives;
    }

    //regelt was passiert, wenn Mantis stirbt
    public void mantisDeath()
    {
        lives = lives - 1;
        doSlider();
        if (lives < 1)
        {
            myCam.GetComponent<CamFollow>().isFollowing = false;
            mantisIsDead = true;
            StartCoroutine(TimerAfterDeath());
            Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
            gameOverAnimator.SetTrigger("gameOver");
            
           
        }
        //camshaker 
        myCam.GetComponent<CamFollow>().ShakeCamera(0.05f, 0.4f);
    }


    //hier wird das smooting für einen moment runtergestellt um einen schöneren Teleporteffekt zu erstellen
    IEnumerator changeSmoothing()
    {
        teleport = true;
        

        for (int i = 0; i<14; i++)
        {
          
                yield return new WaitForSeconds(0.025f);
                myCam.orthographicSize = myCam.orthographicSize -1;
            
            
        }
        myCam.GetComponent<CamFollow>().transform.position = Vector3.Lerp(myCam.GetComponent<CamFollow>().transform.position, myCam.GetComponent<CamFollow>().target.position, 0.03f + Time.deltaTime);
       
            teleport = false;
        StartCoroutine(changeSmoothingBack());

    }


    IEnumerator changeSmoothingBack()
    {
        for (int i = 0; i <14; i++)
        {



            yield return new WaitForSeconds(0.025f);
            myCam.orthographicSize = myCam.orthographicSize + 1;

        }

    }
}