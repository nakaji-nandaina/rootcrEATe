using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMove : MonoBehaviour
{
    float clicktime = 0.3f; 
    float clickcounter = 0f;
    private void Update()
    {
        clickcounter -= Time.deltaTime;
    }
    void OnMouseDrag()
    {
        Vector3 objPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, objPos.z);

        transform.position = Camera.main.ScreenToWorldPoint(mousePos);
    }
    public void Onclick()
    {
        if (clickcounter > 0)
        {
            transform.Rotate(new Vector3(0, 0, 90));
            //Debug.LogError("‰ñ“]‚È‚¤");
        }
        else{
            clickcounter = clicktime;
        }
    }
}
