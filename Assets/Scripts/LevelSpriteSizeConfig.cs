using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpriteSizeConfig : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector2 height;
    private Vector2 width;
    void Awake()
    {
        CalculateScreenSize(ref height, ref width);

        transform.localScale = GetNewLocalScale();

        Vector3 position = Camera.main.ScreenToWorldPoint(Screen.safeArea.center);
        position.z = transform.position.z;
        transform.position = position;
    }
    private void CalculateScreenSize(ref Vector2 height, ref Vector2 width)
    {
        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.xMin, Screen.safeArea.yMin));
        Vector3 bottomRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.xMax, Screen.safeArea.yMin));
        Vector3 topLeft = Camera.main.ScreenToWorldPoint(new Vector2(Screen.safeArea.xMin, Screen.safeArea.yMax));

        height = new Vector2(0, topLeft.y - bottomLeft.y);
        width = new Vector2(bottomRight.x - bottomLeft.x, 0);
    }
    private Vector3 GetNewLocalScale()
    {
        float xScale = width.magnitude / spriteRenderer.sprite.rect.width * spriteRenderer.sprite.pixelsPerUnit;
        float yScale = height.magnitude / spriteRenderer.sprite.rect.height * spriteRenderer.sprite.pixelsPerUnit;
        return new Vector3(xScale, yScale, 1f);
    }
}
