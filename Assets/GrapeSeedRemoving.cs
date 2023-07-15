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
    private int ri;
    private int ci;
    private Image r;
    private Image c;

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
        ri = 1; ci = 1;
    }

    public static void Retry()
    {
        state = State.Intro;
        ri = 1; ci = 1;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void setRC()
    {
        switch (ri) {
            case 1:
                r = r1;
                break;
            case 2:
                r = r2;
                break;
            case 3:
                r = r3;
                break;
            case 4:
                r = r4;
                break;
            case 5:
                r = r5;
                break;
            case 6:
                r = r6;
                break;
            case 7:
                r = r7;
                break;
            case 8:
                r = r8;
                break;
        }

        switch (ci) {
            case 1:
                c = c1;
                break;
            case 2:
                c = c2;
                break;
            case 3:
                c = c3;
                break;
        }
    }
}
