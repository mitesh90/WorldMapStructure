﻿using System.Windows;
using System.Windows.Media;
using System.Collections.Generic;
using System.Windows.Controls;

namespace WorldMap.WpfCommon
{
    public static class clsUIHelpers
    {
        /// <summary>
        /// Finds a parent of a given item on the visual tree.
        /// </summary>
        /// <typeparam name="T">The type of the queried item.</typeparam>
        /// <param name="child">A direct or indirect child of the
        /// queried item.</param>
        /// <returns>The first parent item that matches the submitted
        /// type parameter. If not matching item can be found, a null
        /// reference is being returned.</returns>
        public static T TryFindParent<T>(DependencyObject child) where T : DependencyObject
        {
            //get parent item
            DependencyObject parentObject = GetParentObject(child);

            //we've reached the end of the tree
            if (parentObject == null) return null;

            //check if the parent matches the type we're looking for
            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                //use recursion to proceed with next level
                return TryFindParent<T>(parentObject);
            }
        }

        /// <summary>
        /// This method is an alternative to WPF's
        /// <see cref="VisualTreeHelper.GetParent"/> method, which also
        /// supports content elements. Keep in mind that for content element,
        /// this method falls back to the logical tree of the element!
        /// </summary>
        /// <param name="child">The item to be processed.</param>
        /// <returns>The submitted item's parent, if available. Otherwise
        /// null.</returns>
        public static DependencyObject GetParentObject(this DependencyObject child)
        {
            if (child == null) return null;

            //handle content elements separately
            ContentElement contentElement = child as ContentElement;
            if (contentElement != null)
            {
                DependencyObject parent = ContentOperations.GetParent(contentElement);
                if (parent != null) return parent;

                FrameworkContentElement fce = contentElement as FrameworkContentElement;
                return fce != null ? fce.Parent : null;
            }

            //also try searching for parent in framework elements (such as DockPanel, etc)
            FrameworkElement frameworkElement = child as FrameworkElement;
            if (frameworkElement != null)
            {
                DependencyObject parent = frameworkElement.Parent;
                if (parent != null) return parent;
            }

            //if it's not a ContentElement/FrameworkElement, rely on VisualTreeHelper
            return VisualTreeHelper.GetParent(child);
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            // Confirm parent and childName are valid.    
            if (parent == null) return null;
            T foundChild = null;
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);
                // If the child is not of the request child type child    
                T childType = child as T;
                if (childType == null)
                {
                    // recursively drill down the tree       
                    foundChild = FindChild<T>(child, childName);
                    // If the child is found, break so we do not overwrite the found child.      
                    if (foundChild != null) break;
                }
                else if (!string.IsNullOrEmpty(childName))
                {
                    var frameworkElement = child as FrameworkElement;
                    // If the child's name is set for search      
                    if (frameworkElement != null && frameworkElement.Name == childName)
                    {         // if the child's name is of the request name       
                        foundChild = (T)child;
                        break;
                    }
                }
                else
                {
                    // child element found.       
                    foundChild = (T)child;
                    break;
                }
            }
            return foundChild;
        }
        /// <summary>
        /// Method to get child control of specified type
        /// </summary>
        /// <typeparam name="T">Type of child control queried</typeparam>
        /// <param name="parent">Reference of parent control in which child control resides</param>
        /// <returns>Returns reference of child control of specified type (T) if found, otherwise it will return null.</returns>
        public static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent == null) return null;
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is T)
                    return (T)child;
                else
                {
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        /// <summary>
        /// Method to get child control of specified type
        /// </summary>
        /// <typeparam name="T">Type of child control queried</typeparam>
        /// <param name="parent">Reference of parent control in which child control resides</param>
        /// <returns>Returns reference of child control of specified type (T) if found, otherwise it will return null.</returns>
        public static List<UserControl> FindVisualChilds(DependencyObject parent) //where T : DependencyObject
        {
            var list = new List<UserControl>();
            if (parent == null) return null;

            var ddd = FindChild<UserControl>(parent, string.Empty);
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                if (child != null && child is UserControl)
                    list.Add(child as UserControl);
                else
                {
                    UserControl childOfChild = FindVisualChild<UserControl>(child);
                    if (childOfChild != null)
                        list.Add(childOfChild);
                }
            }
            return list;
        }

        ///summary  
        ///  Helper to search up the VisualTree
        ///summary
        public static T FindAnchestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
    }

}