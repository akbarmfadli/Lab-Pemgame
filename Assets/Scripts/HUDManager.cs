using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    public Image currentEnergy;
    [SerializeField] GameObject pauseMenu;
    public static bool GameisPaused = false;
    public Player playerInstance;

    

    private GameObject player;

    private float energy = 200;
    private float maxEnergy = 200;
    private float kecepatan;
    private float kecepatanLari;
    private float input_x;
    private float input_z;

    private float darah = 100;
    private float maxDarah = 100;
    public Image currentDarah;

    [SerializeField] GameObject GameOverMenu;
    [SerializeField] GameObject Information;
    string info;
   

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        kecepatanLari = player.GetComponent<pergerakan>().speed_lari;
    }

    // Update is called once per frame
    void Update()
    {
        kecepatan = player.GetComponent<pergerakan>().kecepatan;
        input_x = player.GetComponent<pergerakan>().x;
        input_z = player.GetComponent<pergerakan>().z;
        darah = player.GetComponent<sistem_darah>().darah_player;
        info = player.GetComponent<sistem_darah>().info;

        Text pesan = Information.GetComponent<Text>();
        pesan.text = info;
     

        EnergyDrain();
        UpdateEnergy();
        ShowPauseMenu();
        UpdateDarah();
        gameOver();
        
    }

    private void EnergyDrain()
    {
        if(kecepatan == kecepatanLari)
        {
            if (input_x > 0 || input_z > 0)
            {
                if (energy > 0)
                {
                    energy -= 10 * Time.deltaTime;
                }
            }
        }
        else
        {
            if (energy < maxEnergy)
            {
                energy += 15 * Time.deltaTime;
            }
        }
    }

    private void UpdateEnergy()
    {
        float ratio = energy / maxEnergy;
        currentEnergy.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    private void ShowPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        GameisPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Pause()
    {
        pauseMenu.SetActive(true);
        GameisPaused = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayer(playerInstance);
    }

    private void UpdateDarah()
    {
        float ratio = darah / maxDarah;
        currentDarah.rectTransform.localScale = new Vector3(ratio, 1, 1);
    }

    public void gameOver()
    {
        if (darah < 1)
        {
            //player mati
            GameOverMenu.SetActive(true);
            GameisPaused = true;
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
        }
    }
    public void restart()
    {
        SceneManager.LoadScene("MainScenes");
    }
 
}
