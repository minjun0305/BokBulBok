using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WitchPot : MonoBehaviour
{
    public Image wa1;
    public Image wb1;
    public Image oa1;
    public Image ob1;
    public Image oc1;

    public Image rw1;
    public Image ra1;
    public Image rb1;
    public Image rc1;
    
    public Image wa2;
    public Image wb2;
    public Image oa2;
    public Image ob2;
    public Image oc2;

    public Image rw2;
    public Image ra2;
    public Image rb2;
    public Image rc2;
    
    public Image wa3;
    public Image wb3;
    public Image oa3;
    public Image ob3;
    public Image oc3;

    public Image rw3;
    public Image ra3_1;
    public Image ra3_2;
    public Image rb3_1;
    public Image rb3_2;
    public Image rc3;

    public Image wa4;
    public Image wb4;
    public Image oa4;
    public Image ob4;
    public Image oc4;

    public Image rw4;
    public Image ra4;
    public Image rb4;
    public Image rc4;

    public Image wa5;
    public Image wb5;
    public Image oa5;
    public Image ob5;
    public Image oc5;

    public Image rw5;
    public Image ra5;
    public Image rb5;
    public Image rc5;

    public Image wa6;
    public Image wb6;
    public Image oa6;
    public Image ob6;
    public Image oc6;

    public Image rw6;
    public Image ra6;
    public Image rb6;
    public Image rc6;

    public Image wa7;
    public Image wb7;
    public Image oa7;
    public Image ob7;
    public Image oc7;

    public Image rw7;
    public Image ra7;
    public Image rb7;
    public Image rc7;

    public Image wa8;
    public Image wb8;
    public Image oa8;
    public Image ob8;
    public Image oc8;

    public Image rw8;
    public Image ra8;
    public Image rb8;
    public Image rc8;

    public List<Image> wa;
    public List<Image> wb;
    public List<Image> oa;
    public List<Image> ob;
    public List<Image> oc;
    public List<Image> rw;
    public List<Image> ra;
    public List<Image> rb;
    public List<Image> rc;

    private int index;

    private Image witchA;
    private Image witchB;
    private Image choiceA;
    private Image choiceB;
    private Image choiceC;
    
    // Start is called before the first frame update
    void Start()
    {/*
        wa = {wa1, wa2, wa3, wa4, wa5, wa6, wa7, wa8};
        wb = {wb1, wb2, wb3, wb4, wb5, wb6, wb7, wb8};
        oa = {oa1, oa2, oa3, oa4, oa5, oa6, oa7, oa8};
        ob = {ob1, ob2, ob3, ob4, ob5, ob6, ob7, ob8};
        oc = {oc1, oc2, oc3, oc4, oc5, oc6, oc7, oc8};
        rw = {rw1, rw2, rw3, rw4, rw5, rw6, rw7, rw8};
        ra = {ra1, ra2, ra3_1, ra4, ra5, ra6, ra7, ra8};
        rb = {rb1, rb2, rb3_1, rb4, rb5, rb6, rb7, rb8};
        rc = {rc1, rc2, rc3, rc4, rc5, rc6, rc7, rc8};*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    void NextRound()
    {
        index = Random.Range(0, 8);
        witchA = wa[index];
        witchB = wb[index];
        choiceA = oa[index];
        choiceB = ob[index];
        choiceC = oc[index];
            
    }
}
