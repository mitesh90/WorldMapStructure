using System.Windows;
using System.Windows.Controls;

namespace WpfTheme.Controls
{
    public class MenuButton : Button
    {
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set { SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty, OnTitlePropertyChanged));

        private static void OnTitlePropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {

        }

        public string Description
        {
            get
            {
                return (string)GetValue(DescriptionProperty);
            }
            set { SetValue(DescriptionProperty, value); }
        }
        public static readonly DependencyProperty DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(MenuButton), new PropertyMetadata(string.Empty, OnDescriptionPropertyPropertyChanged));

        private static void OnDescriptionPropertyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {

        }

        public Style PathStyle
        {
            get
            {
                return (Style)GetValue(PathStyleProperty);
            }
            set { SetValue(PathStyleProperty, value); }
        }
        public static readonly DependencyProperty PathStyleProperty = DependencyProperty.Register("PathStyle", typeof(Style), typeof(MenuButton), new PropertyMetadata(null, OnPathStylePropertyPropertyChanged));

        private static void OnPathStylePropertyPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {

        }

        public bool IsFirstButton
        {
            get
            {
                return (bool)GetValue(IsFirstButtonProperty);
            }
            set { SetValue(IsFirstButtonProperty, value); }
        }

        public static readonly DependencyProperty IsFirstButtonProperty = DependencyProperty.Register("IsFirstButton", typeof(bool), typeof(MenuButton), new PropertyMetadata(false, OnIsFirstButtonPropertyChanged));
        private static void OnIsFirstButtonPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {

        }

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected", typeof(bool), typeof(MenuButton), new PropertyMetadata(false, OnIsSelectedPropertyChanged));
        private static void OnIsSelectedPropertyChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
