using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;

public class Database : MonoBehaviour
{
    private IDbConnection conn;
    private string dbName = "entifarm.db";

    private void Awake()
    {
        conn = new SqliteConnection(string.Format("URI=file:{0}", dbName));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
