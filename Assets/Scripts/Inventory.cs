using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Inventory
{
    public static string GetName(int itemID) {
        switch (itemID) {
            case 0: return "Rebar";
            case 1: return "Bullet Casing";
            case 2: return "Rusty Knuckles";
            default: return "Item not found.";
        }
    }
}
