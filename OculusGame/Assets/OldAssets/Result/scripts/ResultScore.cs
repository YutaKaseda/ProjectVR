using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ResultScore : MonoBehaviour {

	[SerializeField]
    Animator animator;
    
    //UIテキスト
	[SerializeField]
    Text score;                 //スコア
    [SerializeField]
	Text remainingBullet;       //残弾ボム数
    [SerializeField]
	Text shootingDownRate;      //撃退率
	[SerializeField]
    Text rank;                  //撃退率ランク
    [SerializeField]
	Text balkanExperienceValue; //バルカン経験値
    [SerializeField]
	Text laserExperienceValue;  //レーザー経験値

	//UIテキスト
	bool scoreflg;                 //スコア
	bool remainingBulletflg;       //残弾ボム数
	bool shootingDownRateflg;      //撃退率
	bool rankflg;                  //撃退率ランク
	bool balkanExperienceValueflg; //バルカン経験値
	bool laserExperienceValueflg;  //レーザー経験値
    string shootingDownRank;      //撃退ランクが入る
    double finalShootingDownRate; //撃退率が入る
    double max;                   //1ウェーブに出て来る敵の数が入る
    [SerializeField]
	bool   resultSkipflg;         //リザルトをスキップさせる
    int i;

	public bool resultViweFlg = false;	// リザルトの表示がされてるかどうか(次のwaveに行ってもよいかどうか)

    //仮の値を入れてるんで後々消してください。
    public double dummyshootingDownRate;
    public int dummyScore;
    public int dummyremainingBullet;
    public int dummyrank;
    public int dummybalkanExperienceValue;
    public int dummyLaserExperienceValue;
    ////////////////////////////////////////
   
	

    void Awake(){
        
        //test = GetComponent<Test>();

        //dummy////////////////////////
        dummyScore = 22000;
        dummyremainingBullet = 3;
        dummybalkanExperienceValue = 123;
        dummyLaserExperienceValue = 321;
        dummyshootingDownRate = 10;
        ////////////////////////////////
        
		i = 0;

        resultSkipflg            = false;
		scoreflg                 = true;
		remainingBulletflg       = false;
		shootingDownRateflg      = false;
		rankflg                  = false;
		balkanExperienceValueflg = false; 
		laserExperienceValueflg  = false;
		/*
        score                 = GameObject.Find("Score").GetComponent<Text>();
        remainingBullet       = GameObject.Find("RemainingBullet").GetComponent<Text>();
        shootingDownRate      = GameObject.Find("ShootingDownRate").GetComponent<Text>();
        rank                  = GameObject.Find("Rank").GetComponent<Text>();
        balkanExperienceValue = GameObject.Find("BalkanExperienceValue").GetComponent<Text>();
        laserExperienceValue  = GameObject.Find("LaserExperienceValue").GetComponent<Text>();
		*/
		//animator = GameObject.Find("Result").GetComponent<Animator>();

    }
    
    //撃退率と撃退ランクを出す処理
    public void RankJudge(){

        //ここで1ウェーブ全体の敵の数を入れる（今は仮で15があります）
        max = 13;

        //撃退率を計算して出し、下の方でランク判断をしている
        finalShootingDownRate = dummyshootingDownRate / max * 100;

        if (finalShootingDownRate == 100) { shootingDownRank = "S"; return; }
        if (finalShootingDownRate <= 99 && finalShootingDownRate >= 90) { shootingDownRank = "A"; return; }
        if (finalShootingDownRate <= 89 && finalShootingDownRate >= 60) { shootingDownRank = "B"; return; }
        if (finalShootingDownRate <= 59 && finalShootingDownRate >= 35) { shootingDownRank = "C"; return; }
        if (finalShootingDownRate <= 34 && finalShootingDownRate >= 0)  { shootingDownRank = "D"; return; }

    }
    /*
	public void ScoreCount(){
			score.text = i.ToString();
	}*/

    //リザルト画面に出るテキストに結果を入れる
    public void ResultSkip(){

        score.text                 = dummyScore + "点";
        remainingBullet.text       = dummyremainingBullet + "個";
        shootingDownRate.text      = finalShootingDownRate.ToString("F2") + "％";
        rank.text                  = "" + shootingDownRank;
        balkanExperienceValue.text = dummybalkanExperienceValue.ToString();
        laserExperienceValue.text  = dummyLaserExperienceValue.ToString();

        resultSkipflg = true;
    }

    public void Result(){

		RankJudge();

        if (!resultSkipflg) { 
		    if (i < dummyScore && scoreflg) {i += 200; score.text = i+ "点";
			    if (i == dummyScore) { i = 0; remainingBulletflg = true;scoreflg=false;}}

		    if (i < dummyremainingBullet && remainingBulletflg==true) {i += 1; remainingBullet.text = i+ "個";
			    if (i == dummyremainingBullet) { i = 0; shootingDownRateflg = true;remainingBulletflg=false;}}

		    if (i < (int)finalShootingDownRate && shootingDownRateflg==true) {i += 1;shootingDownRate.text = i+ "％";
                if (i == (int)finalShootingDownRate) { shootingDownRate.text = finalShootingDownRate.ToString("F2") + "％"; i = 0; rankflg = true; shootingDownRateflg = false; }}

		    if (rankflg==true) { rank.text = shootingDownRank; balkanExperienceValueflg = true;rankflg=false;}

		    if (i < dummybalkanExperienceValue && balkanExperienceValueflg==true) { i += 1; balkanExperienceValue.text = i.ToString();
                if (i == dummybalkanExperienceValue) { i = 0; laserExperienceValueflg = true; balkanExperienceValueflg = false; }}

		    if (i < dummyLaserExperienceValue && laserExperienceValueflg==true) {	i += 1; laserExperienceValue.text = i.ToString();
                if (i == dummyLaserExperienceValue) { laserExperienceValueflg = false; resultSkipflg = true; }}
        }

		if (Input.GetKeyDown (KeyCode.Space)) {
            if (!resultSkipflg) { ResultSkip(); }
            else{
				animator.SetBool("closeflg", true);
				resultSkipflg = false;
				resultViweFlg = false;
			}
		}

    }

	public void InitScoreText(){

		score.text                 = 0 + "点";
		remainingBullet.text       = 0 + "個";
		shootingDownRate.text      = 0.00 + "％";
		rank.text                  = "-";
		balkanExperienceValue.text = "0";
		laserExperienceValue.text  = "0";
		scoreflg                 = true;
		remainingBulletflg       = false;
		shootingDownRateflg      = false;
		rankflg                  = false;
		balkanExperienceValueflg = false; 
		laserExperienceValueflg  = false;
		i = 0;
		resultViweFlg = true;
		animator.SetBool ("closeflg", false);
	}



    void Update() { if(resultViweFlg)Result(); }

}
