using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace WpfTheme.Controls
{
    public static class ButtonHelper
    {
        public static readonly DependencyProperty PreserveTextCaseProperty =
            DependencyProperty.RegisterAttached("PreserveTextCase", typeof(bool),
                typeof(ButtonHelper),
                new FrameworkPropertyMetadata(false,
                    FrameworkPropertyMetadataOptions.Inherits |
                    FrameworkPropertyMetadataOptions.AffectsMeasure));

        [AttachedPropertyBrowsableForType(typeof(Button))]
        public static bool GetPreserveTextCase(UIElement element)
        {
            return (bool)element.GetValue(PreserveTextCaseProperty);
        }

        public static void SetPreserveTextCase(UIElement element, bool value)
        {
            element.SetValue(PreserveTextCaseProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius),
                typeof(ButtonHelper),
                new FrameworkPropertyMetadata(new CornerRadius(),
                    FrameworkPropertyMetadataOptions.AffectsMeasure |
                    FrameworkPropertyMetadataOptions.AffectsRender));

        [AttachedPropertyBrowsableForType(typeof(Button))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        public static CornerRadius GetCornerRadius(UIElement element)
        {
            return (CornerRadius)element.GetValue(CornerRadiusProperty);
        }

        public static void SetCornerRadius(UIElement element, CornerRadius value)
        {
            element.SetValue(CornerRadiusProperty, value);
        }
    }
}
