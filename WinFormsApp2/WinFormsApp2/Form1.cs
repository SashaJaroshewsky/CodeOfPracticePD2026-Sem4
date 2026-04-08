using System.Diagnostics;
using System.IO;
using System.Text;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            GenerateFile();
            MessageBox.Show($"Time elapsed GenerateFile: {sw.ElapsedMilliseconds} ms");

            //sw.Restart();
            //await GenerateFileAsync();
            //MessageBox.Show($"Time elapsed GenerateFileAsync: {sw.ElapsedMilliseconds} ms");

            sw.Restart();
            await GenerateFileAsyncWIN();
            MessageBox.Show($"Time elapsed GenerateFileAsyncWIN: {sw.ElapsedMilliseconds} ms");

            //sw.Restart();
            //await GenerateFileAsyncASP2();
            //MessageBox.Show($"Time elapsed GenerateFileAsyncASP2: {sw.ElapsedMilliseconds} ms");

            sw.Stop();
        }

        private void GenerateFile()
        {
            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                for (int i = 0; i < 20_000_000; i++)
                {
                    sw.WriteLine($"Line {i}");
                    if (i % 10000 == 0)
                        progressBar1.Value = (i * 100) / 20_000_000;
                }
                progressBar1.Value = 100;
            }
        }

        private async Task GenerateFileAsync()
        {
            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                for (int i = 0; i < 20_000_000; i++)
                {
                    await sw.WriteLineAsync($"Line {i}");
                    if (i % 10000 == 0)
                    {
                        BeginInvoke(() =>
                        {
                            progressBar1.Value = (i * 100) / 20_000_000;

                        });
                    }
                }
                BeginInvoke(() =>
                {
                    progressBar1.Value = 100;
                });

            }
        }

        private async Task GenerateFileAsyncWIN()
        {
            await Task.Run(() =>
            {
                StringBuilder sb = new StringBuilder();

                using (StreamWriter sw = new StreamWriter("test.txt", true, Encoding.UTF8, bufferSize: 65536))
                {
                    for (uint i = 0; i < 50_000_000; i++)
                    {
                        sb.AppendLine($"Line {i}");
                        if (i % 10000 == 0)
                        {
                            sw.Write(sb);
                            sb.Clear();
                        }
                        uint c = i;
                        if (i % 1_000 == 0)
                        {
                            this.BeginInvoke(() =>
                            {
                                progressBar1.Value = (int)((c * 100) / 50_000_000);
                            });

                        }
                    }
                    sw.Write(sb);
                    sb.Clear();
                }
            });
            progressBar1.Value = 100;
        }

        private async Task GenerateFileAsyncASP2()
        {
            using (StreamWriter sw = new StreamWriter("test.txt"))
            {
                for (int i = 0; i < 20_000_000; i++)
                {
                    await sw.WriteLineAsync($"Line {i}");
                    int c = i;
                    if (i % 10000 == 0)
                    {
                        progressBar1.Value = (c * 100) / 20_000_000;
                    }
                }

            }

            progressBar1.Value = 100;
        }
    }
}
