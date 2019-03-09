namespace WorldMap.Common
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text.RegularExpressions;

    public static class Extensions
    {
        /// <summary>Gets the nested property value.</summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static object GetNestedPropertyValue(this object obj, string propertyName)
        {
            if (obj == null)
                return null;

            foreach (string part in propertyName.Split('.'))
            {
                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);

                if (info == null) { return null; }

                obj = info.GetValue(obj, null);

                if (obj == null)
                    return null;
            }
            return obj;
        }

        /// <summary>Gets the type of the property.</summary>
        /// <param name="obj">The object.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns></returns>
        public static Type GetPropertyType(this Object obj, string propertyName)
        {
            var property = propertyName.Split('.').Last();
            Type type = obj.GetType();
            PropertyInfo info = type.GetProperty(property);
            if (info == null) { return null; }

            return info.PropertyType;
        }

        /// <summary>To the int array.</summary>
        /// <param name="stringValues">The string values.</param>
        /// <returns></returns>
        public static int[] ToIntArray(this string stringValues)
        {
            return stringValues
            .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => Convert.ToInt32(x))
            .ToArray();
        }

        /// <summary>Gets the type of the list.</summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">list is not a List<T>;list</exception>
        public static Type GetListType(this object list)
        {
            Type type = list.GetType();
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
                return type.GetGenericArguments()[0];

            throw new ArgumentException("list is not a List<T>", "list");
        }

        /// <summary>
        /// Determines whether [is valid email].
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static bool IsValidEmail(this string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            email = email.Trim();
            var result = Regex.IsMatch(email, "^(?:[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+\\.)*[\\w\\!\\#\\$\\%\\&\\'\\*\\+\\-\\/\\=\\?\\^\\`\\{\\|\\}\\~]+@(?:(?:(?:[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!\\.)){0,61}[a-zA-Z0-9]?\\.)+[a-zA-Z0-9](?:[a-zA-Z0-9\\-](?!$)){0,61}[a-zA-Z0-9]?)|(?:\\[(?:(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\.){3}(?:[01]?\\d{1,2}|2[0-4]\\d|25[0-5])\\]))$", RegexOptions.IgnoreCase);
            //var result = Regex.IsMatch(email, @"[\w-]+@([\w-]+\.)+[\w-]+", RegexOptions.IgnoreCase);
            return result;
        }

        /// <summary>Gets the file extension.</summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns></returns>
        public static string GetFileExtension(this string fileName)
        {
            string ext = string.Empty;
            int fileExtPos = fileName.LastIndexOf(".", StringComparison.Ordinal);
            if (fileExtPos >= 0)
                ext = fileName.Substring(fileExtPos, fileName.Length - fileExtPos);

            return ext;
        }

        /// <summary>Gets the file information.</summary>
        /// <param name="filePath">The file path.</param>
        /// <returns></returns>
        public static FileInfo GetFileInfo(this string filePath)
        {
            FileInfo fInfo = new FileInfo(filePath);
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string dirName = fInfo.DirectoryName;
            int counter = 1;

            while (fInfo.Exists)
            {
                string extension = fInfo.Extension;
                string nameProper = fileName + "(" + (counter++) + ")";
                filePath = Path.Combine(dirName, nameProper + extension);
                fInfo = new FileInfo(filePath);
            }
            return fInfo;
        }

        /// <summary>Distinct the by.</summary>
        /// <typeparam name="TSource">The type of the source.</typeparam>
        /// <typeparam name="TKey">The type of the key.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="keySelector">The key selector.</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }

        /// <summary>Gets the name of the property.</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyLambda">The property lambda.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'</exception>
        public static string GetPropertyName<T>(Expression<Func<T>> propertyLambda)
        {
            var me = propertyLambda.Body as MemberExpression;
            if (me == null)
            {
                throw new ArgumentException("You must pass a lambda of the form: '() => Class.Property' or '() => object.Property'");
            }
            return me.Member.Name;
        }

        /// <summary>Checks the null or white space.</summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static string CheckNullOrWhiteSpace(this string value, string defaultValue)
        {
            return string.IsNullOrWhiteSpace(value) ? defaultValue : value;
        }

        /// <summary>
        /// Checks the null or white space.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string CheckNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value) ? string.Empty : value;
        }

        /// <summary>Checks the null or zero.</summary>
        /// <param name="value">The value.</param>
        /// <param name="defaultValue">The default value.</param>
        /// <returns></returns>
        public static int CheckNullOrZero(this int value, int defaultValue)
        {
            return value <= 0 ? defaultValue : value;
        }
    }
}