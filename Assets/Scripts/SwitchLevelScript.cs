using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchLevelScript : MonoBehaviour {

    public int levelToLoad;
    public GameObject player;
    public Animator transitionAnim;
    public AudioManager audioManager;
    public GameObject achievements;
    public AchievmentDisplay achievmentDisplay;

    public float currentTime;
    public string saveTime;
    
    

    // Use this for initialization

    private void Awake()
    {
        audioManager =GameObject.FindObjectOfType<AudioManager>();
    }
    void Start () {

        
        currentTime = 0;

        achievements = GameObject.FindGameObjectWithTag("Achievements");
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;

        if (player.GetComponent<PlayerController>().levelCounter == 1)
        {
            PlayerPrefs.SetString("FoundSecretLevel", "False");
        }
        try
        {
            achievmentDisplay = GameObject.FindGameObjectWithTag("CollectAHatAchievement").GetComponent<AchievmentDisplay>();
        }
        catch
        {

        }

        try
        {
        transitionAnim.GetComponentInChildren<Animator>();
        }
        catch { }
    }

    private void Update()
    {
        currentTime += Time.deltaTime;

    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerCollider")
        {
            StartCoroutine(LoadScene());           
        }
    }

    IEnumerator LoadScene()
    {
       
        player.GetComponent<PlayerController>().levelCounter++;
        // transitionAnim.SetTrigger("end");    


        // Zeit die der SPieler braucht um das Level zu schaffen

        saveTime = currentTime+ "level:" + (levelToLoad - 1).ToString();

        PlayerPrefs.SetString("Time",saveTime);

        

        DontDestroyOnLoad(achievements);
        DontDestroyOnLoad(audioManager);
        DontDestroyOnLoad(player);

        
            PlayerPrefs.SetString("FoundSecretLevel", "true");
            SceneManager.LoadScene("Level" + levelToLoad);
            if (achievmentDisplay != null)
            {
                achievmentDisplay.FoundSecretLevel();
        }       
        
            
        

            yield return new WaitForSeconds(1.5f);

    }
}
