using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject m_Crosshair = null;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        m_Crosshair.transform.position = Input.mousePosition;
    }
}
