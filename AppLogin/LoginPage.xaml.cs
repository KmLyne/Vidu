using AppLogin.Models;
using AppLogin.Pages;
using AppLogin.Service;

namespace AppLogin;

public partial class LoginPage : ContentPage
{
	readonly ILoginRepository _loginRepository = new LoginService();
	public LoginPage()
	{
		InitializeComponent();
	}
	private async void Login_Clicked(object sender, EventArgs e)
	{
		string userName = txtUserName.Text;
		string passWord = txtPassWord.Text;

		if (userName == null || passWord == null)
		{
			await DisplayAlert("Warning", "Nhap vao ten hoac pass", "Ok");
			return;
		}
        UserInfo userInfo = await _loginRepository.Login(userName, passWord);
		if (userInfo != null)
		{
			await Navigation.PushAsync(new HomePage());
		}
		else
		{
			await DisplayAlert("Warning", "UserName hoac PassWord khong dung", "Ok");
		}
	}
}