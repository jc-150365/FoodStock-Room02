using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace FoodStock01
{
    [Table("Setting")]//テーブル名を指定
    public class SettingModel
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Set_no { get; set; } //設定No

        public int Set_date { get; set; } //通知日数

        /********************インサートメソッド（通知日数）**********************/
        public static void InsertSetting(int set_date)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにFoodテーブルを作成する
                    db.CreateTable<SettingModel>();

                    db.Insert(new SettingModel() { Set_date = set_date});
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*******************セレクトメソッド（最新の通知日数）*************************************/
        public static List<SettingModel> SelectSetting()
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースに指定したSQLを発行
                    return db.Query<SettingModel>("SELECT [Set_date] " +
                                               "FROM [Setting] " +
                                               "WHERE [Set_no] = " +
                                               "(SELECT MAX[Set_no])" +
                                               "FROM [Setting]");

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }
    }
}