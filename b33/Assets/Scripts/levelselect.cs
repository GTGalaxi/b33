using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelselect : MonoBehaviour {


	public void changeToScene(int SceneToLoad)
	{
		SceneManager.LoadScene (SceneToLoad);
	}

}
