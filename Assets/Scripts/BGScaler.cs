using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScaler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        
        float height = sr.bounds.size.y;    // chiều cao hình
        float width = sr.bounds.size.x;

        Vector3 tmpScale = transform.localScale;

        float worldHeight = Camera.main.orthographicSize * 2f;
        float worldWidth = worldHeight * Screen.width / Screen.height;  // worldHeight * 720 / 1280

        float xScale = worldWidth / width;
        float yScale = worldHeight / height;

        tmpScale.x = xScale;
        tmpScale.y = yScale;
        transform.localScale = tmpScale;
    }

}
