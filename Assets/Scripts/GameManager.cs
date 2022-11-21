using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject clearPanel;
    [SerializeField] GameObject gameOverPanel;

    public static bool clear, gameOver;

    // Start is called before the first frame update
    void Start()
    {
        clear = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (clear)
        {
            Debug.Log(clear);
            clearPanel.SetActive(true);
        }
        else if (gameOver)
        {
            gameOverPanel.SetActive(true);
        }
    }

}
