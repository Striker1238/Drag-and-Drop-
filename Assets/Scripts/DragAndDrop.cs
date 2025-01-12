using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    // Для плавности перетаскивания предметов используем смещение
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

        // Удаляем предмет из текущего хранилища
        if (currentStorage != null)
        {
            currentStorage.RemoveItemFromSlot(gameObject);
            currentStorage = null;
        }
    }

    // Добавляем плавность в переммещение объекта
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

        // Проверяем, находится ли предмет в зоне какого-либо хранилища
        if (currentStorage != null)
        {
            // Пробуем добавить предмет
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

    // Получение координат мышки в мировых координатах
    Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = cam.WorldToScreenPoint(transform.position).z;
        return cam.ScreenToWorldPoint(mousePoint);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Если предмет попадает в зону хранилища
        if (collision.CompareTag("Storage"))
        {
            currentStorage = collision.GetComponent<Storage>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Если предмет покидает зону хранилища
        if (collision.CompareTag("Storage") && currentStorage != null)
        {
            currentStorage = null;
        }
    }
}