using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour {

    public GameObject playerScript;


    public Text scoreText;
     
	// Use this for initialization
	void Start () {
	   
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnGUI()
    {
        
            int w = Screen.width, h = Screen.height;

            GUIStyle style = new GUIStyle();

            Rect rect = new Rect(0, 0, w, h * 2 / 100);
            style.alignment = TextAnchor.UpperRight;
            style.fontSize = h * 4 / 100;
            style.normal.textColor = new Color(255.0f, 0.0f, 0.5f, 1.0f);
        string text = "Score: " + playerScript.GetComponent<player>().killCounter;
            GUI.Label(rect, text, style);
        }
    
}
