using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//스테이지를 관리하는 컨트롤러
//스테이지 시작과 종료 시점에 스테이지의 시작과 마감을 처리하는 기능
//스테이지 내에서 획득하는 포인트를 관리하는 시스템
public class StageController : MonoBehaviour
{
    //스테이지에서 쌓은 포인트를 저장할 변수
    public int StagePoint = 0;
    //포인트 표시용 텍스트
    public Text PointText;
    //스테이지 컨트롤러의 인스턴스를 저장하는 static 변수입니다.
    public static StageController instance;
    //다른 코드 내에서 StageController.instance.AddPoint(10)과 같은 형태로 사용할 수 있게 됩니다.
    //따로 연결해서 쓸 필요가 없어서 편리합니다.

    //2024 - 3- 15 Awake -> Start
    private void Start()
    {
        instance = this;
        var alert = new DialogDataAlert("START", "All destroy slime", delegate () { Debug.Log("OK를 눌렀습니다!"); });

        DialogManager.Instance.Push(alert);
    }

    public void AddPoint(int point)
    {
        StagePoint += point;
        PointText.text = StagePoint.ToString();
    }

    public void FinishGame()
    {
        DialogDataConfirm confirm = new DialogDataConfirm("Restart?", "Please press OK if you want to restart the game.",
        delegate (bool yn)
        {
            if (yn)
                SceneManager.LoadScene("Game");

            else

                Application.Quit();

        });
            //Application.LoadLevel(Application.loadedLevel); 구 버전 코드
        //SceneManager.LoadScene("Game");
        DialogManager.Instance.Push(confirm);
    }
}
