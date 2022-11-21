using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    struct NRM
    {
        public int redBlocks;
        public int blueBlocks;
        public int yellowBlocks;
        public int keys;
        public int timeLimits;
    }

    GameObject map;
    GameObject canvas;
    MapReader reader;
    public static float moveX = 0.0f;
    NRM nrm;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("UICanvas");
        reader = new MapReader("Maps/Map1");
        reader.Start();
        CreateMap();
        CreateNrm();
      
            GameObject obj1 = (GameObject)Resources.Load("UIs/BlocksRed");
        if (nrm.redBlocks != 0)
        {
            Instantiate(obj1, new Vector3(11.5f, 6.5f, 0.0f),Quaternion.identity,canvas.transform);
        }
            GameObject obj2 = (GameObject)Resources.Load("UIs/BlocksBlue");
        if (nrm.blueBlocks!=0)
        {
            Instantiate(obj2, new Vector3(9.5f, 6.5f, 0.0f), Quaternion.identity, canvas.transform);
        }
            GameObject obj3 = (GameObject)Resources.Load("UIs/BlocksYellow");
        if (nrm.yellowBlocks!=0)
        {
            Instantiate(obj3, new Vector3(7.5f, 6.5f, 0.0f), Quaternion.identity, canvas.transform);
        }
            GameObject obj4 = (GameObject)Resources.Load("UIs/Keys");
        if (nrm.keys!=0)
        {
            Instantiate(obj4, new Vector3(5.5f, 6.5f, 0.0f), Quaternion.identity, canvas.transform);
        }
            GameObject obj5 = (GameObject)Resources.Load("UIs/TimeRed");
        if (nrm.timeLimits!=0)
        {
            Instantiate(obj5, new Vector3(3.5f, 6.5f, 0.0f), Quaternion.identity, canvas.transform);
        }

 
    }

   // Update is called once per frame
    void Update()
    {
        moveX += 0.001f;
    }

    private void CreateMap()
    {
        map = GameObject.Find("Map");

        GameObject normalStuff = (GameObject)Resources.Load("Prefabs/" + "BlockPrefab");
        GameObject movingStuff = (GameObject)Resources.Load("Prefabs/" + "MoveBlockPrefab");
        GameObject blower = (GameObject)Resources.Load("Prefabs/" + "BlowerPrefab");
        GameObject gaol = (GameObject)Resources.Load("Prefabs/" + "Goal");

        for (int y = 0; y < reader.mapData.Count; y++)
        {
            for (int x = 0; x < reader.mapData[y].Length; x++)
            {
                switch (reader.mapData[y][x])
                {
                    case "0":
                        break;

                    case "1":
                        Instantiate(normalStuff, new Vector3(2 * x, reader.mapData.Count - y, 0.0f), Quaternion.identity, map.transform);
                        break;

                    case "2":
                        Instantiate(movingStuff, new Vector3(2 * x, reader.mapData.Count - y, 0.0f), Quaternion.identity, map.transform);
                        break;
                    case "3":
                        Instantiate(blower, new Vector3(2 * x, reader.mapData.Count - y, 0.0f), Quaternion.identity, map.transform);
                        break;

                    case "4":
                        Instantiate(gaol, new Vector3(2 * x, reader.mapData.Count - y, 0.0f), Quaternion.identity, map.transform);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    private void CreateNrm()
    {
        for (int y = 0; y < reader.nrmData.Count; y++)
        {
            for (int x = 0; x < reader.nrmData[y].Length; x++)
            {
                if (reader.nrmData[y][x]=="配置赤")
                {
                    nrm.redBlocks = int.Parse(reader.nrmData[y][x + 1]);
                }
                 if (reader.nrmData[y][x]=="配置青")
                {
                    nrm.blueBlocks = int.Parse(reader.nrmData[y][x + 1]);
                }
                 if (reader.nrmData[y][x]=="配置黄")
                {
                    nrm.yellowBlocks = int.Parse(reader.nrmData[y][x + 1]);
                }
                if (reader.nrmData[y][x]=="収集")
                {
                    nrm.keys = int.Parse(reader.nrmData[y][x + 1]);
                }
                if (reader.nrmData[y][x]=="時間")
                {
                    nrm.timeLimits = int.Parse(reader.nrmData[y][x + 1]);
                }
            }
        }
    }
}
