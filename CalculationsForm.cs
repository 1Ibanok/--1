using Npgsql;
using System.Data;


namespace PR1
{
    public partial class CalculationsForm : Form
    {
        NpgsqlConnection conn;
        NpgsqlCommand cmd;
        NpgsqlDataReader reader;
        DataTable dataTable;
        Dictionary<string, string> recipes = new Dictionary<string, string>();
        Dictionary<string, string> materials = new Dictionary<string, string>();

        public CalculationsForm()
        {
            recipes.Add("Ламинат", "Декоративный слой,Фанера,Клей");
            recipes.Add("Массивная доска", "Цельная древесина,Олива и масла");
            recipes.Add("Паркетная доска", "Цельная древесина,Фанера,Олива и масла");
            recipes.Add("Пробковое покрытие", "Пробка,Клей");

            conn = new NpgsqlConnection("Host=localhost;Port=5432;Database=YP_DB;Username=postgres;Password=4825;");
            conn.Open();
            InitializeComponent();

            cmd = new NpgsqlCommand("select * from типы_продукции;", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                material.Items.Add(reader["тип"]);
            }
            cmd.Dispose();
            cmd.Cancel();
            reader.Close();

            cmd = new NpgsqlCommand("select * from типы_материалов;", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                materials.Add(reader["тип"].ToString(), reader["процент_брака"].ToString());
            }
            cmd.Dispose();
            cmd.Cancel();
            reader.Close();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void calcBtn_Click(object sender, EventArgs e)
        {
            double coeff = 0.0f;
            cmd = new NpgsqlCommand("select коэффициент from типы_продукции where тип = '" + material.Text + "';", conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
                coeff = double.Parse(reader["коэффициент"].ToString());

            cmd.Dispose();
            cmd.Cancel();
            reader.Close();

            string[] list = recipes[material.Text].Split(',');
            string result = "";
            foreach (string item in list)
            {
                result += "- " + item;
                string cnt = "";

                if (double.Parse(materials[item]) >= 0.95)
                {
                    if ((double.Parse(count.Text) * 2 / coeff) < 1)
                        cnt = "2";
                    else
                        cnt = Convert.ToInt32(double.Parse(count.Text) * 2 / coeff).ToString();
                }
                else
                {
                    if ((double.Parse(count.Text) * 1 / coeff) < 1)
                        cnt = "1";
                    else
                        cnt = Convert.ToInt32(double.Parse(count.Text) * 1 / coeff).ToString();
                }




                result += " (" + cnt + " шт)\r\n";
            }
            materialsList.Text = result;
        }

        private void materialsList_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CalculationsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
