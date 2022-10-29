using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    public static string GetName(int itemID) {
        switch (itemID) {
            case 0: return "Scrap Metal";
            case 1: return "Bullet Casing";
            default: return "Item not found.";
        }
    }
}
