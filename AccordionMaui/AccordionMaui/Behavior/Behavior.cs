using Syncfusion.Maui.Accordion;
using Syncfusion.Maui.Core.Carousel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccordionMaui
{
    public class Behavior: Behavior<ContentPage>
    {
        Contact? deletedItem = null;
        SfAccordion? accordion;
        Button? HideOrShow;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            accordion = bindable.FindByName<SfAccordion>("Accordion");
            HideOrShow = bindable.FindByName<Button>("HideOrShow");
            HideOrShow.Clicked += OnHideOrShow;
        }
        private void OnHideOrShow(object? sender, EventArgs e)
        {
            var items = (sender as Button)!.BindingContext as ContactViewModel;

            if (deletedItem == null)
            {
                deletedItem = items!.ContactsInfo![2];
                items.ContactsInfo.RemoveAt(2);
            }
            else
            {
                items!.ContactsInfo!.Insert(2, deletedItem);
                deletedItem = null;
            }
        }
    }
}
