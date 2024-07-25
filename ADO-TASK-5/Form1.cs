namespace ADO_TASK_5
{
    public partial class Form1 : Form
    {
        LibraryContext? DataBASE = null;
        public Form1()
        {
            InitializeComponent();
            comboBox1.DataSource = new List<string>() { "Authors", "Themes", "Categories" };
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DataBASE = new())
            {
                var a = comboBox1.SelectedItem as string;
                if (a!.StartsWith("A"))
                    comboBox2.DataSource = DataBASE.Authors.ToList();
                else if (a!.StartsWith("T"))
                    comboBox2.DataSource = DataBASE.Themes.ToList();
                else if (a!.StartsWith("C"))
                    comboBox2.DataSource = DataBASE.Categories.ToList();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (DataBASE = new())
            {
                var a = comboBox1.SelectedItem as string;

                if (a!.StartsWith("A"))
                {
                    var b = comboBox2.SelectedItem as Author;
                    var list = DataBASE.Books.Where(f => f.IdAuthor == b!.Id).ToList();
                    listBox1.DataSource = list;
                }

                else if (a!.StartsWith("C"))
                {
                    var b = comboBox2.SelectedItem as Theme;
                    var list = DataBASE.Books.Where(f => f.IdCategory == b!.Id).ToList();
                    listBox1.DataSource = list;
                }
                else if (a!.StartsWith("T"))
                {
                    var b = comboBox2.SelectedItem as Category;
                    var list = DataBASE.Books.Where(f => f.IdThemes == b!.Id).ToList();
                    listBox1.DataSource = list;
                }
            }
        }
    }
}
