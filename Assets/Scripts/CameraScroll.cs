using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public float maxX = 4.5f;
    public float minX = -4.5f;
    void Update()
    {
        float scroll = Input.GetAxis("Horizontal");

        // ����������� ����� ���������� ��� ������
        Vector3 newPosition = transform.position + new Vector3(scroll, 0, 0) * scrollSpeed * Time.deltaTime;
        // ������������� �� � ���������� �������
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // ������������� ������� ������ � ����� �������
        transform.position = newPosition;
    }
}