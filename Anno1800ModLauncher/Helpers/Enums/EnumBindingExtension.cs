using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

/// <summary>
/// based on: https://brianlagunas.com/a-better-way-to-data-bind-enums-in-wpf/
/// </summary>
namespace Anno1800ModLauncher.Helpers.Enums
{
    public class EnumBindingExtension : MarkupExtension
    {

        public Type EnumType { get; set; }

        public EnumBindingExtension(Type enumType) {
            if (enumType is null || !enumType.IsEnum) {
                throw new Exception("fuck");
            }
            EnumType = enumType;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(EnumType);
        }
    }

    public class EnumDescriptionConverter : EnumConverter 
    {
        public EnumDescriptionConverter(Type type) : base(type)
        { 
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string))
            {
                if (value != null)
                {
                    FieldInfo fi = value.GetType().GetField(value.ToString());
                    if (fi != null)
                    {
                        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                        return ((attributes.Length > 0) && (!String.IsNullOrEmpty(attributes[0].Description))) ? attributes[0].Description : value.ToString();
                    }
                }

                return string.Empty;
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
