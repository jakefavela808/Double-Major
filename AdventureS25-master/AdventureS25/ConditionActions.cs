﻿namespace AdventureS25;

public static class ConditionActions
{
    public static Action WriteOutput(string message)
    {
        return () => { Console.WriteLine(message); };
    }
    
    // add to inventory
    public static Action AddItemToInventory(string itemName)
    {
        return () => { Player.AddItemToInventory(itemName); };
    }
    
    // remove from inventory
    public static Action RemoveItemFromInventory(string itemName)
    {
        return () => Player.RemoveItemFromInventory(itemName); 
    }
    
    // add object to location
    public static Action AddItemToLocation(string itemName, string locationName)
    {
        return () => Map.AddItem(itemName, locationName);
    }
    
    // remove object from location
    public static Action RemoveItemFromLocation(string itemName, string locationName)
    {
        return () => Map.RemoveItem(itemName, locationName);
    }
    
    // record things in a journal
    
    // spawning an npc/mob
    
    // despawn npc/mob
    
    // change our game state
    
    // teleport us or item
    
    // win game
    
    // game losing
}