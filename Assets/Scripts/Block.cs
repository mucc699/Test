using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    bool isToutched = false;
    GameObject map;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map");
    }

    // Update is called once per frame
    void Update()
    {
        if (isToutched && Input.GetMouseButton(0))
        {
            GameObject obj = (GameObject)Resources.Load("Prefabs/" + ChangeColor.color);
            GameObject stuff = Instantiate(obj, gameObject.transform.position, Quaternion.identity,map.transform);
            stuff.AddComponent<Block>();
            Destroy(this.gameObject);
        }
        if (GameManager.clear||GameManager.gameOver)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnMouseOver()
    {
        isToutched = true;
    }

    private void OnMouseExit()
    {
        isToutched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
           Debug.Log(this.gameObject.name);
            if (this.gameObject.name == "RedBlockPrefab(Clone)")
            { 
                GameManager.gameOver = true;
            }
        }
    }
}
