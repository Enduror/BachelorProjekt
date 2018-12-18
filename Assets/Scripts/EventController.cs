using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventController : MonoBehaviour {




    public Texture2D cursorTexture;
    private Vector2 cursorHotspot;

    public int dummyCounter;
    public int dummyQuest;

    public int pressedPlatesCounter;
    public int trainingRoomQuest;

    public PlayerController player;
    public GameObject TrainingRoomExit;
    public GameObject WeaponExit;
    public GameObject weaponPodium;
    public MessageBord messageBoard;
    public SpriteMask devMask;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        Destroy(devMask);
    }

    public void Start()
    {
        cursorHotspot = new Vector2(cursorTexture.width / 2, cursorTexture.height / 2);
        Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit dat Shit");
            Application.Quit();
        }
    }

  

    public void AwakeWeapon()
    {
        player.ActivateWeapon();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void EndGame()
    {
        Application.Quit();
    }


    public void MouseScript()
    {

        // initialize mouse with a new texture with the
        // hotspot set to the middle of the texture
        // (don't forget to set the texture in the inspector
        
            
       

        // To check where your mouse is really pointing
        // track the mouse position in you update function
                
            Vector3 currentMouse = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(currentMouse);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            Debug.DrawLine(ray.origin, hit.point);
        
    
}

}
