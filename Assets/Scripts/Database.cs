using System.Data;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Collections;

public class Database : MonoBehaviour
{
    private IDbConnection conn;
    private string dbName = "Assets/SQL/entifarm.db";

    private ArrayList plants;

    private void Awake()
    {
        conn = new SqliteConnection(string.Format("URI=file:{0}", dbName));
        conn.Open();

        plants = new ArrayList();
    }

    private void Start()
    {
        GetAllPlants();
    }

    private ArrayList GetAllPlants()
    {
        // Miramos si el array est� vac�o. En caso que no est�, retornamos el array
        if (plants.Count == 0)
        {
            return plants;
        }

        // Nos conectamos a la base de datos y ejecutamos el comando de recibir todas las plantas
        IDbCommand cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT * FROM plants;";
        IDataReader reader = cmd.ExecuteReader();


        // Mientras tengamos ROWS que leer, almacenamos los datos en un array, encapsulado en el objecto Plant
        while (reader.Read())
        {
            plants.Add(new Plant(reader.GetString(1), reader.GetFloat(2), reader.GetInt32(3), reader.GetFloat(4), reader.GetFloat(5)));
        }

        return plants;
    }
}
