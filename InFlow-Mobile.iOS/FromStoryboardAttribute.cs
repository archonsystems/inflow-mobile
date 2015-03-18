using System;

namespace InFlow_Mobile.iOS
{
    public class FromStoryboardAttribute : Attribute
    {
        public string StoryboardName { get; set; }

        public FromStoryboardAttribute(string storyboardName = null)
        {
            StoryboardName = storyboardName;
        }
    }
}