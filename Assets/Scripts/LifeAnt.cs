using UnityEngine;
using System.Collections;

public class LifeAnt : MonoBehaviour { 
    public GameObject playerScript;
    public GameObject me;
    public GameObject particleEffekt;
    public Camera myCam;
    // Use this for initialization

    void Start()
    {
        StartCoroutine(lifeEnds());
      
       
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == ("Player"))
        {

            Instantiate(particleEffekt, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1.3f), Quaternion.identity);//level1 (start)
            Destroy(gameObject);
          
           // playerScript.GetComponent<player>().lives++;
        }
    }

    IEnumerator lifeEnds()
    {
        yield return new WaitForSeconds(10);

            gameObject.transform.Translate(new Vector2(0, 443.5f));
    }
}





