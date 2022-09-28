using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace Graphene.Front.Client.Components.Validators;

public class AddressValidator : ComponentBase, IDisposable
{
    private ValidationMessageStore? messageStore;

    [CascadingParameter]
    private EditContext? CurrentEditContext { get; set; }

    //[Parameter]
    //public Address? Model { get; set; }

    private Dictionary<string, object[]> fields;
    private bool disposedValue;

    protected override void OnInitialized()
    {
        if (CurrentEditContext is null)
        {
            throw new InvalidOperationException(
                $@"{nameof(AddressValidator)} requires a cascading
                parameter of type {nameof(EditContext)}.
                For example, you can use {nameof(AddressValidator)}
                inside an {nameof(EditForm)}.");
        }

        if (CurrentEditContext.Model is null)
            throw new ArgumentNullException(nameof(CurrentEditContext.Model));


        messageStore = new(CurrentEditContext);

        CurrentEditContext.OnValidationRequested += CurrentEditContext_OnValidationRequested;
        CurrentEditContext.OnFieldChanged += CurrentEditContext_OnFieldChanged;
    }

    private void CurrentEditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
    {
        messageStore!.Clear(e.FieldIdentifier);
        //ValidateField(e.);
        //messageStore!.Clear();
        //ValidateForm();
        CurrentEditContext!.NotifyValidationStateChanged();
    }

    private void CurrentEditContext_OnValidationRequested(object? sender, ValidationRequestedEventArgs e)
    {
        messageStore!.Clear();
        ValidateForm();
        CurrentEditContext!.NotifyValidationStateChanged();
    }

    public void DisplayErrors(Dictionary<string, List<string>> errors)
    {
        if (CurrentEditContext is not null)
        {
            foreach (KeyValuePair<string, List<string>> err in errors)
            {
                messageStore?.Add(CurrentEditContext.Field(err.Key), err.Value);
            }

            CurrentEditContext.NotifyValidationStateChanged();
        }
    }

    public void ClearErrors()
    {
        messageStore!.Clear();
        CurrentEditContext?.NotifyValidationStateChanged();
    }

    private void ValidateForm()
    {
        foreach (KeyValuePair<string, object[]> field in fields)
        {
            ValidateField(field);
        }
        ValidateOptionalFields();
    }

    private void ValidateOptionalFields()
    {


    }

    private void ValidateField(KeyValuePair<string, object[]> field)
    {
        foreach (object? attibute in field.Value)
        {
            if (attibute is RequiredAttribute requiredAttribute)
            {
                ValidateEmptyField(field.Key, requiredAttribute.ErrorMessage);
            }
        }
    }

    private void ValidateEmptyField(string fieldName, string errorMessage)
    {
        object? value = GetFieldValue(fieldName);
        if (value == null || value == default)
        {
            FieldIdentifier fieldId = CurrentEditContext!.Field(fieldName);
            messageStore!.Add(fieldId, errorMessage);
        }
    }

    private IEnumerable<object?> GetFieldsValues(IEnumerable<KeyValuePair<string, object[]>> fields)
    {
        foreach (KeyValuePair<string, object[]> field in fields)
        {
            yield return GetFieldValue(field.Key);
        }
    }

    private object? GetFieldValue(string fieldName)
    {
        return new();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
                CurrentEditContext.OnValidationRequested -= CurrentEditContext_OnValidationRequested;
                CurrentEditContext.OnFieldChanged -= CurrentEditContext_OnFieldChanged;
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~AddressValidator()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}