using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace prog
{
    public partial class ServiceRequestStatusForm : Form
    {
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.GroupBox grpServiceRequests;
        private System.Windows.Forms.GroupBox grpProgress;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.GroupBox grpDependencies;
        private ComboBox cmbStatusSearch;
        private ComboBox cmbPrioritySearch;
        private Label lblDateSubmitted;
        private Button btnClearFilters;
        private Button btnBack;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.TextBox txtPriority;
        private System.Windows.Forms.DateTimePicker dtpSubmittedDate;



        private void InitializeComponent()
        {
            this.lblDateSubmitted = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.txtPriority = new System.Windows.Forms.TextBox();
            this.dtpSubmittedDate = new System.Windows.Forms.DateTimePicker();
            this.lblTitle = new System.Windows.Forms.Label();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.txtRequestId = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnClearFilters = new System.Windows.Forms.Button();
            this.grpServiceRequests = new System.Windows.Forms.GroupBox();
            this.dgvServiceRequests = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpSearch.SuspendLayout();
            this.grpServiceRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDateSubmitted
            // 
            this.lblDateSubmitted.AutoSize = true;
            this.lblDateSubmitted.Location = new System.Drawing.Point(195, 87);
            this.lblDateSubmitted.Name = "lblDateSubmitted";
            this.lblDateSubmitted.Size = new System.Drawing.Size(102, 16);
            this.lblDateSubmitted.TabIndex = 3;
            this.lblDateSubmitted.Text = "Submitted Date:";
            // 
            // txtStatus
            // 
            this.txtStatus.ForeColor = System.Drawing.Color.Gray;
            this.txtStatus.Location = new System.Drawing.Point(323, 49);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new System.Drawing.Size(200, 22);
            this.txtStatus.TabIndex = 1;
            this.txtStatus.Text = "Status";
            this.txtStatus.Enter += new System.EventHandler(this.TxtStatus_Enter);
            this.txtStatus.Leave += new System.EventHandler(this.TxtStatus_Leave);
            // 
            // txtPriority
            // 
            this.txtPriority.ForeColor = System.Drawing.Color.Gray;
            this.txtPriority.Location = new System.Drawing.Point(323, 21);
            this.txtPriority.Name = "txtPriority";
            this.txtPriority.Size = new System.Drawing.Size(200, 22);
            this.txtPriority.TabIndex = 2;
            this.txtPriority.Text = "Priority";
            this.txtPriority.Enter += new System.EventHandler(this.TxtPriority_Enter);
            this.txtPriority.Leave += new System.EventHandler(this.TxtPriority_Leave);
            // 
            // dtpSubmittedDate
            // 
            this.dtpSubmittedDate.Location = new System.Drawing.Point(323, 81);
            this.dtpSubmittedDate.Name = "dtpSubmittedDate";
            this.dtpSubmittedDate.Size = new System.Drawing.Size(200, 22);
            this.dtpSubmittedDate.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(229, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(382, 35);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Service Request Manager";
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Controls.Add(this.txtRequestId);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtPriority);
            this.grpSearch.Controls.Add(this.txtStatus);
            this.grpSearch.Controls.Add(this.lblDateSubmitted);
            this.grpSearch.Controls.Add(this.dtpSubmittedDate);
            this.grpSearch.Location = new System.Drawing.Point(50, 47);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(700, 120);
            this.grpSearch.TabIndex = 1;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Search Request";
            // 
            // lblSearch
            // 
            this.lblSearch.AutoSize = true;
            this.lblSearch.Location = new System.Drawing.Point(20, 30);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(111, 16);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Enter Request ID:";
            // 
            // txtRequestId
            // 
            this.txtRequestId.Location = new System.Drawing.Point(137, 32);
            this.txtRequestId.Name = "txtRequestId";
            this.txtRequestId.Size = new System.Drawing.Size(100, 22);
            this.txtRequestId.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(581, 73);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 25);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.LightSlateGray;
            this.btnBack.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(53, 436);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(150, 30);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Back to Main Menu";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // btnClearFilters
            // 
            this.btnClearFilters.Location = new System.Drawing.Point(631, 436);
            this.btnClearFilters.Name = "btnClearFilters";
            this.btnClearFilters.Size = new System.Drawing.Size(75, 25);
            this.btnClearFilters.TabIndex = 5;
            this.btnClearFilters.Text = "Clear Filters";
            this.btnClearFilters.Click += new System.EventHandler(this.btnClearFilters_Click);
            // 
            // grpServiceRequests
            // 
            this.grpServiceRequests.Controls.Add(this.dgvServiceRequests);
            this.grpServiceRequests.Location = new System.Drawing.Point(50, 180);
            this.grpServiceRequests.Name = "grpServiceRequests";
            this.grpServiceRequests.Size = new System.Drawing.Size(700, 250);
            this.grpServiceRequests.TabIndex = 2;
            this.grpServiceRequests.TabStop = false;
            this.grpServiceRequests.Text = "Service Requests";
            // 
            // dgvServiceRequests
            // 
            this.dgvServiceRequests.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvServiceRequests.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6});
            this.dgvServiceRequests.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvServiceRequests.Location = new System.Drawing.Point(3, 18);
            this.dgvServiceRequests.Name = "dgvServiceRequests";
            this.dgvServiceRequests.RowHeadersWidth = 51;
            this.dgvServiceRequests.Size = new System.Drawing.Size(694, 200);
            this.dgvServiceRequests.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Request ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Title";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Status";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Priority";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Date Submitted";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Progress";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.Width = 125;
            // 
            // ServiceRequestStatusForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.grpServiceRequests);
            this.Controls.Add(this.btnClearFilters);
            this.Controls.Add(this.btnBack);
            this.Name = "ServiceRequestStatusForm";
            this.Text = "Service Request Manager";
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.grpServiceRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvServiceRequests)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private void btnClearFilters_Click(object sender, EventArgs e)
        {
            // Check for null references (useful for debugging)
            if (txtRequestId == null) MessageBox.Show("txtRequestId is null");
            if (txtStatus == null) MessageBox.Show("txtStatus is null");
            if (txtPriority == null) MessageBox.Show("txtPriority is null");
            if (dtpSubmittedDate == null) MessageBox.Show("dtpDateSubmitted is null");
            if (dgvServiceRequests == null) MessageBox.Show("DataGridView is null");

            // Clear all text fields
            txtRequestId?.Clear();
            txtStatus?.Clear();
            txtPriority?.Clear();

            // Reset the DateTimePicker to the current date
            if (dtpSubmittedDate != null) dtpSubmittedDate.Value = DateTime.Now;

            // Reset the DataGridView to show all services
            ResetDataGridView();
        }



        /// Resets the DataGridView to show all service requests.

        private void ResetDataGridView()
        {
            try
            {
                dgvServiceRequests.Rows.Clear(); // Clear existing rows

                // Reload all service requests
                var allRequests = bstServiceRequests.Values.ToList();
                foreach (var request in allRequests)
                {
                    dgvServiceRequests.Rows.Add(
                        request.RequestID,
                        request.Description,
                        request.Status,
                        request.Priority,
                        request.SubmittedDate.ToString("d"),
                        request.LastUpdated.ToString("g")
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to reset DataGridView: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private List<ServiceRequest> GetServiceRequests()
        {
            if (bstServiceRequests == null || !bstServiceRequests.Any())
            {
                MessageBox.Show("No service requests available.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return new List<ServiceRequest>();
            }
            return bstServiceRequests.Values.ToList();
        }
        private void LoadServiceRequests()
        {
            // Populate with example data (replace with your logic)
            bstServiceRequests = new SortedDictionary<int, ServiceRequest>
    {
        { 1, new ServiceRequest { RequestID = 1, Status = "Open", Priority = "High", SubmittedDate = DateTime.Now.AddDays(-2) } },
        { 2, new ServiceRequest { RequestID = 2, Status = "In Progress", Priority = "Medium", SubmittedDate = DateTime.Now.AddDays(-1) } },
        { 3, new ServiceRequest { RequestID = 3, Status = "Closed", Priority = "Low", SubmittedDate = DateTime.Now } }
    };

            ResetDataGridView();
        }





        private void TxtStatus_Enter(object sender, EventArgs e)
        {
            if (txtStatus.Text == "Status")
            {
                txtStatus.Text = "";
                txtStatus.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TxtStatus_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStatus.Text))
            {
                txtStatus.Text = "Status";
                txtStatus.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void TxtPriority_Enter(object sender, EventArgs e)
        {
            if (txtPriority.Text == "Priority")
            {
                txtPriority.Text = "";
                txtPriority.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TxtPriority_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPriority.Text))
            {
                txtPriority.Text = "Priority";
                txtPriority.ForeColor = System.Drawing.Color.Gray;
            }
        }



        // Form Controls
        private Label lblTitle;
        private Label lblSearch;
        private TextBox txtRequestId;
        private Button btnSearch;
        private DataGridView dgvServiceRequests;
        private Label lblProgress;
        private TextBox txtProgress;
        private Label lblDependency;
        private TextBox txtDependentRequestId;
        private Button btnUpdateRequestStatus;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    }
}
