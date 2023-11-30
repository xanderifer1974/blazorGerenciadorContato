using Blazor.Contact.Wasm.Client.Services;
using Blazor.Contact.Wasm.Shared;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.Contact.Wasm.Client.Pages.Contacts
{
    public partial class  ContactDetails
    {
        [Inject]
        public IContactService ContactService { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public Contato Contact { get; set; }

        [Parameter]
        public int id { get; set; }

        protected  async override Task OnInitializedAsync()
        {
            if(id ==0)
                 Contact = new Contato();
            else
                Contact = await ContactService.GetById(id);
        }

        protected async Task Save()
        {
            await ContactService.SaveContact(Contact);
            NavigateHome();
        }

        private void NavigateHome()
        {
            NavigationManager.NavigateTo("/");
        }
    }
}
