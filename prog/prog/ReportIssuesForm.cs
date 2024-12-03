using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace prog
{
    public partial class ReportIssuesForm : Form
    {
        // List to hold issues
        private List<Issue> issuesList = new List<Issue>();

        public ReportIssuesForm()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        // Event handlers
        private void TxtLocation_Enter(object sender, EventArgs e)
        {
            if (txtLocation.Text == "Enter the location of the issue...")
            {
                txtLocation.Text = "";
                txtLocation.ForeColor = Color.Black;
            }
        }

        private void TxtLocation_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLocation.Text))
            {
                txtLocation.Text = "Enter the location of the issue...";
                txtLocation.ForeColor = Color.Gray;
            }
        }

        private void BtnAttachFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("File attached successfully: " + openFileDialog.FileName);
                lblProgress.Text = "File attached!";
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            // Create a new issue from the form inputs
            var issue = new Issue
            {
                location = txtLocation.Text,
                Category = cmbCategory.SelectedItem?.ToString(),
                Description = rtbDescription.Text,
                Path = openFileDialog.FileName
            };

            // Add the issue to the list
            issuesList.Add(issue);

            // Bind the list to the DataGridView
            dvgReportedIssues.DataSource = null; // Clear previous binding
            dvgReportedIssues.DataSource = issuesList; // Re-bind to the updated list

            // Update the UI
            MessageBox.Show("Issue reported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar.Value = 100;
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dvgReportedIssues_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell clicks if necessary
        }

        private void InitializeDataGridView()
        {
            dvgReportedIssues.AutoGenerateColumns = false;
            dvgReportedIssues.ColumnCount = 4;

            dvgReportedIssues.Columns[0].Name = "Location";
            dvgReportedIssues.Columns[0].DataPropertyName = "Location";
            dvgReportedIssues.Columns[1].Name = "Category";
            dvgReportedIssues.Columns[1].DataPropertyName = "Category";
            dvgReportedIssues.Columns[2].Name = "Description";
            dvgReportedIssues.Columns[2].DataPropertyName = "Description";
            dvgReportedIssues.Columns[3].Name = "File Path";
            dvgReportedIssues.Columns[3].DataPropertyName = "Path"; // Ensure this matches the property in Issue class

            Controls.Add(dvgReportedIssues);
        }
    }

}
