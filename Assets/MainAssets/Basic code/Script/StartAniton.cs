using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAniton : MonoBehaviour {

	public Animation Animation;
	public string AniName;

	public void OnTriggerEnter (Collider other){
		if (other.tag == "line"){
			Animation.Play (AniName);
		}
	}
}
