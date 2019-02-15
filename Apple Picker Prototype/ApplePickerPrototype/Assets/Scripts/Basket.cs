using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour
{
    public TextMesh scoreGT;
    // Start is called before the first frame update
    void Start()
    {
        //Find a reference to ScoreCounter GameObject
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        //get the TextMesh component of the GameObject
        scoreGT = scoreGO.GetComponent<TextMesh>();
        //set the starting score to 0
        scoreGT.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        //Get current screen position of the mouse from Input
        Vector3 mousePos2D = Input.mousePosition;

        //Get camera position set how far to push the mouse
        mousePos2D.z = -Camera.main.transform.position.z;

        //Convert the point from 2D screen space into 3D game world
        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);

        //move the x position of the basket to the x position of the mouse
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }

    void OnCollisionEnter(Collision collision)
    {
        //find out what hit the basket
        GameObject collidedWith = collision.gameObject;
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);

            //parse teh text of the score into a int to add the points
            //from catching the falling aples, each apple worth 100 points
            int score = int.Parse(scoreGT.text);
            score += 100;
            scoreGT.text = score.ToString();
            //track high score
            if (score > HighScore.score)
            {
                HighScore.score = score;
            }
        }
    }
}
