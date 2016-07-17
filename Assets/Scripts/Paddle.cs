using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {

    public bool autoPlay = false;
    private Ball ball;
	// Use this for initialization
	void Start () {
        ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!autoPlay)
        {
            MoveWithMouse();
        }
        else
        {
            AutoPlay();
        }
    }

    void AutoPlay()
    {
        Vector3 PaddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);

        Vector3 ballPos = ball.transform.position;

        PaddlePos.x = Mathf.Clamp(ballPos.x, 0.82f, 15.25f);

        this.transform.position = PaddlePos;
    }

    void MoveWithMouse()
    {
        Vector3 PaddlePos = new Vector3(0.5f, this.transform.position.y, this.transform.position.z);

        float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

        PaddlePos.x = Mathf.Clamp(mousePosInBlocks, 0.82f, 15.25f);

        this.transform.position = PaddlePos;
    }
}
