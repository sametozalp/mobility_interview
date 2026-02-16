namespace Project_One
{
    public partial class Form1 : Form
    {
        Thread thread2;

        public Form1()
        {
            InitializeComponent();
        }

        private bool IsPrime(int number)
        {
            if (number < 2) return false;

            for (int i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }
    
        private void CalculatePrimes(int number, ListBox listBox)
        {
            for (int i = 2; i <= number; i++)
            {
                if (IsPrime(i))
                {
                    listBox.Invoke(new Action(() =>
                    {
                        listBox.Items.Add(i);
                    }));
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            Thread thread1 = new Thread(()=>CalculatePrimes(int.Parse(textBox1.Text.ToString()),listBox1));
            thread1.IsBackground = true;
            thread1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            thread2 = new Thread(() => CalculatePrimes(int.Parse(textBox2.Text.ToString()), listBox2));
            thread2.IsBackground = true;
            thread2.Start();
        }
    }
}
