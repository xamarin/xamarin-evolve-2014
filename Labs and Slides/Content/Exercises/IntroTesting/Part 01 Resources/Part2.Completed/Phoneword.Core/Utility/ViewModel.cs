using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Phoneword.Core
{
    /// <summary>
    /// This class implements the simplest view model -- one that implements INPC.
    /// </summary>
    public class ViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        /// <summary>
        /// This raises the INotifyPropertyChanged.PropertyChanged event to indicate
        /// a specific property has changed value. This version provides a compile-time safe
        /// way to indicate the property through the use of an expression tree / lambda.
        /// Be aware that for high-volume changes this version might be much slower than
		/// the below "magic-string" version due to the creation of an expression and runtime lookup.
        /// </summary>
		/// <code>
        ///    public string Name
        ///    {
        ///       get { return _name; }
        ///       set
        ///       {
        ///           _name = value;
        ///           RaisePropertyChanged(() => Name);
        ///       }
        ///    }
		/// </code>
        /// <typeparam name="T">Type where it is being raised</typeparam>
		/// <param name="propExpr">Expression for the property that was changed</param>
        protected void RaisePropertyChanged<T>(Expression<Func<T>> propExpr)
        {
            var prop = (PropertyInfo)((MemberExpression)propExpr.Body).Member;
            this.RaisePropertyChanged(prop.Name);
        }

        /// <summary>
        /// This raises the INotifyPropertyChanged.PropertyChanged event to indicate
        /// a specific property has changed value.
        /// </summary>
		/// <code>
		///    public string Name
		///    {
		///       get { return _name; }
		///       set
		///       {
		///           _name = value;
		///           RaisePropertyChanged();
		///       }
		///    }
		/// </code>
		/// <param name="propertyName">Property name that was changed</param>
        protected void RaisePropertyChanged([CallerMemberName] string propertyName= "")
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
