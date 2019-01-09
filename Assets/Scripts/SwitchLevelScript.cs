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

    // Use this for initialization

    private void Awake()
    {
        audioManager =GameObject.FindObjectOfType<AudioManager>();
    }
    void Start () {
        achievements = GameObject.FindGameObjectWithTag("Achievements");
        player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        transitionAnim.GetComponentInChildren<Animator>();
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
        transitionAnim.SetTrigger("end");       
        DontDestroyOnLoad(achievements);
        DontDestroyOnLoad(audioManager);
        DontDestroyOnLoad(player);
        if (levelToLoad>13)
        {
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            SceneManager.LoadScene("Level" + levelToLoad);
        }
        
        yield return new WaitForSeconds(1.5f);

    }
}
