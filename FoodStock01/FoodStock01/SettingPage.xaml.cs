using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodStock01
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingPage : ContentPage
	{
        int notice = 0;//SetPickerの値を一時的に保持する

        public SettingPage (string title)
		{
            if (SettingModel.SelectSetting() != null)
            {
                //タブに表示される文字列
                Title = title;

                InitializeComponent();
            }
            else
            {
                SettingModel.InsertSetting(1, 3);

                //タブに表示される文字列
                Title = title;

                InitializeComponent();
            }
		}

        /***********通知日数を選択したとき************************************/
        private void SetPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = SetPicker.SelectedIndex;

            notice = x+1;//
        }

        /**********保存ボタンを押した時**************************/
        private void Set_Save_Clicked(object sender, EventArgs e)
        {
            if (notice == 0)
            {
                DisplayAlert("通知日数エラー","通知日数を選択してください", "OK");
            }
            else
            {
                SettingModel.UpdateSetting(1,notice);
                DisplayAlert("通知日数", notice.ToString(), "OK");
            }
        }

        /***************Testボタンを押したとき*********************/
        private void Test_Button_Clicked(object sender, EventArgs e)
        {
            List<SettingModel> list = SettingModel.SelectSetting();

         
            //int x = y.ElementAt<SettingModel>;

            /*string[] names =
            {
                "Hartono, Tommy", "Adams, Terry", "Andersen, Henriette Thaulow", 

                "Hedlund, Magnus", "Ito, Shu" 
            };

            Random random = new Random(DateTime.Now.Millisecond);

            string name = names.ElementAt(random.Next(0, names.Length));

            Console.WriteLine("The name chosen at random is '{0}'.", name);*/

            DisplayAlert("最新の通知日数", list.ToString(), "OK");

            
        }
    }
}