using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Contacts.Model;

namespace Contacts
{
    public static class SectionIndexBuilder
    {
        public static Java.Lang.Object[] BuildSectionHeader(List<Contact> data)
        {
            var results = new List<string>();
            var used = new SortedSet<string>();

            foreach (var item in data)
            {
                var letter = item.Name[0].ToString();

                if (!used.Contains(letter))
                    results.Add(letter);

                used.Add(letter);
            }

            var jObjects = new Java.Lang.Object[results.Count];

            for (var iterator = 0; iterator < results.Count; iterator++)
            {
                jObjects[iterator] = results[iterator];
            }

            return jObjects;
        }

        public static Dictionary<int, int> BuildSectionForPositionMap(List<Contact> contacts)
        {
            var results = new Dictionary<int, int>();
            var used = new SortedSet<string>();
            int section = -1;

            for (int i = 0; i < contacts.Count; i++)
            {
                var letter = contacts[i].Name[0].ToString();

                if (!used.Contains(letter))
                {
                    section++;
                    used.Add(letter);
                }

                results.Add(i, section);
            }

            return results;
        }

        public static Dictionary<int, int> BuildPositionForSectionMap(List<Contact> contacts)
        {
            var results = new Dictionary<int, int>();
            var used = new SortedSet<string>();
            int section = -1;

            for (int i = 0; i < contacts.Count; i++)
            {
                var letter = contacts[i].Name[0].ToString();

                if (!used.Contains(letter))
                {
                    section++;
                    used.Add(letter);
                    results.Add(section, i);
                }
            }

            return results;
        }
    }
}