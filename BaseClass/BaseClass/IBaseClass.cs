using System.Collections.Generic;

namespace BaseClass
{
    public interface IBaseClass<T>
    {
        /// <summary>
        /// Adds the specified instance to the current list.
        /// </summary>
        /// <param name="obj">The <see cref="T"/> instance that is being added to the current list.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="obj"/> is <c>null</c>.
        /// </exception>
        void BCAdd(T obj);

        /// <summary>
        /// Replaces the list's instance at the calculated index with che given instance.
        /// </summary>
        /// <param name="obj">The <see cref="T"/> instance that is being substituted.</param>
        /// <exception cref="System.ArgumentNullException">
        /// <paramref name="obj"/> is null.
        /// </exception>
        void BCUpdate(T obj);

        /// <summary>
        /// Removes and Disposes all the contained instances in the given list from the current list.
        /// </summary>
        /// <param name="list">The <see cref="List{T}"/> list is being removed.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="list"/> is empty.
        /// </exception>
        void BCRemove(List<T> list);

        /// <summary>
        /// Saves the given list on CSV File.
        /// </summary>
        /// <param name="list">The <see cref="List{T}"/> where Data are taken from.</param>
        /// <param name="path">The path where the file is being saved.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="list"/> is empty.
        /// </exception>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="path"/> is inaccesible.
        /// </exception>
        void BCSaveCSV(IEnumerable<T> items, string path);

        /// <summary>
        /// Deserialize the given CSV File into a list.
        /// </summary>
        /// <param name="fileName">The CSV File where Data are taken from.</param>
        /// <exception cref="System.ArgumentException">
        /// <paramref name="fileName"/> is inaccessible.
        /// </exception>
        List<T> BCDeserializeObject<T>(string fileName);

        /// <summary>
        /// Stores the first half of the given list in list1 and the second in list2.
        /// </summary>
        /// <param name="list1"> Contains the first half of the current list.</param>
        /// <param name="list2">Contains the second half of the current list.</param>
        void BCDivideList(List<T> list1, List<T> list2);
    }
}