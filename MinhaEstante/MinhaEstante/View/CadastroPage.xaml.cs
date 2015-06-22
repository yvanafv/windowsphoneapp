using MinhaEstante.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace MinhaEstante.View
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CadastroPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        public CadastroPage()
        {
            this.InitializeComponent();

            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        //#region Password

        //public string Password
        //{
        //    get { return (string)GetValue(PasswordProperty); }
        //    set { SetValue(PasswordProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PasswordProperty =
        //    DependencyProperty.Register("Password", typeof(string), typeof(NumericPasswordBox), new PropertyMetadata(null));

        //#endregion

        //#region MaxLength

        //public int MaxLength
        //{
        //    get { return (int)GetValue(MaxLengthProperty); }
        //    set { SetValue(MaxLengthProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MaxLength.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty MaxLengthProperty =
        //    DependencyProperty.Register("MaxLength", typeof(int), typeof(NumericPasswordBox), new PropertyMetadata(100));

        //#endregion

        //public NumericPasswordBox()
        //{
        //    InitializeComponent();

        //}

        //private void PasswordTextBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        //{
        //    Password = PasswordTextBox.Text;

        //    //replace text by *
        //    PasswordTextBox.Text = Regex.Replace(Password, @".", "?");

        //    //take cursor to end of string
        //    PasswordTextBox.SelectionStart = PasswordTextBox.Text.Length;
        //}

        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }


        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }


        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }


        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        #region NavigationHelper registration

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion
    }

}
