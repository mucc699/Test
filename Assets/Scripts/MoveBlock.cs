using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBlock : MonoBehaviour
{
    bool isToutched = false;
    GameObject map;
    Vector3 trans;
    Vector3 r0;

    public static int num = 0;

    // Start is called before the first frame update
    void Start()
    {
        map = GameObject.Find("Map");
        r0 = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float x = MapManager.moveX;
        if (isToutched && Input.GetMouseButtonDown(0))
        {
            GameObject obj = (GameObject)Resources.Load("Prefabs/" + ChangeColor.color);
            GameObject stuff = Instantiate(obj,r0, Quaternion.identity, map.transform);
            stuff.AddComponent<MoveBlock>();
            Destroy(gameObject);
        } 
        trans = transform.position;
        trans.x = r0.x + 3.0f * Mathf.Sin(x);
        transform.position = trans;
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
}
