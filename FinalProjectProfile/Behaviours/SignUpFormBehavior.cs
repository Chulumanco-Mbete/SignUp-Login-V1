using FinalProjectProfile.Models.SignUp;
using FinalProjectProfile.StartUp;
using Syncfusion.Maui.DataForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectProfile.Behaviours
{
    public class SignUpFormBehavior : Behavior<ContentPage>
    {
        private SfDataForm? dataForm;
        private Button? signUpButton;
        private Button? cancelButton;

        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.dataForm = bindable.FindByName<SfDataForm>("signUpForm");
            if (dataForm != null)
            {
                dataForm.DefaultLayoutSettings.LabelPosition = DataFormLabelPosition.Top;
                dataForm.ColumnCount = 2;
                this.dataForm.GenerateDataFormItem += this.OnGenerateDataFormItem;
            }

            this.cancelButton = bindable.FindByName<Button>("cancelButton");
            this.signUpButton = bindable.FindByName<Button>("signUpButton");

            if (this.cancelButton != null)
            {
                this.cancelButton.Clicked += OnCancelButtonClicked;
            }

            if (this.signUpButton != null)
            {
                this.signUpButton.Clicked += OnSignUpButtonClicked;
            }
        }
        private void OnGenerateDataFormItem(object? sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem != null)
            {
                if (e.DataFormItem.FieldName == nameof(SignUpFormModel.FirstName) || e.DataFormItem.FieldName == nameof(SignUpFormModel.LastName)
                    || e.DataFormItem.FieldName == nameof(SignUpFormModel.Email) || e.DataFormItem.FieldName == nameof(SignUpFormModel.MobileNumber)
                    || e.DataFormItem.FieldName == nameof(SignUpFormModel.Password) || e.DataFormItem.FieldName == nameof(SignUpFormModel.RetypePassword))
                {
                    e.DataFormItem.ColumnSpan = 1;
                }
                else if (e.DataFormItem.FieldName == nameof(SignUpFormModel.Email) && e.DataFormItem is DataFormTextEditorItem textItem)
                {
                    textItem.Keyboard = Keyboard.Email;
                }
            }
        }

        private async void OnSignUpButtonClicked(object? sender, EventArgs e)
        {
            if (this.dataForm != null && App.Current?.MainPage != null)
            {
                if (this.dataForm.Validate())
                {
                    await App.Current.MainPage.DisplayAlert("", "Signed up successfully", "OK");
                    await Shell.Current.GoToAsync("login");
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("", "Please enter the required details", "OK");
                }
            }
        }

        private void OnCancelButtonClicked(object? sender, EventArgs e)
        {
            if (this.dataForm != null)

            {
                this.dataForm.DataObject = new SignUpFormModel();
            }
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            if (this.cancelButton != null)
            {
                this.cancelButton.Clicked -= OnCancelButtonClicked;
            }

            if (this.signUpButton != null)
            {
                this.signUpButton.Clicked -= OnSignUpButtonClicked;
            }

            if (this.dataForm != null)
            {
                this.dataForm.GenerateDataFormItem -= this.OnGenerateDataFormItem;
            }
        }
    }
}
