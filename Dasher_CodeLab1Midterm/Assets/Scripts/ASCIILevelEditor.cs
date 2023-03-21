using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ASCIILevelEditor : MonoBehaviour
{
    public GameObject player;

    public GameObject wall;

    public GameObject exit;
    
    private const string FILE_DIR = "/level/";

    private const string FILE_NAME = "levelNum.txt";

    private string FILE_PATH;

    public float xOffSet;

    public float yOffSet;

    private GameObject level;

    private int currentLevel = 0;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
            LoadLevel(currentLevel); //whenever level changes, load scene
        }
    }
    
    void Start()
    {
        LoadLevel(currentLevel); //load first level
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadLevel(currentLevel); //press R to reset level
        }
    }

    void LoadLevel(int currentLevel)
    {
        Destroy(level); //clear existed level
        level = new GameObject("Level"); //create empty parent
        
        //set current level file path
        string currentFILE_NAME = FILE_NAME.Replace("Num", currentLevel.ToString());
        FILE_PATH = Application.dataPath + FILE_DIR + currentFILE_NAME;
        
        string[] fileLines = File.ReadAllLines(FILE_PATH);
        for (int yPos = 0; yPos < fileLines.Length; yPos++) //for each line 
        {
            char[] lineChars = fileLines[yPos].ToCharArray(); 
            for (int xPos = 0; xPos < lineChars.Length; xPos++) //for each char in line
            {
                char currentChar = lineChars[xPos];
                GameObject newObj;

                switch (currentChar)
                {
                    case 'p': //if char is a p
                        newObj = Instantiate<GameObject>(player); //instantiate player
                        break;
                    
                    case '-': //if char is a -
                        newObj = Instantiate<GameObject>(wall); //instantiate wall
                        break;
                    
                    case 'x': // if char is a x
                        newObj = Instantiate<GameObject>(exit); //instantiate exit
                        break;
                    
                    default: //if char is anything else
                        newObj = null; //skip
                        break;
                }

                if (newObj != null) 
                {
                    newObj.transform.position = new Vector2(xPos + xOffSet, -yPos - yOffSet); //put obj in (xpos, ypos)
                    newObj.transform.parent = level.transform; //set all obj as children
                }
            }
        }
    }

    public void HitExit()
    {
        CurrentLevel++;
    }
}
