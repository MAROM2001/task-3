using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CafeApp
{
    public partial class MainForm : Form
    {
        private Dictionary<string, double> menu = new Dictionary<string, double>()
        {
            {"Coffee", 2.50},
            {"Tea", 2.00},
            {"Cake", 3.00},
            {"Sandwich", 5.00}
        };

        private List<OrderItem> orderItems = new List<OrderItem>();
        private object comboBoxItems;
        private object numericUpDownQuantity;

        public MainForm()
        {
            InitializeComponent();
            PopulateDropDown();
        }

        private void InitializeComponent()
        {
            throw new NotImplementedException();
        }

        private void PopulateDropDown()
        {
            comboBoxItems.Items.AddRange(menu.Keys.ToArray());
        }

        private void btnAddToOrder_Click(object sender, EventArgs e)
        {
            if (comboBoxItems.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an item to add to the order.");
                return;
            }

            string selectedItem = comboBoxItems.SelectedItem.ToString();
            int quantity = (int)numericUpDownQuantity.Value;

            orderItems.Add(new OrderItem(selectedItem, menu[selectedItem], quantity));

            MessageBox.Show("Item added to order.");
        }

        private void btnDisplayReceipt_Click(object sender, EventArgs e)
        {
            if (orderItems.Count == 0)
            {
                MessageBox.Show("Your order is empty. Please add items to your order first.");
                return;
            }

            double total = 0;
            string receipt = "Receipt:\n\n";

            foreach (var item in orderItems)
            {
                receipt += $"{item.Name} - {item.Quantity} x ${item.Price.ToString("0.00")} = ${item.Total.ToString("0.00")}\n";
                total += item.Total;
            }

            receipt += $"\nTotal: ${total.ToString("0.00")}";

            MessageBox.Show(receipt, "Order Receipt");
        }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double Total => Price * Quantity;

        public OrderItem(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}

