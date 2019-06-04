using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CannonInterface : MonoBehaviour 
{
    [SerializeField]
    Cursor targetCursor;

    [SerializeField]
    CannonController cannon;

    [SerializeField]
    Text timeOfFlightText;

    [SerializeField]
    float defaultFireSpeed = 35;

    [SerializeField]
    float defaultFireAngle = 45;

    private float initialFireAngle;
    private float initialFireSpeed;
    private bool useLowAngle;

    private bool useInitialAngle;
    private GameObject endGameScreen = null;

    void Awake()
    {
        useLowAngle = true;

        initialFireAngle = defaultFireAngle;
        initialFireSpeed = defaultFireSpeed;

        useInitialAngle = true;
    }


    private void Start()
    {
        endGameScreen = GameObject.Find("EndGame");
        endGameScreen.SetActive(false);
    }
    void Update()
    {
        if (useInitialAngle)
            cannon.SetTargetWithAngle(targetCursor.transform.position, initialFireAngle);
        else
            cannon.SetTargetWithSpeed(targetCursor.transform.position, initialFireSpeed, useLowAngle);

        if (Input.GetButtonDown("Fire1") && !EventSystem.current.IsPointerOverGameObject())
        {
            cannon.Fire();

            Text destroy = GameObject.Find("usedBomb").GetComponent<Text>();
            destroy.text = (int.Parse(destroy.text) - 1) + "";

            if ((int.Parse(destroy.text)) <= 0)
            {
                endGameScreen.SetActive(true);
                GameObject gamesatus = GameObject.Find("GameStatus");

                
                gamesatus.transform.position = new Vector3(endGameScreen.transform.position.x+130, endGameScreen.transform.position.y+200, 0);
                 Time.timeScale = 0;
            }
        }

        timeOfFlightText.text = Mathf.Clamp(cannon.lastShotTimeOfFlight - (Time.time - cannon.lastShotTime), 0, float.MaxValue).ToString("F3");
    }

    public void SetInitialFireAngle(string angle)
    {
        initialFireAngle = Convert.ToSingle(angle);
    }

    public void SetInitialFireSpeed(string speed)
    {
        initialFireSpeed = Convert.ToSingle(speed);
    }

    public void SetLowAngle(bool useLowAngle)
    {
        this.useLowAngle = useLowAngle;
    }

    public void UseInitialAngle(bool value)
    {
        useInitialAngle = value;
    }
}
