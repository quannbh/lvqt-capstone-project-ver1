using QuanLySinhVienThucTap.UserControllerNEU;
using QuanLySinhVienThucTap.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace QuanLySinhVienThucTap.Pages
{
    public partial class QuanLyNhanSu : Page
    {
        public QuanLyNhanSu(string PhongBanUser)
        {
            InitializeComponent();
            QuanLyNhanSuViewModel qlns = new QuanLyNhanSuViewModel();
            qlns.UserDepart = PhongBanUser;
            DataContext = qlns;
        }

        private void QuanLyNhanSu_Loaded(object sender, RoutedEventArgs e)
        {
            if (DataContext is QuanLyNhanSuViewModel viewModel)
            {
                viewModel.OnLoaded();
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("ok");
        }


        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListDuAnItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
        /* private void ThemDuAnButton_Click(object sender, RoutedEventArgs e)
{
//AddProjectWindow addProjectWindow = new AddProjectWindow();
//addProjectWindow.Owner = Application.Current.MainWindow;
// if (addProjectWindow.ShowDialog() == true)
{
string projectName = addProjectWindow.ProjectNameTextBox.Text;
// Tạo một Expander mới
Expander newExpander = new Expander
{
   HorizontalAlignment = HorizontalAlignment.Stretch,
   Header = projectName, // Đặt tên cho Expander mới
   FontWeight = FontWeights.Bold,
   Foreground = Brushes.DarkBlue
};
StackPanel stackPanel = new StackPanel
{
   Margin = new Thickness(24, 8, 24, 16),
   Orientation = Orientation.Vertical
};

// Thêm các chức năng vào StackPanel này
stackPanel.Children.Add(new ListBoxItem { Content = "Thêm nhân sự dự án", FontWeight = FontWeights.Normal, Foreground = Brushes.Black });
stackPanel.Children.Add(new ListBoxItem { Content = "Xóa nhân sự dự án", FontWeight = FontWeights.Normal, Foreground = Brushes.Black });
stackPanel.Children.Add(new ListBoxItem { Content = "Chỉnh sửa dự án", FontWeight = FontWeights.Normal, Foreground = Brushes.Black });

// Đặt StackPanel là nội dung của Expander
newExpander.Content = stackPanel;
Border newborder = new Border
{
   Height = 1,
   Background = Brushes.Black,
   VerticalAlignment = VerticalAlignment.Bottom
};

// Tạo nội dung cho Expander mới, giống như bạn đã làm cho Expander hiện có.

// Thêm Expander mới vào Container
//expanderContainer.Children.Add(newExpander);
//expanderContainer.Children.Add(newborder);
}*/
        // }

    }
}
