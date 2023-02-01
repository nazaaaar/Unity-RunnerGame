using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private static Panel instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameObject.SetActive(false);
    }
    private void _Show()
    {
        Cursor.visible = true;
        gameObject.SetActive(true);
    }
    public static void Show()
    {
        Score.GetScore();
        instance._Show();
    }

}
