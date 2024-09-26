using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] private Transform openPage;
    [SerializeField] private TMP_Text scoreText;
    public static int count;
    [SerializeField] private GameObject exitButton;
    [SerializeField] private GameObject[] thingsToHide;
    // Start is called before the first frame update
    void Start()
    {
            count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 3)
        {
            count=0;
            openPage.gameObject.SetActive(true);
            scoreText.text = Score.returnScore().ToString();
        }
    }

    public void playAgain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void seeCreation()
    {
        openPage.gameObject.SetActive(false);
        exitButton.gameObject.SetActive(true);
        foreach (GameObject obj in thingsToHide)
        {
            obj.SetActive(false);
        }
    }
}
