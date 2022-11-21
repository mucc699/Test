using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public static string color = "GreenBlockPrefab";
    int wh;
    GameObject[] colors;

    // Start is called before the first frame update
    void Start()
    {
        colors = new GameObject[3];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = transform.GetChild(i).gameObject;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //‰ñ“]‚ÌŽæ“¾
        wh += (int)(Input.GetAxis("Mouse ScrollWheel")*10);
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i].SetActive(false);
        }
        colors[Mathf.Abs(wh % 3)].SetActive(true);
        Change();
        if (GameManager.clear||GameManager.gameOver)
        {
            Destroy(this.gameObject);
        }
    }

    void Change()
    {
        switch (Mathf.Abs(wh%3))
        {
            case 0:
                color = "GreenBlockPrefab";
                break;

            case 1:
                color="RedBlockPrefab";
                break;

            case 2:
                color = "YellowBlockPrefab";
                break;
        }
    }
}
