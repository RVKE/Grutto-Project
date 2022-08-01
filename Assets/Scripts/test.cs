using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    public float chosenTime;
    public Camera mainCamera;
    public bool skipIntro;
    [HideInInspector] public bool cursorMode = true;
    private RaycastHit hit;
    public GameObject startMenu;
    public GameObject creatureInfo;
    public GameObject followCanvas;
    public GameObject controlsCanvas;
    public GameObject speedCanvas;
    public GameObject creatureImage;
    public Text[] creatureTexts;
    public GameObject child;
    public CreatureController creatureController;
    public int totalDeaths;
    public int totalBirths;
    private bool pauseStatus = false;
    private bool speedTwoStatus = false;
    private bool speedThreeStatus = false;
    public Image pauseImage;
    public Sprite[] pauseImages;
    public TextMesh[] debugText;
    public GameObject debugTower;

    [SerializeField] private int aantalAanrakingenMetEenVrouw;




    {
        }

        if (Input.GetKeyDown(KeyCode.Space) && !startMenu.activeSelf && !controlsCanvas.activeSelf)
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.F) && creatureInfo.activeSelf)
        {
            FollowCreature();
        }
        if (Input.GetKeyDown(KeyCode.Escape) && creatureInfo.activeSelf)
        {
            DisableInfo();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && mainCamera.GetComponent<CameraFollow>().target)
        {
            StopFollowing();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && controlsCanvas.activeSelf)
        {
            CloseControlMenu();
        }
    }

    public void StartGame()
    {
        startMenu.SetActive(false);
        speedCanvas.SetActive(true);
        Time.timeScale = chosenTime;
        mainCamera.farClipPlane = 1000.0f;
    }

    public void OpenControlMenu()
    {
        startMenu.SetActive(false);
        controlsCanvas.SetActive(true);
    }

    public void CloseControlMenu()
    {
        controlsCanvas.SetActive(false);
        startMenu.SetActive(true);
    }

    public void PauseGame()
    {
        if (!pauseStatus)
        {
            pauseStatus = true;
            pauseImage.sprite = pauseImages[1];
            Time.timeScale = 0;
            Debug.Log("0");
        }
        else if (pauseStatus)
        {
            pauseStatus = false;
            pauseImage.sprite = pauseImages[0];
            Time.timeScale = 1;
            Debug.Log("1");
        }
    }

    public void SpeedTwo()
    {
        if (!speedTwoStatus)
        {
            speedTwoStatus = true;
            Time.timeScale = 2.5f;
            Debug.Log("2.5");
        }
        else if (speedTwoStatus)
        {
            speedTwoStatus = false;
            Time.timeScale = 1;
            Debug.Log("1");
        }
    }

    public void SpeedThree()
    {
        if (!speedThreeStatus)
        {
            speedThreeStatus = true;
            Time.timeScale = 5;
            Debug.Log("5");
        }
        else if (speedThreeStatus)
        {
            speedThreeStatus = false;
            Time.timeScale = 1;
            Debug.Log("1");
        }
    }

    public void FollowCreature()
    {
        DisableInfo();
        followCanvas.SetActive(true);
        mainCamera.GetComponent<CameraFollow>().LockOn();
    }

    public void StopFollowing()
    {
        followCanvas.SetActive(false);
        speedCanvas.SetActive(true);
        mainCamera.GetComponent<CameraFollow>().LockOff();
    }

    public void DisableInfo()
    {
        creatureInfo.SetActive(false);
        speedCanvas.SetActive(true);
    }
}
