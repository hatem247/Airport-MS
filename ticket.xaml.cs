using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mine_branch
{
    /// <summary>
    /// Interaction logic for ticket.xaml
    /// </summary>
    public partial class ticket : Page
    {
        lololoEntities db = new lololoEntities();
        public ticket()
        {
            InitializeComponent();
        }



        private void Buy_btn_Click_1(object sender, RoutedEventArgs e)
        {
            if (Seat_tb.Text != "" && combo.Text != combo.SelectedItem)
            {
                Ticket t = new Ticket();
                t.Ticket_Status = "Confirmed";
                t.Seat_Number = int.Parse(Seat_tb.Text);
                t.Ticket_Price = (int.Parse(combo.Text));
                db.Tickets.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ticket has been added");
                gg.ItemsSource = db.Tickets.ToList();
            }
            else if (Seat_tb.Text == "")
            {
                MessageBox.Show("Add details");
            }
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
           
            if (Seat_tb.Text != "" && combo.Text != combo.SelectedItem)
            {
                Ticket t = new Ticket();
                t= db.Tickets.First(x => x.Seat_Number == int.Parse(Seat_tb.Text));
                t.Ticket_Status = "Confirmed";
                t.Seat_Number = int.Parse(Seat_tb.Text);
                t.Passenger_Name = Passenger_tb.Text;
                t.Ticket_Price = (int.Parse(combo.Text));
                db.Tickets.AddOrUpdate(t);
                Loginpage lp = new Loginpage();
                Passenger ps = new Passenger();
                if (lp.Usernametxtbox.Text == ps.Passenger_Name)
                {
                    t.Passenger_Id = ps.Passenger_Id;
                }
                db.SaveChanges();
                MessageBox.Show("Ticket Updated");
            }
            else if (Seat_tb.Text == "")
            {
                MessageBox.Show("Add details");
            }

        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            Ticket t = new Ticket();
            t = db.Tickets.Remove(db.Tickets.First(x => x.Seat_Number == int.Parse(Seat_tb.Text)));
            db.SaveChanges();
            MessageBox.Show("Deleted");
        }
    }
}
