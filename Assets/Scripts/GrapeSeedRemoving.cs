using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrapeSeedRemoving : MonoBehaviour
{
    public Image r1;
    public Image r2;
    public Image r3;
    public Image c1;
    public Image c2;
    public Image c3;
    public Image c4;
    public Image c5;
    public Image c6;
    public Image c7;
    public Image c8;

    public Text text;
    public Button retry;

    private enum State {Intro, Howto, Run, Success, Fail};
    private static State state;

    private int life;
    private int count;
    private float time;
    // private string log;
    private float timeLimit;

    public int threshold;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Intro;
        timeLimit = gameObject.GetComponent<GameCommonData>().timeLimit;
    }

    public static void Retry()
    {
        state = State.Intro;
    }
}
