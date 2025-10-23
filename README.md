# how-to-show-or-hide-accordion-item-in-.net-maui-accordion

This sample shows how to show or hide an Accordion item in a .NET MAUI application using Syncfusion's SfAccordion control and BindableLayout. 

## Overview

The core idea is to populate `SfAccordion` with items using `BindableLayout.ItemsSource` and a `DataTemplate` that creates `AccordionItem` instances. Showing or hiding an item can be achieved by manipulating the underlying collection exposed by the page's `BindingContext` (for example, adding/removing items or toggling a boolean on the model and conditionally creating the template). The recommended approach keeps UI logic in the ViewModel so it is testable and works consistently across platforms.

Reference

- Official Getting Started (UG): [Getting Started with MAUI Accordion](https://help.syncfusion.com/maui/accordion/getting-started)

Key points

- Use `BindableLayout.ItemsSource` with `SfAccordion` to generate items from a collection.
- Use a view model (for example `ContactViewModel`) exposing an observable collection such as `ObservableCollection<Contact>` or similar.
- To show/hide items, update the collection (add/remove) or bind a visibility flag on the model and control the template generation in code-behind or with a converter.

## XAML 

The snippet below is taken from the sample project's `MainPage.xaml`. It demonstrates binding the `SfAccordion` to a `ContactsInfo` collection on the page view-model and using a `DataTemplate` to produce each `AccordionItem`.

```
    <ContentPage.BindingContext>
        <local:ContactViewModel />
    </ContentPage.BindingContext>

    <ContentPage.Behaviors>
        <local:Behavior />
    </ContentPage.Behaviors>

    <ContentPage.Content>
        <Grid x:Name="mainGrid">
            <Grid.RowDefinitions>
                <RowDefinition Height="50" />
                <RowDefinition Height="*" />
            </Grid.RowDefinitions>
            <Button x:Name="HideOrShow"
                    Text="Hide / Show item" />
            <syncfusion:SfAccordion x:Name="Accordion"
                                    Grid.Row="1"
                                    ExpandMode="MultipleOrNone"
                                    BindableLayout.ItemsSource="{Binding ContactsInfo}">
                <BindableLayout.ItemTemplate>
                    <DataTemplate>
                        <syncfusion:AccordionItem Margin="10">
                            <syncfusion:AccordionItem.Header>
                                <Grid HeightRequest="50">
                                    <Label Text="{Binding ContactName}" />
                                </Grid>
                            </syncfusion:AccordionItem.Header>
                            <syncfusion:AccordionItem.Content>
                                <Grid HeightRequest="50"
                                      Padding="10">
                                    <Label Text="{Binding CallTime}" />
                                </Grid>
                            </syncfusion:AccordionItem.Content>
                        </syncfusion:AccordionItem>
                    </DataTemplate>
                </BindableLayout.ItemTemplate>
            </syncfusion:SfAccordion>
        </Grid>
    </ContentPage.Content>
```

## How to show or hide an item

There are multiple ways to control which items are visible:

- Modify the collection: remove an item from the `ContactsInfo` collection to hide it; add it back to show it again. Using an `ObservableCollection<T>` will automatically update the UI.
- Use a property on the model: include a boolean such as `IsVisible` on your item model. Then use code-behind or a view-model to filter the collection (for example, expose a filtered view or a separate collection bound to the `SfAccordion`).
- Conditional generation: in code-behind, when preparing items, you can skip creating items for which `IsVisible` is false.

##### Conclusion

I hope you enjoyed learning about how to show or hide accordion item in .NET MAUI Accordion(SfAccordion).

You can refer to our [.NET MAUI Accordion](https://www.syncfusion.com/maui-controls/maui-accordion) feature tour page to know about its other groundbreaking feature representations. You can also explore our [.NET MAUI Accordion documentation](https://help.syncfusion.com/maui/accordion/getting-started) to understand how to present and manipulate data.

For current customers, you can check out our components from the [License and Downloads](https://www.syncfusion.com/account/login) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to check out our other controls.

If you have any queries or require clarifications, please let us know in the comments section below. You can also contact us through our [support forums](https://www.syncfusion.com/forums/), [Direct-Trac](https://support.syncfusion.com/create), or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sflistview). We are always happy to assist you!
