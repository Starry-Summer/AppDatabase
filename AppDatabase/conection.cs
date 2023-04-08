using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Path = System.IO.Path;

namespace AppDatabase
{
    //Creación de la tabla de base de datos
    public class Sign
    {
        public Sign() { }

        //Columna usuarios
        [MaxLength(50)]
        public String User { get; set; }

        //Columna ID con su llave primaria
        [PrimaryKey, AutoIncrement]
        [MaxLength(8)]
        public int ID { set; get; }

        //Columna Email
        [MaxLength(150)]
        public String Email { get; set; }

        //Columna descripción
        [MaxLength(200)]
        public String Description { get; set; }
    }

    //Hacemos la conexión a la base de datos
    public class Auxiliar
    {
        static object locker = new object();
        SQLiteConnection conection;
        public Auxiliar()
        {
            conection = conectionDabatase();
            conection.CreateTable<Sign>();
            
        }

        public SQLite.SQLiteConnection conectionDabatase()
        {
            SQLiteConnection enterDatabase;
            String nameDatabase = "queryDatabase.db3";
            String path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            String completPath = Path.Combine(path, nameDatabase);
            enterDatabase = new SQLiteConnection(completPath);
            return enterDatabase;
        }

        //Buscar registro
        public Sign Selection(int Data)
        {
            lock(locker)
            {
                return conection.Table<Sign>().FirstOrDefault(i => i.ID == Data);
            }
        }
        //Eliminar registro
        public int Destroy(int Id)
        {
            lock (locker)
            {
                return conection.Delete<Sign>(Id);
            }
        }

        //Insertar registro y/o actualizar
        public int Insert(Sign sign)
        {
            lock (locker)
            {
                if (sign.ID == 0)
                {
                    return conection.Insert(sign);
                }
                else
                {
                    return conection.Update(sign);
                }
            }
        }
    }
}