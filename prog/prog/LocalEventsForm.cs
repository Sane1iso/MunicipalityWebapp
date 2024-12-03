using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace prog
{
    public partial class LocalEventsForm : Form
    {
        // Data structures
        private SortedDictionary<DateTime, Queue<Event>> eventQueue;   // Store events by date
        private HashSet<string> categoriesSet;                         // Store unique categories
        private Dictionary<string, int> searchHistory;                 // Track search patterns
        private Stack<Event> recentSearchResults;                      // Store recent searches

        // Placeholder related fields
        private string placeholderText = "Enter event name...";
        private bool isPlaceholderActive = true;

        public LocalEventsForm()
        {
            InitializeComponent();
            InitializeDataStructures();
            LoadEvents();
        }

        private void InitializeDataStructures()
        {
            // Initialize event data structures
            eventQueue = new SortedDictionary<DateTime, Queue<Event>>();
            categoriesSet = new HashSet<string> { "Music", "Sports", "Tech", "Education" };
            searchHistory = new Dictionary<string, int>();  // Track search patterns
            recentSearchResults = new Stack<Event>();       // Track recent search results
        }

        private void LoadEvents()
        {
            // Example: Load some dummy events
            var event1 = new Event("Music Concert", "Music", new DateTime(2024, 10, 22));
            var event2 = new Event("Tech Conference", "Tech", new DateTime(2024, 10, 23));
            var event3 = new Event("Football Match", "Sports", new DateTime(2024, 10, 24));
            var event4 = new Event("Art Exhibition", "Arts", new DateTime(2024, 11, 05));
            var event5 = new Event("Education Seminar", "Education", new DateTime(2024, 10, 25));
            var event6 = new Event("Basketball Game", "Sports", new DateTime(2024, 10, 28));
            var event7 = new Event("Music Festival", "Music", new DateTime(2024, 11, 02));
            var event8 = new Event("Coding Bootcamp", "Tech", new DateTime(2024, 11, 10));
            var event9 = new Event("Theater Play", "Arts", new DateTime(2024, 11, 08));
            var event10 = new Event("Science Fair", "Education", new DateTime(2024, 11, 15));

            // Add all events to the queue
            AddEvent(event1);
            AddEvent(event2);
            AddEvent(event3);
            AddEvent(event4);
            AddEvent(event5);
            AddEvent(event6);
            AddEvent(event7);
            AddEvent(event8);
            AddEvent(event9);
            AddEvent(event10);

            // Display events in the list view
            DisplayEvents();
        }

        private void AddEvent(Event newEvent)
        {
            // Add event to the sorted dictionary based on the date
            if (!eventQueue.ContainsKey(newEvent.Date))
            {
                eventQueue[newEvent.Date] = new Queue<Event>();
            }

            eventQueue[newEvent.Date].Enqueue(newEvent);
        }

        private void DisplayEvents()
        {
            // Display upcoming events in a ListView
            listViewEvents.Items.Clear();
            foreach (var eventDate in eventQueue.Keys)
            {
                foreach (var evnt in eventQueue[eventDate])
                {
                    ListViewItem item = new ListViewItem(new[] { evnt.Name, evnt.Category, evnt.Date.ToShortDateString() });
                    listViewEvents.Items.Add(item);
                }
            }
        }

        // Search events by category and date
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string selectedCategory = comboBoxCategory.SelectedItem?.ToString();
            DateTime selectedDate = dateTimePicker.Value.Date;
            string searchText = textBoxSearch.Text;

            // Check if placeholder text is active
            if (isPlaceholderActive)
            {
                searchText = null;  // Don't include placeholder text in the search
            }

            var results = SearchEvents(selectedCategory, selectedDate, searchText);
            DisplaySearchResults(results);

            // Add to recent search stack
            if (results.Count > 0)
            {
                recentSearchResults.Push(results.First());
            }

            // Track search history for recommendations
            if (selectedCategory != null)
            {
                if (searchHistory.ContainsKey(selectedCategory))
                {
                    searchHistory[selectedCategory]++;
                }
                else
                {
                    searchHistory[selectedCategory] = 1;
                }
            }

            // Display recommendations based on search history
            DisplayRecommendations();
        }


        private List<Event> SearchEvents(string category, DateTime date, string eventName)
        {
            List<Event> exactMatches = new List<Event>();
            List<Event> closestFutureEvents = new List<Event>();

            // Convert eventName to lower case for case-insensitive search
            eventName = eventName?.ToLower();

            foreach (var eventDate in eventQueue.Keys)
            {
                foreach (var evnt in eventQueue[eventDate])
                {
                    // Check if the event matches the search criteria (name, category, and date)
                    bool isNameMatch = string.IsNullOrWhiteSpace(eventName) || evnt.Name.ToLower().Contains(eventName);
                    bool isCategoryMatch = string.IsNullOrEmpty(category) || evnt.Category == category;
                    bool isDateMatch = eventDate.Date == date;

                    // Exact matches (event name, category, and date)
                    if (isNameMatch && isCategoryMatch && isDateMatch)
                    {
                        exactMatches.Add(evnt);
                    }
                    // Future events with matching name and category
                    else if (isNameMatch && isCategoryMatch && eventDate > date)
                    {
                        closestFutureEvents.Add(evnt);
                    }
                }
            }

            // Return exact matches if found, otherwise closest future events
            if (exactMatches.Count > 0)
            {
                return exactMatches;
            }
            else if (closestFutureEvents.Count > 0)
            {
                // Sort closest future events by date
                return closestFutureEvents.OrderBy(e => e.Date).ToList();
            }

            // Return an empty list if no matches found
            return new List<Event>();
        }


        private void DisplaySearchResults(List<Event> results)
        {
            // Clear existing items and add search results
            listViewEvents.Items.Clear();

            if (results.Count == 0)
            {
                // If no results found, display a message
                ListViewItem noResultsItem = new ListViewItem("No events found for the selected category and date.");
                listViewEvents.Items.Add(noResultsItem);
            }
            else
            {
                foreach (var evnt in results)
                {
                    ListViewItem item = new ListViewItem(new[] { evnt.Name, evnt.Category, evnt.Date.ToShortDateString() });
                    listViewEvents.Items.Add(item);
                }
            }
        }

        private void DisplayRecommendations()
        {
            // Example logic for recommendations based on search history
            string recommendations = "Recommended based on your searches: ";
            var topCategories = searchHistory.OrderByDescending(x => x.Value).Take(3);

            foreach (var category in topCategories)
            {
                recommendations += $"{category.Key} (searched {category.Value} times), ";
            }

            labelRecommendations.Text = recommendations.TrimEnd(',', ' ');
        }

        // Placeholder functionality for search TextBox
        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (isPlaceholderActive)
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.Black;
                isPlaceholderActive = false;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxSearch.Text))
            {
                textBoxSearch.Text = placeholderText;
                textBoxSearch.ForeColor = Color.Gray;
                isPlaceholderActive = true;
            }
        }

        private void btnRecentSearch_Click(object sender, EventArgs e)
        {
            // Logic to display recent searches (example)
            if (recentSearchResults.Count > 0)
            {
                var recentEvent = recentSearchResults.Peek(); // Get the most recent search
                MessageBox.Show($"Most Recent Search: {recentEvent.Name}");
            }
            else
            {
                MessageBox.Show("No recent searches.");
            }
        }
        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            // Clear search fields
            comboBoxCategory.SelectedIndex = -1; // Deselect the category
            dateTimePicker.Value = DateTime.Today; // Reset the date picker to today
            textBoxSearch.Text = placeholderText;  // Reset the search text box to placeholder
            textBoxSearch.ForeColor = Color.Gray;
            isPlaceholderActive = true;

            // Refresh the ListView to show all events
            DisplayEvents();
        }

       
    }

    // Example Event class
    public class Event
    {
        public string Name { get; }
        public string Category { get; }
        public DateTime Date { get; }

        public Event(string name, string category, DateTime date)
        {
            Name = name;
            Category = category;
            Date = date;
        }
    }
}
