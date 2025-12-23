using Undervein.QuestSystem;
using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public enum QuestType
{
    DestroyEnemy,
    AcquireItem,
}

[Serializable]
public class Quest
{
    public int id;

    public QuestType type;
    public int targetID;

    public int count;
    public int completedCount;

    public int rewardExp;
    public int rewardGold;
    public int rewardItemID;

    public string title;
    public string description;


}
