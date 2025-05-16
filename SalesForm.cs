using Npgsql;
using System.Data;

namespace PR1
{
    public partial class SalesForm : Form
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader reader;
        DataTable dataTable;

        public SalesForm()
        {
            InitializeComponent();
            conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=YP_DB;Username=postgres;Password=4825;");
            conn.Open();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximumSize = this.Size;
            LoadSales();
        }

        void LoadSales()
        {
            cmd = new NpgsqlCommand("select наименование ,директор, телефон, рейтинг, sum(количество) сумма from продажи, партнеры where партнеры.ин = ин_партнеров group by наименование, директор,телефон, рейтинг order by наименование;", conn);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Label partnerLabel = new Label();
                {
                    partnerLabel.AutoSize = true;
                    partnerLabel.Location = new Point(18, 15);
                    partnerLabel.Name = "partnerLabel";
                    partnerLabel.Size = new Size(16, 15);
                    partnerLabel.TabIndex = 0;
                    partnerLabel.Text = reader["наименование"].ToString();
                }

                Label directorLabel = new Label();
                {
                    directorLabel.AutoSize = true;
                    directorLabel.Location = new Point(18, 44);
                    directorLabel.Name = "directorLabel";
                    directorLabel.Size = new Size(38, 15);
                    directorLabel.TabIndex = 1;
                    directorLabel.Text = reader["директор"].ToString();
                }

                Label phoneLabel = new Label();
                {
                    phoneLabel.AutoSize = true;
                    phoneLabel.Location = new Point(18, 72);
                    phoneLabel.Name = "phoneLabel";
                    phoneLabel.Size = new Size(38, 15);
                    phoneLabel.TabIndex = 2;
                    phoneLabel.Text = reader["телефон"].ToString();
                }

                Label ratingLabel = new Label();
                {
                    ratingLabel.AutoSize = true;
                    ratingLabel.Location = new Point(18, 98);
                    ratingLabel.Name = "ratingLabel";
                    ratingLabel.Size = new Size(38, 15);
                    ratingLabel.TabIndex = 3;
                    ratingLabel.Text = reader["рейтинг"].ToString();
                }



                Label saleLabel = new Label();
                {
                    saleLabel.AutoSize = true;
                    saleLabel.Location = new Point(396, 62);
                    saleLabel.Name = "saleLabel";
                    saleLabel.Size = new Size(38, 15);
                    saleLabel.TabIndex = 4;
                    int count = int.Parse(reader["сумма"].ToString());
                    if (count < 10000)
                        saleLabel.Text = "0%";
                    else if (count >= 300000)
                        saleLabel.Text = "15%";
                    else if (count >= 50000)
                        saleLabel.Text = "10%";
                    else if (count >= 10000)
                        saleLabel.Text = "5%";
                    saleLabel.Text += " (" + count + ")";
                }



                Panel salesPanel = new Panel();
                {
                    salesPanel.AutoScroll = true;
                    salesPanel.Controls.Add(saleLabel);
                    salesPanel.Controls.Add(ratingLabel);
                    salesPanel.Controls.Add(phoneLabel);
                    salesPanel.Controls.Add(directorLabel);
                    salesPanel.Controls.Add(partnerLabel);
                    salesPanel.Location = new Point(3, 3);
                    salesPanel.BackColor = Color.White;
                    salesPanel.Name = "panel1";
                    salesPanel.Size = new Size(salesList.Width - 30, 145);
                    salesPanel.TabIndex = 0;
                }

                salesList.Controls.Add(salesPanel);
            }
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
