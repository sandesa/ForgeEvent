using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace ForgeEventApp.Functions;

public class Validations : IValidations
{
    private readonly IEventRepository _eventRepository;
    private EditContext _editContext;

    public Validations(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    private bool formValid = false;
    public bool isFormValid => formValid;

    public async Task<bool> SubmitFormAsync(Action formSubmit)
    {
        formSubmit();

        if(_editContext == null)
        {
            formValid = true;
        }
        else
        {
            formValid = false;
        }

        return await Task.FromResult(isFormValid);
    }

    public async Task RestValidFormBool()
    {
        formValid = false;
    }


    public string DisplayCategory(object category)
    {
        string changed = "";

        foreach(char c in category.ToString())
        {
            if (c == '_')
            {
                changed += " ";
            }
            else
            {
                changed += c;
            }
        }

        return changed;
    }

    public async Task<bool> ValidateTicketAmountLeft(int ticketAmount, int id)
    {
        return ticketAmount > 0;
    }
}