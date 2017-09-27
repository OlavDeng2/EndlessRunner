using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadOnClick : MonoBehaviour {
	
	//public GameObject loadingImage;
	
    //load the next scene based on the Int value of the scene in the build settings when clicked on in a button.
	public void LoadScene(int Scene)
	{
		//loadingImage.SetActive(true);
        
		SceneManager.LoadScene(Scene);
	}
}
