using Firebase.Database;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserScore
{
    public static string userIDPath = "user_ID";
    public static string userNamePath = "userName";
    public static string scorePath = "score";
    public static string timestampPath = "timestamp";
    public static string otherDataPath = "otherData";

    public string userID;
    public string userName;
    public long score;
    public long timestamp;
    public Dictionary<string, object> otherData;

    public UserScore(string userID, string userName, long score, long timestamp, Dictionary<string, object> otherData)
    {
        this.userID = userID;
        this.userName = userName;
        this.score = score;
        this.timestamp = timestamp;
        this.otherData = otherData;
    }

    public UserScore(DataSnapshot record)
    {
        userID = record.Child(userIDPath).Value.ToString();

        if (record.Child(userNamePath).Exists)
        {
            userName = record.Child(userNamePath).Value.ToString();
        }

        long score;
        if (Int64.TryParse(record.Child(scorePath).Value.ToString(), out score))
        {
            this.score = score;
        }
        else
        {
            this.score = Int64.MinValue;
        }

        long timestamp;
        if (Int64.TryParse(record.Child(scorePath).Value.ToString(), out timestamp))
        {
            this.timestamp = timestamp;
        }

        if (record.Child(otherDataPath).Exists && record.Child(otherDataPath).HasChildren)
        {
            this.otherData = new Dictionary<string, object>();
            foreach (var keyValue in record.Child(otherDataPath).Children)
            {
                otherData[keyValue.Key] = keyValue.Value;
            }
        }
    }

    public static UserScore CreateScoreFromRecord(DataSnapshot record)
    {
        if (record == null)
        {
            Debug.LogWarning("Null DataSnapshot record in UserScore.CreateScoreFromRecord");
            return null;
        }

        if (record.Child(userIDPath).Exists && record.Child(scorePath).Exists && record.Child(timestampPath).Exists) 
        {
            return new UserScore(record);
        }

        Debug.LogWarning("Invalid record format in UserScore.CreateScoreFromRecord");

        return null;
    }

    public Dictionary<string, object> ToDictionary()
    {
        return new Dictionary<string, object>()
        {
            {userIDPath, userID},
            {userNamePath, userName},
            {scorePath, score},
            {timestampPath, timestamp},
            {otherDataPath, otherData}
        };
    }
}
