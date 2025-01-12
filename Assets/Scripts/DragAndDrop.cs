using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // ��� ��������� �������������� ��������� ���������� ��������
    private Vector3 offset;
    private Camera cam;
    private bool isDragging = false;
    private Storage currentStorage;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        offset = transform.position - GetMouseWorldPos();
        isDragging = true;
        GetComponent<Rigidbody2D>().gravityScale = 0;

        // ������� ������� �� �������� ���������
        if (currentStorage != null)
        {
            currentStorage.RemoveItemFromSlot(gameObject);
            currentStorage = null;
        }
    }

    // ��������� ��������� � ������������ �������
    void OnMouseDrag()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;

        // ���������, ��������� �� ������� � ���� ������-���� ���������
        if (currentStorage != null)
        {
            // ������� �������� �������
            if (!currentStorage.AddItemToSlot(gameObject))
            {
                GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }

    // ��������� ��������� ����� � ������� �����������
    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z;
        return cam.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ���� ������� �������� � ���� ���������
        if (collision.CompareTag("Storage"))
        {
            currentStorage = collision.GetComponent<Storage>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // ���� ������� �������� ���� ���������
        if (collision.CompareTag("Storage") && currentStorage != null)
        {
            currentStorage = null;
        }
    }
}