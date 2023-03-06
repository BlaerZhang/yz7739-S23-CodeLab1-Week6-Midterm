using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEditor : MonoBehaviour
{
    public AnimatorController studentAnimatorController; //animator controller for regular students
    
    public AnimatorController studentLeaderAnimatorController; //for students at front line and student leader

    public GameObject me;

    public GameObject meObeyingOrder;

    public GameObject student;

    public GameObject studentFollowing;

    public GameObject studentReversed;

    public GameObject studentGivingOrder;
    
    public GameObject studentObeyingOrder;

    public GameObject studentFreePracticing; //getting all kinds of prefabs from inspector

    const string FILE_DIR = "/Level/";

    const string FILE_NAME = "levelNum.txt";

    string FILE_PATH; //set file path

    public float xStartPoint;
    
    public float yStartPoint; //set level start point (offset)

    public float xSpace;

    public float ySpace; //set spacing of each student

    private GameObject level; //set parent object that holds the level
    
    
    void Start()
    {
        LoadLevel();
    }

    void LoadLevel()
    {
        level = new GameObject("Level"); //set parent object that holds the level
        string filename = FILE_NAME.Replace("Num", SceneManager.GetActiveScene().buildIndex.ToString()); 
        FILE_PATH = Application.dataPath + FILE_DIR + filename; //set file name according to the scene index
        string[] FileLine = File.ReadAllLines(FILE_PATH); //read lines
        for (int y = 0; y < FileLine.Length; y++) //loop through lines
        {
            char[] LineChar = FileLine[y].ToCharArray(); //split line into char array

            for (int x = 0; x < LineChar.Length; x++) //loop through char
            {
                GameObject newObj;

                switch (LineChar[x]) //check letters in level txt
                {
                    case 'm':
                        newObj = Instantiate<GameObject>(me); //if m, put me, and put lots of stuff from scene into prefab's inspector
                        newObj.GetComponent<NewAnimationControl>().turnAudio =
                            GameObject.Find("turn").GetComponent<AudioSource>();
                        newObj.GetComponent<NewAnimationControl>().atEaseAudio =
                            GameObject.Find("atease").GetComponent<AudioSource>();
                        newObj.GetComponent<MouseClick>().subText =
                            GameObject.Find("SubText").GetComponent<TextMeshProUGUI>();
                        newObj.GetComponent<MouseClick>().systemText =
                            GameObject.Find("System Text").GetComponent<TextMeshProUGUI>();
                        newObj.GetComponent<MouseClick>().mainCamera = Camera.main;
                        break; //if m, instantiate me, and put lots of stuff from scene into prefab's inspector
                    case 's':
                        newObj = Instantiate<GameObject>(student);
                        break; //if s, instantiate student
                    case 'g':
                        newObj = Instantiate<GameObject>(studentGivingOrder);
                        newObj.GetComponent<NewGiveOrder>().allTurnAudio =
                            GameObject.Find("allturn").GetComponent<AudioSource>();
                        newObj.GetComponent<NewGiveOrder>().allAtEaseAudio =
                            GameObject.Find("allatease").GetComponent<AudioSource>();
                        newObj.GetComponent<NewGiveOrder>().dialog =
                            GameObject.Find("Dialog").GetComponent<TextMeshPro>();
                        newObj.GetComponent<NewGiveOrder>().turnVoice =
                            GameObject.Find("turnvoice").GetComponent<AudioSource>();
                        break; //if g, instantiate studentGivingOrder, and put lots of stuff from scene into prefab's inspector
                    case 'o':
                        newObj = Instantiate<GameObject>(studentObeyingOrder);
                        break; //if o, instantiate studentObeyingOrder
                    case 'w':
                        newObj = Instantiate<GameObject>(meObeyingOrder);
                        newObj.GetComponent<NewAnimationControl>().turnAudio =
                            GameObject.Find("turn").GetComponent<AudioSource>();
                        newObj.GetComponent<NewAnimationControl>().atEaseAudio =
                            GameObject.Find("atease").GetComponent<AudioSource>();
                        newObj.GetComponent<MouseClick>().subText =
                            GameObject.Find("SubText").GetComponent<TextMeshProUGUI>();
                        newObj.GetComponent<MouseClick>().systemText =
                            GameObject.Find("System Text").GetComponent<TextMeshProUGUI>();
                        newObj.GetComponent<MouseClick>().mainCamera = Camera.main;
                        break; //if w, instantiate meObeyingOrder, and put lots of stuff from scene into prefab's inspector
                    case 'f':
                        newObj = Instantiate<GameObject>(studentFollowing);
                        newObj.GetComponent<NewAnimationControl>().turnAudio =
                            GameObject.Find("allturn").GetComponent<AudioSource>();
                        newObj.GetComponent<NewAnimationControl>().atEaseAudio =
                            GameObject.Find("allatease").GetComponent<AudioSource>();
                        break; //if f, instantiate studentFollowing, and put lots of stuff from scene into prefab's inspector
                    case 'r':
                        newObj = Instantiate<GameObject>(studentReversed);
                        break; //if r, instantiate studentReversed
                    case 'p':
                        newObj = Instantiate<GameObject>(studentFreePracticing);
                        newObj.GetComponent<FreePractice>().turnAudio =
                            GameObject.Find("allturn").GetComponent<AudioSource>();
                        newObj.GetComponent<FreePractice>().atEaseAudio =
                            GameObject.Find("allatease").GetComponent<AudioSource>();
                        newObj.GetComponent<FreePractice>().dialog =
                            GameObject.Find("Dialog").GetComponent<TextMeshPro>();
                        break; //if p, instantiate studentFreePracticing, and put lots of stuff from scene into prefab's inspector
                    default:
                        newObj = null;
                        break; //if not listed, set null
                }

                if (newObj != null)
                {
                    newObj.transform.position = new Vector2(xStartPoint + (x * xSpace), yStartPoint - (y * ySpace)); //put obj instantiated into the right place according to x and y
                    newObj.transform.parent = level.transform; //set obj as child of level
                    newObj.GetComponent<SpriteRenderer>().sortingOrder = y; //set sorting Order of SpriteRenderer according to y
                    if (y >= 16)
                    {
                        newObj.GetComponent<Animator>().runtimeAnimatorController = studentLeaderAnimatorController; //set front line students and leader the according animator controller
                    }
                    else
                    {
                        newObj.GetComponent<Animator>().runtimeAnimatorController = studentAnimatorController; //set regular animator controller
                    }
                }
            }
        }

        GameObject[] obeyArray = GameObject.FindGameObjectsWithTag("ObeyingOrder"); //create array containing all gameobjects with tag "ObeyingOrder"
        for (int i = 0; i < obeyArray.Length; i++) 
        {
            obeyArray[i].GetComponent<NewObeyOrder>().newGiveOrder =
                GameObject.FindWithTag("GivingOrder").GetComponent<NewGiveOrder>(); //set NewObeyOrder component a NewGiveOrder component from a studentGivingOrder in the scene
        }
    }
}
