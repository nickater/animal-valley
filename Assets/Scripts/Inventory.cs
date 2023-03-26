using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Inventory
{
    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots) 
    {
        for (int i = 0; i < numSlots; i++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    [System.Serializable]
    public class Slot
    {
        public CollectableType type;
        public int count;
        public int maxAllowed;
        public Sprite icon;

        public Slot()
        {
            type = CollectableType.NONE;
            count = 0;
            maxAllowed = 99;
        }

        public bool CanAddItem()
        {
            return count < maxAllowed;
        }

        public void AddItem(Collectable item)
        {
            this.type = item.type;
            this.icon = item.icon;

            count++;
        }
    }

    

    public void Add(Collectable item)
    {
        foreach (Slot slot in slots)
        {
            if (item.type == slot.type && slot.CanAddItem())
            {
                slot.AddItem(item);
                return;
            } 
        }

        foreach (Slot slot in slots)
        {
            if (slot.type == CollectableType.NONE)
            {
                slot.AddItem(item);
                return;
            }
        }
    }

}
