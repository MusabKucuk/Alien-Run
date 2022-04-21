using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Elec204 : MonoBehaviour
{
    private Texts texts;
    private Controller controller;
    public static float scoreT;

    private void Awake()
    {      
        texts = GetComponent<Texts>();
        controller = GetComponent<Controller>();
    }
    private void Update()
    {
        scoreT = texts.getScore();
        WriteScore();
        WriteState();
    }

    public static void WriteScore()
    {
        string path = Application.persistentDataPath + "/scoreandstates.txt";

        string s = scoreT.ToString("0");

        string[] lines = System.IO.File.ReadAllLines(path);
        lines[0] = s;
        System.IO.File.WriteAllLines(path, lines);
    }

    public void WriteState()
    {
        string path = Application.persistentDataPath + "/scoreandstates.txt";

        string s;

        switch (controller.characterStates)
        {
            case Controller.States.Idle:
                s = "00";
                break;
            case Controller.States.Jump:
                s = "01";
                break;
            case Controller.States.Run:
                s = "10";
                break;

            case Controller.States.Fire:
                s = "11";
                break;

            default:
                s = "00";
                break;
        }

        string[] lines = System.IO.File.ReadAllLines(path);
        lines[1] = s;
        System.IO.File.WriteAllLines(path, lines);
    }
}
