using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float maxX = 4.5f;
    public float minX = -4.5f;
    void Update()
    {
        float scroll = Input.GetAxis("Horizontal");

        // –асчитываем новые координаты дл€ камеры
        Vector3 newPosition = transform.position + new Vector3(scroll, 0, 0) * scrollSpeed * Time.deltaTime;
        // ”станавливаем ее в допустимые границы
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // ”станавливаем позицию камеры в новые границы
        transform.position = newPosition;
    }
}