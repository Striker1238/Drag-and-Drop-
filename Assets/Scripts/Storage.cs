using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Storage : MonoBehaviour
{
    public List<Slot> slots = new List<Slot>();
    public Transform[] slotPositions; // Позиции слотов в хранилище

    private void Start()
    {
        foreach (var position in slotPositions)
        {
            slots.Add(new Slot(position.position));
        }
    }
    // Добавляем предмет в слот
    public bool AddItemToSlot(GameObject item)
    {
        Slot slot = slots.FirstOrDefault(s => s.IsEmpty());
        if (slot == null)
        {
            Debug.Log($"В хранилище {name}: нет места!");
            return false;
        }

        slot.obj = item;
        item.transform.position = slot.position;

        // Отключаем гравитацию и различные импульсы
        var rb = item.GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 0;

        return true;
    }

    // Удаляем предмет из слота
    public void RemoveItemFromSlot(GameObject item)
    {
        Slot slot = slots.FirstOrDefault(s => s.obj == item);
        if (slot != null)
        {
            slot.Clear();
        }
    }
}