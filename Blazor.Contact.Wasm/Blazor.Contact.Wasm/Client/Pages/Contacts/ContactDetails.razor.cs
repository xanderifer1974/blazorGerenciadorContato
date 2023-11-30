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

        protected  async override Task OnInitializedAsync()
        {
            Contact = new Contato();
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
