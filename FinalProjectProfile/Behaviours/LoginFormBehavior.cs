using FinalProjectProfile.Models.Login;
using Syncfusion.Maui.DataForm;

namespace FinalProjectProfile.Behaviours
{
    public class LoginFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm dataForm;
        private Button loginButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            dataForm = bindable.FindByName<SfDataForm>("loginForm");
            dataForm.GenerateDataFormItem += OnGenerateDataFormItem;

            loginButton = bindable.FindByName<Button>("loginButton");

            if (loginButton != null)
            {
                loginButton.Clicked += OnLoginButtonCliked;
            }
        }

        private void OnGenerateDataFormItem(object sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null && e.DataFormItem.FieldName == nameof(LoginFormModel.Email) && e.DataFormItem is DataFormTextEditorItem textItem)
            {
                textItem.Keyboard = Keyboard.Email;
            }
        }

        private async void OnLoginButtonCliked(object sender, EventArgs e)
        {
            if (dataForm != null && Application.Current?.MainPage != null)
            {
                if (dataForm.Validate())
                {
                    await Application.Current.MainPage.DisplayAlert("", "Signed in successfully", "OK");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("", "Please enter the required details", "OK");
                }
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (loginButton != null)
            {
                loginButton.Clicked -= OnLoginButtonCliked;
            }
            if (dataForm != null)
            {
                dataForm.GenerateDataFormItem -= OnGenerateDataFormItem;
            }
        }
    }
}
