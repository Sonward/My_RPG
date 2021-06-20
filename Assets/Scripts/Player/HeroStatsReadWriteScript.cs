using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HeroStatsReadWriteScript : MonoBehaviour
{
    private string path = "Assets/TextFiles/test.txt";
    private string[] lines;

    // Start is called before the first frame update
    void Start()
    {
        WriteString();
        //NewWrite();
        ReadString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WriteString()
    {
        //StreamWriter writer = new StreamWriter(path, true);

        //writer.WriteLine("Hello");
        //writer.Close();
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine("Hello");
        }
    }

    void NewWrite()
    {
        //StreamWriter writer = new StreamWriter(path, false);

        //writer.WriteLine("New Hello");
        //writer.Close();
        using (StreamWriter writer = new StreamWriter(path, false))
        {
            writer.WriteLine("New Hello");
        }
    }

    void ReadString()
    {
        //StringReader reader = new StringReader(path);
        //string toDebugLine = reader.ReadToEnd();
        //Debug.Log(toDebugLine);
        //reader.Close();

        using (StreamReader reader = new StreamReader(path))
        {
            List<string> toDebugLines = new List<string>();
            string ln;
            while ((ln = reader.ReadLine()) != null)
            {
                toDebugLines.Add(ln);
            }
            foreach (string iter in toDebugLines)
            {
                Debug.Log(iter);
            }
        }
    }
}
