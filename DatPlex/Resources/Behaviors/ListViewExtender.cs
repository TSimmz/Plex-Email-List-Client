﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DatPlex.Resources.Behaviors
{
    public class ListViewExtender : DependencyObject
    {
        #region Properties

        public static readonly DependencyProperty AutoScrollToCurrentItemProperty = DependencyProperty.RegisterAttached("AutoScrollToCurrentItem", typeof(bool), typeof(ListViewExtender), new UIPropertyMetadata(default(bool), OnAutoScrollToCurrentItemChanged));

        /// <summary>
        /// Returns the value of the AutoScrollToCurrentItemProperty
        /// </summary>
        /// <param name="obj">The dependency-object whichs value should be returned</param>
        /// <returns>The value of the given property</returns>
        public static bool GetAutoScrollToCurrentItem(DependencyObject obj)
        {
            return (bool)obj.GetValue(AutoScrollToCurrentItemProperty);
        }

        /// <summary>
        /// Sets the value of the AutoScrollToCurrentItemProperty
        /// </summary>
        /// <param name="obj">The dependency-object whichs value should be set</param>
        /// <param name="value">The value which should be assigned to the AutoScrollToCurrentItemProperty</param>
        public static void SetAutoScrollToCurrentItem(DependencyObject obj, bool value)
        {
            obj.SetValue(AutoScrollToCurrentItemProperty, value);
        }

        #endregion

        #region Events

        /// <summary>
        /// This method will be called when the AutoScrollToCurrentItem
        /// property was changed
        /// </summary>
        /// <param name="s">The sender (the ListView)</param>
        /// <param name="e">Some additional information</param>
        public static void OnAutoScrollToCurrentItemChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {
            var listBox = s as ListView;
            if (listBox != null)
            {
                var listBoxItems = listBox.Items;
                if (listBoxItems != null)
                {
                    var newValue = (bool)e.NewValue;

                    var autoScrollToCurrentItemWorker = new EventHandler((s1, e2) => OnAutoScrollToCurrentItem(listBox, listBox.Items.CurrentPosition));

                    if (newValue)
                        listBoxItems.CurrentChanged += autoScrollToCurrentItemWorker;
                    else
                        listBoxItems.CurrentChanged -= autoScrollToCurrentItemWorker;
                }
            }
        }

        /// <summary>
        /// This method will be called when the ListView should
        /// be scrolled to the given index
        /// </summary>
        /// <param name="listBox">The ListView which should be scrolled</param>
        /// <param name="index">The index of the item to which it should be scrolled</param>
        public static void OnAutoScrollToCurrentItem(ListView listBox, int index)
        {
            try
            {
                if (listBox != null && listBox.Items != null && listBox.Items.Count > index && index >= 0)
                    listBox.ScrollIntoView(listBox.Items[index]);
            }
            catch (Exception e)
            { }

        }

        #endregion
    }
}
