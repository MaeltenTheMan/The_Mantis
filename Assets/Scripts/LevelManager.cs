using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

    public GameObject prefab;
    public GameObject prefabWarri;
    public GameObject prefabJumper;
    public GameObject suicide;
    public GameObject lifeAnt;
    private int counter = 0;
    public GameObject playerScript;

    public int anzAnts;
    public float createNewAnt;
    public float createNewLifeAnt;

    public bool coroutineMid; //dieser Bool ist wichtig, weil er dafür sorgt, dass die updatemethode nicht bei jedem frame die neue timer coroutine startet
    public bool coroutineTop;
    public GameObject text;

    // Use this for initialization
    void Start()
    {
        coroutineMid = true;
        coroutineTop = false;
        InstantiateLevel();
        StartCoroutine(CreateMidEnemys());
        StartCoroutine(AmeisenSpawn());
        StartCoroutine(LifeAmeisenSpawn());
        createWarriTeleortUp();
       

    }

    // Update is called once per frame
    void Update()
    {
        if (coroutineMid == false && playerScript.GetComponent<player>().imMid == true)
        {
            coroutineMid = true;
            coroutineTop = false;
            StartCoroutine(CreateMidEnemys());
        }
        else if (coroutineTop == false && playerScript.GetComponent<player>().imTop == true)
        {
            coroutineMid = false;
            coroutineTop = true;
            StartCoroutine(CreateTopEnemys());
            StartCoroutine(CreateTopEnemys2());
            StartCoroutine(CreateTopEnemys3());
        }

    }


    //diese Methode erstellt ixants wenn das nötige event triggert 
    void createAnts(GameObject objectHere)
    {
        for (int i = 0; i < anzAnts; i++)
        {
            createAntsTop(objectHere);
            createAntsMid(objectHere);
            createAntsBot(objectHere);

        }
    }

    //hier baue ich die Spawnpunkte der Ameisen für alle drei Ebenen
    void createAntsTop(GameObject objectHere)
    {
        int randi = Random.Range(1, 8);
           if(randi == 1)
           {
            Instantiate(objectHere, new Vector3(Random.Range(-22f, 3.1f), 43.62f, 0), Quaternion.identity);
            }
           else if(randi == 2 || randi == 5)
           {
            Instantiate(objectHere, new Vector3(Random.Range(-65.6f ,- 38.2f), 43.62f, 0), Quaternion.identity);
           }
           else if(randi == 3 || randi == 6)
           {
            Instantiate(objectHere, new Vector3(Random.Range(-82f, -99), 43.62f, 0), Quaternion.identity);
           }
           else if (randi == 4 || randi == 7)
        {
            Instantiate(objectHere, new Vector3(Random.Range(13.7f, 110.7f), 43.62f, 0), Quaternion.identity);
        }
    }

    void createAntsMid(GameObject objectHere)
    {
        int randipopandi = Random.Range(1, 6);
        if (randipopandi == 1 || randipopandi ==5)
        {
            Instantiate(objectHere, new Vector3(Random.Range(-94.5f, 5.4f), 2.66f, 0), Quaternion.identity);
        }
        else if (randipopandi == 2)
        {
            Instantiate(objectHere, new Vector3(Random.Range(19.8f, 67), 2.66f, 0), Quaternion.identity);
        }
        else if (randipopandi == 3 || randipopandi == 4)
        {
            Instantiate(objectHere, new Vector3(Random.Range(85.9f,110.7f), 2.66f, 0), Quaternion.identity);
        }  
    }

    void createAntsBot(GameObject objectHere) { 
        int randilein = Random.Range(1, 6);
           if(randilein == 1)
           {
            //vorm teleport up
            Instantiate(objectHere, new Vector3(Random.Range(-94.5f, -50f), -40.2f, 0), Quaternion.identity);
            }
           else if(randilein == 2)
           {
            Instantiate(objectHere, new Vector3(Random.Range(-35.2f ,- 7.5f), -40.2f, 0), Quaternion.identity);
            }
           else if(randilein == 3)
           {
            Instantiate(objectHere, new Vector3(Random.Range(3.2f, 23f), -40.2f, 0), Quaternion.identity);
           }
           else if (randilein == 4)
            {
            //bei teleport down
            Instantiate(objectHere, new Vector3(Random.Range(38f, 84.1f),-40.2f, 0), Quaternion.identity);
           }
        else if (randilein == 5)
        {
            //bei teleport down
            Instantiate(objectHere, new Vector3(Random.Range(97f, 110.7f), -40.2f, 0), Quaternion.identity);
        }
    }


    //creates Warriors for midlvl (flying or walking)
    void createWarriLeft()
    {
        int randi = Random.Range(1, 3);
        Debug.Log(randi);
        if (randi == 1)
        {

            Instantiate(prefabWarri, new Vector3(-101, 2.7f, -201), Quaternion.identity);
        }
       
        else if (randi == 2)
        {
            Instantiate(prefabJumper, new Vector3(-101, 5.7f, -201), Quaternion.identity);
        }
    }
   void createWarriRight()
    {
        int randi = Random.Range(1, 3);
         if (randi == 1)
        {
            Instantiate(prefabWarri, new Vector3(123.8f, 2.7f, -201), Quaternion.identity);
        }
        else if (randi == 2)
        {
            Instantiate(prefabJumper, new Vector3(123.8f, 5.7f, -201), Quaternion.identity);
        }
    }

    
    public void createWarriTeleortUp()
    {
        int randi = Random.Range(1, 3);
        if (randi == 1)
        {
            Instantiate(prefabWarri, new Vector3(68.5f, 2.7f, -201), Quaternion.identity);
        }
        else if (randi == 2)
        {
            Instantiate(prefabJumper, new Vector3(68.5f, 5.7f, -201), Quaternion.identity);
        }

    }

    public void createWarriTeleortDown()
    {
        int randi = Random.Range(1, 3);
        if (randi == 1)
        {
            Instantiate(prefabWarri, new Vector3(95.5f, 2.7f, -201), Quaternion.identity);
        }
        else if (randi == 2)
        {
            Instantiate(prefabJumper, new Vector3(95.5f, 5.7f, -201), Quaternion.identity);
        }

    }



    public void createSuicide()
    {
        Instantiate(suicide, new Vector3(playerScript.GetComponent<player>().targetto.position.x, 80, -98), Quaternion.identity);

    }
    public void createSuicidePlus()
    {
        Instantiate(suicide, new Vector3(playerScript.GetComponent<player>().targetto.position.x +Random.Range(40,48), 80, -98), Quaternion.identity);
    }
    public void createSuicideMinus()
    {
        Instantiate(suicide, new Vector3(playerScript.GetComponent<player>().targetto.position.x - Random.Range(40, 48), 80, -98), Quaternion.identity);

    }

    //instantiierung der Startanzahl der Ameisen
    void InstantiateLevel()
    {
        createAnts(prefab);//mid
        
    }

    //Hier werden die regelmäßigen Ameisen gespawnt
    IEnumerator AmeisenSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(createNewAnt);
            if (playerScript.GetComponent<player>().imMid)
            {
                createAntsBot(prefab);
                createAntsTop(prefab);
            }
            else if (playerScript.GetComponent<player>().imTop)
            {
                createAntsBot(prefab);
                createAntsMid(prefab);
            }
            else
            {
                createAntsTop(prefab);
                createAntsMid(prefab);
            }
            
        }
    }
    //in die ifabfrage kann man noch pfeile einbauen, wo der Spieler die nächste Life Ameise findet!!
    IEnumerator LifeAmeisenSpawn()
    {

        //Hier bitte noch eine Abfrage, wo sich der player gerade befindet, in diesem level kann kein life 
        while (true)
        {
            yield return new WaitForSeconds(createNewLifeAnt);
            int randi = Random.Range(1, 4);
            if (playerScript.GetComponent<player>().imMid)
            {
                int randi2 = Random.Range(1, 3);
                if (randi2 == 1) {
                    createAntsBot(lifeAnt);
                }
                else if (randi2 == 2)
                {
                    createAntsTop(lifeAnt);
                }
               
               
            }
            else if (playerScript.GetComponent<player>().imTop)
            {
                int randi2 = Random.Range(1, 3);
                if (randi2 == 1)
                {
                    createAntsBot(lifeAnt);
                }
                else if (randi2 == 2)
                {
                    createAntsMid(lifeAnt);
                }
            }
            else
            {
                int randi2 = Random.Range(1, 3);
                if (randi2 == 1)
                {
                    createAntsMid(lifeAnt);
                }
                else if (randi2 == 2)
                {
                    createAntsTop(lifeAnt);
                }
            }

        }
    }


    //diese Methode erstellt einen Timer nach dem die antwarriors erscheinen
    IEnumerator CreateMidEnemys()
    {
        while (playerScript.GetComponent<player>().imMid && coroutineMid == true)
        {
            counter++;
           
            if (counter % 2 == 1)
            {

                yield return new WaitForSeconds(Random.Range(0.5f, 2));
                createWarriRight();
              
            }
            else if (counter % 2 == 0)
            {

                yield return new WaitForSeconds(Random.Range(0.5f, 2));
                createWarriLeft();
               
            }
        }
    }

    IEnumerator CreateTopEnemys()
    {
        while (playerScript.GetComponent<player>().imTop && coroutineTop == true)
        {
            if (playerScript.GetComponent<player>().runsRight)
            {
                yield return new WaitForSeconds(Random.Range(1.0f, 2.10f));
                {

                    createSuicidePlus();

                    yield return new WaitForSeconds(0.1f);
                    createSuicidePlus();


                    yield return new WaitForSeconds(0.1f);
                    createSuicidePlus();

                }
            }
           else if (playerScript.GetComponent<player>().runsRight== false)
            {
                yield return new WaitForSeconds(Random.Range(1.0f, 2.10f));
                {
                    yield return new WaitForSeconds(0.1f);
                    createSuicideMinus();

                    yield return new WaitForSeconds(0.1f);
                    createSuicideMinus();


                    yield return new WaitForSeconds(0.1f);
                    createSuicideMinus();

                }
            }
        }

    }
    IEnumerator CreateTopEnemys2()
    {
        while (playerScript.GetComponent<player>().imTop && coroutineTop == true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 2f));
            createSuicidePlus();
            createSuicide();

        }
    }
    IEnumerator CreateTopEnemys3()
    {
        while (playerScript.GetComponent<player>().imTop && coroutineTop == true)
        {
            yield return new WaitForSeconds(Random.Range(1.0f, 1.5f));
            createSuicideMinus();
            createSuicide();


        }
    }
}

