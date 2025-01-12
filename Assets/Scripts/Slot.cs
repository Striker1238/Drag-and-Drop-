using UnityEngine;

// Логика слотов
public class Slot
{
    public Vector3 position; // Позиция слота
    public GameObject obj;   // Объект в слоте

    public Slot(Vector3 position)
    {
        this.position = position;
        this.obj = null;
    }

    // Проверка на null
    public bool IsEmpty()
    {
        return obj == null;
    }

    // Отчистка слота
    public void Clear()
    {
        obj = null;
    }
}