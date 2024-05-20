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



    public async Task<bool> ValidateTicketAmountLeft(int ticketAmount, int id)
    {
        int amount = ticketAmount;
        int eventId = id;
        int ticketAmountLeft = await _eventRepository.GetTicketAmountAsync(eventId);

        if (ticketAmountLeft > amount)
        {
            return false;
        }

        return true;
    }
}