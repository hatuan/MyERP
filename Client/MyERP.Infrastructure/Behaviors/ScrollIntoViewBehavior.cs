using System;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace MyERP.Infrastructure.Behaviors
{
    /// <summary>
    /// Use : 
    /// <sdk:DataGrid AutoGenerateColumns="true" ItemsSource="{Binding ObjectList}" SelectedItem="{Binding SelectedObject, Mode=TwoWay}" Name="dataGridObjects">
    ///     <i:Interaction.Behaviors>
    ///         <behaviors:ScrollIntoViewBehavior/>
    ///     </i:Interaction.Behaviors>
    /// </sdk:DataGrid>
    /// </summary>
    public class ScrollIntoViewBehavior : Behavior<RadGridView>
    {
        private GridViewCellInfo currentCellInfo;
        protected override void OnAttached()
        {
            base.OnAttached();
            currentCellInfo = (this.AssociatedObject as RadGridView).CurrentCellInfo;
            this.AssociatedObject.SelectionChanged += new EventHandler<SelectionChangeEventArgs>(AssociatedObject_SelectionChanged);
        }

        void AssociatedObject_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (sender is RadGridView)
            {
                RadGridView grid = (sender as RadGridView);
                if (grid.SelectedItem != null)
                {
                    grid.ScrollIntoViewAsync(grid.SelectedItem, r =>
                    {
                        var row = r as GridViewRow;

                        if (row != null)
                            row.IsSelected = true;
                    });
                }
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectionChanged -= new EventHandler<SelectionChangeEventArgs>(AssociatedObject_SelectionChanged);
        }
    }
}
