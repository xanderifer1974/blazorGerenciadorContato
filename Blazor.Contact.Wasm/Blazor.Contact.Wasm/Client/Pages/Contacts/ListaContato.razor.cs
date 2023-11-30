using Blazor.Contact.Wasm.Client.Services;
using Blazor.Contact.Wasm.Shared;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Blazor.Contact.Wasm.Client.Pages.Contacts
{
    public partial class ListaContato
    {
        [Inject]
        public IContactService ContactService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public IEnumerable<Contato> Contacts { get; set; }        

        public string Message { get; set; }


        protected async override Task OnInitializedAsync()
        {
            try
            {
                Contacts = await ContactService.GetAll();
            }
            catch (System.Exception e)
            {

                Message = "Error... " + e.Message;
            }
        }
    }
}
