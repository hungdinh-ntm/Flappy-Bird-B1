using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : LoadMonoBehaviour
{
    [Header("Game Manager")]
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] protected bool isGameStarted = false;
    public bool IsGameStarted => isGameStarted;

    [SerializeField] protected bool isGameOver = false;
    public bool IsGameOver => isGameOver;

    [SerializeField] protected int gameScore = 0;
    public int GameScore => gameScore;

    [SerializeField] protected UIGameOver uiGameOver;
    public UIGameOver UIGameOver => uiGameOver;

    protected override void Awake()
    {
        base.Awake();
        if (GameManager.instance != null) Debug.LogError("Only 1 GameManager allow to exist");
        GameManager.instance = this;
    }

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadUIGameOver();
    }

    protected virtual void LoadUIGameOver()
    {
        if (this.uiGameOver != null) return;
        Transform uiCenter = GameObject.Find("Canvas").transform.Find("UICenter");

        this.uiGameOver = uiCenter.Find("UIGameOver").GetComponent<UIGameOver>();
    }

    public virtual void OnSpacePressed()
    {
        if (!this.isGameStarted)
        {
            this.StartGame();
            BirdCtrl.Instance.BirdGravity.GravityScale();
        }
        BirdCtrl.Instance.AbilityFly.Fly();
        SoundsManager.Instance.PlayWing();
    }

    protected virtual void StartGame()
    {
        this.isGameStarted = true;
    }

    public virtual void GameOver()
    {
        if (isGameOver) return;
        this.isGameOver = true;

        BirdCtrl.Instance.BirdGravity.StopBird();
        this.uiGameOver.ShowResult(gameScore);
    }

    public virtual void AddScore()
    {
        this.gameScore += 1;
    }

    public virtual void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
