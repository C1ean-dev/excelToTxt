using System.Diagnostics;

using ClosedXML.Excel;

namespace excelToAll
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<string> excelList = new List<string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            DropList.AllowDrop = true;
            DropList.DragEnter += new DragEventHandler(DropList_DragEnter);
            DropList.DragDrop += new DragEventHandler(DropList_DragDrop);

            TransformerButton.Click += new EventHandler(TransformerButton_Click);
            buttonFindExcel.Click += new EventHandler(buttonFindExcel_Click);
            buttonRemove.Click += new EventHandler(DeleteButton_Click);

        }

        private void DropList_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void DropList_DragDrop(object? sender, DragEventArgs e)
        {
            string[] files = (string[]) e.Data.GetData(DataFormats.FileDrop);
            try
            {
                foreach (string file in files)
                {
                    if (Path.GetExtension(file) == ".xls" || Path.GetExtension(file) == ".xlsx")
                    {
                        DropList.Items.Add(Path.GetFileName(file));
                        excelList.Add(file);
                    }
                }
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
}
        private void buttonFindExcel_Click(object? sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Arquivos Excel (*.xls;*.xlsx)|*.xls;*.xlsx|Todos os arquivos (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    DropList.Items.Add(Path.GetFileName(path));
                    excelList.Add(path);
                }
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void TransformerButton_Click(object? sender, EventArgs e)
        {
            try
            {
                TransformerButton.Enabled = false;
                //percorre todos os arquivos excel na lista
                foreach (string excelFile in excelList)
                {
                    //abre esse arquivo excel em um "livro"
                    using (var workbook = new XLWorkbook(excelFile))
                    {
                        foreach (var worksheet in workbook.Worksheets)
                        {
                            //esse dicionario vai ficar reponsavel por armazenar os dados do livro 
                            //a key sao as colunas a, b, c e os valores sao uma lista dentro delas 
                            Dictionary<string, List<string>> data = new Dictionary<string, List<string>>();
                            //pega o valor da primeira linha escrita em cada coluna
                            var headers = worksheet.FirstRowUsed().Cells().Select(c => c.Value.ToString()).ToList();
                            foreach (var header in headers)
                            {
                                data[header] = new List<string>();
                            }
                                //vai passsar por todas as linhas menos a do cabeçario 
                                foreach (var row in worksheet.RowsUsed().Skip(1))
                                {
                                    //aqui preciso juntar o que tem dentro de cada linha com o header 
                                    //deve ter jeito mais sofisticado confeso que me perdi um pouco nos conceitos 
                                    for (int i = 0; i < headers.Count; i++)
                                    {
                                        var cell = row.Cell(i + 1);
                                        if (!string.IsNullOrEmpty(cell.Value.ToString()))
                                        {
                                            //aqui data ja deve ter key: header Value: <row>
                                            data[headers[i]].Add(cell.Value.ToString());
                                        }
                                    }
                                }
                            //criando um "escritor" para escrever as informaçoes de excelFile no txt
                            using (var writer = new StreamWriter(Path.ChangeExtension(excelFile, ".txt")))
                            {
                                foreach (var item in data)
                                {
                                    writer.WriteLine(item.Key + ": [");
                                    writer.WriteLine(string.Join(",", item.Value));
                                    writer.WriteLine("]");
                                }
                            }
                        }
                    }
                }
                TransformerButton.Enabled = true;
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        private void DeleteButton_Click(object? sender, EventArgs e)
        {
            try
            {
                DropList.Items.Clear();
                excelList.Clear();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
