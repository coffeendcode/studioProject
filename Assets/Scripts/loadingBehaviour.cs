using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingBehaviour : MonoBehaviour {

    public Text loadingText;
    public AsyncOperation async;
    public string level;
    public bool isActive;
    public float time;

    // Use this for initialization
    void Start () {
        gameObject.SetActive(false);
    }

	
	// Update is called once per frame
	void Update () {

        time += Time.deltaTime;

        if (time >= 0.2f)
        {
            loadingText.text = "Loading.";
        }
        if (time >= 0.4f)
        {
            loadingText.text = "Loading..";
        }
        if (time >= 0.6f)
        {
            loadingText.text = "Loading...";
        }

        if (async == null)
            async = SceneManager.LoadSceneAsync(level);

        async.allowSceneActivation = false;
        Debug.Log(async.progress);

        if (async.progress == 0.9f)
            StartCoroutine(load());
	}

    public void loadLevel(string level)
    {
        async = SceneManager.LoadSceneAsync(level);
    }

    IEnumerator load()
    {
        yield return new WaitForSeconds(1);
        async.allowSceneActivation = true;
    }
}
