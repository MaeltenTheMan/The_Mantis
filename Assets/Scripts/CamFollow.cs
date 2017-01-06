using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour
{

    public float smoothing = 0.08f;

    public Transform target;
    public Camera myCam;
    public GameObject playerScript;

    private Vector3 teleporter = new Vector3(0, 0.5f, 0);

    public float teleportVar = 0.6f;
    public float maxY;

    public float minX = -66;
    public float maxX = 80;

    public float shakeTimer;
    public float shakeAmount;

    public bool isFollowing;

    void Start()
    {
        myCam = GetComponent<Camera>();
        isFollowing = true;

    }

    // Update is called once per frame



    void Update()
    {
        //hier  erstelle ich die lerpmethode, die dafür sorgt, dass die cam dem target"player" folgt
        if (playerScript.GetComponent<player>().teleport == false && isFollowing == true)
        {
            if (target)
            {
                if (playerScript.GetComponent<player>().runsRight)
                {
                    transform.position = Vector3.Lerp(transform.position, target.position, smoothing + Time.deltaTime) + new Vector3(1, teleportVar, -20);
                }
                else if (playerScript.GetComponent<player>().runsRight == false)
                {
                    transform.position = Vector3.Lerp(transform.position, target.position, smoothing + Time.deltaTime) + new Vector3(-1, teleportVar, -20);//1.6

                }
            }

            if (shakeTimer >= 0)
            {
                Vector2 ShakePos = Random.insideUnitCircle;

                transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);

                shakeTimer -= Time.deltaTime;
            }
            if (Input.GetButtonDown("Fire1"))
            {
                ShakeCamera(0.05f, 0.1f);
            }

            //in diesen beiden ifabfragen wird erstellt, dass die Kamera über bestimmte bereiche nicht hinsausgehen kann
            if (transform.position.x < minX)
            {
                transform.position = new Vector3(minX, transform.position.y, transform.position.z);
            }

            if (transform.position.x > maxX)
            {
                transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
            }
        }
    }


    //hier wird der Camshaker (kurzes wackeln des screens) erstellt
    public void ShakeCamera(float shakePwr, float shakeDur)
    {
        shakeAmount = shakePwr;
        shakeTimer = shakeDur;
    }

    }
