using System.Windows;
using System.Windows.Controls;

namespace DevX.Resources.Controls
{
    /// <summary>
    /// Interaction logic for LoadingSpinner.xaml
    /// </summary>
    /// 

    public partial class LoadingSpinner : UserControl
    {

        #region Busy DP

        /// <summary>
        /// Gets or sets the Value which is being displayed
        /// </summary>
        public object Busy
        {
            get { return (object)GetValue(BusyProperty); }
            set { SetValue(BusyProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty BusyProperty =
            DependencyProperty.Register("Busy", typeof(object),
              typeof(LoadingSpinner), new PropertyMetadata(null));

        #endregion

        #region Size DP

        /// <summary>
        /// Gets or sets the Value which is being displayed
        /// </summary>
        public object Size
        {
            get { return (object)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(object),
              typeof(LoadingSpinner), new PropertyMetadata(null));

        #endregion

        #region SpinnerHorizontalAlignment DP

        /// <summary>
        /// Gets or sets the Value which is being displayed
        /// </summary>
        public HorizontalAlignment SpinnerHorizontalAlignment
        {
            get { return (HorizontalAlignment)GetValue(SpinnerHorizontalAlignmentProperty); }
            set { SetValue(SpinnerHorizontalAlignmentProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty SpinnerHorizontalAlignmentProperty =
            DependencyProperty.Register("SpinnerHorizontalAlignment", typeof(HorizontalAlignment),
              typeof(LoadingSpinner), new PropertyMetadata(HorizontalAlignment.Center));

        #endregion

        #region SpinnerMargin DP

        /// <summary>
        /// Gets or sets the Value which is being displayed
        /// </summary>
        public object SpinnerMargin
        {
            get { return (object)GetValue(SpinnerMarginProperty); }
            set { SetValue(SpinnerMarginProperty, value); }
        }

        /// <summary>
        /// Identified the Label dependency property
        /// </summary>
        public static readonly DependencyProperty SpinnerMarginProperty =
            DependencyProperty.Register("SpinnerMargin", typeof(object),
              typeof(LoadingSpinner), new PropertyMetadata("0,0,0,0"));

        #endregion

        public LoadingSpinner()
        {
            InitializeComponent();
            MainBorder.DataContext = this;
        }
    }
}
