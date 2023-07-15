using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KingArthersBulkUp : MonoBehaviour
{
    public Image down;
    public Image up;
    public Image struggle;
    public Image success;
    public Text text;
    public Button retry;

    private enum State {Intro, Howto, BulkUp, Success, Fail};
    private static State state;
    private int count;
    private float time;
    private bool initUp;
    private string log;
    private float timeLimit;

    public int threshold;

    // Start is called before the first frame update
    void Start()
    {
        state = State.Intro;
        timeLimit = gameObject.GetComponent<GameCommonData>().timeLimit;
        // todo gameObject.GetComponent<GameCommonData>().timeoverFunc
    }

    public static void Retry()
    {
        state = State.Intro;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Intro) {       
            down.enabled = false;
            up.enabled = false;
            struggle.enabled = true;
            success.enabled = false;
            text.enabled = true;
            retry.gameObject.SetActive(false);
            initUp = true;

            count = 0;
            time = timeLimit;

            text.text = "아서왕은 전설의 칼 엑스칼리버를 뽑아내고자 하지만, 근력 부족으로 아직 쉽지 않습니다.\n엔터를 눌러 아서왕의 벌크업을 도와주세요.";
            if (Input.GetKeyDown(KeyCode.Return)) {
                state = State.Howto;
            }
        } else if (state == State.Howto) {
            text.text = "규칙은 다음과 같습니다.\n주어진 제한시간 내에 엔터를 최대한 많이 눌러 주세요.\n정해진 운동횟수를 돌파하면 아서왕은 벌크업에 성공해 엑스칼리버를 뽑고 전설의 주인공으로 길이 남을 것입니다!\n\n벌크업을 위해 남은 운동횟수: " + threshold.ToString() + "\n\n엔터를 눌러 게임을 시작하세요!";
            if (Input.GetKeyDown(KeyCode.Return)) {
                state = State.BulkUp;

                down.enabled = false;
                up.enabled = true;
                struggle.enabled = false;
                success.enabled = false;
                Debug.Log("벌크업 시작");
            }
        } else if (state == State.BulkUp) {
            time -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Return)) {
                down.enabled = true;
                up.enabled = false;
                Debug.Log("엔터다운");
            }
            else if (Input.GetKeyUp(KeyCode.Return)) {
                if (initUp) {
                    initUp = false;
                } else {
                    count++;
                }
                down.enabled = false;
                up.enabled = true;
                Debug.Log("엔터업");
            }

            text.text = "벌크업을 위해 남은 운동횟수: " + (threshold - count).ToString() + "회" + "\n남은 시간: " + ((int)time).ToString();

            if (count >= threshold) {
                state = State.Success;
                log = text.text;
            } else if (time <= 0) {
                state = State.Fail;
                log = text.text;
            }
        } else if (state == State.Success) {
                down.enabled = false;
                up.enabled = false;
                struggle.enabled = false;
                success.enabled = true;
                text.text = log + "\n\n성공!";
                retry.gameObject.SetActive(true);
        } else {
            // state == Fail
                down.enabled = false;
                up.enabled = false;
                struggle.enabled = true;
                success.enabled = false;
                text.text = log + "\n\n실패!";
                retry.gameObject.SetActive(true);
        }
    }
}
