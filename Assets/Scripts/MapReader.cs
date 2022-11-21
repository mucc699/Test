using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MapReader
{
    private TextAsset mapFile;  
    private TextAsset nrmFile;  
    public string fileName;
    public List<string[]> mapData = new List<string[]>();
    public List<string[]> nrmData = new List<string[]>();


    public MapReader(string fileName_)
    {
        fileName = fileName_;
    }

    public void Start()
    {
        mapFile = Resources.Load(fileName) as TextAsset;   
        StringReader mapReader = new StringReader(mapFile.text);     

        while (mapReader.Peek() != -1)
        {
            string line = mapReader.ReadLine();   
            mapData.Add(line.Split(','));    
        }

        nrmFile = Resources.Load(fileName + "nrm") as TextAsset;
        StringReader nrmReader = new StringReader(nrmFile.text);

        while (nrmReader.Peek() != -1)
        {
            string line = nrmReader.ReadLine();
            nrmData.Add(line.Split(','));
        }
    }
}
