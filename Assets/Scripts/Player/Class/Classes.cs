﻿public class Classes
{
    public static readonly PlayerClass Warrior = new PlayerClass("warrior", new ClassInventory(ItemType.Sword, ItemType.Helm, ItemType.Armor), new StatData(150f, 8f, 10f), new StatData(10f, 1f, 2f), new StatData(10f, 1f, 2f));
    public static readonly PlayerClass Wizard = new PlayerClass("wizard", new ClassInventory(ItemType.Staff, ItemType.Spell, ItemType.Armor), new StatData(100f, 12f, 8f), new StatData(10f, 1f, 2f), new StatData(10f, 1f, 2f));
    public static readonly PlayerClass Priest = new PlayerClass("priest", new ClassInventory(ItemType.Wand, ItemType.Book, ItemType.Armor), new StatData(100f, 10f, 12f), new StatData(10f, 1f, 2f), new StatData(10f, 1f, 2f));
}
