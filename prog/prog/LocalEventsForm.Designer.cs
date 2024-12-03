using System.Windows.Forms;

namespace prog
{
    public partial class LocalEventsForm : Form
    {
        // Declare UI components
        private Label labelLocalEvents;
        private ListView listViewEvents;
        private ComboBox comboBoxCategory;
        private DateTimePicker dateTimePicker;
        private TextBox textBoxSearch;
        private Button btnSearch;
        private Label labelRecommendations;
        private Button btnRecentSearch;
        private Button btnClearSearch;
        private RichTextBox richTextBoxAnnouncements;

        private void InitializeComponent()
        {
            this.labelLocalEvents = new System.Windows.Forms.Label();
            this.listViewEvents = new System.Windows.Forms.ListView();
            this.comboBoxCategory = new System.Windows.Forms.ComboBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.labelRecommendations = new System.Windows.Forms.Label();
            this.btnRecentSearch = new System.Windows.Forms.Button();
            this.btnClearSearch = new System.Windows.Forms.Button();
            this.richTextBoxAnnouncements = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // Add columns to the ListView
            this.listViewEvents.Columns.Add("Event Name", 200);
            this.listViewEvents.Columns.Add("Category", 100);
            this.listViewEvents.Columns.Add("Date", 100);

            // Ensure the ListView is in Details view mode
            this.listViewEvents.View = View.Details;
            // 
            // labelLocalEvents
            // 
            this.labelLocalEvents.AutoSize = true;
            this.labelLocalEvents.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.labelLocalEvents.Location = new System.Drawing.Point(100, 20);
            this.labelLocalEvents.Name = "labelLocalEvents";
            this.labelLocalEvents.Size = new System.Drawing.Size(405, 29);
            this.labelLocalEvents.TabIndex = 0;
            this.labelLocalEvents.Text = "Local Events and Announcements";
            // 
            // listViewEvents
            // 
            this.listViewEvents.HideSelection = false;
            this.listViewEvents.Location = new System.Drawing.Point(50, 70);
            this.listViewEvents.Name = "listViewEvents";
            this.listViewEvents.Size = new System.Drawing.Size(500, 150);
            this.listViewEvents.TabIndex = 1;
            this.listViewEvents.UseCompatibleStateImageBehavior = false;
            this.listViewEvents.View = System.Windows.Forms.View.Details;
            // 
            // comboBoxCategory
            // 
            this.comboBoxCategory.FormattingEnabled = true;
            this.comboBoxCategory.Items.AddRange(new object[] {
            "Music",
            "Sports",
            "Tech",
            "Education",
            "Arts"});
            this.comboBoxCategory.Location = new System.Drawing.Point(50, 240);
            this.comboBoxCategory.Name = "comboBoxCategory";
            this.comboBoxCategory.Size = new System.Drawing.Size(150, 24);
            this.comboBoxCategory.TabIndex = 2;
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(220, 240);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker.TabIndex = 3;
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.ForeColor = System.Drawing.Color.Gray;
            this.textBoxSearch.Location = new System.Drawing.Point(50, 280);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(370, 22);
            this.textBoxSearch.TabIndex = 4;
            this.textBoxSearch.Text = "Enter event name...";
            this.textBoxSearch.Enter += new System.EventHandler(this.textBoxSearch_Enter);
            this.textBoxSearch.Leave += new System.EventHandler(this.textBoxSearch_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(440, 280);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // labelRecommendations
            // 
            this.labelRecommendations.AutoSize = true;
            this.labelRecommendations.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.labelRecommendations.Location = new System.Drawing.Point(50, 330);
            this.labelRecommendations.Name = "labelRecommendations";
            this.labelRecommendations.Size = new System.Drawing.Size(393, 19);
            this.labelRecommendations.TabIndex = 6;
            this.labelRecommendations.Text = "Recommended Events Based on Your Searches: ";
            // 
            // btnRecentSearch
            // 
            this.btnRecentSearch.Location = new System.Drawing.Point(166, 370);
            this.btnRecentSearch.Name = "btnRecentSearch";
            this.btnRecentSearch.Size = new System.Drawing.Size(150, 30);
            this.btnRecentSearch.TabIndex = 7;
            this.btnRecentSearch.Text = "Show Recent Search";
            this.btnRecentSearch.UseVisualStyleBackColor = true;
            this.btnRecentSearch.Click += new System.EventHandler(this.btnRecentSearch_Click);
            // 
            // btnClearSearch
            // 
            this.btnClearSearch.Location = new System.Drawing.Point(374, 370);
            this.btnClearSearch.Name = "btnClearSearch";
            this.btnClearSearch.Size = new System.Drawing.Size(150, 30);
            this.btnClearSearch.TabIndex = 8;
            this.btnClearSearch.Text = "Clear Search";
            this.btnClearSearch.UseVisualStyleBackColor = true;
            this.btnClearSearch.Click += new System.EventHandler(this.btnClearSearch_Click);
            // 
            // richTextBoxAnnouncements
            // 
            this.richTextBoxAnnouncements.Location = new System.Drawing.Point(50, 420);
            this.richTextBoxAnnouncements.Name = "richTextBoxAnnouncements";
            this.richTextBoxAnnouncements.Size = new System.Drawing.Size(500, 150);
            this.richTextBoxAnnouncements.TabIndex = 9;
            this.richTextBoxAnnouncements.Text = "Announcement: A new library will be built in the area starting next month.";
            // 
            // LocalEventsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSteelBlue;
            this.ClientSize = new System.Drawing.Size(718, 600);
            this.Controls.Add(this.richTextBoxAnnouncements);
            this.Controls.Add(this.btnClearSearch);
            this.Controls.Add(this.btnRecentSearch);
            this.Controls.Add(this.labelRecommendations);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.comboBoxCategory);
            this.Controls.Add(this.listViewEvents);
            this.Controls.Add(this.labelLocalEvents);
            this.Name = "LocalEventsForm";
            this.Text = "Local Events and Announcements";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
