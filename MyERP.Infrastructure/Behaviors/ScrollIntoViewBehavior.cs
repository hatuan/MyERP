using System;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;
using Telerik.Windows.Controls.GridView;

namespace MyERP.Infrastructure.Behaviors
{
    public class ScrollIntoViewBehavior : Behavior<RadGridView>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
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
                        {
                            row.IsCurrent = true;
                            row.Focus();
                        }

                        grid.CurrentCellInfo = new GridViewCellInfo(grid.SelectedItem, grid.Columns[0]);
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
