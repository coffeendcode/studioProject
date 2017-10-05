using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

    

    private GameObject player;
    public GameObject gameOverMenu;
    public GameObject pauseMenu;
    public GameObject newRegion;
    public GameObject bFortress, rFortress;
    public GameObject loadingScreen;
    public GameObject optionsMenu;

    public int worldSize;

    public static gameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this.gameObject);
        loadingScreen = GameObject.Find("LoadingScreen");
    }

    // Use this for initialization
    void Start () {
        worldSize = 9;
        loadingScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (SceneManager.GetActiveScene().name == "Level")
        {
            
            if (!player)
            {
                gameOverMenu.SetActive(true);
            }
        }
	}

    private void OnLevelWasLoaded(int level)
    {
        switch (level)
        {
            case 0:
                loadingScreen = GameObject.Find("LoadingScreen");
                break;
            case 1:
                gameOverMenu = GameObject.Find("GameOverMenu");
                gameOverMenu.SetActive(false);
                pauseMenu = GameObject.Find("PauseMenu");
                pauseMenu.SetActive(false);
                loadingScreen = GameObject.Find("LoadingScreen");
                //loadingScreen.SetActive(false);
                player = GameObject.Find("Player");
                int row = 2;
                int col = 2;

                GameObject[] regions;
                regions = GameObject.FindGameObjectsWithTag("Region");

                for (int i = 0; i < 3; i ++)
                {
                    if (i == 2)
                        Instantiate(bFortress, new Vector2(Random.Range(20, -20) + this.transform.position.x, Random.Range(20, -20) + this.transform.position.y), new Quaternion(Random.Range(100, -100), Random.Range(100, -100), 0, 0));
                    col++;
                    
                    for (int j = 0; j < 3; j++)
                    {
                        Instantiate(newRegion, transform.position + new Vector3(40 * i, j * -40, 0), transform.rotation);
                        
                        if (j == 2 && i == 2)
                            Instantiate(rFortress, new Vector2(Random.Range(20, -20) + this.transform.position.x + 40 * i, Random.Range(20, -20) + this.transform.position.y + -40 * j), new Quaternion(Random.Range(100, -100), Random.Range(100, -100), 0, 0));
                        row++;
                    }
                }
                break;
        }
    }

    public void loadLevelAsync(string level)
    {
        loadingScreen.SetActive(true);
        loadingScreen.GetComponent<loadingBehaviour>().level = level;
    }
}
