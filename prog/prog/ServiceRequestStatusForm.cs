using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace prog
{
    public partial class ServiceRequestStatusForm : Form
    {
        private BinarySearchTree bst;
        private SortedDictionary<int, ServiceRequest> bstServiceRequests;

        public ServiceRequestStatusForm()
        {
            InitializeComponent(); // Call the designer-generated method
            bst = new BinarySearchTree();
            bstServiceRequests = new SortedDictionary<int, ServiceRequest>();

            PopulateSampleRequests();
        }

        private void PopulateSampleRequests()
        {
            var request1 = new ServiceRequest
            {
                RequestID = 1,
                Description = "Fix streetlight",
                Status = "Closed",
                SubmittedDate = DateTime.Now.AddDays(-3),
                Priority = "High",
                LastUpdated = DateTime.Now
            };

            var request2 = new ServiceRequest
            {
                RequestID = 2,
                Description = "Pothole repair",
                Status = "In Progress",
                SubmittedDate = DateTime.Now.AddDays(-8),
                Priority = "Medium",
                LastUpdated = DateTime.Now.AddDays(-2)
            };

            var request3 = new ServiceRequest
            {
                RequestID = 3,
                Description = "Road Maintenance",
                Status = "Closed",
                SubmittedDate = DateTime.Now.AddDays(-7),
                Priority = "Low",
                LastUpdated = DateTime.Now.AddDays(-1)
            };

            var request4 = new ServiceRequest
            {
                RequestID = 4,
                Description = "Street Wastage Plumbing",
                Status = "Open",
                SubmittedDate = DateTime.Now.AddDays(-5),
                Priority = "High",
                LastUpdated = DateTime.Now.AddDays(-4)
            };

            bstServiceRequests.Add(request1.RequestID, request1);
            bst.Insert(request1);

            bstServiceRequests.Add(request2.RequestID, request2);
            bst.Insert(request2);

            bstServiceRequests.Add(request3.RequestID, request3);
            bst.Insert(request3);

            bstServiceRequests.Add(request4.RequestID, request4);
            bst.Insert(request4);

            UpdateDataGridView(bstServiceRequests.Values);
        }

        private void UpdateDataGridView(IEnumerable<ServiceRequest> requests)
        {
            dgvServiceRequests.Rows.Clear();
            foreach (var request in requests)
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

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var filteredRequests = bstServiceRequests.Values.AsEnumerable();

            // Filter by Request ID
            if (int.TryParse(txtRequestId.Text, out int requestId) && txtRequestId.ForeColor != Color.Gray)
                filteredRequests = filteredRequests.Where(req => req.RequestID == requestId);

            // Filter by Status
            if (!string.IsNullOrWhiteSpace(txtStatus.Text) && txtStatus.ForeColor != Color.Gray)
                filteredRequests = filteredRequests.Where(req => req.Status.Equals(txtStatus.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            // Filter by Priority
            if (!string.IsNullOrWhiteSpace(txtPriority.Text) && txtPriority.ForeColor != Color.Gray)
                filteredRequests = filteredRequests.Where(req => req.Priority.Equals(txtPriority.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            // Filter by Submitted Date
            if (dtpSubmittedDate.Value.Date != DateTime.Now.Date)
                filteredRequests = filteredRequests.Where(req => req.SubmittedDate.Date == dtpSubmittedDate.Value.Date);

            UpdateDataGridView(filteredRequests);
        }
    }
}
