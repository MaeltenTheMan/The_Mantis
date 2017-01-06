using UnityEngine;
using System.Collections;
using Spine.Unity;

public class MantisAnimations : MonoBehaviour {

	[SpineAnimation]
	public string jumpAni;
	[SpineAnimation]
	public string walkAni;
	[SpineAnimation]
	public string slideAni;

	SkeletonAnimation skeletonAnimation;

    public GameObject playerScript;

	// Use this for initialization
	void Start () {

		skeletonAnimation = GetComponent<SkeletonAnimation> ();

		//skeletonAnimation.state.Complete += delegate {
		//	skeletonAnimation.skeleton.SetToSetupPose ();
		//}; 


	}

	
	// Update is called once per frame
	void Update () {

	

		if (Input.GetButtonDown ("Jump")) {



			skeletonAnimation.state.SetAnimation (0, jumpAni, false);
			skeletonAnimation.state.AddAnimation (0, walkAni, true, 0f);

		} else if (Input.GetKeyDown ("s") && playerScript.GetComponent<player>().teleport == false) { //der zusatz hinter dem && macht, dass beim teleport die ducken animation nicht gestartet wird

			skeletonAnimation.state.SetAnimation (0, slideAni, false);
			skeletonAnimation.state.AddAnimation (0, walkAni, true, 0f);
            gameObject.GetComponent<BoxCollider2D>().enabled = false; //deaktiviert den gesamten Collider
            StartCoroutine(ducken()); //ruft die timerfunktion auf, die das ducken beendet
           
        }



	}
    //dieser Timer setzt nach einer Sekunde den collider wieder aktiv
    IEnumerator ducken()
    {
            yield return new WaitForSeconds(1);
            gameObject.GetComponent<BoxCollider2D>().enabled = true;

    }
}
