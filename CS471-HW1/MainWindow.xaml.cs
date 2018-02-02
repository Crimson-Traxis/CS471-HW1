using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CS471_HW1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Modles.CartItem> CartItems = new ObservableCollection<Modles.CartItem>();
        public List<string> MenuItems = new List<string> { "Store", "Cart", "Summary" };

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();

            CartItemsListBox.DataContext = CartItems;
            MenuListBox.DataContext = MenuItems;

            LoadScreen("Store");

            CartItems.CollectionChanged += CartItems_CollectionChanged;

            CartItems.Add(new Modles.CartItem { ItemId = "", Name = "Text", Quantity = 7 });
            CartItems.Add(new Modles.CartItem { ItemId = "", Name = "Text1", Quantity = 6 });
            CartItems.Add(new Modles.CartItem { ItemId = "", Name = "Text2", Quantity = 5 });
            CartItems.Add(new Modles.CartItem { ItemId = "", Name = "Text3", Quantity = 4 });
            CartItems.Add(new Modles.CartItem { ItemId = "", Name = "Text4", Quantity = 3 });
            CartItems.Add(new Modles.CartItem { ItemId = "", Name = "Text5", Quantity = 2 });
            CartItems.Add(new Modles.CartItem { ItemId = "", Name = "Text6", Quantity = 1 });
        }

        private void CartItems_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CountingBadge.Badge = CartItems.Count;
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            //dependencyObject.GetValue()

            LoadScreen(((ListBox)sender).SelectedValue.ToString());

            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        private void LoadScreen(string screen)
        {
            switch(screen)
            {
                case "Store":
                    MainContent.Children.Clear();
                    MainContent.Children.Add(new UserControls.Store());

                    break;
                case "Cart":

                    break;
                case "Summary":

                    break;
            }
        }

        private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        {

            await DialogHost.Show("", "RootDialog");
        }
    }
}
