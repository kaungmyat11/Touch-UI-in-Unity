using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchExample : MonoBehaviour
{

    public Text text;

    Vector2 endMousePos;
    Vector2 BeginMousePos;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Input.mousePosition;


        #region LeftRight
        if (Input.GetMouseButtonDown(0))    /*if(Input.touchCount > 0)*/
        {

            //Touch touchPos = Input.GetTouch(0);
            //Vector2 touchPos = touch.Position;

            if (mousePos.x < Screen.width / 2)
            {
                text.text = "LEFT";
            }
            else
            {
                text.text = "RIGHT";
            }
        }
        else
        {
            text.text = "";
        }
        #endregion


        #region DrawLine
        for (int i = 0; i < Input.touchCount; i++)
        {
            Vector2 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);

            Debug.DrawLine(Vector3.zero, worldPos, Color.red);
        }
        #endregion

        #region Swipe

        if(Input.GetMouseButtonDown(0))
        {
            BeginMousePos = Input.mousePosition;
            BeginMousePos = Camera.main.ScreenToViewportPoint(BeginMousePos);

        }
        else if(Input.GetMouseButtonUp(0))
        {
            endMousePos = Input.mousePosition;
            endMousePos = Camera.main.ScreenToViewportPoint(endMousePos);

            if( Mathf.Abs(BeginMousePos.x - endMousePos.x) < 0.1f)       //Mathf.Abs ka value pal yu tal direction htae ma sin sar buu
            {
                return;
            }
            else if( endMousePos.x < BeginMousePos.x)
            {
                Debug.Log("Left");
            }
            else if(endMousePos.x > BeginMousePos.y)
            {
                Debug.Log("Right");
            }
        }
        
        #endregion
    }
}
