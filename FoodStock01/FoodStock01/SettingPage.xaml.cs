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
            //タブに表示される文字列
            Title = title;

            InitializeComponent();
		}

        private void SetPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var x = SetPicker.SelectedIndex;

            notice = x+1;//
        }

        private void Set_Save_Clicked(object sender, EventArgs e)
        {
            if (notice == 0)
            {
                DisplayAlert("通知日数エラー","通知日数を選択してください", "OK");
            }
            else
            {
                SettingModel.InsertSetting(notice);
                DisplayAlert("通知日数", notice.ToString(), "OK");
            }
        }

        private void Test_Button_Clicked(object sender, EventArgs e)
        {
            var y = SettingModel.SelectSetting();

            DisplayAlert("最新の通知日数", y.ToString(), "OK");
        }
    }
}